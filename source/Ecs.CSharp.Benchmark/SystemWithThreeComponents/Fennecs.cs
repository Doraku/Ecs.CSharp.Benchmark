using System;
using System.Buffers;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.Fennecs_Components;
using fennecs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithThreeComponents
    {
        [Context] private readonly FennecsContext _fennecs;
        private Query<Component1, Component2, Component3> Query => _fennecs.query;

        // ReSharper disable once ClassNeverInstantiated.Local
        private sealed class FennecsContext : FennecsBaseContext
        {
            internal readonly Query<Component1, Component2, Component3> query;

            public FennecsContext(int entityCount, int entityPadding) : base(entityCount)
            {
                query = World.Query<Component1, Component2, Component3>().Build();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        Entity padding = World.Spawn();
                        switch (j % 3)
                        {
                            case 0:
                                padding.Add<Component1>();
                                break;
                            case 1:
                                padding.Add<Component2>();
                                break;
                            case 2:
                                padding.Add<Component3>();
                                break;
                        }
                    }

                    World.Spawn().Add<Component1>()
                        .Add(new Component2 {Value = 1})
                        .Add(new Component3 {Value = 1});
                }

                query.Warmup();
            }
        }


        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark(Description = "fennecs (For)")]
        public void fennecs_For()
        {
            Query.For(
                static (ref Component1 c1, ref Component2 c2, ref Component3 c3) =>
                {
                    c1.Value = c1.Value + c2.Value + c3.Value;
                });
        }


        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark(Description = $"fennecs (Job)")]
        public void fennecs_Job()
        {
            Query.Job(
                static (ref Component1 c1, ref Component2 c2, ref Component3 c3) =>
                {
                    c1.Value = c1.Value + c2.Value + c3.Value;
                });
        }


        #region Raw

        // fennecs guarantees contiguous memory access in the form of Query<>.Raw(MemoryAction<>)
        // Raw runners are intended to process data or transfer it via the fastest available means,
        // Example use cases:
        //  - transfer buffers to/from GPUs or Game Engines
        //  - Disk, Database, or Network I/O
        //  - SIMD calculations
        //  - snapshotting / copying / rollback / compression / decompression / diffing / permutation
        // As example / reference & benchmark, we vectorized our calculation here using AVX2, SSE2, and AdvSIMD

        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark(Description = "fennecs (Raw)")]
        public void fennecs_Raw()
        {
            Query.Raw(Raw_Workload_Unoptimized);
        }

        [BenchmarkCategory(Categories.Fennecs, Capabilities.Avx2)]
        [Benchmark(Description = "fennecs (Raw AVX2)")]
        public void fennecs_Raw_AVX2()
        {
            Query.Raw(Raw_Workload_AVX2);
        }

        [BenchmarkCategory(Categories.Fennecs, Capabilities.Sse2)]
        [Benchmark(Description = "fennecs (Raw SSE2)")]
        public void fennecs_Raw_SSE2()
        {
            Query.Raw(Raw_Workload_SSE2);
        }

        [BenchmarkCategory(Categories.Fennecs, Capabilities.AdvSimd)]
        [Benchmark(Description = "fennecs (Raw AdvSIMD)")]
        public void fennecs_Raw_AdvSIMD()
        {
            Query.Raw(Raw_Workload_AdvSIMD);
        }

        #region Workloads

        private static void Raw_Workload_Unoptimized(Memory<Component1> c1V, Memory<Component2> c2V, Memory<Component3> c3V)
        {
            Span<Component1> c1S = c1V.Span;
            Span<Component2> c2S = c2V.Span;
            Span<Component3> c3S = c3V.Span;

            for (int i = 0; i < c1S.Length; i++)
            {
                c1S[i].Value = c1S[i].Value + c2S[i].Value + c3S[i].Value;
            }
        }

        private static void Raw_Workload_AVX2(Memory<Component1> c1V, Memory<Component2> c2V, Memory<Component3> c3V)
        {
            int count = c1V.Length;

            using MemoryHandle mem1 = c1V.Pin();
            using MemoryHandle mem2 = c2V.Pin();
            using MemoryHandle mem3 = c3V.Pin();

            unsafe
            {
                int* p1 = (int*)mem1.Pointer;
                int* p2 = (int*)mem2.Pointer;
                int* p3 = (int*)mem3.Pointer;

                int vectorSize = Vector256<int>.Count;
                int vectorEnd = count - count % vectorSize;
                for (int i = 0; i <= vectorEnd; i += vectorSize)
                {
                    Vector256<int> v1 = Avx.LoadVector256(p1 + i);
                    Vector256<int> v2 = Avx.LoadVector256(p2 + i);
                    Vector256<int> v3 = Avx.LoadVector256(p3 + i);
                    Vector256<int> sum = Avx2.Add(v1, Avx2.Add(v2, v3));

                    Avx.Store(p1 + i, sum);
                }

                for (int i = vectorEnd; i < count; i++) // remaining elements
                {
                    p1[i] = p1[i] + p2[i] + p3[i];
                }
            }
        }

        private static void Raw_Workload_SSE2(Memory<Component1> c1V, Memory<Component2> c2V, Memory<Component3> c3V)
        {
            (int Item1, int Item2) range = (0, c1V.Length);

            using MemoryHandle mem1 = c1V.Pin();
            using MemoryHandle mem2 = c2V.Pin();
            using MemoryHandle mem3 = c3V.Pin();

            unsafe
            {
                int* p1 = (int*)mem1.Pointer;
                int* p2 = (int*)mem2.Pointer;
                int* p3 = (int*)mem3.Pointer;

                int vectorSize = Vector128<int>.Count;
                int i = range.Item1;
                int vectorEnd = range.Item2 - vectorSize;
                for (; i <= vectorEnd; i += vectorSize)
                {
                    Vector128<int> v1 = Sse2.LoadVector128(p1 + i);
                    Vector128<int> v2 = Sse2.LoadVector128(p2 + i);
                    Vector128<int> v3 = Sse2.LoadVector128(p3 + i);
                    Vector128<int> sum = Sse2.Add(v1, Sse2.Add(v2, v3));

                    Sse2.Store(p1 + i, sum);
                }

                for (; i < range.Item2; i++) // remaining elements
                {
                    p1[i] = p1[i] + p2[i] + p3[i];
                }
            }
        }

        private static void Raw_Workload_AdvSIMD(Memory<Component1> c1V, Memory<Component2> c2V, Memory<Component3> c3V)
        {
            (int Item1, int Item2) range = (0, c1V.Length);

            using MemoryHandle mem1 = c1V.Pin();
            using MemoryHandle mem2 = c2V.Pin();
            using MemoryHandle mem3 = c3V.Pin();

            unsafe
            {
                int* p1 = (int*)mem1.Pointer;
                int* p2 = (int*)mem2.Pointer;
                int* p3 = (int*)mem3.Pointer;

                int vectorSize = Vector128<int>.Count;
                int i = range.Item1;
                int vectorEnd = range.Item2 - vectorSize;
                for (; i <= vectorEnd; i += vectorSize)
                {
                    Vector128<int> v1 = AdvSimd.LoadVector128(p1 + i);
                    Vector128<int> v2 = AdvSimd.LoadVector128(p2 + i);
                    Vector128<int> v3 = AdvSimd.LoadVector128(p3 + i);
                    Vector128<int> sum = AdvSimd.Add(v1, AdvSimd.Add(v2, v3));

                    AdvSimd.Store(p1 + i, sum);
                }

                for (; i < range.Item2; i++) // remaining elements
                {
                    p1[i] = p1[i] + p2[i] + p3[i];
                }
            }
        }
        #endregion
        
        #endregion
    }
}
#pragma warning restore IDE0008

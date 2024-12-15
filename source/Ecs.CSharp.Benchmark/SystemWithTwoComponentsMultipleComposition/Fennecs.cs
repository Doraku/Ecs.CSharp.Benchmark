using System;
using System.Buffers;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.Fennecs_Components;
using fennecs;

// ReSharper disable ConvertToCompoundAssignment

// ReSharper disable once CheckNamespace
namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        [Context] private readonly FennecsContext _fennecs;
        private  Stream<Component1, Component2> Stream => _fennecs.stream;

        // ReSharper disable once ClassNeverInstantiated.Local
        private sealed class FennecsContext : FennecsBaseContext
        {
            private struct Padding1;

            private struct Padding2;

            private struct Padding3;

            private struct Padding4;

            public readonly Stream<Component1, Component2> stream;

            public FennecsContext(int entityCount) : base(entityCount)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    Entity entity = World.Spawn().Add<Component1>().Add(new Component2 { Value = 1 });
                    switch (i % 4)
                    {
                        case 0:
                            entity.Add<Padding1>();
                            break;
                        case 1:
                            entity.Add<Padding2>();
                            break;
                        case 2:
                            entity.Add<Padding3>();
                            break;
                        case 3:
                            entity.Add<Padding4>();
                            break;
                    }
                }
                
                stream = World.Query<Component1, Component2>().Stream();
            }
            
            public override void Dispose()
            {
                stream.Query.Dispose();
                base.Dispose();
            }
        }

        /// <summary>
        /// fennecs For runners are the classic swiss army knife of this ECS. 
        /// </summary>
        /// <remarks>
        /// They are the most versatile and offer decent single-threaded baseline performance to boot.
        /// </remarks>
        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark(Description = "fennecs(For)")]
        public void fennecs_For()
        {
            Stream.For(
                static (ref Component1 c1, ref Component2 c2) =>
                {
                    c1.Value = c1.Value + c2.Value;
                });
        }


        /// <summary>
        /// fennecs Job runners are the most scalable runners.
        /// </summary>
        /// <remarks>
        /// <para>
        /// They're still an area for improvement :)
        /// </para>
        /// <para>
        /// Job is designed for heavy individual workloads (e.g. update 20 physics worlds on 20 cores),
        /// or large numbers of entities in many big archetypes. They only start paying off at around
        /// 500,000 components when the individual work steps are simple (e.g. vector multiplications).
        /// </para>
        /// </remarks>
        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark(Description = $"fennecs(Job)")]
        public void fennecs_Job()
        {
            Stream.Job(
                static (ref Component1 c1, ref Component2 c2) =>
                {
                    c1.Value = c1.Value + c2.Value;
                });
        }


        // fennecs Raw runners guarantee contiguous memory access in the form of Query<>.Raw(MemoryAction<>)
        // Raw runners are intended to process data or transfer it via the fastest available means.
        // Example use cases:
        //  - transfer data to/from GPU
        //  - transfer data to/from Game Engine
        //  - Disk, Database, or Network I/O
        //  - SIMD calculations
        //  - snapshotting / copying / rollback / compression / hashing / diffing / permutation
        //  - etc.
        //
        // As example / reference / benchmarks, we vectorize our calculation here using AVX2, SSE2, and AdvSIMD
        // Despite the 'unsafe' tags, this is quite safe ;) The Memory<T>s are pinned till end of scope.
        // We also keep an Unoptimized Workload around to let RyuJIT show off its magic. (still good!)

        #region Raw Runners
        
        /// <summary>
        /// Unoptimized workload for fennecs(Raw)
        /// </summary>
        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark(Description = "fennecs(Raw)")]
        public void fennecs_Raw()
        {
            Stream.Raw(Raw_Workload_Unoptimized);
        }

        /// <summary>
        /// Vectorized Benchmark Contender for fennecs. (AVX2)
        /// </summary>
        /// <remarks>
        /// This benchmark is automatically excluded if the current environment does not support AVX2.
        /// </remarks>
        [BenchmarkCategory(Categories.Fennecs, Capabilities.Avx2)]
        [Benchmark(Description = "fennecs(AVX2)")]
        public void fennecs_Raw_AVX2()
        {
            Stream.Raw(Raw_Workload_AVX2);
        }

        /// <summary>
        /// Vectorized Benchmark Contender for fennecs. (SSE2 / AVX1)
        /// </summary>
        /// <remarks>
        /// This benchmark is automatically excluded if the current environment does not support SSE2.
        /// </remarks>
        [BenchmarkCategory(Categories.Fennecs, Capabilities.Sse2)]
        [Benchmark(Description = "fennecs(SSE2)")]
        public void fennecs_Raw_SSE2()
        {
            Stream.Raw(Raw_Workload_SSE2);
        }

        /// <summary>
        /// Vectorized Benchmark Contender for fennecs. (Arm64 AdvSIMD)
        /// </summary>
        /// <remarks>
        /// This benchmark is automatically excluded if the current environment does not support AdvSIMD.
        /// </remarks>
        [BenchmarkCategory(Categories.Fennecs, Capabilities.AdvSimd)]
        [Benchmark(Description = "fennecs(AdvSIMD)")]
        public void fennecs_Raw_AdvSIMD()
        {
            Stream.Raw(Raw_Workload_AdvSIMD);
        }

        /// <summary>
        /// Unoptimized workload for fennecs(Raw)
        /// Treating the Memory Slabs basically as Arrays.
        /// </summary>
        /// <remarks>
        /// However, RyuJIT is able to optimize this workload to a degree,
        /// especially if we use an explicit assignment instead of a compound assignment
        /// for our addition. 
        /// </remarks>
        private static void Raw_Workload_Unoptimized(Memory<Component1> c1V, Memory<Component2> c2V)
        {
            Span<Component1> c1S = c1V.Span;
            Span<Component2> c2S = c2V.Span;

            for (int i = 0; i < c1S.Length; i++)
            {
                // Compound Assignment is not as optimized as explicit assignment
                c1S[i].Value = c1S[i].Value + c2S[i].Value;
            }
        }

        /// <summary>
        /// AVX2 workload for fennecs(Raw)
        /// We use AVX2 intrinsics to vectorize the workload, executing 8 additions in parallel.
        /// (256 bits)
        /// </summary>
        private static void Raw_Workload_AVX2(Memory<Component1> c1V, Memory<Component2> c2V)
        {
            int count = c1V.Length;

            using MemoryHandle mem1 = c1V.Pin();
            using MemoryHandle mem2 = c2V.Pin();

            unsafe
            {
                int* p1 = (int*)mem1.Pointer;
                int* p2 = (int*)mem2.Pointer;

                int vectorSize = Vector256<int>.Count;
                int vectorEnd = count - (count % vectorSize);
                for (int i = 0; i < vectorEnd; i += vectorSize)
                {
                    Vector256<int> v1 = Avx.LoadVector256(p1 + i);
                    Vector256<int> v2 = Avx.LoadVector256(p2 + i);
                    Vector256<int> sum = Avx2.Add(v1, v2);

                    Avx.Store(p1 + i, sum);
                }

                for (int i = vectorEnd; i < count; i++) // remaining elements
                {
                    // Compound Assignment is not as optimized as explicit assignment
                    p1[i] = p1[i] + p2[i];
                }
            }
        }

        /// <summary>
        /// SSE2 workload for fennecs(Raw)
        /// We use SSE2 (same as AVX1) intrinsics to vectorize the workload, executing 4 additions in parallel.
        /// (128 bits) 
        /// </summary>
        private static void Raw_Workload_SSE2(Memory<Component1> c1V, Memory<Component2> c2V)
        {
            int count = c1V.Length;

            using MemoryHandle mem1 = c1V.Pin();
            using MemoryHandle mem2 = c2V.Pin();

            unsafe
            {
                int* p1 = (int*)mem1.Pointer;
                int* p2 = (int*)mem2.Pointer;

                int vectorSize = Vector128<int>.Count;
                int vectorEnd = count - (count % vectorSize);
                for (int i = 0; i < vectorEnd; i += vectorSize)
                {
                    Vector128<int> v1 = Sse2.LoadVector128(p1 + i);
                    Vector128<int> v2 = Sse2.LoadVector128(p2 + i);
                    Vector128<int> sum = Sse2.Add(v1, v2);

                    Sse2.Store(p1 + i, sum);
                }

                for (int i = vectorEnd; i < count; i++) // remaining elements
                {
                    // Compound Assignment is not as optimized as explicit assignment
                    p1[i] = p1[i] + p2[i];
                }
            }
        }

        /// <summary>
        /// AdvSIMD workload for fennecs(Raw)
        /// We use AdvSIMD intrinsics to vectorize the workload, executing 4 additions in parallel.
        /// (128 bits) 
        /// </summary>
        private static void Raw_Workload_AdvSIMD(Memory<Component1> c1V, Memory<Component2> c2V)
        {
            int count = c1V.Length;

            using MemoryHandle mem1 = c1V.Pin();
            using MemoryHandle mem2 = c2V.Pin();

            unsafe
            {
                int* p1 = (int*)mem1.Pointer;
                int* p2 = (int*)mem2.Pointer;

                int vectorSize = Vector128<int>.Count;
                int vectorEnd = count - (count % vectorSize);
                for (int i = 0; i < vectorEnd; i += vectorSize)
                {
                    Vector128<int> v1 = AdvSimd.LoadVector128(p1 + i);
                    Vector128<int> v2 = AdvSimd.LoadVector128(p2 + i);
                    Vector128<int> sum = AdvSimd.Add(v1, v2);

                    AdvSimd.Store(p1 + i, sum);
                }

                for (int i = vectorEnd; i < count; i++) // remaining elements
                {
                    // Compound Assignment is not as optimized as explicit assignment
                    p1[i] = p1[i] + p2[i];
                }
            }
        }

        #endregion
    }
}

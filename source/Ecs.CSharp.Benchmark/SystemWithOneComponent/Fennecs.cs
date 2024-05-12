using System;
using System.Buffers;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.Fennecs_Components;
using fennecs;

// ReSharper disable once CheckNamespace
namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        [Context] private readonly FennecsContext _fennecs;

        // ReSharper disable once ClassNeverInstantiated.Local
        private sealed class FennecsContext : FennecsBaseContext
        {
            public readonly Query<Component1> query;

            public FennecsContext(int entityCount, int entityPadding) : base(entityCount)
            {
                query = World.Query<Component1>().Build();
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.Spawn();
                    }

                    World.Spawn().Add<Component1>();
                }

                query.Warmup();
                query.Batch(Batch.AddConflict.Replace)
                    .Add(new Component1 { Value = 0 })
                    .Submit();
            }
        }

        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs_ForEach()
        {
            _fennecs.query.For(delegate(ref Component1 v) { v.Value++; });
        }

        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs_Batch()
        {
            int newValue = _fennecs.query[0].Ref<Component1>().Value + 1;
            
            _fennecs.query
                .Batch(Batch.AddConflict.Replace)
                .Add(new Component1 { Value = newValue })
                .Submit();
        }

        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs_Job()
        {
            _fennecs.query.Job(delegate(ref Component1 v) { v.Value++; });
        }
        
        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs_Raw()
        {
            _fennecs.query.Raw(delegate(Memory<Component1> vectors)
            {
                foreach (ref var v in vectors.Span)
                {
                    v.Value++;
                }
            });
        }
        
        #region Raw Runners
        
        [BenchmarkCategory(Categories.Fennecs, Capabilities.Avx2)]
        [Benchmark(Description = "fennecs (Raw AVX2)")]
        public void Fennecs_Raw_AVX2()
        {
            _fennecs.query.Raw(delegate(Memory<Component1> mem1)
            {
                int count = mem1.Length;
                
                using MemoryHandle handle1 = mem1.Pin();

                unsafe
                {
                    int* p1 = (int*)handle1.Pointer;

                    int vectorSize = Vector256<int>.Count;
                    int vectorEnd = count - (count % vectorSize);
                    for (int i = 0; i < vectorEnd; i += vectorSize)
                    {
                        Vector256<int> v1 = Avx.LoadVector256(p1 + i);
                        Avx.Store(p1 + i, Avx2.Add(v1, Vector256<int>.One));
                    }

                    for (int i = vectorEnd; i < count; i++) // remaining elements
                    {
                        p1[i]++;
                    }
                }
            });
        }
        
        
        
        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark(Description = "fennecs (Raw Blit)")]
        public void Fennecs_Raw_Blit()
        {
            _fennecs.query.Raw(delegate(Memory<Component1> mem1)
            {
                Component1 newValue = mem1.Span[0];
                newValue.Value++;
                
                mem1.Span.Fill(newValue);
            });
        }
        
        [BenchmarkCategory(Categories.Fennecs, Capabilities.Sse2)]
        [Benchmark(Description = "fennecs (Raw SSE2)")]
        public void Fennecs_Raw_SSE2()
        {
            _fennecs.query.Raw(delegate(Memory<Component1> mem1)
            {
                int count = mem1.Length;
                
                using MemoryHandle handle1 = mem1.Pin();

                unsafe
                {
                    int* p1 = (int*)handle1.Pointer;

                    int vectorSize = Vector128<int>.Count;
                    int vectorEnd = count - (count % vectorSize);
                    for (int i = 0; i < vectorEnd; i += vectorSize)
                    {
                        Vector128<int> v1 = Sse2.LoadVector128(p1 + i);
                        Sse2.Store(p1 + i, Sse2.Add(v1, Vector128<int>.One));
                    }

                    for (int i = vectorEnd; i < count; i++) // remaining elements
                    {
                        p1[i]++;
                    }
                }
            });
        }
        
        [BenchmarkCategory(Categories.Fennecs, Capabilities.AdvSimd)]
        [Benchmark(Description = "fennecs (Raw AdvSIMD)")]
        public void Fennecs_Raw_AdvSimd()
        {
            _fennecs.query.Raw(delegate(Memory<Component1> mem1)
            {
                int count = mem1.Length;
                
                using MemoryHandle handle1 = mem1.Pin();

                unsafe
                {
                    int* p1 = (int*)handle1.Pointer;

                    int vectorSize = Vector128<int>.Count;
                    int vectorEnd = count - (count % vectorSize);
                    for (int i = 0; i < vectorEnd; i += vectorSize)
                    {
                        Vector128<int> v1 = AdvSimd.LoadVector128(p1 + i);
                        AdvSimd.Store(p1 + i, AdvSimd.Add(v1, Vector128<int>.One));
                    }

                    for (int i = vectorEnd; i < count; i++) // remaining elements
                    {
                        p1[i]++;
                    }
                }
            });
        }
        
        #endregion
    }
}

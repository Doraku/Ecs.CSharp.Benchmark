using System;
using System.Runtime.Intrinsics;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.FrifloEngine_Components;
using Friflo.Engine.ECS;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        internal sealed class FrifloEngineEcsContext : FrifloEngineEcsBaseContext
        {
            public FrifloEngineEcsContext(int entityCount, int padding)
                : base(entityCount, padding, ComponentTypes.Get<Component1>())
            { }
            
            internal static void ForEach(Chunk<Component1> component1, ChunkEntities entities)
            {
                foreach (ref Component1 component in component1.Span)
                {
                    ++component.Value;
                }  
            }
        }

        [Context]
        private readonly FrifloEngineEcsContext _frifloEngineEcs;

        [BenchmarkCategory(Categories.FrifloEngineEcs)]
        [Benchmark]
        public void FrifloEngineEcs_MonoThread()
        {
            foreach ((Chunk<Component1> component1, ChunkEntities _) in _frifloEngineEcs.queryOne.Chunks)
            {
                foreach (ref Component1 component in component1.Span)
                {
                    ++component.Value;
                }
            }
        }
        
        [BenchmarkCategory(Categories.FrifloEngineEcs)]
        [Benchmark]
        public void FrifloEngineEcs_MultiThread()
        {
            _frifloEngineEcs.jobOne.RunParallel();
        }
        
        [BenchmarkCategory(Categories.FrifloEngineEcs)]
        [Benchmark]
        public void FrifloEngineEcs_SIMD_MonoThread()
        {
            Vector256<int> add = Vector256.Create<int>(1);              // create int[8] vector - all values = 1

            foreach ((Chunk<Component1> component1, ChunkEntities _) in _frifloEngineEcs.queryOne.Chunks)
            {
                Span<int> component1Span = component1.AsSpan256<int>(); // Length - multiple of 8
                int step = component1.StepSpan256;                      // step = 8
                for (int n = 0; n < component1Span.Length; n += step)
                {
                    Span<int> slice = component1Span.Slice(n, step);
                    Vector256<int> value = Vector256.Create<int>(slice);
                    Vector256<int> result = Vector256.Add(value, add);  // execute 8 add instructions at once
                    result.CopyTo(slice);
                }
            }
        }
    }
}

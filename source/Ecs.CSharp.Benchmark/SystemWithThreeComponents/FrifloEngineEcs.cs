using System;
using System.Runtime.Intrinsics;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.FrifloEngine_Components;
using Friflo.Engine.ECS;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithThreeComponents
    {
        private sealed class FrifloEngineEcsContext : FrifloEngineEcsBaseContext
        {
            public FrifloEngineEcsContext(int entityCount, int padding)
                : base(entityCount, padding, ComponentTypes.Get<Component1, Component2>())
            { }
        }

        [Context]
        private readonly FrifloEngineEcsContext _frifloEngineEcs;

        [BenchmarkCategory(Categories.FrifloEngineEcs)]
        [Benchmark]
        public void FrifloEngineEcs_MonoThread()
        {
            EntityStore world = _frifloEngineEcs.EntityStore;
            ArchetypeQuery<Component1, Component2, Component3> query = world.Query<Component1, Component2, Component3>();

            foreach ((Chunk<Component1> component1, Chunk<Component2> component2, Chunk<Component3> component3, ChunkEntities _) in query.Chunks)
            {
                Span<Component1> component1Span = component1.Span;
                Span<Component2> component2Span = component2.Span;
                Span<Component3> component3Span = component3.Span;
                for (int n = 0; n < component1Span.Length; n++)
                {
                    Update(ref component1Span[n], ref component2Span[n], ref component3Span[n]);
                }
            }
        }

        private static void Update(ref Component1 c1, ref Component2 c2, ref Component3 c3)
        {
            c1.Value = c2.Value + c3.Value;
        }

        [BenchmarkCategory(Categories.FrifloEngineEcs)]
        [Benchmark]
        public void FrifloEngineEcs_SIMD_MonoThread()
        {
            EntityStore world = _frifloEngineEcs.EntityStore;
            ArchetypeQuery<Component1, Component2, Component3> query = world.Query<Component1, Component2, Component3>();

            foreach ((Chunk<Component1> component1, Chunk<Component2> component2, Chunk<Component3> component3, ChunkEntities _) in query.Chunks)
            {
                Span<int> component1Span = component1.AsSpan256<int>();     // Length - multiple of 8
                Span<int> component2Span = component2.AsSpan256<int>();     // Length - multiple of 8
                Span<int> component3Span = component3.AsSpan256<int>();     // Length - multiple of 8
                int step = component1.StepSpan256;                          // step = 8
                for (int n = 0; n < component1Span.Length; n += step)
                {
                    Vector256<int> value1 = Vector256.Create<int>(component1Span.Slice(n, step));
                    Vector256<int> value2 = Vector256.Create<int>(component2Span.Slice(n, step));
                    Vector256<int> result = Vector256.Add(value1, value2);  // execute 8 add instructions at once
                    result.CopyTo(component3Span.Slice(n, step));
                }
            }
        }
    }
}

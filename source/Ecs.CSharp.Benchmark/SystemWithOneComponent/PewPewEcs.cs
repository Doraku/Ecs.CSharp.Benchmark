using System;
using System.Numerics;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using PewPew.Ecs.Core;
using PewPew.Ecs.Hybrid;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        [Context]
        private readonly PewPewEcsContext _pewPewEcsContext;

        [BenchmarkCategory(Categories.PewPewEcs)]
        [Benchmark]
        public void PewPewEcs() =>
            _pewPewEcsContext.HybridWorld.ExecuteQueryWithoutId<OneComponentsQuery, PPComponent1>(_pewPewEcsContext.Query);

        [BenchmarkCategory(Categories.PewPewEcs)]
        [Benchmark]
        public void PewPewEcs_Simd() =>
            _pewPewEcsContext.HybridWorld.ExecuteBatchQuery<OneComponentsBatchQuery, PPComponent1>(_pewPewEcsContext.BatchQuery);

        private sealed class PewPewEcsContext : PewPewEcsBaseContext
        {
            public OneComponentsQuery Query;
            public OneComponentsBatchQuery BatchQuery;

            public PewPewEcsContext(int entityCount, int entityPadding) : base(entityCount, entityPadding)
            {
                Query = default;

                HybridWorld.InitComponent<PPComponent1>();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        HybridWorld.CreateEntityId();
                    }

                    EntityId entityId = HybridWorld.CreateEntityId();
                    HybridWorld.AddComponent<PPComponent1>(entityId);
                }
            }
        }

        internal struct OneComponentsQuery : IQueryWithoutId<PPComponent1>
        {
            public void Update(ref PPComponent1 component1)
            {
                ++component1.Value;
            }
        }

        internal struct OneComponentsBatchQuery : IBatchQuery<PPComponent1>
        {
            public void BatchUpdate(Span<PPComponent1> component1)
            {
                int vectorCount = Vector<int>.Count; // 8
                int length = component1.Length - (component1.Length % vectorCount);

                Span<Vector<int>> vectors1 = MemoryMarshal.Cast<PPComponent1, Vector<int>>(component1.Slice(0, length));

                for (int i = 0; i < vectors1.Length; i++)
                    vectors1[i] += Vector<int>.One;

                for (int i = length; i < component1.Length; i++)
                    component1[i].Value++;
            }

            public void SparseUpdate(ref PPComponent1 component1) => ++component1.Value;
        }
    }
}

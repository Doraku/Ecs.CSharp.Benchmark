using System;
using System.Numerics;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using PewPew.Ecs.Core;
using PewPew.Ecs.Filters;
using PewPew.Ecs.Hybrid;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponents
    {
        [Context]
        private readonly PewPewEcsContext _pewPewEcsContext;

        [BenchmarkCategory(Categories.PewPewEcs)]
        [Benchmark]
        public void PewPewEcs() =>
            _pewPewEcsContext.HybridWorld.ExecuteQueryWithoutId<TwoComponentsQuery, PPComponent1, PPComponent2>(
                _pewPewEcsContext.FilterDefinition,
                _pewPewEcsContext.Query);

        [BenchmarkCategory(Categories.PewPewEcs)]
        [Benchmark]
        public void PewPewEcs_Simd() =>
            _pewPewEcsContext.HybridWorld.ExecuteBatchQuery<TwoComponentsBatchQuery, PPComponent1, PPComponent2>(
                _pewPewEcsContext.FilterDefinition,
                _pewPewEcsContext.BatchQuery);

        private sealed class PewPewEcsContext : PewPewEcsBaseContext
        {
            public FilterDefinition FilterDefinition;

            public TwoComponentsQuery Query;
            public TwoComponentsBatchQuery BatchQuery;

            public PewPewEcsContext(int entityCount, int entityPadding) : base(entityCount, entityPadding)
            {
                HybridWorld.InitTwoComponentArchetype();

                Query = default;
                BatchQuery = default;

                FilterDefinition = new FilterDefinition()
                    .With<PPComponent1>()
                    .With<PPComponent2>();

                TwoComponentArchetype archetype = HybridWorld.GetTwoComponentArchetype();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        EntityId paddingEntityId = HybridWorld.CreateEntityId();
                        switch (j % 2)
                        {
                            case 0:
                                HybridWorld.AddComponent<PPComponent1>(paddingEntityId);
                                break;

                            case 1:
                                HybridWorld.AddComponent<PPComponent2>(paddingEntityId);
                                break;
                        }
                    }

                    EntityId entityId = HybridWorld.CreateEntityId();

                    TwoComponent components = archetype.Add(entityId);
                    components.Component1 = new PPComponent1 { Value = 0 };
                    components.Component2 = new PPComponent2 { Value = 1 };
                }
            }
        }
    }

    [PewPew.Ecs.Hybrid.Archetype]
    public ref struct TwoComponent
    {
        public ref PPComponent1 Component1;
        public ref PPComponent2 Component2;

        public TwoComponent(ref PPComponent1 component1, ref PPComponent2 component2)
        {
            Component1 = ref component1;
            Component2 = ref component2;
        }
    }

    public struct TwoComponentsQuery : IQueryWithoutId<PPComponent1, PPComponent2>
    {
        public void Update(ref PPComponent1 component1, ref PPComponent2 component2)
        {
            component1.Value += component2.Value;
        }
    }

    public struct TwoComponentsBatchQuery : IBatchQuery<PPComponent1, PPComponent2>
    {
        public void BatchUpdate(Span<PPComponent1> component1, Span<PPComponent2> component2)
        {
            int vectorCount = Vector<int>.Count; // 8
            int length = component1.Length - (component1.Length % vectorCount);

            Span<Vector<int>> vectors1 = MemoryMarshal.Cast<PPComponent1, Vector<int>>(component1.Slice(0, length));
            Span<Vector<int>> vectors2 = MemoryMarshal.Cast<PPComponent2, Vector<int>>(component2.Slice(0, length));

            for (int i = 0; i < vectors1.Length; i++)
                vectors1[i] += vectors2[i];

            for (int i = length; i < component1.Length; i++)
                component1[i].Value += component2[i].Value;
        }

        public void SparseUpdate(ref PPComponent1 component1, ref PPComponent2 component2)
        {
            component1.Value += component2.Value;
        }
    }

}

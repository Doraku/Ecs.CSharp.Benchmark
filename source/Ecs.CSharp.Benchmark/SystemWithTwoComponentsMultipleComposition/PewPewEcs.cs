using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using PewPew.Ecs.Core;
using PewPew.Ecs.Filters;
using PewPew.Ecs.Hybrid;
using IComponent = PewPew.Ecs.Core.IComponent;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
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

            public PewPewEcsContext(int entityCount) : base(entityCount)
            {
                HybridWorld.InitStaticArchetype<PPComponent1, PPComponent2, Padding1>();
                HybridWorld.InitStaticArchetype<PPComponent1, PPComponent2, Padding2>();
                HybridWorld.InitStaticArchetype<PPComponent1, PPComponent2, Padding3>();
                HybridWorld.InitStaticArchetype<PPComponent1, PPComponent2, Padding4>();

                Query = default;
                BatchQuery = default;

                FilterDefinition = new FilterDefinition()
                    .With<PPComponent1>()
                    .With<PPComponent2>();

                var staticArchetype1 = HybridWorld.GetStaticArchetype<PPComponent1, PPComponent2, Padding1>();
                var staticArchetype2 = HybridWorld.GetStaticArchetype<PPComponent1, PPComponent2, Padding2>();
                var staticArchetype3 = HybridWorld.GetStaticArchetype<PPComponent1, PPComponent2, Padding3>();
                var staticArchetype4 = HybridWorld.GetStaticArchetype<PPComponent1, PPComponent2, Padding4>();

                for (int i = 0; i < entityCount; ++i)
                {
                    EntityId entityId = HybridWorld.CreateEntityId();

                    switch (i % 4)
                    {
                        case 0:
                            staticArchetype1.Add(entityId, new PPComponent1 { Value = 0 }, new PPComponent2 { Value = 1 }, new Padding1());
                            break;

                        case 1:
                            staticArchetype2.Add(entityId, new PPComponent1 { Value = 0 }, new PPComponent2 { Value = 1 }, new Padding2());
                            break;

                        case 2:
                            staticArchetype3.Add(entityId, new PPComponent1 { Value = 0 }, new PPComponent2 { Value = 1 }, new Padding3());
                            break;

                        case 3:
                            staticArchetype4.Add(entityId, new PPComponent1 { Value = 0 }, new PPComponent2 { Value = 1 }, new Padding4());
                            break;
                    }
                }
            }

            private record struct Padding1() : IComponent;

            private record struct Padding2() : IComponent;

            private record struct Padding3() : IComponent;

            private record struct Padding4() : IComponent;
        }
    }

}

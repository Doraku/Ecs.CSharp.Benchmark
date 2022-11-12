using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using HypEcs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        private class HypEcsContext : HypEcsBaseContext
        {
            private struct Padding1 {}

            private struct Padding2 {}

            private struct Padding3 {}

            private struct Padding4 {}

            private sealed class MonoThreadRunSystem : ISystem
            {
                public void Run(World world)
                {
                    Query<Component1, Component2> query = world.Query<Component1, Component2>().Build();
                    foreach ((Ref<Component1> c1, Ref<Component2> c2) in query)
                    {
                        c1.Value.Value += c2.Value.Value;
                    }
                }
            }

            public ISystem MonoThreadSystem { get; } = new MonoThreadRunSystem();

            public HypEcsContext(int entityCount)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    EntityBuilder entity = World.Spawn()
                        .Add(new Component1())
                        .Add(new Component2 { Value = 1 });

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
            }
        }

        [Context] private readonly HypEcsContext _hypEcs;

        [BenchmarkCategory(Categories.HypEcs)]
        [Benchmark]
        public void HypEcs() => _hypEcs.MonoThreadSystem.Run(_hypEcs.World);
    }
}
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using RelEcs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithThreeComponents
    {
        private sealed class RelEcsContext : RelEcsBaseContext
        {
            private sealed class MonoThreadRunSystem : ISystem
            {
                public void Run(World world)
                {
                    Query<Component1, Component2, Component3> query = world.Query<Component1, Component2, Component3>().Build();
                    foreach ((Component1 c1, Component2 c2, Component3 c3) in query)
                    {
                        c1.Value += c2.Value + c3.Value;
                    }
                }
            }

            public ISystem MonoThreadSystem { get; } = new MonoThreadRunSystem();

            public RelEcsContext(int entityCount, int entityPadding)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        EntityBuilder padding = World.Spawn();
                        switch (j % 3)
                        {
                            case 0:
                                padding.Add(new Component1());
                                break;

                            case 1:
                                padding.Add(new Component2());
                                break;

                            case 2:
                                padding.Add(new Component3());
                                break;
                        }
                    }

                    World.Spawn()
                        .Add(new Component1())
                        .Add(new Component2 { Value = 1 })
                        .Add(new Component3 { Value = 1 });
                }
            }
        }

        [Context]
        private readonly RelEcsContext _relEcs;

        [BenchmarkCategory(Categories.RelEcs)]
        [Benchmark]
        public void RelEcs() => _relEcs.MonoThreadSystem.Run(_relEcs.World);
    }
}

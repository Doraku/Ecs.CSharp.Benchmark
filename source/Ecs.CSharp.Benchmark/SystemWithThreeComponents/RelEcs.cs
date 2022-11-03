using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using RelEcs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithThreeComponents
    {
        private class RelEcsContext : RelEcsBaseContext
        {
            private sealed class MonoThreadRunSystem : ISystem
            {
                public World World { get; set; }
                public void Run()
                {
                    var query = World.Query<Component1, Component2, Component3>().Build();
                    foreach(var (c1, c2, c3) in query)
                    {
                        c1.Value += c2.Value + c3.Value;
                    }
                }
            }

            public ISystem MonoThreadSystem { get; }

            public RelEcsContext(int entityCount, int entityPadding)
            {
                MonoThreadSystem = new MonoThreadRunSystem();
                MonoThreadSystem.World = World;

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        var padding = World.Spawn();
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

        private RelEcsContext _relEcs;

        [BenchmarkCategory(Categories.RelEcs)]
        [Benchmark]
        public void RelEcs() => _relEcs.MonoThreadSystem.Run();
    }
}

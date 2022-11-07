using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using RelEcs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        private class RelEcsContext : RelEcsBaseContext
        {
            private record Padding1();

            private record Padding2();

            private record Padding3();

            private record Padding4();

            private sealed class MonoThreadRunSystem : ISystem
            {
                public World World { get; set; }
                public void Run()
                {
                    Query<Component1, Component2> query = World.Query<Component1, Component2>().Build();
                    foreach ((Component1 c1, Component2 c2) in query)
                    {
                        c1.Value += c2.Value;
                    }
                }
            }

            public ISystem MonoThreadSystem { get; } = new MonoThreadRunSystem();

            public RelEcsContext(int entityCount)
            {
                MonoThreadSystem.World = World;

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

        [Context]
        private readonly RelEcsContext _relEcs;

        [BenchmarkCategory(Categories.RelEcs)]
        [Benchmark]
        public void RelEcs() => _relEcs.MonoThreadSystem.Run();
    }
}

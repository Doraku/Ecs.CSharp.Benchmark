using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using RelEcs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        private sealed class RelEcsContext : RelEcsBaseContext
        {
            private sealed record Padding1();

            private sealed record Padding2();

            private sealed record Padding3();

            private sealed record Padding4();

            private sealed class MonoThreadRunSystem : ISystem
            {
                public void Run(World world)
                {
                    Query<Component1, Component2> query = world.Query<Component1, Component2>().Build();
                    foreach ((Component1 c1, Component2 c2) in query)
                    {
                        c1.Value += c2.Value;
                    }
                }
            }

            public ISystem MonoThreadSystem { get; } = new MonoThreadRunSystem();

            public RelEcsContext(int entityCount)
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

        [Context] private readonly RelEcsContext _relEcs;

        [BenchmarkCategory(Categories.RelEcs)]
        [Benchmark]
        public void RelEcs() => _relEcs.MonoThreadSystem.Run(_relEcs.World);
    }
}
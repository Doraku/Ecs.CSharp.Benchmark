using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using HypEcs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        private sealed class HypEcsContext : HypEcsBaseContext
        {
            private struct Padding1
            {
            }

            private struct Padding2
            {
            }

            private struct Padding3
            {
            }

            private struct Padding4
            {
            }

            private sealed class MonoThreadRunSystem : ISystem
            {
                public void Run(World world)
                {
                    Query<Component1, Component2> query = world.Query<Component1, Component2>().Build();
                    query.Run((count, s1, s2) =>
                    {
                        for (int i = 0; i < count; i++)
                        {
                            s1[i].Value += s2[i].Value;
                        }
                    });
                }
            }

            private sealed class MultiThreadRunSystem : ISystem
            {
                public void Run(World world)
                {
                    Query<Component1, Component2> query = world.Query<Component1, Component2>().Build();
                    query.RunParallel((count, s1, s2) =>
                    {
                        for (int i = 0; i < count; i++)
                        {
                            s1[i].Value += s2[i].Value;
                        }
                    });
                }
            }

            public ISystem MonoThreadSystem { get; } = new MonoThreadRunSystem();
            public ISystem MultiThreadSystem { get; } = new MultiThreadRunSystem();

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
        public void HypEcs_MonoThread() => _hypEcs.MonoThreadSystem.Run(_hypEcs.World);

        [BenchmarkCategory(Categories.HypEcs)]
        [Benchmark]
        public void HypEcs_MultiThread() => _hypEcs.MultiThreadSystem.Run(_hypEcs.World);
    }
}
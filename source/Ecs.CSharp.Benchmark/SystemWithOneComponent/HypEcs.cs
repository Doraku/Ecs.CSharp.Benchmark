using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using HypEcs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        private class HypEcsContext : HypEcsBaseContext
        {
            private sealed class MonoThreadRunSystem : ISystem
            {
                public void Run(World world)
                {
                    foreach (Ref<Component1> c in world.Query<Component1>().Build())
                    {
                        c.Value.Value++;
                    }
                }
            }

            public ISystem MonoThreadSystem { get; } = new MonoThreadRunSystem();

            public HypEcsContext(int entityCount, int entityPadding)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.Spawn();
                    }

                    World
                        .Spawn()
                        .Add(new Component1());
                }
            }
        }

        [Context]
        private readonly HypEcsContext _hypEcs;

        [BenchmarkCategory(Categories.HypEcs)]
        [Benchmark]
        public void HypEcs() => _hypEcs.MonoThreadSystem.Run(_hypEcs.World);
    }
}

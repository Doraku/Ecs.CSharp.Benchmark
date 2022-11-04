using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using RelEcs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        private class RelEcsContext : RelEcsBaseContext
        {
            private sealed class MonoThreadRunSystem : ISystem
            {
                public World World { get; set; }
                public void Run()
                {
                    foreach(Component1 c in World.Query<Component1>().Build())
                    {
                        c.Value++;
                    }
                }
            }

            public ISystem MonoThreadSystem { get; } = new MonoThreadRunSystem();

            public RelEcsContext(int entityCount, int entityPadding)
            {
                MonoThreadSystem.World = World;

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.Spawn();
                    }

                    World.Spawn()
                        .Add(new Component1());
                }
            }
        }

        private RelEcsContext _relEcs;

        [BenchmarkCategory(Categories.RelEcs)]
        [Benchmark]
        public void RelEcs() => _relEcs.MonoThreadSystem.Run();
    }
}

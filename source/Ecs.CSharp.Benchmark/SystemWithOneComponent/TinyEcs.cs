using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.TinyEcs_Components;
using TinyEcs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        [Context] private readonly TinyEcsContext _tinyEcs;

        private sealed class TinyEcsContext : TinyEcsBaseContext
        {
            public TinyEcsContext(int entityCount, int entityPadding) : base()
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.Entity();
                    }

                    World.Entity().Set<Component1>();
                }
            }
        }

        [BenchmarkCategory(Categories.TinyEcs)]
        [Benchmark]
        public void TinyEcs_Each()
        {
            _tinyEcs.World.Each((EntityView _, ref Component1 c1) => c1.Value++);
        }

        [BenchmarkCategory(Categories.TinyEcs)]
        [Benchmark]
        public void TinyEcs_EachJob()
        {
            _tinyEcs.World.EachJob((EntityView _, ref Component1 c1) => c1.Value++);
        }
    }
}

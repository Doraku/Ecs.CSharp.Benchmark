using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.TinyEcs_Components;
using TinyEcs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithThreeComponents
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
                        var padding = World.Entity();
                        switch (j % 3)
                        {
                            case 0:
                                padding.Set(new Component1());
                                break;

                            case 1:
                                padding.Set(new Component2());
                                break;

                            case 2:
                                padding.Set(new Component3());
                                break;
                        }
                    }

                    World.Entity()
                        .Set(new Component1())
                        .Set(new Component2 { Value = 1 })
                        .Set(new Component3 { Value = 1 });
                }
            }
        }

        [BenchmarkCategory(Categories.TinyEcs)]
        [Benchmark]
        public void TinyEcs_Each()
        {
            _tinyEcs.World.Each((EntityView _, ref Component1 c1, ref Component2 c2, ref Component3 c3) => c1.Value += c2.Value + c3.Value);
        }

        [BenchmarkCategory(Categories.TinyEcs)]
        [Benchmark]
        public void TinyEcs_EachJob()
        {
            _tinyEcs.World.EachJob((EntityView _, ref Component1 c1, ref Component2 c2, ref Component3 c3) => c1.Value += c2.Value + c3.Value);
        }
    }
}

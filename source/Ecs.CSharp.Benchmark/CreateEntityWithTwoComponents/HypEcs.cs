using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithTwoComponents
    {
        [Context] private readonly HypEcsBaseContext _hypEcs;

        [BenchmarkCategory(Categories.HypEcs)]
        [Benchmark]
        public void HypEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _hypEcs.World.Spawn()
                    .Add(new HypEcsBaseContext.Component1())
                    .Add(new HypEcsBaseContext.Component2());
            }
        }
    }
}
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithThreeComponents
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
                    .Add(new HypEcsBaseContext.Component2())
                    .Add(new HypEcsBaseContext.Component3());
            }
        }
    }
}
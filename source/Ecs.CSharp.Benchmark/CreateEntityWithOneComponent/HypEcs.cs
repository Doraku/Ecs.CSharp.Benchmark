using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithOneComponent
    {
        [Context] private readonly HypEcsBaseContext _hypEcs;

        [BenchmarkCategory(Categories.RelEcs)]
        [Benchmark]
        public void HypEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _hypEcs.World.Spawn().Add(new HypEcsBaseContext.Component1());
            }
        }
    }
}
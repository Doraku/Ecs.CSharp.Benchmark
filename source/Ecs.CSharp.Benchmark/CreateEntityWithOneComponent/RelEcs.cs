using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithOneComponent
    {
        [Context]
        private readonly RelEcsBaseContext _relEcs;

        [BenchmarkCategory(Categories.RelEcs)]
        [Benchmark]
        public void RelEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _relEcs.World.Spawn().Add(new RelEcsBaseContext.Component1());
            }
        }
    }
}

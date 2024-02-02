using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.Arch_Components;
using Flecs.NET.Core;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithTwoComponents
    {
        [Context]
        private readonly FlecsNetBaseContext _flecs;

        [BenchmarkCategory(Categories.FlecsNet)]
        [Benchmark]
        public void FlecsNet()
        {
            World world = _flecs.World;

            for (int i = 0; i < EntityCount; ++i)
            {
                world.Entity()
                    .Set<Component1>(new())
                    .Set<Component2>(new());
            }
        }
    }
}

using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.FlecsNet_Components;
using Flecs.NET.Core;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithOneComponent
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
                    .Set<Component1>(new());
            }
        }
    }
}

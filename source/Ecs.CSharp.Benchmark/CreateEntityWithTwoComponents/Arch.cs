using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithTwoComponents
    {
        private ArchBaseContext _arch;
        private Type[] archetype = { typeof(ArchBaseContext.Component1), typeof(ArchBaseContext.Component2) };

        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch() 
        {
            var world = _arch.World;
            world.Reserve(archetype, EntityCount);
            for (int i = 0; i < EntityCount; ++i) {
                world.Create(archetype);
            }
        }
    }
}

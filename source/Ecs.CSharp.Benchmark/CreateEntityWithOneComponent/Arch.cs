using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;

namespace Ecs.CSharp.Benchmark {

    public partial class CreateEntityWithOneComponent
    {

        private ArchBaseContext _arch;
        private Type[] archetype = { typeof(ArchBaseContext.Component1) };
        
        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch() 
        {
            var world = _arch.World;
            world.Reserve(archetype, EntityCount);  // Optional, bulk allocates 
            for (int i = 0; i < EntityCount; ++i) {
                world.Create(archetype);
            }
        }
    }

}
using System;
using Arch.Core;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Ecs.CSharp.Benchmark.Context.Arch_Components;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithOneComponent
    {
        private static readonly Type[] _archetype = { typeof(Component1) };

        private ArchBaseContext _arch;

        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch()
        {
            World world = _arch.World;
            world.Reserve(_archetype, EntityCount);

            for (int i = 0; i < EntityCount; ++i)
            {
                world.Create(_archetype);
            }
        }
    }
}
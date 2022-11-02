using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithThreeComponents
    {
        private static readonly Type[] _archetype = { typeof(ArchBaseContext.Component1), typeof(ArchBaseContext.Component2), typeof(ArchBaseContext.Component3) };

        private ArchBaseContext _arch;

        [BenchmarkCategory(Categories.Entitas)]
        [Benchmark]
        public void Arch()
        {
            Arch.Core.World world = _arch.World;
            world.Reserve(_archetype, EntityCount);

            for (int i = 0; i < EntityCount; ++i)
            {
                world.Create(_archetype);
            }
        }
    }
}
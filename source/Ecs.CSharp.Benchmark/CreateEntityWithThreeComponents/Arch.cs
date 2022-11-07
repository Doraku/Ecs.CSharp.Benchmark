using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Ecs.CSharp.Benchmark.Context.Arch_Components;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithThreeComponents
    {
        private static readonly Type[] _archetype = { typeof(Component1), typeof(Component2), typeof(Component3) };

        [Context]
        private readonly ArchBaseContext _arch;

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
using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.Myriad_Components;
using Myriad.ECS.Command;
using Myriad.ECS.Worlds;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithOneComponent
    {
        [Context]
        private readonly MyriadBaseContext _myriad;

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad()
        {
            World world = _myriad.World;

            CommandBuffer buffer = new CommandBuffer(world);

            for (int i = 0; i < EntityCount; ++i)
            {
                buffer.Create().Set(new Component1());
            }

            buffer.Playback().Dispose();
        }
    }
}

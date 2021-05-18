using System;
using BenchmarkDotNet.Attributes;
using Leopotam.Ecs;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntity
    {
        private class LeopotamEcsContext : IDisposable
        {
            public EcsWorld World { get; }

            public LeopotamEcsContext()
            {
                World = new EcsWorld();
            }

            public void Dispose()
            {
                World.Destroy();
            }
        }

        private LeopotamEcsContext _leopotamEcs;

        [Benchmark]
        public void LeopotamEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _leopotamEcs.World.NewEntity();
            }
        }
    }
}

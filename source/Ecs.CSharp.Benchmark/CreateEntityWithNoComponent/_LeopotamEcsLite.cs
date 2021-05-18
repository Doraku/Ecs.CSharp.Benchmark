using System;
using BenchmarkDotNet.Attributes;
using Leopotam.EcsLite;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithNoComponent
    {
        private class LeopotamEcsLiteContext : IDisposable
        {
            public EcsWorld World { get; }

            public LeopotamEcsLiteContext()
            {
                World = new EcsWorld();
            }

            public void Dispose()
            {
                World.Destroy();
            }
        }

        private LeopotamEcsLiteContext _leopotamEcsLite;

        [Benchmark]
        public void LeopotamEcsLite()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _leopotamEcsLite.World.NewEntity();
            }
        }
    }
}

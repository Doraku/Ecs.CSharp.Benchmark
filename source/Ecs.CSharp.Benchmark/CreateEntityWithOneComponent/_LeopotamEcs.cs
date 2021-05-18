using System;
using BenchmarkDotNet.Attributes;
using Leopotam.Ecs;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithOneComponent
    {
        private class LeopotamEcsContext : IDisposable
        {
#pragma warning disable CS0649
            public struct Component
            {
                public int Value;
            }

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
                _leopotamEcs.World.NewEntity().Replace(new LeopotamEcsContext.Component());
            }
        }
    }
}

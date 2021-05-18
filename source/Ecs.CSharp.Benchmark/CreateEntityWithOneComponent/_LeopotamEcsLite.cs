using System;
using BenchmarkDotNet.Attributes;
using Leopotam.EcsLite;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithOneComponent
    {
        private class LeopotamEcsLiteContext : IDisposable
        {
#pragma warning disable CS0649
            public struct Component
            {
                public int Value;
            }

            public EcsWorld World { get; }

            public EcsPool<Component> Components { get; }

            public LeopotamEcsLiteContext()
            {
                World = new EcsWorld();
                Components = World.GetPool<Component>();
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
                _leopotamEcsLite.Components.Add(_leopotamEcsLite.World.NewEntity());
            }
        }
    }
}

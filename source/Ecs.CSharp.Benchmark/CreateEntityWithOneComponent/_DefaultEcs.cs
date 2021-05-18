using System;
using BenchmarkDotNet.Attributes;
using DefaultEcs;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithOneComponent
    {
        private class DefaultEcsContext : IDisposable
        {
#pragma warning disable CS0649
            public struct Component
            {
                public int Value;
            }

            public World World { get; }

            public DefaultEcsContext()
            {
                World = new World();
            }

            public void Dispose()
            {
                World.Dispose();
            }
        }

        private DefaultEcsContext _defaultEcs;

        [Benchmark]
        public void DefaultEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _defaultEcs.World.CreateEntity().Set<DefaultEcsContext.Component>();
            }
        }
    }
}

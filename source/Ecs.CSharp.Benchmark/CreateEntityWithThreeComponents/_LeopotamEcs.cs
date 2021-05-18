using System;
using BenchmarkDotNet.Attributes;
using Leopotam.Ecs;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithThreeComponents
    {
        private class LeopotamEcsContext : IDisposable
        {
#pragma warning disable CS0649
            public struct Component1
            {
                public int Value;
            }

            public struct Component2
            {
                public int Value;
            }

            public struct Component3
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
                _leopotamEcs.World
                    .NewEntity()
                    .Replace(new LeopotamEcsContext.Component1())
                    .Replace(new LeopotamEcsContext.Component2())
                    .Replace(new LeopotamEcsContext.Component3());
            }
        }
    }
}

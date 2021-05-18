using System;
using BenchmarkDotNet.Attributes;
using Leopotam.EcsLite;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithTwoComponents
    {
        private class LeopotamEcsLiteContext : IDisposable
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

            public EcsWorld World { get; }

            public EcsPool<Component1> Components1 { get; }

            public EcsPool<Component2> Components2 { get; }

            public LeopotamEcsLiteContext()
            {
                World = new EcsWorld();
                Components1 = World.GetPool<Component1>();
                Components2 = World.GetPool<Component2>();
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
                int entity = _leopotamEcsLite.World.NewEntity();
                _leopotamEcsLite.Components1.Add(entity);
                _leopotamEcsLite.Components2.Add(entity);
            }
        }
    }
}

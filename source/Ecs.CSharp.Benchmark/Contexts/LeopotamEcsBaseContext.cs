using System;
using Leopotam.Ecs;

namespace Ecs.CSharp.Benchmark.Contexts
{
    internal class LeopotamEcsBaseContext : IDisposable
    {
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

        public LeopotamEcsBaseContext()
        {
            World = new EcsWorld();
        }

        public virtual void Dispose()
        {
            World.Destroy();
        }
    }
}

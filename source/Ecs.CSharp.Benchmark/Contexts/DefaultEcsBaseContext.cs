using System;
using DefaultEcs;

namespace Ecs.CSharp.Benchmark.Contexts
{
    internal class DefaultEcsBaseContext : IDisposable
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

        public World World { get; }

        public DefaultEcsBaseContext()
        {
            World = new World();
        }

        public virtual void Dispose()
        {
            World.Dispose();
        }
    }
}

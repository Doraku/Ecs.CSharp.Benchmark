using System;
using RelEcs;

namespace Ecs.CSharp.Benchmark.Context
{
    internal class RelEcsBaseContext : IDisposable
    {
        public class Component1
        {
            public int Value;
        }

        public class Component2
        {
            public int Value;
        }

        public class Component3
        {
            public int Value;
        }

        public World World { get; }

        public RelEcsBaseContext()
        {
            World = new World();
        }

        public virtual void Dispose()
        {
            // World.Destroy();
        }
    }
}

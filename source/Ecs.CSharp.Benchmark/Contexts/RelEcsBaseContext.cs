using System;
using RelEcs;

namespace Ecs.CSharp.Benchmark.Contexts
{
    internal class RelEcsBaseContext : IDisposable
    {
        public sealed class Component1
        {
            public int Value;
        }

        public sealed class Component2
        {
            public int Value;
        }

        public sealed class Component3
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

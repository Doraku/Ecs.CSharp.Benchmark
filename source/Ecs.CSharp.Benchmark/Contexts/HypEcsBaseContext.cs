using System;
using HypEcs;

namespace Ecs.CSharp.Benchmark.Contexts
{
    internal class HypEcsBaseContext : IDisposable
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

        public HypEcsBaseContext()
        {
            World = new World();
        }

        public virtual void Dispose()
        {
            // World.Destroy();
        }
    }
}
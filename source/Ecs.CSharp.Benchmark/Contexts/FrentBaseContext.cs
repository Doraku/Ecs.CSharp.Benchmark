using System;
using Frent;

namespace Ecs.CSharp.Benchmark.Contexts
{
    internal class FrentBaseContext : IDisposable
    {
        public World World { get; } = new();
        public void Dispose() => World.Dispose();

        internal struct Component1
        {
            public int Value;
        }

        internal struct Component2
        {
            public int Value;
        }

        internal struct Component3
        {
            public int Value;
        }
    }
}

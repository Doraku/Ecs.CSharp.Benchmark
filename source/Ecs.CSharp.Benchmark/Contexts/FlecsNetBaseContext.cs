using System;
using Flecs.NET.Core;

namespace Ecs.CSharp.Benchmark.Contexts
{
    namespace FlecsNet_Components
    {
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

    internal class FlecsNetBaseContext : IDisposable
    {
        public World World { get; }

        public FlecsNetBaseContext()
        {
            World = World.Create();
        }

        public void Dispose()
        {
            World.Dispose();
        }
    }
}

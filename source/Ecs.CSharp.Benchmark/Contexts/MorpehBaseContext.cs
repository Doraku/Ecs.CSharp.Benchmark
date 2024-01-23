using System;
using Scellecs.Morpeh;

namespace Ecs.CSharp.Benchmark.Contexts
{
    internal class MorpehBaseContext : IDisposable
    {
        public struct Component1 : IComponent
        {
            public int Value;
        }

        public struct Component2 : IComponent
        {
            public int Value;
        }

        public struct Component3 : IComponent
        {
            public int Value;
        }

        public World World { get; }

        public MorpehBaseContext()
        {
            World = World.Create();
        }

        public virtual void Dispose()
        {
            World.Dispose();
        }
    }
}

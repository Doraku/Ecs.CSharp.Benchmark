using System;
using MonoGame.Extended.Entities;

namespace Ecs.CSharp.Benchmark.Context
{
    internal class MonoGameExtendedBaseContext : IDisposable
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

        public MonoGameExtendedBaseContext()
        {
            World = new WorldBuilder().Build();
        }

        public virtual void Dispose()
        {
            World.Dispose();
        }
    }
}

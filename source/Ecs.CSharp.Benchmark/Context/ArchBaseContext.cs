using System;
using Arch.Core;

namespace Ecs.CSharp.Benchmark.Context
{
    namespace Arch_Components
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

    internal class ArchBaseContext : IDisposable
    {
        public World World { get; }

        public ArchBaseContext()
        {
            World = World.Create();
        }

        public ArchBaseContext(Type[] archetype, int amount)
        {
            World = World.Create();
            World.Reserve(archetype, amount);

            for (int index = 0; index < amount; index++)
            {
                World.Create(archetype);
            }
        }

        public virtual void Dispose()
        {
            World.Destroy(World);
        }
    }
}
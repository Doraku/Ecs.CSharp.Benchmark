using System;
using fennecs;

namespace Ecs.CSharp.Benchmark.Contexts
{
    namespace Fennecs_Components
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

    internal class FennecsBaseContext(int entityCount) : IDisposable
    {
        public World World { get; } = new(entityCount * 2);

        public virtual void Dispose()
        {
            World.Dispose();
        }
    }
}

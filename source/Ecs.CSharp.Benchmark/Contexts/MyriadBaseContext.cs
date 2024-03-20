using System;
using System.Runtime.InteropServices;
using Myriad.ECS;
using Myriad.ECS.Worlds;

namespace Ecs.CSharp.Benchmark.Contexts
{
    namespace Myriad_Components
    {
        internal struct Component1
            : IComponent
        {
            public int Value;
        }

        internal struct Component2
            : IComponent
        {
            public int Value;
        }

        internal struct Component3
            : IComponent
        {
            public int Value;
        }

        internal struct Padding1
            : IComponent
        {
        }

        internal struct Padding2
            : IComponent
        {
        }

        internal struct Padding3
            : IComponent
        {
        }

        internal struct Padding4
            : IComponent
        {
        }
    }

    internal class MyriadBaseContext
        : IDisposable
    {
        public World World { get; }

        public MyriadBaseContext()
        {
            World = new WorldBuilder().Build();
        }

        public void Dispose()
        {
        }
    }
}

using System;
using Sia;

namespace Ecs.CSharp.Benchmark.Contexts
{
    internal class SiaBaseContext : IDisposable
    {
        public partial record struct Component1(int Value);

        public partial record struct Component2(int Value);

        public partial record struct Component3(int Value);

        public World World { get; }

        public SiaBaseContext()
        {
            World = new World();
            Context<World>.Current = World;
        }

        public virtual void Dispose()
        {
            World.Dispose();
        }
    }
}

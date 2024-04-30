using System;
using TinyEcs;

namespace Ecs.CSharp.Benchmark.Contexts
{
    namespace TinyEcs_Components
    {
        public record struct Component1(int Value);

        public record struct Component2(int Value);

        public record struct Component3(int Value);
    }

    internal class TinyEcsBaseContext : IDisposable
    {
        public World World { get; }

        public TinyEcsBaseContext()
        {
            World = new World();
        }

        public virtual void Dispose()
        {
            World?.Dispose();
        }
    }
}

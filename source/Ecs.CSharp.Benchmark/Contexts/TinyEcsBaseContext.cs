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

    public class TinyEcsBaseContext
    {
        public World World { get; }

        public TinyEcsBaseContext()
        {
            World = new World();
        }
    }
}

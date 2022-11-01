using System;
using Arch.Core;

namespace Ecs.CSharp.Benchmark.Context {

    internal class ArchBaseContext : IDisposable
    {

        public struct Component1
        {
            public int Value;
        }

        public struct Component2
        {
            public int Value;
        }

        public struct Component3
        {
            public int Value;
        }
        
        public World World { get; }

        public ArchBaseContext() {
            World = World.Create();
        }

        public ArchBaseContext(Type[] archetype, int amount) {
            
            World = World.Create();
            World.Reserve(archetype, amount);
            for(var index = 0; index < amount; index++)
                World.Create(archetype);
        }

        public virtual void Dispose()
        {
            World.Destroy(World);
        }
    }

}
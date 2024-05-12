using System;
using System.Runtime.CompilerServices;
using fennecs;

namespace Ecs.CSharp.Benchmark.Contexts
{
    namespace Fennecs_Components
    {
        internal struct Component1
        {
            public static implicit operator Component1(int value) => new() { Value = value }; 
            public static implicit operator Component2(Component1 self) => new() { Value = self.Value }; 
            public static implicit operator Component3(Component1 self) => new() { Value = self.Value }; 
            public static implicit operator int (Component1 c) => c.Value;
            
            public int Value;
        }

        internal struct Component2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Component1(Component2 self) => new() { Value = self.Value }; 
            public static implicit operator Component2(int value) => new() { Value = value }; 
            public static implicit operator Component3(Component2 self) => new() { Value = self.Value }; 
            public static implicit operator int (Component2 c) => c.Value;
            
            public int Value;
        }

        internal struct Component3
        {
            public static implicit operator Component1(Component3 self) => new() { Value = self.Value }; 
            public static implicit operator Component2(Component3 self) => new() { Value = self.Value }; 
            public static implicit operator Component3(int value) => new() { Value = value }; 
            public static implicit operator int (Component3 c) => c.Value;
            
            public int Value;
        }
    }

    internal class FennecsBaseContext(int entityCount) : IDisposable
    {
        public World World { get; } = new World(entityCount * 2);

        public virtual void Dispose()
        {
            World.Dispose();
        }
        public FennecsBaseContext() : this(100000)
        { }
    }
}

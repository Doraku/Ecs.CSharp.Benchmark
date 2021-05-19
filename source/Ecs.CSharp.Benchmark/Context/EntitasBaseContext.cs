using System;
using Entitas;

namespace Ecs.CSharp.Benchmark.Context
{
    internal class EntitasBaseContext : IDisposable
    {
        public class Component1 : IComponent
        {
            public int Value;
        }

        public class Component2 : IComponent
        {
            public int Value;
        }

        public class Component3 : IComponent
        {
            public int Value;
        }

        public Context<Entity> Context { get; }

        public EntitasBaseContext()
        {
            Context = new Context<Entity>(3, () => new Entity());
        }

        public virtual void Dispose()
        {
            Context.DestroyAllEntities();
        }
    }
}

﻿using System;
using Entitas;

namespace Ecs.CSharp.Benchmark.Contexts
{
    internal class EntitasBaseContext : IDisposable
    {
        public sealed class Component1 : IComponent
        {
            public int Value;
        }

        public sealed class Component2 : IComponent
        {
            public int Value;
        }

        public sealed class Component3 : IComponent
        {
            public int Value;
        }

        public Context<Entity> Context { get; }

        public EntitasBaseContext()
        {
            Context = new Context<Entity>(6, () => new Entity());
        }

        public virtual void Dispose()
        {
            Context.DestroyAllEntities();
        }
    }
}

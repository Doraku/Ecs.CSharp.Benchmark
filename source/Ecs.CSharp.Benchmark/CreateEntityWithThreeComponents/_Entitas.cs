using System;
using BenchmarkDotNet.Attributes;
using Entitas;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithThreeComponents
    {
        private class EntitasContext : IDisposable
        {
#pragma warning disable CS0649
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

            public EntitasContext()
            {
                Context = new Context<Entity>(3, () => new Entity());
            }

            public void Dispose()
            {
                Context.DestroyAllEntities();
            }
        }

        private EntitasContext _entitas;

        [Benchmark]
        public void Entitas()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = _entitas.Context.CreateEntity();
                entity.AddComponent(0, new EntitasContext.Component1());
                entity.AddComponent(1, new EntitasContext.Component2());
                entity.AddComponent(2, new EntitasContext.Component3());
            }
        }
    }
}

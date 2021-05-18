using System;
using BenchmarkDotNet.Attributes;
using Entitas;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithOneComponent
    {
        private class EntitasContext : IDisposable
        {
#pragma warning disable CS0649
            public class Component : IComponent
            {
                public int Value;
            }

            public Context<Entity> Context { get; }

            public EntitasContext()
            {
                Context = new Context<Entity>(1, () => new Entity());
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
                _entitas.Context.CreateEntity().AddComponent(0, new EntitasContext.Component());
            }
        }
    }
}

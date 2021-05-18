using System;
using BenchmarkDotNet.Attributes;
using Entitas;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        private class EntitasContext : IDisposable
        {
            private class Component : IComponent
            {
                public int Value;
            }

            private class EntitasSystem : JobSystem<Entity>
            {
                public EntitasSystem(Context<Entity> context, int threadCount)
                    : base(context.GetGroup(Matcher<Entity>.AllOf(0)), threadCount)
                { }

                public EntitasSystem(Context<Entity> context)
                    : this(context, 1)
                { }

                protected override void Execute(Entity entity)
                {
                    Component component = (Component)entity.GetComponent(0);
                    ++component.Value;
                }
            }

            public Context<Entity> Context { get; }

            public IExecuteSystem MonoThreadSystem { get; }

            public IExecuteSystem MultiThreadSystem { get; }

            public EntitasContext(int entityCount)
            {
                Context = new Context<Entity>(1, () => new Entity());
                MonoThreadSystem = new EntitasSystem(Context);
                MultiThreadSystem = new EntitasSystem(Context, Environment.ProcessorCount);

                for (int i = 0; i < entityCount; ++i)
                {
                    Entity entity = Context.CreateEntity();
                    entity.AddComponent(0, new Component());
                }
            }

            public void Dispose()
            {
                Context.DestroyAllEntities();
            }
        }

        private EntitasContext _entitas;

        [Benchmark]
        public void Entitas_MonoThread() => _entitas.MonoThreadSystem.Execute();

        [Benchmark]
        public void Entitas_MultiThread() => _entitas.MultiThreadSystem.Execute();
    }
}

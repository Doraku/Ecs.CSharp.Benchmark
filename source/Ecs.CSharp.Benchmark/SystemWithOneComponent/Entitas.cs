using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Entitas;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        private sealed class EntitasContext : EntitasBaseContext
        {
            private sealed class EntitasSystem : JobSystem<Entity>
            {
                public EntitasSystem(Context<Entity> context, int threadCount)
                    : base(context.GetGroup(Matcher<Entity>.AllOf(0)), threadCount)
                { }

                public EntitasSystem(Context<Entity> context)
                    : this(context, 1)
                { }

                protected override void Execute(Entity entity)
                {
                    Component1 component = (Component1)entity.GetComponent(0);
                    ++component.Value;
                }
            }

            public IExecuteSystem MonoThreadSystem { get; }

            public IExecuteSystem MultiThreadSystem { get; }

            public EntitasContext(int entityCount, int entityPadding)
            {
                MonoThreadSystem = new EntitasSystem(Context);
                MultiThreadSystem = new EntitasSystem(Context, Environment.ProcessorCount);

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        Context.CreateEntity();
                    }

                    Entity entity = Context.CreateEntity();
                    entity.AddComponent(0, new Component1());
                }
            }
        }

        [Context]
        private readonly EntitasContext _entitas;

        [BenchmarkCategory(Categories.Entitas)]
        [Benchmark]
        public void Entitas_MonoThread() => _entitas.MonoThreadSystem.Execute();

        [BenchmarkCategory(Categories.Entitas)]
        [Benchmark]
        public void Entitas_MultiThread() => _entitas.MultiThreadSystem.Execute();
    }
}

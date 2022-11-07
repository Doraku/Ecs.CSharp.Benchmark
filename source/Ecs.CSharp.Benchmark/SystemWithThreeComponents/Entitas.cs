using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Entitas;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithThreeComponents
    {
        private class EntitasContext : EntitasBaseContext
        {
            private class EntitasSystem : JobSystem<Entity>
            {
                public EntitasSystem(Context<Entity> context, int threadCount)
                    : base(context.GetGroup(Matcher<Entity>.AllOf(0, 1, 2)), threadCount)
                { }

                public EntitasSystem(Context<Entity> context)
                    : this(context, 1)
                { }

                protected override void Execute(Entity entity)
                {
                    Component1 c1 = (Component1)entity.GetComponent(0);
                    Component2 c2 = (Component2)entity.GetComponent(1);
                    Component3 c3 = (Component3)entity.GetComponent(2);

                    c1.Value += c2.Value + c3.Value;
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
                        Entity padding = Context.CreateEntity();
                        switch (j % 3)
                        {
                            case 0:
                                padding.AddComponent(0, new Component1());
                                break;

                            case 1:
                                padding.AddComponent(1, new Component2());
                                break;

                            case 2:
                                padding.AddComponent(2, new Component3());
                                break;
                        }
                    }

                    Entity entity = Context.CreateEntity();
                    entity.AddComponent(0, new Component1());
                    entity.AddComponent(1, new Component2 { Value = 1 });
                    entity.AddComponent(2, new Component3 { Value = 1 });
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

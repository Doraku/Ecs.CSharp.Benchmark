﻿using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Entitas;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        private sealed class EntitasContext : EntitasBaseContext
        {
            private sealed record Padding1() : IComponent;

            private sealed record Padding2() : IComponent;

            private sealed record Padding3() : IComponent;

            private sealed record Padding4() : IComponent;

            private sealed class EntitasSystem : JobSystem<Entity>
            {
                public EntitasSystem(Context<Entity> context, int threadCount)
                    : base(context.GetGroup(Matcher<Entity>.AllOf(0, 1)), threadCount)
                { }

                public EntitasSystem(Context<Entity> context)
                    : this(context, 1)
                { }

                protected override void Execute(Entity entity)
                {
                    Component1 c1 = (Component1)entity.GetComponent(0);
                    Component2 c2 = (Component2)entity.GetComponent(1);

                    c1.Value += c2.Value;
                }
            }

            public IExecuteSystem MonoThreadSystem { get; }

            public IExecuteSystem MultiThreadSystem { get; }

            public EntitasContext(int entityCount)
            {
                MonoThreadSystem = new EntitasSystem(Context);
                MultiThreadSystem = new EntitasSystem(Context, Environment.ProcessorCount);

                for (int i = 0; i < entityCount; ++i)
                {
                    Entity entity = Context.CreateEntity();
                    entity.AddComponent(0, new Component1());
                    entity.AddComponent(1, new Component2 { Value = 1 });

                    switch (i % 4)
                    {
                        case 0:
                            entity.AddComponent(2, new Padding1());
                            break;

                        case 1:
                            entity.AddComponent(3, new Padding2());
                            break;

                        case 2:
                            entity.AddComponent(4, new Padding3());
                            break;

                        case 3:
                            entity.AddComponent(5, new Padding4());
                            break;
                    }
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

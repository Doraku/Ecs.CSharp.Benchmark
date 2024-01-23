using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Svelto.DataStructures;
using Svelto.ECS;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        private sealed class SveltoECSContext : SveltoECSBaseContext
        {
            private record struct Padding1() : IEntityComponent;

            private record struct Padding2() : IEntityComponent;

            private record struct Padding3() : IEntityComponent;

            private record struct Padding4() : IEntityComponent;

            public sealed class SveltoEngine : IQueryingEntitiesEngine
            {
                public EntitiesDB entitiesDB { get; set; }

                public void Ready()
                { }

                public void Update()
                {
                    (NB<Component1> c1, NB<Component2> c2, int count) = entitiesDB.QueryEntities<Component1, Component2>(Group);

                    for (int i = 0; i < count; i++)
                    {
                        c1[i].Value += c2[i].Value;
                    }
                }
            }

            private sealed class Entity1 : GenericEntityDescriptor<Component1, Component2, Padding1>
            { }

            private sealed class Entity2 : GenericEntityDescriptor<Component1, Component2, Padding2>
            { }

            private sealed class Entity3 : GenericEntityDescriptor<Component1, Component2, Padding3>
            { }

            private sealed class Entity4 : GenericEntityDescriptor<Component1, Component2, Padding4>
            { }

            private sealed class Entity : GenericEntityDescriptor<Component1, Component2>
            { }

            public SveltoEngine Engine { get; }

            public SveltoECSContext(int entityCount)
            {
                Engine = new SveltoEngine();
                Root.AddEngine(Engine);

                uint id = 0;
                for (int i = 0; i < entityCount; ++i)
                {
                    EntityInitializer entity = (i % 4) switch
                    {
                        0 => Factory.BuildEntity<Entity1>(id++, Group),
                        1 => Factory.BuildEntity<Entity2>(id++, Group),
                        2 => Factory.BuildEntity<Entity3>(id++, Group),
                        _ => Factory.BuildEntity<Entity4>(id++, Group)
                    };

                    entity.GetOrAdd<Component2>() = new Component2 { Value = 1 };
                }

                Scheduler.SubmitEntities();
            }
        }

        [Context]
        private readonly SveltoECSContext _sveltoECS;

        [BenchmarkCategory(Categories.SveltoECS)]
        [Benchmark]
        public void SveltoECS() => _sveltoECS.Engine.Update();
    }
}

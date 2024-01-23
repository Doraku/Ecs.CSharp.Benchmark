using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Svelto.DataStructures;
using Svelto.ECS;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponents
    {
        private sealed class SveltoECSContext : SveltoECSBaseContext
        {
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

            public sealed class Padding1Entity : GenericEntityDescriptor<Component1>
            { }

            public sealed class Padding2Entity : GenericEntityDescriptor<Component2>
            { }

            public sealed class Entity : GenericEntityDescriptor<Component1, Component2>
            { }

            public SveltoEngine Engine { get; }

            public SveltoECSContext(int entityCount, int entityPadding)
            {
                Engine = new SveltoEngine();
                Root.AddEngine(Engine);

                uint id = 0;
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        switch (j % 2)
                        {
                            case 0:
                                Factory.BuildEntity<Padding1Entity>(id++, Group);
                                break;

                            case 1:
                                Factory.BuildEntity<Padding2Entity>(id++, Group);
                                break;
                        }
                    }

                    EntityInitializer entity = Factory.BuildEntity<Entity>(id++, Group);
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

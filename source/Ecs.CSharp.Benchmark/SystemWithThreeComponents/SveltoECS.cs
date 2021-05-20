using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Svelto.ECS;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithThreeComponents
    {
        private class SveltoECSContext : SveltoECSBaseContext
        {
            public sealed class SveltoEngine : IQueryingEntitiesEngine
            {
                public EntitiesDB entitiesDB { get; set; }

                public void Ready()
                { }

                public void Update()
                {
                    var (c1, c2, c3, count) = entitiesDB.QueryEntities<Component1, Component2, Component3>(Group);

                    for (var i = 0; i < count; i++)
                    {
                        c1[i].Value += c2[i].Value + c3[i].Value;
                    }
                }
            }

            public sealed class Padding1Entity : GenericEntityDescriptor<Component1>
            { }

            public sealed class Padding2Entity : GenericEntityDescriptor<Component2>
            { }

            public sealed class Padding3Entity : GenericEntityDescriptor<Component3>
            { }

            public sealed class Entity : GenericEntityDescriptor<Component1, Component2, Component3>
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
                        switch (j % 3)
                        {
                            case 0:
                                Factory.BuildEntity<Padding1Entity>(id++, Group);
                                break;

                            case 1:
                                Factory.BuildEntity<Padding2Entity>(id++, Group);
                                break;

                            case 2:
                                Factory.BuildEntity<Padding3Entity>(id++, Group);
                                break;
                        }
                    }

                    EntityInitializer entity = Factory.BuildEntity<Entity>(id++, Group);
                    entity.GetOrCreate<Component2>() = new Component2 { Value = 1 };
                    entity.GetOrCreate<Component3>() = new Component3 { Value = 1 };
                }

                Scheduler.SubmitEntities();
            }
        }

        private SveltoECSContext _sveltoECS;

        [Benchmark]
        public void SveltoECS() => _sveltoECS.Engine.Update();
    }
}

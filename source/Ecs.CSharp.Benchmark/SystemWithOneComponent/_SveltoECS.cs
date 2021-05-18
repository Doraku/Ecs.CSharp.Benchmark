using System;
using BenchmarkDotNet.Attributes;
using Svelto.ECS;
using Svelto.ECS.Schedulers;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        private class SveltoECSContext : IDisposable
        {
            public struct Component : IEntityComponent
            {
                public int Value;
            }

            public sealed class SveltoEngine : IQueryingEntitiesEngine
            {
                public EntitiesDB entitiesDB { get; set; }

                public void Ready()
                { }

                public void Update()
                {
                    var (entityViews, count) = entitiesDB.QueryEntities<Component>(Group);

                    for (var i = 0; i < count; i++)
                    {
                        ++entityViews[i].Value;
                    }
                }
            }

            public sealed class Entity : GenericEntityDescriptor<Component>
            { }

            public static ExclusiveGroup Group { get; } = new();

            public SimpleEntitiesSubmissionScheduler Scheduler { get; }
            public EnginesRoot Root { get; }
            public IEntityFactory Factory { get; }
            public SveltoEngine Engine { get; }

            public SveltoECSContext(int entityCount)
            {
                Scheduler = new SimpleEntitiesSubmissionScheduler();
                Root = new EnginesRoot(Scheduler);
                Factory = Root.GenerateEntityFactory();
                Engine = new SveltoEngine();
                Root.AddEngine(Engine);

                for (int i = 0; i < entityCount; ++i)
                {
                    Factory.BuildEntity<Entity>((uint)i, Group);
                }

                Scheduler.SubmitEntities();
            }

            public void Dispose()
            {
                Root.Dispose();
                Scheduler.Dispose();
            }
        }

        private SveltoECSContext _sveltoECS;

        [Benchmark]
        public void SveltoECS() => _sveltoECS.Engine.Update();
    }
}

using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Svelto.ECS;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
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
                    var (entityViews, count) = entitiesDB.QueryEntities<Component1>(Group);

                    for (var i = 0; i < count; i++)
                    {
                        ++entityViews[i].Value;
                    }
                }
            }

            public sealed class Entity : GenericEntityDescriptor<Component1>
            { }

            public SveltoEngine Engine { get; }

            public SveltoECSContext(int entityCount)
            {
                Engine = new SveltoEngine();
                Root.AddEngine(Engine);

                for (int i = 0; i < entityCount; ++i)
                {
                    Factory.BuildEntity<Entity>((uint)i, Group);
                }

                Scheduler.SubmitEntities();
            }
        }

        private SveltoECSContext _sveltoECS;

        [Benchmark]
        public void SveltoECS() => _sveltoECS.Engine.Update();
    }
}

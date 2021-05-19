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

            public sealed class Entity : GenericEntityDescriptor<Component1, Component2, Component3>
            { }

            public SveltoEngine Engine { get; }

            public SveltoECSContext(int entityCount)
            {
                Engine = new SveltoEngine();
                Root.AddEngine(Engine);

                for (int i = 0; i < entityCount; ++i)
                {
                    EntityInitializer entity = Factory.BuildEntity<Entity>((uint)i, Group);
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

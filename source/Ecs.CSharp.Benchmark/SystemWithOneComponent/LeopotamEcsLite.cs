using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Leopotam.EcsLite;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        private sealed class LeopotamEcsLiteContext : LeopotamEcsLiteBaseContext
        {
            private sealed class MonoThreadRunSystem : IEcsInitSystem, IEcsRunSystem
            {
                private EcsFilter _filter;
                private EcsPool<Component1> _components;

                public void Init(IEcsSystems systems)
                {
                    EcsWorld world = systems.GetWorld();

                    _filter = world.Filter<Component1>().End();
                    _components = world.GetPool<Component1>();
                }

                public void Run(IEcsSystems systems)
                {
                    int[] entities = _filter.GetRawEntities();
                    for (int i = 0, iMax = _filter.GetEntitiesCount(); i < iMax; i++)
                    {
                        ++_components.Get(entities[i]).Value;
                    }
                }
            }

            public IEcsSystems MonoThreadSystem { get; }

            public LeopotamEcsLiteContext(int entityCount, int entityPadding)
            {
                MonoThreadSystem = new EcsSystems(World).Add(new MonoThreadRunSystem());

                MonoThreadSystem.Init();

                EcsPool<Component1> c1 = World.GetPool<Component1>();
                EcsPool<Component2> c2 = World.GetPool<Component2>();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        // LeopotamEcsLite does not support empty entities
                        c2.Add(World.NewEntity());
                    }

                    int entity = World.NewEntity();
                    c1.Add(entity);
                }
            }
        }

        [Context]
        private readonly LeopotamEcsLiteContext _leopotamEcsLite;

        [BenchmarkCategory(Categories.LeopotamEcsLite)]
        [Benchmark]
        public void LeopotamEcsLite() => _leopotamEcsLite.MonoThreadSystem.Run();
    }
}

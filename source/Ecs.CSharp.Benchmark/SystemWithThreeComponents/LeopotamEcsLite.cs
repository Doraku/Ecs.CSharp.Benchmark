using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Leopotam.EcsLite;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithThreeComponents
    {
        private sealed class LeopotamEcsLiteContext : LeopotamEcsLiteBaseContext
        {
            private sealed class MonoThreadRunSystem : IEcsInitSystem, IEcsRunSystem
            {
                private EcsFilter _filter;
                private EcsPool<Component1> _c1;
                private EcsPool<Component2> _c2;
                private EcsPool<Component3> _c3;

                public void Init(IEcsSystems systems)
                {
                    EcsWorld world = systems.GetWorld();

                    _filter = world.Filter<Component1>().Inc<Component2>().Inc<Component3>().End();
                    _c1 = world.GetPool<Component1>();
                    _c2 = world.GetPool<Component2>();
                    _c3 = world.GetPool<Component3>();
                }

                public void Run(IEcsSystems systems)
                {
                    int[] entities = _filter.GetRawEntities();
                    for (int i = 0, iMax = _filter.GetEntitiesCount(); i < iMax; i++)
                    {
                        _c1.Get(entities[i]).Value += _c2.Get(entities[i]).Value + _c3.Get(entities[i]).Value;
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
                EcsPool<Component3> c3 = World.GetPool<Component3>();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        int padding = World.NewEntity();
                        switch (j % 3)
                        {
                            case 0:
                                c1.Add(padding);
                                break;

                            case 1:
                                c2.Add(padding);
                                break;

                            case 2:
                                c3.Add(padding);
                                break;
                        }
                    }

                    int entity = World.NewEntity();
                    c1.Add(entity);
                    c2.Add(entity) = new Component2 { Value = 1 };
                    c3.Add(entity) = new Component3 { Value = 1 };
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

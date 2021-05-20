using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Threads;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        private class LeopotamEcsLiteContext : LeopotamEcsLiteBaseContext
        {
            private sealed class MonoThreadRunSystem : IEcsInitSystem, IEcsRunSystem
            {
                private EcsFilter _filter;
                private EcsPool<Component1> _components;

                public void Init(EcsSystems systems)
                {
                    EcsWorld world = systems.GetWorld();

                    _filter = world.Filter<Component1>().End();
                    _components = world.GetPool<Component1>();
                }

                public void Run(EcsSystems systems)
                {
                    var entities = _filter.GetRawEntities();
                    for (int i = 0, iMax = _filter.GetEntitiesCount(); i < iMax; i++)
                    {
                        ++_components.Get(entities[i]).Value;
                    }
                }
            }

            private struct Thread : IEcsThread<Component1>
            {
                private int[] _entities;
                private EcsPool<Component1>.PoolItem[] _pool;

                public void Init(int[] entities, EcsPool<Component1>.PoolItem[] pool)
                {
                    _entities = entities;
                    _pool = pool;
                }

                public void Execute(int fromIndex, int beforeIndex)
                {
                    for (int i = fromIndex; i < beforeIndex; i++)
                    {
                        ++_pool[_entities[i]].Data.Value;
                    }
                }
            }

            private sealed class MultiThreadRunSystem : EcsThreadSystem<Thread, Component1>
            {
                protected override int GetChunkSize(EcsSystems systems) => 1000;

                protected override EcsWorld GetWorld(EcsSystems systems) => systems.GetWorld();

                protected override EcsFilter GetFilter(EcsWorld world) => world.Filter<Component1>().End();
            }

            public IEcsRunSystem MonoThreadSystem { get; }

            public IEcsRunSystem MultiThreadSystem { get; }

            public EcsSystems Systems { get; }

            public LeopotamEcsLiteContext(int entityCount, int entityPadding)
            {
                MonoThreadSystem = new MonoThreadRunSystem();
                MultiThreadSystem = new MultiThreadRunSystem();

                Systems = new EcsSystems(World)
                    .Add(MonoThreadSystem)
                    .Add(MultiThreadSystem);

                Systems.Init();

                EcsPool<Component1> c1 = World.GetPool<Component1>();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.NewEntity();
                    }

                    int entity = World.NewEntity();
                    c1.Add(entity);
                }
            }
        }

        private LeopotamEcsLiteContext _leopotamEcsLite;

        [BenchmarkCategory(Categories.LeopotamEcsLite)]
        [Benchmark]
        public void LeopotamEcsLite_MonoThread() => _leopotamEcsLite.MonoThreadSystem.Run(_leopotamEcsLite.Systems);

        [BenchmarkCategory(Categories.LeopotamEcsLite)]
        [Benchmark]
        public void LeopotamEcsLite_MultiThread() => _leopotamEcsLite.MultiThreadSystem.Run(_leopotamEcsLite.Systems);
    }
}

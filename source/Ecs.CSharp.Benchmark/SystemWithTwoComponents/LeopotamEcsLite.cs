using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Threads;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponents
    {
        private class LeopotamEcsLiteContext : LeopotamEcsLiteBaseContext
        {
            private sealed class MonoThreadRunSystem : IEcsInitSystem, IEcsRunSystem
            {
                private EcsFilter _filter;
                private EcsPool<Component1> _c1;
                private EcsPool<Component2> _c2;

                public void Init(EcsSystems systems)
                {
                    EcsWorld world = systems.GetWorld();

                    _filter = world.Filter<Component1>().Inc<Component2>().End();
                    _c1 = world.GetPool<Component1>();
                    _c2 = world.GetPool<Component2>();
                }

                public void Run(EcsSystems systems)
                {
                    var entities = _filter.GetRawEntities();
                    for (int i = 0, iMax = _filter.GetEntitiesCount(); i < iMax; i++)
                    {
                        _c1.Get(entities[i]).Value += _c2.Get(entities[i]).Value;
                    }
                }
            }

            private struct Thread : IEcsThread<Component1, Component2>
            {
                private int[] _entities;
                private EcsPool<Component1>.PoolItem[] _pool1;
                private EcsPool<Component2>.PoolItem[] _pool2;

                public void Init(int[] entities, EcsPool<Component1>.PoolItem[] pool1, EcsPool<Component2>.PoolItem[] pool2)
                {
                    _entities = entities;
                    _pool1 = pool1;
                    _pool2 = pool2;
                }

                public void Execute(int fromIndex, int beforeIndex)
                {
                    for (int i = fromIndex; i < beforeIndex; i++)
                    {
                        _pool1[_entities[i]].Data.Value += _pool2[_entities[i]].Data.Value;
                    }
                }
            }

            private sealed class MultiThreadRunSystem : EcsThreadSystem<Thread, Component1, Component2>
            {
                protected override int GetChunkSize(EcsSystems systems) => 1000;

                protected override EcsWorld GetWorld(EcsSystems systems) => systems.GetWorld();

                protected override EcsFilter GetFilter(EcsWorld world) => world.Filter<Component1>().Inc<Component2>().End();
            }

            public IEcsRunSystem MonoThreadSystem { get; }

            public IEcsRunSystem MultiThreadSystem { get; }

            public EcsSystems Systems { get; }

            public LeopotamEcsLiteContext(int entityCount)
            {
                MonoThreadSystem = new MonoThreadRunSystem();
                MultiThreadSystem = new MultiThreadRunSystem();

                Systems = new EcsSystems(World)
                    .Add(MonoThreadSystem)
                    .Add(MultiThreadSystem);

                Systems.Init();

                EcsPool<Component1> c1 = World.GetPool<Component1>();
                EcsPool<Component2> c2 = World.GetPool<Component2>();

                for (int i = 0; i < entityCount; ++i)
                {
                    int entity = World.NewEntity();
                    c1.Add(entity);
                    c2.Add(entity) = new Component2 { Value = 1 };
                }
            }
        }

        private LeopotamEcsLiteContext _leopotamEcsLite;

        [Benchmark]
        public void LeopotamEcsLite_MonoThread() => _leopotamEcsLite.MonoThreadSystem.Run(_leopotamEcsLite.Systems);

        [Benchmark]
        public void LeopotamEcsLite_MultiThread() => _leopotamEcsLite.MultiThreadSystem.Run(_leopotamEcsLite.Systems);
    }
}

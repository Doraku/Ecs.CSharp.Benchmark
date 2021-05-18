using System;
using BenchmarkDotNet.Attributes;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Threads;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        private class LeopotamEcsLiteContext : IDisposable
        {
            public struct Component
            {
                public int Value;
            }

            private sealed class MonoThreadRunSystem : IEcsInitSystem, IEcsRunSystem
            {
                private EcsFilter _filter;
                private EcsPool<Component> _components;

                public void Init(EcsSystems systems)
                {
                    EcsWorld world = systems.GetWorld();

                    _filter = world.Filter<Component>().End();
                    _components = world.GetPool<Component>();
                }

                public void Run(EcsSystems systems)
                {
                    foreach (int entity in _filter)
                    {
                        ++_components.Get(entity).Value;
                    }
                }
            }

            private struct Thread : IEcsThread<Component>
            {
                private int[] _entities;
                private EcsPool<Component>.PoolItem[] _pool;

                public void Init(int[] entities, EcsPool<Component>.PoolItem[] pool)
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

            private sealed class MultiThreadRunSystem : EcsThreadSystem<Thread, Component>
            {
                protected override int GetChunkSize(EcsSystems systems) => 1000;

                protected override EcsWorld GetWorld(EcsSystems systems) => systems.GetWorld();

                protected override EcsFilter GetFilter(EcsWorld world) => world.Filter<Component>().End();
            }

            public EcsWorld World { get; }

            public EcsPool<Component> Components { get; }

            public IEcsRunSystem MonoThreadSystem { get; }

            public IEcsRunSystem MultiThreadSystem { get; }

            public EcsSystems Systems { get; }

            public LeopotamEcsLiteContext(int entityCount)
            {
                World = new EcsWorld();
                Components = World.GetPool<Component>();
                MonoThreadSystem = new MonoThreadRunSystem();
                MultiThreadSystem = new MultiThreadRunSystem();

                Systems = new EcsSystems(World)
                    .Add(MonoThreadSystem)
                    .Add(MultiThreadSystem);

                Systems.Init();

                for (int i = 0; i < entityCount; ++i)
                {
                    int entity = World.NewEntity();
                    Components.Add(entity);
                }
            }

            public void Dispose()
            {
                World.Destroy();
            }
        }

        private LeopotamEcsLiteContext _leopotamEcsLite;

        [Benchmark]
        public void LeopotamEcsLite_MonoThread() => _leopotamEcsLite.MonoThreadSystem.Run(_leopotamEcsLite.Systems);

        [Benchmark]
        public void LeopotamEcsLite_MultiThread() => _leopotamEcsLite.MultiThreadSystem.Run(_leopotamEcsLite.Systems);
    }
}

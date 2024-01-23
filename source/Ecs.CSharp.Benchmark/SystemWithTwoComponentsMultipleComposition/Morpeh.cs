﻿using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Scellecs.Morpeh;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        private sealed class MorpehContext : MorpehBaseContext
        {
            private record struct Padding1() : IComponent;

            private record struct Padding2() : IComponent;

            private record struct Padding3() : IComponent;

            private record struct Padding4() : IComponent;

            private sealed class DirectSystem : ISystem
            {
                public World World { get; set; }
                private Filter _filter;

                public void OnAwake()
                {
                    _filter = World.Filter.With<Component1>().With<Component2>();
                }

                public void OnUpdate(float deltaTime)
                {
                    foreach (Entity entity in _filter)
                    {
                        entity.GetComponent<Component1>().Value += entity.GetComponent<Component2>().Value;
                    }
                }

                void IDisposable.Dispose() { }
            }

            private sealed class StashSystem : ISystem
            {
                public World World { get; set; }
                private Stash<Component1> _stash1;
                private Stash<Component2> _stash2;
                private Filter _filter;

                public void OnAwake()
                {
                    _stash1 = World.GetStash<Component1>();
                    _stash2 = World.GetStash<Component2>();
                    _filter = World.Filter.With<Component1>().With<Component2>();
                }

                public void OnUpdate(float deltaTime)
                {
                    foreach (Entity entity in _filter)
                    {
                        _stash1.Get(entity).Value += _stash2.Get(entity).Value;
                    }
                }

                public void Dispose()
                {
                    _stash1.Dispose();
                    _stash2.Dispose();
                }
            }

            public ISystem MonoThreadDirectSystem { get; }
            public ISystem MonoThreadStashSystem { get; }

            public MorpehContext(int entityCount)
            {
                MonoThreadDirectSystem = new DirectSystem { World = World };
                MonoThreadDirectSystem.OnAwake();

                MonoThreadStashSystem = new StashSystem { World = World };
                MonoThreadStashSystem.OnAwake();

                for (int i = 0; i < entityCount; ++i)
                {
                    Entity entity = World.CreateEntity();
                    entity.AddComponent<Component1>();
                    entity.SetComponent(new Component2 { Value = 1 });

                    switch (i % 4)
                    {
                        case 0:
                            entity.AddComponent<Padding1>();
                            break;

                        case 1:
                            entity.AddComponent<Padding2>();
                            break;

                        case 2:
                            entity.AddComponent<Padding3>();
                            break;

                        case 3:
                            entity.AddComponent<Padding4>();
                            break;
                    }
                }

                World.Commit();
            }
        }

        [Context]
        private readonly MorpehContext _context;

        [BenchmarkCategory(Categories.Morpeh)]
        [Benchmark]
        public void Morpeh_Direct() => _context.MonoThreadDirectSystem.OnUpdate(0f);

        [BenchmarkCategory(Categories.Morpeh)]
        [Benchmark]
        public void Morpeh_Stash() => _context.MonoThreadStashSystem.OnUpdate(0f);
    }
}

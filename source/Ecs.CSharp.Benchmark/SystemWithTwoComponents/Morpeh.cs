using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Scellecs.Morpeh;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponents
    {
        private sealed class MorpehContext : MorpehBaseContext
        {
            private sealed class DirectSystem : ISystem
            {
                public World World { get; set; }
                private Filter _filter;

                public void OnAwake()
                {
                    _filter = World.Filter.With<Component1>().With<Component2>().Build();
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
                    _filter = World.Filter.With<Component1>().With<Component2>().Build();
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

            public MorpehContext(int entityCount, int entityPadding)
            {
                MonoThreadDirectSystem = new DirectSystem { World = World };
                MonoThreadDirectSystem.OnAwake();

                MonoThreadStashSystem = new StashSystem { World = World };
                MonoThreadStashSystem.OnAwake();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        Entity padding = World.CreateEntity();
                        switch (j % 2)
                        {
                            case 0:
                                padding.AddComponent<Component1>();
                                break;

                            case 1:
                                padding.AddComponent<Component2>();
                                break;
                        }
                    }

                    Entity entity = World.CreateEntity();
                    entity.AddComponent<Component1>();
                    entity.SetComponent(new Component2 { Value = 1 });
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

using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Ecs.CSharp.Benchmark.Context;

namespace Ecs.CSharp.Benchmark
{
    [BenchmarkCategory(Categories.System)]
    [MemoryDiagnoser]
#if CHECK_CACHE_MISSES
    [HardwareCounters(HardwareCounter.CacheMisses)]
#endif
    public partial class SystemWithTwoComponents
    {
        private partial class DefaultEcsContext : DefaultEcsBaseContext
        {
            private sealed partial class EntitySetSystem : AEntitySetSystem<int>
            {
                [Update]
                private static void Update(ref Component1 c1, in Component2 c2)
                {
                    c1.Value += c2.Value;
                }
            }

            public IParallelRunner Runner { get; }

            public ISystem<int> MonoThreadEntitySetSystem { get; }

            public ISystem<int> MultiThreadEntitySetSystem { get; }

            public DefaultEcsContext(int entityCount, int entityPadding)
            {
                Runner = new DefaultParallelRunner(Environment.ProcessorCount);
                MonoThreadEntitySetSystem = new EntitySetSystem(World);
                MultiThreadEntitySetSystem = new EntitySetSystem(World, Runner);

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        Entity padding = World.CreateEntity();
                        switch (j % 2)
                        {
                            case 0:
                                padding.Set<Component1>();
                                break;

                            case 1:
                                padding.Set<Component2>();
                                break;
                        }
                    }

                    Entity entity = World.CreateEntity();
                    entity.Set<Component1>();
                    entity.Set(new Component2 { Value = 1 });
                }
            }

            public override void Dispose()
            {
                base.Dispose();

                Runner.Dispose();
            }
        }

        [Params(100000)]
        public int EntityCount { get; set; }

        [Params(0, 10)]
        public int EntityPadding { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _defaultEcs = new(EntityCount, EntityPadding);
            _entitas = new(EntityCount, EntityPadding);
            _leopotamEcs = new(EntityCount, EntityPadding);
            _leopotamEcsLite = new(EntityCount, EntityPadding);
            _monoGameExtended = new(EntityCount, EntityPadding);
            _sveltoECS = new(EntityCount, EntityPadding);
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _defaultEcs.Dispose();
            _entitas.Dispose();
            _leopotamEcs.Dispose();
            _leopotamEcsLite.Dispose();
            _monoGameExtended.Dispose();
            _sveltoECS.Dispose();
        }

        private DefaultEcsContext _defaultEcs;

        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark(Baseline = true)]
        public void DefaultEcs_MonoThread() => _defaultEcs.MonoThreadEntitySetSystem.Update(0);

        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark]
        public void DefaultEcs_MultiThread() => _defaultEcs.MultiThreadEntitySetSystem.Update(0);
    }
}

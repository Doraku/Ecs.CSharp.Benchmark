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
    [HardwareCounters(HardwareCounter.CacheMisses)]
    public partial class SystemWithOneComponent
    {
        private partial class DefaultEcsContext : DefaultEcsBaseContext
        {
            private sealed class ComponentSystem : AComponentSystem<int, Component1>
            {
                public ComponentSystem(World world, IParallelRunner runner)
                    : base(world, runner)
                { }

                public ComponentSystem(World world)
                    : base(world)
                { }

                protected override void Update(int state, Span<Component1> components)
                {
                    foreach (ref Component1 component in components)
                    {
                        ++component.Value;
                    }
                }
            }

            private sealed partial class EntitySetSystem : AEntitySetSystem<int>
            {
                [Update]
                private static void Update(ref Component1 component)
                {
                    ++component.Value;
                }
            }

            public IParallelRunner Runner { get; }

            public ISystem<int> MonoThreadComponentSystem { get; }

            public ISystem<int> MultiThreadComponentSystem { get; }

            public ISystem<int> MonoThreadEntitySetSystem { get; }

            public ISystem<int> MultiThreadEntitySetSystem { get; }

            public DefaultEcsContext(int entityCount, int entityPadding)
            {
                Runner = new DefaultParallelRunner(Environment.ProcessorCount);
                MonoThreadComponentSystem = new ComponentSystem(World);
                MultiThreadComponentSystem = new ComponentSystem(World, Runner);
                MonoThreadEntitySetSystem = new EntitySetSystem(World);
                MultiThreadEntitySetSystem = new EntitySetSystem(World, Runner);

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.CreateEntity();
                    }

                    Entity entity = World.CreateEntity();
                    entity.Set<Component1>();
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
        public void DefaultEcs_ComponentSystem_MonoThread() => _defaultEcs.MonoThreadComponentSystem.Update(0);

        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark]
        public void DefaultEcs_ComponentSystem_MultiThread() => _defaultEcs.MultiThreadComponentSystem.Update(0);

        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark]
        public void DefaultEcs_EntitySetSystem_MonoThread() => _defaultEcs.MonoThreadEntitySetSystem.Update(0);

        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark]
        public void DefaultEcs_EntitySetSystem_MultiThread() => _defaultEcs.MultiThreadEntitySetSystem.Update(0);
    }
}

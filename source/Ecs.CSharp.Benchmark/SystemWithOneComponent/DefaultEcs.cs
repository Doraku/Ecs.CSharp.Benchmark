using System;
using BenchmarkDotNet.Attributes;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Ecs.CSharp.Benchmark.Context;

namespace Ecs.CSharp.Benchmark
{
    [MemoryDiagnoser]
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

                protected override void Update(int state, ref Component1 component)
                {
                    ++component.Value;
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

            public DefaultEcsContext(int entityCount)
            {
                Runner = new DefaultParallelRunner(Environment.ProcessorCount);
                MonoThreadComponentSystem = new ComponentSystem(World);
                MultiThreadComponentSystem = new ComponentSystem(World, Runner);
                MonoThreadEntitySetSystem = new EntitySetSystem(World);
                MultiThreadEntitySetSystem = new EntitySetSystem(World, Runner);

                for (int i = 0; i < entityCount; ++i)
                {
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

        [IterationSetup]
        public void Setup()
        {
            _defaultEcs = new(EntityCount);
            _entitas = new(EntityCount);
            _leopotamEcs = new(EntityCount);
            _leopotamEcsLite = new(EntityCount);
            _monoGameExtended = new(EntityCount);
            _sveltoECS = new(EntityCount);
        }

        [IterationCleanup]
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

        [Benchmark(Baseline = true)]
        public void DefaultEcs_ComponentSystem_MonoThread() => _defaultEcs.MonoThreadComponentSystem.Update(0);

        [Benchmark]
        public void DefaultEcs_ComponentSystem_MultiThread() => _defaultEcs.MultiThreadComponentSystem.Update(0);

        [Benchmark]
        public void DefaultEcs_EntitySetSystem_MonoThread() => _defaultEcs.MonoThreadEntitySetSystem.Update(0);

        [Benchmark]
        public void DefaultEcs_EntitySetSystem_MultiThread() => _defaultEcs.MultiThreadEntitySetSystem.Update(0);
    }
}

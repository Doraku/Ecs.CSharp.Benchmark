using System;
using BenchmarkDotNet.Attributes;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        private partial class DefaultEcsContext : IDisposable
        {
            private struct Component
            {
                public int Value;
            }

            private sealed class ComponentSystem : AComponentSystem<int, Component>
            {
                public ComponentSystem(World world, IParallelRunner runner)
                    : base(world, runner)
                { }

                public ComponentSystem(World world)
                    : base(world)
                { }

                protected override void Update(int state, ref Component component)
                {
                    ++component.Value;
                }
            }

            private sealed partial class EntitySetSystem : AEntitySetSystem<int>
            {
                [Update]
                private static void Update(ref Component component)
                {
                    ++component.Value;
                }
            }

            public IParallelRunner Runner { get; }

            public World World { get; }

            public ISystem<int> MonoThreadComponentSystem { get; }

            public ISystem<int> MultiThreadComponentSystem { get; }

            public ISystem<int> MonoThreadEntitySetSystem { get; }

            public ISystem<int> MultiThreadEntitySetSystem { get; }

            public DefaultEcsContext(int entityCount)
            {
                Runner = new DefaultParallelRunner(Environment.ProcessorCount);
                World = new World();
                MonoThreadComponentSystem = new ComponentSystem(World);
                MultiThreadComponentSystem = new ComponentSystem(World, Runner);
                MonoThreadEntitySetSystem = new EntitySetSystem(World);
                MultiThreadEntitySetSystem = new EntitySetSystem(World, Runner);

                for (int i = 0; i < entityCount; ++i)
                {
                    Entity entity = World.CreateEntity();
                    entity.Set<Component>();
                }
            }

            public void Dispose()
            {
                World.Dispose();
                Runner.Dispose();
            }
        }

        private DefaultEcsContext _defaultEcs;

        [Benchmark]
        public void DefaultEcs_ComponentSystem_MonoThread() => _defaultEcs.MonoThreadComponentSystem.Update(0);

        [Benchmark]
        public void DefaultEcs_ComponentSystem_MultiThread() => _defaultEcs.MultiThreadComponentSystem.Update(0);

        [Benchmark]
        public void DefaultEcs_EntitySetSystem_MonoThread() => _defaultEcs.MonoThreadEntitySetSystem.Update(0);

        [Benchmark]
        public void DefaultEcs_EntitySetSystem_MultiThread() => _defaultEcs.MultiThreadEntitySetSystem.Update(0);
    }
}

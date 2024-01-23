using System;
using BenchmarkDotNet.Attributes;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Ecs.CSharp.Benchmark.Contexts;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        private sealed partial class DefaultEcsContext : DefaultEcsBaseContext
        {
            private record struct Padding1();

            private record struct Padding2();

            private record struct Padding3();

            private record struct Padding4();

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

            public DefaultEcsContext(int entityCount)
            {
                Runner = new DefaultParallelRunner(Environment.ProcessorCount);
                MonoThreadEntitySetSystem = new EntitySetSystem(World);
                MultiThreadEntitySetSystem = new EntitySetSystem(World, Runner);

                for (int i = 0; i < entityCount; ++i)
                {
                    Entity entity = World.CreateEntity();
                    entity.Set<Component1>();
                    entity.Set(new Component2 { Value = 1 });

                    switch (i % 4)
                    {
                        case 0:
                            entity.Set<Padding1>();
                            break;

                        case 1:
                            entity.Set<Padding2>();
                            break;

                        case 2:
                            entity.Set<Padding3>();
                            break;

                        case 3:
                            entity.Set<Padding4>();
                            break;
                    }
                }
            }

            public override void Dispose()
            {
                base.Dispose();

                Runner.Dispose();
            }
        }

        [Context]
        private readonly DefaultEcsContext _defaultEcs;

        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark]
        public void DefaultEcs_MonoThread() => _defaultEcs.MonoThreadEntitySetSystem.Update(0);

        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark]
        public void DefaultEcs_MultiThread() => _defaultEcs.MultiThreadEntitySetSystem.Update(0);
    }
}

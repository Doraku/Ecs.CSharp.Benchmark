using System;
using BenchmarkDotNet.Attributes;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Ecs.CSharp.Benchmark.Contexts;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithThreeComponents
    {
        private sealed partial class DefaultEcsContext : DefaultEcsBaseContext
        {
            private sealed partial class EntitySetSystem : AEntitySetSystem<int>
            {
                [Update]
                private static void Update(ref Component1 c1, in Component2 c2, in Component3 c3)
                {
                    c1.Value += c2.Value + c3.Value;
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
                        switch (j % 3)
                        {
                            case 0:
                                padding.Set<Component1>();
                                break;

                            case 1:
                                padding.Set<Component2>();
                                break;

                            case 2:
                                padding.Set<Component3>();
                                break;
                        }
                    }

                    Entity entity = World.CreateEntity();
                    entity.Set<Component1>();
                    entity.Set(new Component2 { Value = 1 });
                    entity.Set(new Component3 { Value = 1 });
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

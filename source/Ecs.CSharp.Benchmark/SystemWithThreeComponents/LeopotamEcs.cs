using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Leopotam.Ecs;
using Leopotam.Ecs.Threads;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithThreeComponents
    {
        private class LeopotamEcsContext : LeopotamEcsBaseContext
        {
            private sealed class MonoThreadRunSystem : IEcsRunSystem
            {
                private readonly EcsFilter<Component1, Component2, Component3> _filter = null;

                public void Run()
                {
                    for (int i = 0, iMax = _filter.GetEntitiesCount(); i < iMax; i++)
                    {
                        _filter.Get1(i).Value += _filter.Get2(i).Value + _filter.Get3(i).Value;
                    }
                }
            }

            private sealed class MultiThreadRunSystem : EcsMultiThreadSystem<EcsFilter<Component1, Component2, Component3>>
            {
                private readonly EcsFilter<Component1, Component2, Component3> _filter = null;

                protected override EcsFilter<Component1, Component2, Component3> GetFilter() => _filter;

                protected override int GetMinJobSize() => 0;

                protected override int GetThreadsCount() => Environment.ProcessorCount - 1;

                protected override EcsMultiThreadWorker GetWorker() => Worker;

                private static void Worker(EcsMultiThreadWorkerDesc workerDesc)
                {
                    foreach (var i in workerDesc)
                    {
                        workerDesc.Filter.Get1(i).Value += workerDesc.Filter.Get2(i).Value + workerDesc.Filter.Get3(i).Value;
                    }
                }
            }

            public IEcsRunSystem MonoThreadSystem { get; }

            public IEcsRunSystem MultiThreadSystem { get; }

            public LeopotamEcsContext(int entityCount, int entityPadding)
            {
                MonoThreadSystem = new MonoThreadRunSystem();
                MultiThreadSystem = new MultiThreadRunSystem();

                new EcsSystems(World)
                    .Add(MonoThreadSystem)
                    .Add(MultiThreadSystem)
                    .ProcessInjects()
                    .Init();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        EcsEntity padding = World.NewEntity();
                        switch (j % 3)
                        {
                            case 0:
                                padding.Replace(new Component1());
                                break;

                            case 1:
                                padding.Replace(new Component2());
                                break;

                            case 2:
                                padding.Replace(new Component3());
                                break;
                        }
                    }

                    World.NewEntity()
                        .Replace(new Component1())
                        .Replace(new Component2 { Value = 1 })
                        .Replace(new Component3 { Value = 1 });
                }
            }
        }

        private LeopotamEcsContext _leopotamEcs;

        [BenchmarkCategory(Categories.LeopotamEcs)]
        [Benchmark]
        public void LeopotamEcs_MonoThread() => _leopotamEcs.MonoThreadSystem.Run();

        [BenchmarkCategory(Categories.LeopotamEcs)]
        [Benchmark]
        public void LeopotamEcs_MultiThread() => _leopotamEcs.MultiThreadSystem.Run();
    }
}

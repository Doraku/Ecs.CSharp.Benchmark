using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Leopotam.Ecs;
using Leopotam.Ecs.Threads;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponents
    {
        private class LeopotamEcsContext : LeopotamEcsBaseContext
        {
            private sealed class MonoThreadRunSystem : IEcsRunSystem
            {
                private readonly EcsFilter<Component1, Component2> _filter = null;

                public void Run()
                {
                    for (int i = 0, iMax = _filter.GetEntitiesCount(); i < iMax; i++)
                    {
                        _filter.Get1(i).Value += _filter.Get2(i).Value;
                    }
                }
            }

            private sealed class MultiThreadRunSystem : EcsMultiThreadSystem<EcsFilter<Component1, Component2>>
            {
                private readonly EcsFilter<Component1, Component2> _filter = null;

                protected override EcsFilter<Component1, Component2> GetFilter() => _filter;

                protected override int GetMinJobSize() => 0;

                protected override int GetThreadsCount() => Environment.ProcessorCount - 1;

                protected override EcsMultiThreadWorker GetWorker() => Worker;

                private static void Worker(EcsMultiThreadWorkerDesc workerDesc)
                {
                    foreach (var i in workerDesc)
                    {
                        workerDesc.Filter.Get1(i).Value += workerDesc.Filter.Get2(i).Value;
                    }
                }
            }

            public EcsSystems MonoThreadSystem { get; }

            public EcsSystems MultiThreadSystem { get; }

            public LeopotamEcsContext(int entityCount, int entityPadding)
            {
                MonoThreadSystem = new EcsSystems(World).Add(new MonoThreadRunSystem()).ProcessInjects();
                MultiThreadSystem = new EcsSystems(World).Add(new MultiThreadRunSystem()).ProcessInjects();

                MonoThreadSystem.Init();
                MultiThreadSystem.Init();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        EcsEntity padding = World.NewEntity();
                        switch (j % 2)
                        {
                            case 0:
                                padding.Replace(new Component1());
                                break;

                            case 1:
                                padding.Replace(new Component2());
                                break;
                        }
                    }

                    World.NewEntity()
                        .Replace(new Component1())
                        .Replace(new Component2 { Value = 1 });
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

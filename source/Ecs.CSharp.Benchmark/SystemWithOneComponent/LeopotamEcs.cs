using System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Leopotam.Ecs;
using Leopotam.Ecs.Threads;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        private class LeopotamEcsContext : LeopotamEcsBaseContext
        {
            private sealed class MonoThreadRunSystem : IEcsRunSystem
            {
                private readonly EcsFilter<Component1> _filter = null;

                public void Run()
                {
                    for (int i = 0, iMax = _filter.GetEntitiesCount(); i < iMax; i++)
                    {
                        ++_filter.Get1(i).Value;
                    }
                }
            }

            private sealed class MultiThreadRunSystem : EcsMultiThreadSystem<EcsFilter<Component1>>
            {
                private readonly EcsFilter<Component1> _filter = null;

                protected override EcsFilter<Component1> GetFilter() => _filter;

                protected override int GetMinJobSize() => 0;

                protected override int GetThreadsCount() => Environment.ProcessorCount - 1;

                protected override EcsMultiThreadWorker GetWorker() => Worker;

                private static void Worker(EcsMultiThreadWorkerDesc workerDesc)
                {
                    foreach (var i in workerDesc)
                    {
                        ++workerDesc.Filter.Get1(i).Value;
                    }
                }
            }

            public IEcsRunSystem MonoThreadSystem { get; }

            public IEcsRunSystem MultiThreadSystem { get; }

            public LeopotamEcsContext(int entityCount)
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
                    World.NewEntity()
                        .Replace(new Component1());
                }
            }
        }

        private LeopotamEcsContext _leopotamEcs;

        [Benchmark]
        public void LeopotamEcs_MonoThread() => _leopotamEcs.MonoThreadSystem.Run();

        [Benchmark]
        public void LeopotamEcs_MultiThread() => _leopotamEcs.MultiThreadSystem.Run();
    }
}

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using DefaultEcs;
using Ecs.CSharp.Benchmark.Context;

namespace Ecs.CSharp.Benchmark
{
    [BenchmarkCategory(Categories.CreateEntity)]
    [MemoryDiagnoser]
#if CHECK_CACHE_MISSES
    [HardwareCounters(HardwareCounter.CacheMisses)]
#endif
    public partial class CreateEntityWithThreeComponents
    {
        [Params(100000)]
        public int EntityCount { get; set; }

        [IterationSetup]
        public void Setup()
        {
            _arch = new();
            _defaultEcs = new();
            _entitas = new();
            _leopotamEcs = new();
            _leopotamEcsLite = new();
            _monoGameExtended = new();
            _relEcs = new();
            _sveltoECS = new();
        }

        [IterationCleanup]
        public void Cleanup()
        {
            _arch.Dispose();
            _defaultEcs.Dispose();
            _entitas.Dispose();
            _leopotamEcs.Dispose();
            _leopotamEcsLite.Dispose();
            _monoGameExtended.Dispose();
            _sveltoECS.Dispose();
        }

        private DefaultEcsBaseContext _defaultEcs;

        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark(Baseline = true)]
        public void DefaultEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = _defaultEcs.World.CreateEntity();
                entity.Set<DefaultEcsBaseContext.Component1>();
                entity.Set<DefaultEcsBaseContext.Component2>();
                entity.Set<DefaultEcsBaseContext.Component3>();
            }
        }
    }
}

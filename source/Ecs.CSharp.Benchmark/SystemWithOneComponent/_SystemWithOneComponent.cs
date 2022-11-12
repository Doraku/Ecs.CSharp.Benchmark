using BenchmarkDotNet.Attributes;

namespace Ecs.CSharp.Benchmark
{
    [BenchmarkCategory(Categories.System)]
    [MemoryDiagnoser]
#if CHECK_CACHE_MISSES
    [HardwareCounters(BenchmarkDotNet.Diagnosers.HardwareCounter.CacheMisses)]
#endif
    public partial class SystemWithOneComponent
    {
        [Params(100000)]
        public int EntityCount { get; set; }

        [Params(0, 10)]
        public int EntityPadding { get; set; }

        [GlobalSetup]
        public void Setup() => BenchmarkOperations.SetupContexts(this, EntityCount, EntityPadding);

        [GlobalCleanup]
        public void Cleanup() => BenchmarkOperations.CleanupContexts(this);
    }
}

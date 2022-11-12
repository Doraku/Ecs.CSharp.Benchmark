using BenchmarkDotNet.Attributes;

namespace Ecs.CSharp.Benchmark
{
    [BenchmarkCategory(Categories.System)]
    [MemoryDiagnoser]
#if CHECK_CACHE_MISSES
    [HardwareCounters(BenchmarkDotNet.Diagnosers.HardwareCounter.CacheMisses)]
#endif
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        [Params(100000)]
        public int EntityCount { get; set; }

        [GlobalSetup]
        public void Setup() => BenchmarkOperations.SetupContexts(this, EntityCount);

        [GlobalCleanup]
        public void Cleanup() => BenchmarkOperations.CleanupContexts(this);
    }
}

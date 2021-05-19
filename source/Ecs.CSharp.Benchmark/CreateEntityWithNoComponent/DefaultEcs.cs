using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;

namespace Ecs.CSharp.Benchmark
{
    [MemoryDiagnoser]
    public partial class CreateEntityWithNoComponent
    {
        [Params(100000)]
        public int EntityCount { get; set; }

        [IterationSetup]
        public void Setup()
        {
            _defaultEcs = new();
            _entitas = new();
            _leopotamEcs = new();
            _leopotamEcsLite = new();
            _monoGameExtended = new();
            _sveltoECS = new();
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

        private DefaultEcsBaseContext _defaultEcs;

        [Benchmark(Baseline = true)]
        public void DefaultEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _defaultEcs.World.CreateEntity();
            }
        }
    }
}

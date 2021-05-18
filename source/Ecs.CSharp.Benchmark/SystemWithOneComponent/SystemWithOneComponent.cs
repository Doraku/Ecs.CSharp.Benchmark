using BenchmarkDotNet.Attributes;

namespace Ecs.CSharp.Benchmark
{
    [MemoryDiagnoser]
    public partial class SystemWithOneComponent
    {
        [Params(100000)]
        public int EntityCount { get; set; }

        [IterationSetup]
        public void Setup()
        {
            _defaultEcs = new DefaultEcsContext(EntityCount);
            _entitas = new EntitasContext(EntityCount);
            _monoGameExtended = new MonoGameExtendedContext(EntityCount);
            _leopotamEcs = new LeopotamEcsContext(EntityCount);
            _sveltoECS = new SveltoECSContext(EntityCount);
            _leopotamEcsLite = new LeopotamEcsLiteContext(EntityCount);
        }

        [IterationCleanup]
        public void Cleanup()
        {
            _defaultEcs.Dispose();
            _entitas.Dispose();
            _monoGameExtended.Dispose();
            _leopotamEcs.Dispose();
            _sveltoECS.Dispose();
            _leopotamEcsLite.Dispose();
        }
    }
}

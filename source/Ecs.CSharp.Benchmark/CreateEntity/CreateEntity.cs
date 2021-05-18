using BenchmarkDotNet.Attributes;

namespace Ecs.CSharp.Benchmark
{
    [MemoryDiagnoser]
    public partial class CreateEntity
    {
        [Params(100000)]
        public int EntityCount { get; set; }

        [IterationSetup]
        public void Setup()
        {
            _defaultEcs = new DefaultEcsContext();
            _entitas = new EntitasContext();
            _monoGameExtended = new MonoGameExtendedContext();
            _leopotamEcs = new LeopotamEcsContext();
            _sveltoECS = new SveltoECSContext();
        }

        [IterationCleanup]
        public void Cleanup()
        {
            _defaultEcs.Dispose();
            _entitas.Dispose();
            _monoGameExtended.Dispose();
            _leopotamEcs.Dispose();
            _sveltoECS.Dispose();
        }
    }
}

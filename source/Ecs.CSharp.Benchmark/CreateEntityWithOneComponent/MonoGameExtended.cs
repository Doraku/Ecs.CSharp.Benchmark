using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithOneComponent
    {
        private MonoGameExtendedBaseContext _monoGameExtended;

        [Benchmark]
        public void MonoGameExtended()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _monoGameExtended.World.CreateEntity().Attach(new MonoGameExtendedBaseContext.Component1());
            }
        }
    }
}

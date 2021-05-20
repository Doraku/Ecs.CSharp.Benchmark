using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithNoComponent
    {
        private EntitasBaseContext _entitas;

        [BenchmarkCategory(Categories.Entitas)]
        [Benchmark]
        public void Entitas()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _entitas.Context.CreateEntity();
            }
        }
    }
}

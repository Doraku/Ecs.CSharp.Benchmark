using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Entitas;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithTwoComponents
    {
        private EntitasBaseContext _entitas;

        [BenchmarkCategory(Categories.Entitas)]
        [Benchmark]
        public void Entitas()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = _entitas.Context.CreateEntity();
                entity.AddComponent(0, new EntitasBaseContext.Component1());
                entity.AddComponent(1, new EntitasBaseContext.Component2());
            }
        }
    }
}

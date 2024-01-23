using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Leopotam.EcsLite;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithOneComponent
    {
        [Context]
        private readonly LeopotamEcsLiteBaseContext _leopotamEcsLite;

        [BenchmarkCategory(Categories.LeopotamEcsLite)]
        [Benchmark]
        public void LeopotamEcsLite()
        {
            EcsPool<LeopotamEcsLiteBaseContext.Component1> c1 = _leopotamEcsLite.World.GetPool<LeopotamEcsLiteBaseContext.Component1>();

            for (int i = 0; i < EntityCount; ++i)
            {
                c1.Add(_leopotamEcsLite.World.NewEntity());
            }
        }
    }
}

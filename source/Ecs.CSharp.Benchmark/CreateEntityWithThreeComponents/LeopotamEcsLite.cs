using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Leopotam.EcsLite;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithThreeComponents
    {
        [Context]
        private readonly LeopotamEcsLiteBaseContext _leopotamEcsLite;

        [BenchmarkCategory(Categories.LeopotamEcsLite)]
        [Benchmark]
        public void LeopotamEcsLite()
        {
            EcsPool<LeopotamEcsLiteBaseContext.Component1> c1 = _leopotamEcsLite.World.GetPool<LeopotamEcsLiteBaseContext.Component1>();
            EcsPool<LeopotamEcsLiteBaseContext.Component2> c2 = _leopotamEcsLite.World.GetPool<LeopotamEcsLiteBaseContext.Component2>();
            EcsPool<LeopotamEcsLiteBaseContext.Component3> c3 = _leopotamEcsLite.World.GetPool<LeopotamEcsLiteBaseContext.Component3>();

            for (int i = 0; i < EntityCount; ++i)
            {
                int entity = _leopotamEcsLite.World.NewEntity();
                c1.Add(entity);
                c2.Add(entity);
                c3.Add(entity);
            }
        }
    }
}

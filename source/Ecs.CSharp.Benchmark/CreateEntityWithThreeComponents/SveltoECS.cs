using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Svelto.ECS;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithThreeComponents
    {
        private sealed class SveltoEntity : GenericEntityDescriptor<SveltoECSBaseContext.Component1, SveltoECSBaseContext.Component2, SveltoECSBaseContext.Component3>
        { }

        [Context]
        private readonly SveltoECSBaseContext _sveltoECS;

        [Benchmark]
        public void SveltoECS()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _sveltoECS.Factory.BuildEntity<SveltoEntity>((uint)i, SveltoECSBaseContext.Group);
            }

            _sveltoECS.Scheduler.SubmitEntities();
        }
    }
}

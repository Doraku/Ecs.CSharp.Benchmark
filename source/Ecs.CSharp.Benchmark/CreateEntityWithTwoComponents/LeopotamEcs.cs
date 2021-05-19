using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Leopotam.Ecs;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithTwoComponents
    {
        private LeopotamEcsBaseContext _leopotamEcs;

        [Benchmark]
        public void LeopotamEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _leopotamEcs.World.NewEntity()
                    .Replace(new LeopotamEcsBaseContext.Component1())
                    .Replace(new LeopotamEcsBaseContext.Component2());
            }
        }
    }
}

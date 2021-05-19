using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithNoComponent
    {
        private LeopotamEcsBaseContext _leopotamEcs;

        [Benchmark]
        public void LeopotamEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _leopotamEcs.World.NewEntity();
            }
        }
    }
}

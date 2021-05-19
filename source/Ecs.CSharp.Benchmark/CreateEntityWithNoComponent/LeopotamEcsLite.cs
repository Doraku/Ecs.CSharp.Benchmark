using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithNoComponent
    {
        private LeopotamEcsLiteBaseContext _leopotamEcsLite;

        [Benchmark]
        public void LeopotamEcsLite()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _leopotamEcsLite.World.NewEntity();
            }
        }
    }
}

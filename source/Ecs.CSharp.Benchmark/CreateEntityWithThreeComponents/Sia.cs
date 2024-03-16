using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Sia;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithThreeComponents
    {
        [Context]
        private readonly SiaBaseContext _sia;

        [BenchmarkCategory(Categories.Sia)]
        [Benchmark]
        public void Sia()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _sia.World.CreateInArrayHost(Bundle.Create(
                    new SiaBaseContext.Component1(),
                    new SiaBaseContext.Component2(),
                    new SiaBaseContext.Component3()
                ));
            }
        }
    }
}

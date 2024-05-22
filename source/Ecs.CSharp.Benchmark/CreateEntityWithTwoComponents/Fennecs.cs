using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.Fennecs_Components;
using fennecs;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithTwoComponents
    {
        [Context] private readonly FennecsBaseContext _fennecs;
        
        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark(Description = "fennecs")]
        public void Fennecs()
        {
            World world = _fennecs.World;

            world.Entity()
                .Add(new Component1())
                .Add(new Component2())
                .Spawn(EntityCount);
        }
    }
}

using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.Fennecs_Components;
using fennecs;

// ReSharper disable once CheckNamespace
namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithThreeComponents
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
                .Add(new Component3())
                .Spawn(EntityCount);
        }
    }
}

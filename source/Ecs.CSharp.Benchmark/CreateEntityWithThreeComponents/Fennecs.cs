using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.Fennecs_Components;
using fennecs;

// ReSharper disable once CheckNamespace
namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithThreeComponents
    {
        [Context]
        private readonly FennecsBaseContext _fennecs;

        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs()
        {
            World world = _fennecs.World;

            for (int i = 0; i < EntityCount; ++i)
            {
                world.Spawn()
                    .Add<Component1>()
                    .Add<Component2>()
                    .Add<Component3>();
            }
        }
    }
}

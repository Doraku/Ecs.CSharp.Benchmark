using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using PewPew.Ecs.Core;
using PewPew.Ecs.Hybrid;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithThreeComponents
    {
        [BenchmarkCategory(Categories.PewPewEcs)]
        [Benchmark]
        public void PewPewEcs()
        {
            HybridWorld world = WorldFactory.Shared.CreateHybridWorld(c => c.MaxEntitiesCount = EntityCount);
            world.InitStaticArchetype<PPComponent1, PPComponent2, PPComponent3>();

            var archetype = world.GetStaticArchetype<PPComponent1, PPComponent2, PPComponent3>();

            for (int i = 0; i < EntityCount; ++i)
            {
                EntityId entityId = world.CreateEntityId();
                archetype.Create(entityId);
            }
        }
    }
}

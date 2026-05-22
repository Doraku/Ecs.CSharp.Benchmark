using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using PewPew.Ecs.Core;
using PewPew.Ecs.Hybrid;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithOneComponent
    {
        [BenchmarkCategory(Categories.PewPewEcs)]
        [Benchmark]
        public void PewPewEcs()
        {
            HybridWorld world = WorldFactory.Shared.CreateHybridWorld(c => c.MaxEntitiesCount = EntityCount);
            world.InitComponent<PPComponent1>();

            for (int i = 0; i < EntityCount; ++i)
            {
                EntityId entityId = world.CreateEntityId();
                world.AddComponent<PPComponent1>(entityId);
            }
        }
    }
}

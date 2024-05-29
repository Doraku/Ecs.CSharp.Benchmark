using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts.FrifloEngine_Components;
using Friflo.Engine.ECS;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithOneComponent
    {
        [BenchmarkCategory(Categories.FrifloEngineEcs)]
        [Benchmark]
        public void FrifloEngineEcs()
        {
            EntityStore store = new EntityStore(PidType.UsePidAsId);
            Archetype archetype = store.GetArchetype(ComponentTypes.Get<Component1>());
            // returns an enumerator of created entities
            archetype.CreateEntities(EntityCount);
        }
    }
}

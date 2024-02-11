using System;
using Ecs.CSharp.Benchmark.Contexts.FrifloEngine_Components;
using Friflo.Engine.ECS;

namespace Ecs.CSharp.Benchmark.Contexts
{
    namespace FrifloEngine_Components
    {
        internal struct Component1 : IComponent
        {
            public int Value;
        }

        internal struct Component2 : IComponent
        {
            public int Value;
        }

        internal struct Component3 : IComponent
        {
            public int Value;
        }
    }

    internal class FrifloEngineEcsBaseContext : IDisposable
    {
        protected EntityStore EntityStore { get; }
        public readonly ArchetypeQuery<Component1> queryOne;
        public readonly ArchetypeQuery<Component1, Component2> queryTwo;
        public readonly ArchetypeQuery<Component1, Component2, Component3> queryThree;
        
        public readonly QueryJob<Component1> jobOne;
        public readonly QueryJob<Component1, Component2> jobTwo;
        public readonly QueryJob<Component1, Component2, Component3> jobThree;
        public readonly QueryJob<Component1, Component2> jobTwoWithComposition;


        protected FrifloEngineEcsBaseContext()
        {
            ParallelJobRunner runner = new ParallelJobRunner(Environment.ProcessorCount);
            EntityStore = new EntityStore(PidType.UsePidAsId) { JobRunner = runner };
            queryOne    = EntityStore.Query<Component1>();
            queryTwo    = EntityStore.Query<Component1, Component2>();
            queryThree  = EntityStore.Query<Component1, Component2, Component3>();
            
            jobOne = queryOne.ForEach(SystemWithOneComponent.FrifloEngineEcsContext.ForEach);
            jobTwo = queryTwo.ForEach(SystemWithTwoComponents.FrifloEngineEcsContext.ForEach);
            jobThree = queryThree.ForEach(SystemWithThreeComponents.FrifloEngineEcsContext.ForEach);
            jobTwoWithComposition = queryTwo.ForEach(SystemWithTwoComponentsMultipleComposition.FrifloEngineEcsContext.ForEach);
        }

        /// <summary>See padding notes</summary>
        /// <param name="entityCount"></param>
        /// <param name="padding">
        /// has no influence on benchmarks performance for: SystemWith...Components
        /// e.g. Params[Params(0, 10)] at <see cref="SystemWithOneComponent.EntityPadding"/>
        /// </param>
        /// <param name="componentTypes"></param>
        protected FrifloEngineEcsBaseContext(int entityCount, int padding, ComponentTypes componentTypes) : this()
        {

            EntityStore.EnsureCapacity(entityCount + (padding * entityCount));

            Archetype archetype = EntityStore.GetArchetype(componentTypes);
            archetype.EnsureCapacity(entityCount);

            for (int index = 0; index < entityCount; index++)
            {
                for (int n = 0; n < padding; n++)
                {
                    EntityStore.CreateEntity();
                }
                archetype.CreateEntity();
            }
        }

        public virtual void Dispose()
        {
            EntityStore.JobRunner?.Dispose();
        }
    }
}

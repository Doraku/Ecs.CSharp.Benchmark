using System;
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
        public EntityStore EntityStore { get; }

        public FrifloEngineEcsBaseContext()
        {
            EntityStore = new EntityStore(PidType.UsePidAsId);
        }

        /// <summary>See padding notes</summary>
        /// <param name="entityCount"></param>
        /// <param name="padding">
        /// has no influence on benchmarks performance for: SystemWith...Components
        /// e.g. Params[Params(0, 10)] at <see cref="SystemWithOneComponent.EntityPadding"/>
        /// </param>
        /// <param name="componentTypes"></param>
        public FrifloEngineEcsBaseContext(int entityCount, int padding, ComponentTypes componentTypes)
        {
            EntityStore = new EntityStore(PidType.UsePidAsId);
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
        }
    }
}

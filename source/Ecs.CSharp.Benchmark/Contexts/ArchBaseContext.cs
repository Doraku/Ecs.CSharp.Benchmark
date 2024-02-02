using System;
using Arch.Core;
using Arch.Core.Utils;

namespace Ecs.CSharp.Benchmark.Contexts
{
    namespace Arch_Components
    {
        internal struct Component1
        {
            public int Value;
        }

        internal struct Component2
        {
            public int Value;
        }

        internal struct Component3
        {
            public int Value;
        }
    }

    internal class ArchBaseContext : IDisposable
    {
        public World World { get; }
        public JobScheduler.JobScheduler JobScheduler { get; set; }

        public ArchBaseContext()
        {
            World = World.Create();
        }

        public ArchBaseContext(ComponentType[] archetype, int amount)
        {
            JobScheduler = new JobScheduler.JobScheduler("Arch");
            World = World.Create();
            World.Reserve(archetype, amount);

            for (int index = 0; index < amount; index++)
            {
                World.Create(archetype);
            }
        }

        public virtual void Dispose()
        {
            World.Destroy(World);
            JobScheduler?.Dispose();
        }
    }
}

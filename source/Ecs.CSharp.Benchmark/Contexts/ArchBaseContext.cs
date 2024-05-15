using System;
using Arch.Core;
using Arch.Core.Utils;
using Schedulers;

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
        public JobScheduler JobScheduler { get; set; }

        public ArchBaseContext()
        {
            World = World.Create();
        }

        public ArchBaseContext(ComponentType[] archetype, int amount)
        {
            JobScheduler = new JobScheduler(new JobScheduler.Config
            {
                ThreadPrefixName = "Arch.Samples",
                ThreadCount = 0,
                MaxExpectedConcurrentJobs = 64,
                StrictAllocationMode = false,
            });
            
            World = World.Create();
            World.SharedJobScheduler = JobScheduler;
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

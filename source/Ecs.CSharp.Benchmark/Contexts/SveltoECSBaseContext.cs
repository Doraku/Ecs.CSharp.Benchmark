using System;
using Svelto.ECS;
using Svelto.ECS.Schedulers;

namespace Ecs.CSharp.Benchmark.Contexts
{
    internal class SveltoECSBaseContext : IDisposable
    {
        public struct Component1 : IEntityComponent
        {
            public int Value;
        }

        public struct Component2 : IEntityComponent
        {
            public int Value;
        }

        public struct Component3 : IEntityComponent
        {
            public int Value;
        }

        public static ExclusiveGroup Group { get; } = new();

        public SimpleEntitiesSubmissionScheduler Scheduler { get; }
        public EnginesRoot Root { get; }
        public IEntityFactory Factory { get; }

        public SveltoECSBaseContext()
        {
            Scheduler = new SimpleEntitiesSubmissionScheduler();
            Root = new EnginesRoot(Scheduler);
            Factory = Root.GenerateEntityFactory();
        }

        public virtual void Dispose()
        {
            Root.Dispose();
            Scheduler.Dispose();
        }
    }
}

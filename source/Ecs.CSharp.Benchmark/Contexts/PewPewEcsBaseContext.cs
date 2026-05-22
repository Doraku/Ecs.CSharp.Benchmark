using System;
using PewPew.Ecs.Core;
using PewPew.Ecs.Hybrid;

namespace Ecs.CSharp.Benchmark
{
    public struct PPComponent1 : IComponent
    {
        public int Value;
    }

    public struct PPComponent2 : IComponent
    {
        public int Value;
    }

    public struct PPComponent3 : IComponent
    {
        public int Value;
    }
}

namespace Ecs.CSharp.Benchmark.Contexts
{

    public class PewPewEcsBaseContext
    {
        public HybridWorld HybridWorld { get; }

        public PewPewEcsBaseContext()
        {

        }

        public PewPewEcsBaseContext(int entityCount)
        {
            HybridWorld = WorldFactory.Shared.CreateHybridWorld(c => c.MaxEntitiesCount = entityCount);
        }

        public PewPewEcsBaseContext(int entityCount, int entityPadding)
        {
            HybridWorld = WorldFactory.Shared.CreateHybridWorld(c => c.MaxEntitiesCount = entityCount * entityPadding + entityCount);
        }
    }
}

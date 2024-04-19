using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Arch.Core;
using Arch.Core.Utils;
using Arch.System;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.Arch_Components;
using Schedulers;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        private struct ForEach2 : IForEach<Component1, Component2>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Update(ref Component1 t0, ref Component2 t1)
            {
                t0.Value += t1.Value;
            }
        }
        
        [Query]
        private static void ForEach(ref Component1 t0, Component2 t1)
        {
            t0.Value += t1.Value;
        }

        private sealed class ArchContext : ArchBaseContext
        {
            private record struct Padding1();

            private record struct Padding2();

            private record struct Padding3();

            private record struct Padding4();

            public ArchContext(int entityCount)
            {
                JobScheduler = new JobScheduler( new JobScheduler.Config
                {
                    ThreadPrefixName = "Arch.Benchmark",
                    ThreadCount = 0,
                    MaxExpectedConcurrentJobs = 64,
                    StrictAllocationMode = false,
                });
                World.SharedJobScheduler = JobScheduler;
                
                ComponentType[] paddingTypes = [
                    typeof(Padding1),
                    typeof(Padding2),
                    typeof(Padding3),
                    typeof(Padding4)
                ];

                ComponentType[][] archetypes = paddingTypes.Select(t => _filter.Concat(Enumerable.Repeat(t, 1)).ToArray()).ToArray();

                foreach (ComponentType[] archetype in archetypes)
                {
                    World.Reserve(archetype, entityCount / 4);
                }

                for (int index = 0; index < entityCount; index++)
                {
                    World.Create(archetypes[index % archetypes.Length]);
                }
            }
        }

        private static readonly ComponentType[] _filter = [typeof(Component1), typeof(Component2)];
        private static readonly QueryDescription _queryDescription = new() { All = _filter };

        [Context]
        private readonly ArchContext _arch;
        private ForEach2 _forEach2;

        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch()
        {
            World world = _arch.World;
            world.InlineQuery<ForEach2, Component1, Component2>(in _queryDescription, ref _forEach2);
        }
        
        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch_MonoThread_SourceGenerated()
        {
            ForEachQuery(_arch.World);
        }
        
        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch_MultiThread()
        {
            World world = _arch.World;
            world.InlineParallelQuery<ForEach2, Component1, Component2>(in _queryDescription, ref _forEach2);
        }
    }
}

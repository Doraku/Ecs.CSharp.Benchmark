using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Arch.Core;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Ecs.CSharp.Benchmark.Context.Arch_Components;

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

        private sealed class ArchContext : ArchBaseContext
        {
            private record struct Padding1();

            private record struct Padding2();

            private record struct Padding3();

            private record struct Padding4();

            public ArchContext(int entityCount)
            {
                Type[] paddingTypes = new[]
                {
                    typeof(Padding1),
                    typeof(Padding2),
                    typeof(Padding3),
                    typeof(Padding4)
                };

                Type[][] archetypes = paddingTypes.Select(t => _filter.Concat(Enumerable.Repeat(t, 1)).ToArray()).ToArray();

                foreach (Type[] archetype in archetypes)
                {
                    World.Reserve(archetype, entityCount / 4);
                }

                for (int index = 0; index < entityCount; index++)
                {
                    World.Create(archetypes[index % archetypes.Length]);
                }
            }
        }

        private static readonly Type[] _filter = { typeof(Component1), typeof(Component2) };
        private static readonly QueryDescription _queryDescription = new() { All = _filter };

        [Context]
        private readonly ArchContext _arch;

        private ForEach2 _forEach2;

        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch()
        {
            World world = _arch.World;
            world.HPQuery<ForEach2, Component1, Component2>(in _queryDescription, ref _forEach2);
        }
    }
}
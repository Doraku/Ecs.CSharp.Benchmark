using System;
using System.Runtime.CompilerServices;
using Arch.Core;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Ecs.CSharp.Benchmark.Context.Arch_Components;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponents
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
            public ArchContext(int entityCount, int _)
                : base(_filter, entityCount)
            { }
        }

        private static readonly Type[] _filter = { typeof(Component1), typeof(Component2) };
        private static readonly QueryDescription _queryDescription = new() { All = _filter };

        [Context]
        private readonly ArchContext _arch;

        private ForEach2 _forEach2;

        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch_MonoThread()
        {
            World world = _arch.World;
            world.HPQuery<ForEach2, Component1, Component2>(in _queryDescription, ref _forEach2);
        }
        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch_MultiThread()
        {
            World world = _arch.World;
            world.HPParallelQuery<ForEach2, Component1, Component2>(in _queryDescription, ref _forEach2);
        }
    }
}
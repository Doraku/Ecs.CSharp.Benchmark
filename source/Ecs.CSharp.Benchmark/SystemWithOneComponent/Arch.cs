using System;
using System.Runtime.CompilerServices;
using Arch.Core;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Ecs.CSharp.Benchmark.Context.Arch_Components;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        private struct ForEach1 : IForEach<Component1>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Update(ref Component1 t0)
            {
                ++t0.Value;
            }
        }

        private sealed class ArchContext : ArchBaseContext
        {
            public ArchContext(int entityCount, int _)
                : base(_filter, entityCount)
            { }
        }

        private static readonly Type[] _filter = { typeof(Component1) };
        private static readonly QueryDescription _queryDescription = new() { All = _filter };

        [Context]
        private readonly ArchContext _arch;

        private ForEach1 _forEach;

        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch_MonoThread()
        {
            World world = _arch.World;
            world.HPQuery<ForEach1, Component1>(_queryDescription, ref _forEach);
        }
        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch_MultiThread()
        {
            World world = _arch.World;
            world.HPParallelQuery<ForEach1, Component1>(_queryDescription, ref _forEach);
        }
    }
}
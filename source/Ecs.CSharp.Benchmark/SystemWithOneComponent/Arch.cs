using System;
using System.Runtime.CompilerServices;
using Arch.Core;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Ecs.CSharp.Benchmark.Context.Arch_Components;

namespace Ecs.CSharp.Benchmark
{
    public struct ForEach1 : IForEach<Component1>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Update(ref Component1 t0)
        {
            ++t0.Value;
        }
    }

    public partial class SystemWithOneComponent
    {
        private static readonly Type[] _filter = { typeof(Component1) };
        private static readonly QueryDescription _queryDescription = new() { All = _filter };

        private ArchBaseContext _arch;
        private static ForEach1 _forEach;

        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch()
        {
            World world = _arch.World;
            world.HPQuery<ForEach1, Component1>(_queryDescription, ref _forEach);
        }
    }
}
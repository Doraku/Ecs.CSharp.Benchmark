using System;
using System.Runtime.CompilerServices;
using Arch.Core;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Ecs.CSharp.Benchmark.Context.Arch_Components;

namespace Ecs.CSharp.Benchmark
{
    
    public struct ForEach3 : IForEach<Component1, Component2, Component3>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Update(ref Component1 t0, ref Component2 t1, ref Component3 t3) {
            t0.Value += t1.Value + t3.Value;
        }
    }
    
    public partial class SystemWithThreeComponents
    {
        private static readonly Type[] _filter = { typeof(Component1), typeof(Component2), typeof(Component3) };
        private static readonly QueryDescription _queryDescription = new() { All = _filter };

        private ArchBaseContext _arch;
        private ForEach3 _forEach3;

        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch()
        {
            World world = _arch.World;
            world.HPQuery<ForEach3, Component1, Component2, Component3>(_queryDescription, ref _forEach3);
        }
    }
}
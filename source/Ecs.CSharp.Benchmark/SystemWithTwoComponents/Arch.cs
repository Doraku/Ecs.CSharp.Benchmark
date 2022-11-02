using System;
using Arch.Core;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponents
    {
        private static readonly Type[] _filter = { typeof(ArchBaseContext.Component1), typeof(ArchBaseContext.Component2) };
        private static readonly QueryDescription _queryDescription = new() { All = _filter };

        private ArchBaseContext _arch;

        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch()
        {
            World world = _arch.World;

            world.Query(_queryDescription, (ref ArchBaseContext.Component1 c1, ref ArchBaseContext.Component1 c2) => c1.Value += c2.Value);
        }
    }
}
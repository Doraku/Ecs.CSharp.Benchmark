using System;
using Arch.Core;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;

namespace Ecs.CSharp.Benchmark {

    public partial class SystemWithOneComponent {

        private ArchBaseContext _arch;
        private static Type[] filter = { typeof(ArchBaseContext.Component1) };
        private static QueryDescription queryDescription = new() { All = filter};
        
        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch() 
        {
            var world = _arch.World;
            world.Query(queryDescription, (ref ArchBaseContext.Component1 cmp) => ++cmp.Value);
        }
    }
}
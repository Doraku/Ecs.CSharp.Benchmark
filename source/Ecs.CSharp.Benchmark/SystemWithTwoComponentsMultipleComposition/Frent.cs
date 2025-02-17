using System;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Frent;
using Frent.Systems;
using static Ecs.CSharp.Benchmark.Contexts.FrentBaseContext;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        [Context]
        private readonly FrentContext _frent;
        internal sealed class FrentContext : FrentBaseContext
        {
            public FrentContext(int entityCount)
            {
                for (int i = 0; i < entityCount; i++)
                {
                    Entity e = (entityCount % 4) switch
                    {
                        0 => World.Create<Component1, Component2, Padding1>(default, new() { Value = 1 }, default),
                        1 => World.Create<Component1, Component2, Padding2>(default, new() { Value = 1 }, default),
                        2 => World.Create<Component1, Component2, Padding3>(default, new() { Value = 1 }, default),
                        _ => World.Create<Component1, Component2, Padding4>(default, new() { Value = 1 }, default),
                    };
                }

                Query = World.Query<With<Component1>, With<Component2>>();
            }

            public Query Query;

            struct Padding1;
            struct Padding2;
            struct Padding3;
            struct Padding4;
        }

        internal struct Sum : IAction<Component1, Component2>
        {
            public void Run(ref Component1 t0, ref Component2 t1)
            {
                t0.Value += t1.Value;
            }
        }

        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_QueryInline()
        {
            _frent.Query.Inline<Sum, Component1, Component2>(default);
        }

        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_Simd()
        {
            foreach ((var s1, var s2) in _frent.Query.EnumerateChunks<Component1, Component2>())
            {
                int len = s1.Length - (s1.Length & 7);

                Span<Vector256<int>> ints = MemoryMarshal.Cast<Component1, Vector256<int>>(s1.Slice(0, len));
                Span<Vector256<int>> a = MemoryMarshal.Cast<Component2, Vector256<int>>(s2.Slice(0, len))[..ints.Length];

                for (int i = 0; i < ints.Length; i++)
                    ints[i] += a[i];

                for (int i = len; i < s1.Length; i++)
                    s1[i].Value += s2[i].Value;
            }
        }
    }
}

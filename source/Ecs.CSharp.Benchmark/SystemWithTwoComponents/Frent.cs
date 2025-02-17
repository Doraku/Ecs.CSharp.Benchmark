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
    public partial class SystemWithTwoComponents
    {
        [Context]
        private readonly FrentContext _frent;

        internal sealed class FrentContext : FrentBaseContext
        {
            public FrentContext(int entityCount, int padding)
            {
                for (int i = 0; i < entityCount; i++)
                {
                    World.Create<Component1, Component2>(default, new() { Value = 1 });
                    for (int j = 0; j < padding; j++)
                    {
                        World.Create();
                    }
                }

                Query = World.Query<With<Component1>, With<Component2>>();
            }

            public Query Query;
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
        public void Frent_QueryDelegate()
        {
            _frent.Query.Delegate((ref Component1 c1, ref Component2 c2) => c1.Value += c2.Value);
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

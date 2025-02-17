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
    public partial class SystemWithThreeComponents
    {
        [Context]
        private readonly FrentContext _frent;

        private sealed class FrentContext : FrentBaseContext
        {
            public FrentContext(int entityCount, int _)
            {
                for (int i = 0; i < entityCount; i++)
                {
                    World.Create<Component1, Component2, Component3>(default, new() { Value = 1 }, new() { Value = 1 });
                }

                Query = World.Query<With<Component1>, With<Component2>, With<Component3>>();
            }

            public Query Query;
        }

        internal struct Sum : IAction<Component1, Component2, Component3>
        {
            public void Run(ref Component1 t0, ref Component2 t1, ref Component3 t2)
            {
                t0.Value += t1.Value + t2.Value;
            }
        }

        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_QueryInline()
        {
            _frent.Query.Inline<Sum, Component1, Component2, Component3>(default);
        }

        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_QueryDelegate()
        {
            _frent.Query.Delegate((ref Component1 c1, ref Component2 c2, ref Component1 c3) => c1.Value += c2.Value + c3.Value);
        }

        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_Simd()
        {
            foreach ((var s1, var s2, var s3) in _frent.Query.EnumerateChunks<Component1, Component2, Component3>())
            {
                int len = s1.Length - (s1.Length & 7);

                Span<Vector256<int>> ints = MemoryMarshal.Cast<Component1, Vector256<int>>(s1.Slice(0, len));
                Span<Vector256<int>> a = MemoryMarshal.Cast<Component2, Vector256<int>>(s2.Slice(0, len))[..ints.Length];
                Span<Vector256<int>> b = MemoryMarshal.Cast<Component3, Vector256<int>>(s3.Slice(0, len))[..ints.Length];

                for (int i = 0; i < ints.Length; i++)
                    ints[i] += a[i] + b[i];

                for (int i = len; i < s1.Length; i++)
                    s1[i].Value += s2[i].Value + s3[i].Value;
            }
        }
    }
}

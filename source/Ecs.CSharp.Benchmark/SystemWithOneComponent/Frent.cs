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
    public partial class SystemWithOneComponent
    {
        [Context]
        private readonly FrentContext _frent;

        private sealed class FrentContext : FrentBaseContext
        {
            public FrentContext(int entityCount, int entityPadding)
            {
                for (int i = 0; i < entityCount; i++)
                {
                    World.Create<Component1>(default);
                    for (int j = 0; j < entityPadding; j++)
                    {
                        World.Create();
                    }
                }

                Query = World.Query<With<Component1>>();
            }

            public Query Query;
        }

        internal struct Increment : IAction<Component1>
        {
            public void Run(ref Component1 t0)
            {
                t0.Value++;
            }
        }

        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_QueryInline()
        {
            _frent.Query.Inline<Increment, Component1>(default);
        }

        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_QueryDelegate()
        {
            _frent.Query.Delegate((ref Component1 c) => c.Value++);
        }

        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_Simd()
        {
            Vector256<int> sum = Vector256.Create(1);
            foreach (ChunkTuple<Component1> chunk in _frent.Query.EnumerateChunks<Component1>())
            {
                int len = chunk.Span.Length - (chunk.Span.Length & 7);
                Span<Vector256<int>> ints = MemoryMarshal.Cast<Component1, Vector256<int>>(chunk.Span.Slice(0, len));
                for (int i = 0; i < ints.Length; i++)
                {
                    ints[i] += sum;
                }

                for (int i = len; i < chunk.Span.Length; i++)
                {
                    chunk.Span[i].Value++;
                }
            }
        }
    }
}

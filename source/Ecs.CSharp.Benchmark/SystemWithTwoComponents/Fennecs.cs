using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.Fennecs_Components;
using fennecs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponents
    {
        [Context] private readonly FennecsContext _fennecs;

        private sealed class FennecsContext : FennecsBaseContext
        {
            public Query<Component1, Component2> query;

            public FennecsContext(int entityCount, int entityPadding)
            {
                query = World.Query<Component1, Component2>().Build();
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        Entity padding = World.Spawn();
                        switch (j % 2)
                        {
                            case 0:
                                padding.Add<Component1>();
                                break;

                            case 1:
                                padding.Add<Component2>();
                                break;
                        }
                    }

                    World.Spawn().Add<Component1>().Add(new Component2 { Value = 1 });
                }
            }
        }

        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs_ForEach()
        {
            _fennecs.query.For((ref Component1 c1, ref Component2 c2) => c1.Value += c2.Value);
        }

        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs_Job()
        {
            _fennecs.query.Job(delegate(ref Component1 c1, ref Component2 c2) { c1.Value += c2.Value; }, 1024);
        }

        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs_Raw()
        {
            _fennecs.query.Raw(delegate(Memory<Component1> c1v, Memory<Component2> c2v)
            {
                var c1vs = c1v.Span;
                var c2vs = c2v.Span;
                for (int i = 0; i < c1vs.Length; ++i)
                {
                    ref Component1 c1 = ref c1vs[i];
                    c1.Value += c2vs[i].Value;
                }
            });
        }
    }
}

using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.Fennecs_Components;
using fennecs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        [Context] private readonly FennecsContext _fennecs;

        private sealed class FennecsContext : FennecsBaseContext
        {
            public Query<Component1> query;

            public FennecsContext(int entityCount, int entityPadding)
            {
                query = World.Query<Component1>().Build();
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.Spawn();
                    }

                    World.Spawn().Add<Component1>();
                }
            }
        }

        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs_ForEach()
        {
            _fennecs.query.For((ref Component1 comp0) => comp0.Value++);
        }

        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs_Job()
        {
            _fennecs.query.Job(delegate(ref Component1 v) { v.Value++; }, 1024);
        }
        
        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs_Raw()
        {
            _fennecs.query.Raw(delegate(Memory<Component1> vectors)
            {
                foreach (ref var v in vectors.Span)
                {
                    v.Value++;
                }
            });
        }
    }
}

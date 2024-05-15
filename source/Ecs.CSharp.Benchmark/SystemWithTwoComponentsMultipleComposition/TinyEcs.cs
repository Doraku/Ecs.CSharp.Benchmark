using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.TinyEcs_Components;
using TinyEcs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        [Context] private readonly TinyEcsContext _tinyEcs;

        private sealed class TinyEcsContext : TinyEcsBaseContext
        {
            
            private record struct Padding1();
            private record struct Padding2();
            private record struct Padding3();
            private record struct Padding4();
            public Query Query { get; }

            
            public TinyEcsContext(int entityCount) : base()
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    var entity = World.Entity();
                    entity.Set<Component1>();
                    entity.Set(new Component2 { Value = 1 });

                    switch (i % 4)
                    {
                        case 0:
                            entity.Set<Padding1>();
                            break;

                        case 1:
                            entity.Set<Padding2>();
                            break;

                        case 2:
                            entity.Set<Padding3>();
                            break;

                        case 3:
                            entity.Set<Padding4>();
                            break;
                    }
                }

                Query = World.QueryBuilder().With<Component1>().With<Component2>().Build();
            }
        }

        [BenchmarkCategory(Categories.TinyEcs)]
        [Benchmark]
        public void TinyEcs_Each()
        {
            _tinyEcs.Query.Each((ref Component1 c1, ref Component2 c2) => c1.Value += c2.Value);
        }

        [BenchmarkCategory(Categories.TinyEcs)]
        [Benchmark]
        public void TinyEcs_EachJob()
        {
            _tinyEcs.Query.EachJob((ref Component1 c1, ref Component2 c2) => c1.Value += c2.Value);
        }
    }
}

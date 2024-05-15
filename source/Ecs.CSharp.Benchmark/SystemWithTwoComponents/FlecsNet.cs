using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.Arch_Components;
using Flecs.NET.Core;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponents
    {
        [Context]
        private readonly FlecsContext _flecs;

        private sealed class FlecsContext : FlecsNetBaseContext
        {
            public Query query;

            public FlecsContext(int entityCount, int entityPadding)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        Entity padding = World.Entity();
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

                    World.Entity().Add<Component1>()
                        .Set(new Component2
                        {
                            Value = 1
                        });
                }
                query = World.QueryBuilder().With<Component1>().With<Component2>().Build();
            }
        }

        [BenchmarkCategory(Categories.FlecsNet)]
        [Benchmark]
        public void FlecsNet_Each()
        {
            _flecs.query.Each((ref Component1 c1, ref Component2 c2) =>
            {
                c1.Value += c2.Value;
            });
        }

        [BenchmarkCategory(Categories.FlecsNet)]
        [Benchmark]
        public void FlecsNet_Iter()
        {
            _flecs.query.Iter((Iter it, Column<Component1> c1, Column<Component2> c2) =>
            {
                foreach (int i in it)
                {
                    c1[i].Value += c2[i].Value;
                }
            });
        }
    }
}

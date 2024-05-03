using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.Arch_Components;
using Flecs.NET.Core;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        [Context]
        private readonly FlecsContext _flecs;
        

        private sealed class FlecsContext : FlecsNetBaseContext
        {
            
            private record struct Padding1();

            private record struct Padding2();

            private record struct Padding3();

            private record struct Padding4();
            
            public Query query;

            public FlecsContext(int entityCount)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    Entity entity = World.Entity().Add<Component1>().Set(new Component2 { Value = 1 });
                    switch (i % 4)
                    {
                        case 0:
                            entity.Add<Padding1>();
                            break;
                        case 1:
                            entity.Add<Padding2>();
                            break;
                        case 2:
                            entity.Add<Padding3>();
                            break;
                        case 3:
                            entity.Add<Padding4>();
                            break;
                    }
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

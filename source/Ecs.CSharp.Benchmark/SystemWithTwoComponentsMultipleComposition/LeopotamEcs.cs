using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Leopotam.Ecs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        private sealed class LeopotamEcsContext : LeopotamEcsBaseContext
        {
            private record struct Padding1();

            private record struct Padding2();

            private record struct Padding3();

            private record struct Padding4();

            private sealed class MonoThreadRunSystem : IEcsRunSystem
            {
                private readonly EcsFilter<Component1, Component2> _filter;

                public void Run()
                {
                    for (int i = 0, iMax = _filter.GetEntitiesCount(); i < iMax; i++)
                    {
                        _filter.Get1(i).Value += _filter.Get2(i).Value;
                    }
                }
            }

            public EcsSystems MonoThreadSystem { get; }

            public LeopotamEcsContext(int entityCount)
            {
                MonoThreadSystem = new EcsSystems(World).Add(new MonoThreadRunSystem()).ProcessInjects();

                MonoThreadSystem.Init();

                for (int i = 0; i < entityCount; ++i)
                {
                    EcsEntity entity = World
                        .NewEntity()
                        .Replace(new Component1())
                        .Replace(new Component2 { Value = 1 });

                    switch (i % 4)
                    {
                        case 0:
                            entity.Replace(new Padding1());
                            break;

                        case 1:
                            entity.Replace(new Padding2());
                            break;

                        case 2:
                            entity.Replace(new Padding3());
                            break;

                        case 3:
                            entity.Replace(new Padding4());
                            break;
                    }
                }
            }
        }

        [Context]
        private readonly LeopotamEcsContext _leopotamEcs;

        [BenchmarkCategory(Categories.LeopotamEcs)]
        [Benchmark]
        public void LeopotamEcs() => _leopotamEcs.MonoThreadSystem.Run();
    }
}

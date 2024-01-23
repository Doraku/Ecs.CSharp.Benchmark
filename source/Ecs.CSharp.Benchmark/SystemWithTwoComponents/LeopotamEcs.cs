using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Leopotam.Ecs;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponents
    {
        private sealed class LeopotamEcsContext : LeopotamEcsBaseContext
        {
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

            public LeopotamEcsContext(int entityCount, int entityPadding)
            {
                MonoThreadSystem = new EcsSystems(World).Add(new MonoThreadRunSystem()).ProcessInjects();

                MonoThreadSystem.Init();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        EcsEntity padding = World.NewEntity();
                        switch (j % 2)
                        {
                            case 0:
                                padding.Replace(new Component1());
                                break;

                            case 1:
                                padding.Replace(new Component2());
                                break;
                        }
                    }

                    World.NewEntity()
                        .Replace(new Component1())
                        .Replace(new Component2 { Value = 1 });
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

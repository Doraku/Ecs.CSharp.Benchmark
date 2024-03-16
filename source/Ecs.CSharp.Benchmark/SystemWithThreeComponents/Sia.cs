using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Sia;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithThreeComponents
    {
        private sealed class SiaContext : SiaBaseContext
        {
            public sealed class MonoThreadUpdateSystem()
                : SystemBase(matcher: Matchers.Of<Component1, Component2, Component3>())
            {
                public override void Execute(World world, Scheduler scheduler, IEntityQuery query)
                {
                    query.ForSlice((ref Component1 c1, ref Component2 c2, ref Component3 c3) => {
                        c1.Value += c2.Value + c3.Value;
                    });
                }
            }

            public sealed class MultiThreadUpdateSystem()
                : SystemBase(matcher: Matchers.Of<Component1, Component2, Component3>())
            {
                public override void Execute(World world, Scheduler scheduler, IEntityQuery query)
                {
                    query.ForSliceOnParallel((ref Component1 c1, ref Component2 c2, ref Component3 c3) => {
                        c1.Value += c2.Value + c3.Value;
                    });
                }
            }

            public SiaContext(int entityCount, int entityPadding)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        switch (j % 3)
                        {
                            case 0:
                                World.CreateInArrayHost(Bundle.Create(new Component1()));
                                break;

                            case 1:
                                World.CreateInArrayHost(Bundle.Create(new Component2()));
                                break;

                            case 2:
                                World.CreateInArrayHost(Bundle.Create(new Component3()));
                                break;
                        }
                    }

                    World.CreateInArrayHost(Bundle.Create(
                        new Component1(),
                        new Component2(),
                        new Component3()));
                }
            }
        }

        [Context]
        private readonly SiaContext _sia;

        [BenchmarkCategory(Categories.Sia)]
        [Benchmark]
        public void Sia_MonoThread()
        {
            Scheduler scheduler = new();

            SystemChain.Empty
                .Add<SiaContext.MonoThreadUpdateSystem>()
                .RegisterTo(_sia.World, scheduler);

            scheduler.Tick();
        }

        [BenchmarkCategory(Categories.Sia)]
        [Benchmark]
        public void Sia_MultiThread()
        {
            Scheduler scheduler = new();

            SystemChain.Empty
                .Add<SiaContext.MultiThreadUpdateSystem>()
                .RegisterTo(_sia.World, scheduler);

            scheduler.Tick();
        }
    }
}

using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Sia;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        private sealed class SiaContext : SiaBaseContext
        {
            private partial record struct Padding1();

            private partial record struct Padding2();

            private partial record struct Padding3();

            private partial record struct Padding4();

            public sealed class MonoThreadUpdateSystem()
                : SystemBase(matcher: Matchers.Of<Component1, Component2>())
            {
                public override void Execute(World world, Scheduler scheduler, IEntityQuery query)
                {
                    query.ForSlice((ref Component1 c1, ref Component2 c2) => {
                        c1.Value += c2.Value;
                    });
                }
            }

            public sealed class MultiThreadUpdateSystem()
                : SystemBase(matcher: Matchers.Of<Component1, Component2>())
            {
                public override void Execute(World world, Scheduler scheduler, IEntityQuery query)
                {
                    query.ForSliceOnParallel((ref Component1 c1, ref Component2 c2) => {
                        c1.Value += c2.Value;
                    });
                }
            }

            public SiaContext(int entityCount) : base()
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    switch (i % 4)
                    {
                        case 0:
                            World.CreateInArrayHost(Bundle.Create(new Component1(), new Component2(), new Padding1()));;
                            break;

                        case 1:
                            World.CreateInArrayHost(Bundle.Create(new Component1(), new Component2(), new Padding2()));
                            break;

                        case 2:
                            World.CreateInArrayHost(Bundle.Create(new Component1(), new Component2(), new Padding3()));
                            break;

                        case 3:
                            World.CreateInArrayHost(Bundle.Create(new Component1(), new Component2(), new Padding4()));
                            break;
                    }
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

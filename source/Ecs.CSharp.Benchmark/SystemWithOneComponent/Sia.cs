using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Sia;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        private sealed class SiaContext : SiaBaseContext
        {
            public sealed class MonoThreadUpdateSystem()
                : SystemBase(matcher: Matchers.Of<Component1>())
            {
                public override void Execute(World world, Scheduler scheduler, IEntityQuery query)
                {
                    query.ForSlice((ref Component1 component) => {
                        ++component.Value;
                    });
                }
            }

            public sealed class MultiThreadUpdateSystem()
                : SystemBase(matcher: Matchers.Of<Component1>())
            {
                public override void Execute(World world, Scheduler scheduler, IEntityQuery query)
                {
                    query.ForSliceOnParallel((ref Component1 component) => {
                        ++component.Value;
                    });
                }
            }

            public SiaContext(int entityCount, int entityPadding) : base()
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    World.CreateInArrayHost(Bundle.Create(new Component1()));
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

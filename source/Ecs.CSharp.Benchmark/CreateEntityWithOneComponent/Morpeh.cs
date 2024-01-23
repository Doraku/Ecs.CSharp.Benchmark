using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Scellecs.Morpeh;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithOneComponent
    {
        [Context]
        private readonly MorpehBaseContext _context;

        [BenchmarkCategory(Categories.Morpeh)]
        [Benchmark]
        public void Morpeh_Direct()
        {
            World world = _context.World;
            for (int i = 0; i < EntityCount; ++i)
            {
                world.CreateEntity().AddComponent<MorpehBaseContext.Component1>();
            }

            world.Commit();
        }

        [BenchmarkCategory(Categories.Morpeh)]
        [Benchmark]
        public void Morpeh_Stash()
        {
            World world = _context.World;
            Stash<MorpehBaseContext.Component1> stash1 = world.GetStash<MorpehBaseContext.Component1>();
            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = world.CreateEntity();
                stash1.Add(entity);
            }

            world.Commit();
        }
    }
}

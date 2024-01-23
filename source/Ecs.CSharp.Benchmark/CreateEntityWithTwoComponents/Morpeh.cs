using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Scellecs.Morpeh;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithTwoComponents
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
                world.CreateEntity().AddComponent<MorpehBaseContext.Component2>();
                world.CreateEntity().AddComponent<MorpehBaseContext.Component3>();
            }

            world.Commit();
        }

        [BenchmarkCategory(Categories.Morpeh)]
        [Benchmark]
        public void Morpeh_Stash()
        {
            World world = _context.World;
            Stash<MorpehBaseContext.Component1> stash1 = world.GetStash<MorpehBaseContext.Component1>();
            Stash<MorpehBaseContext.Component2> stash2 = world.GetStash<MorpehBaseContext.Component2>();
            Stash<MorpehBaseContext.Component3> stash3 = world.GetStash<MorpehBaseContext.Component3>();
            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = world.CreateEntity();
                stash1.Add(entity);
                stash2.Add(entity);
                stash3.Add(entity);
            }

            world.Commit();
        }
    }
}

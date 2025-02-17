using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Frent;
using Frent.Core;
using static Ecs.CSharp.Benchmark.Contexts.FrentBaseContext;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithOneComponent
    {
        private static readonly EntityType _entityType = Entity.EntityTypeOf([Component<Component1>.ID], []);

        [Context]
        private readonly FrentBaseContext _frent;

        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent()
        {
            World world = _frent.World;
            world.EnsureCapacity(_entityType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
                world.Create<Component1>(default);
        }

        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_Bulk()
        {
            World world = _frent.World;
            var chunks = world.CreateMany<Component1>(EntityCount);

            for (int i = 0; i < chunks.Span.Length; i++)
                chunks.Span[i] = new();
        }
    }
}

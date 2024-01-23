using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        private sealed class MonoGameExtendedContext : MonoGameExtendedBaseContext
        {
            public sealed class UpdateSystem : EntityUpdateSystem
            {
                private ComponentMapper<Component1> _components;

                public UpdateSystem()
                    : base(Aspect.All(typeof(Component1)))
                { }

                public override void Initialize(IComponentMapperService mapperService)
                {
                    _components = mapperService.GetMapper<Component1>();
                }

                public override void Update(GameTime gameTime)
                {
                    foreach (int entityId in ActiveEntities)
                    {
                        ++_components.Get(entityId).Value;
                    }
                }
            }

            private readonly UpdateSystem _system;

            public new World World { get; }

            public GameTime Time { get; }

            public MonoGameExtendedContext(int entityCount, int entityPadding)
            {
                _system = new UpdateSystem();
                World = new WorldBuilder().AddSystem(_system).Build();
                Time = new GameTime();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.CreateEntity();
                    }

                    Entity entity = World.CreateEntity();
                    entity.Attach(new Component1());
                }
            }

            public override void Dispose()
            {
                World.Dispose();
                _system.Dispose();

                base.Dispose();
            }
        }

        [Context]
        private readonly MonoGameExtendedContext _monoGameExtended;

        [BenchmarkCategory(Categories.MonoGameExtended)]
        [Benchmark]
        public void MonoGameExtended() => _monoGameExtended.World.Update(_monoGameExtended.Time);
    }
}

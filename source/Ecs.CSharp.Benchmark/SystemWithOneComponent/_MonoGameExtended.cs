using System;
using BenchmarkDotNet.Attributes;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        private class MonoGameExtendedContext : IDisposable
        {
            public class Component
            {
                public int Value;
            }

            public class UpdateSystem : EntityUpdateSystem
            {
                private ComponentMapper<Component> _components;

                public UpdateSystem()
                    : base(Aspect.All(typeof(Component)))
                { }

                public override void Initialize(IComponentMapperService mapperService)
                {
                    _components = mapperService.GetMapper<Component>();
                }

                public override void Update(GameTime gameTime)
                {
                    foreach (int entityId in ActiveEntities)
                    {
                        ++_components.Get(entityId).Value;
                    }
                }
            }

            public World World { get; }

            public GameTime Time { get; }

            public MonoGameExtendedContext(int entityCount)
            {
                World = new WorldBuilder().AddSystem(new UpdateSystem()).Build();
                Time = new GameTime();

                for (int i = 0; i < entityCount; ++i)
                {
                    Entity entity = World.CreateEntity();
                    entity.Attach(new Component());
                }
            }

            public void Dispose()
            {
                World.Dispose();
            }
        }

        private MonoGameExtendedContext _monoGameExtended;

        [Benchmark]
        public void MonoGameExtended() => _monoGameExtended.World.Update(_monoGameExtended.Time);
    }
}

using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithThreeComponents
    {
        private class MonoGameExtendedContext : MonoGameExtendedBaseContext
        {
            public class UpdateSystem : EntityUpdateSystem
            {
                private ComponentMapper<Component1> _c1;
                private ComponentMapper<Component2> _c2;
                private ComponentMapper<Component3> _c3;

                public UpdateSystem()
                    : base(Aspect.All(typeof(Component1), typeof(Component2), typeof(Component3)))
                { }

                public override void Initialize(IComponentMapperService mapperService)
                {
                    _c1 = mapperService.GetMapper<Component1>();
                    _c2 = mapperService.GetMapper<Component2>();
                    _c3 = mapperService.GetMapper<Component3>();
                }

                public override void Update(GameTime gameTime)
                {
                    foreach (int entityId in ActiveEntities)
                    {
                        _c1.Get(entityId).Value += _c2.Get(entityId).Value + _c3.Get(entityId).Value;
                    }
                }
            }

            public new World World { get; }

            public GameTime Time { get; }

            public MonoGameExtendedContext(int entityCount)
            {
                World = new WorldBuilder().AddSystem(new UpdateSystem()).Build();
                Time = new GameTime();

                for (int i = 0; i < entityCount; ++i)
                {
                    Entity entity = World.CreateEntity();
                    entity.Attach(new Component1());
                    entity.Attach(new Component2 { Value = 1 });
                    entity.Attach(new Component3 { Value = 1 });
                }
            }

            public override void Dispose()
            {
                World.Dispose();

                base.Dispose();
            }
        }

        private MonoGameExtendedContext _monoGameExtended;

        [Benchmark]
        public void MonoGameExtended() => _monoGameExtended.World.Update(_monoGameExtended.Time);
    }
}

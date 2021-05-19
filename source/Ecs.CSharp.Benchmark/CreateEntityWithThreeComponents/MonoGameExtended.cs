using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using MonoGame.Extended.Entities;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithThreeComponents
    {
        private MonoGameExtendedBaseContext _monoGameExtended;

        [Benchmark]
        public void MonoGameExtended()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = _monoGameExtended.World.CreateEntity();
                entity.Attach(new MonoGameExtendedBaseContext.Component1());
                entity.Attach(new MonoGameExtendedBaseContext.Component2());
                entity.Attach(new MonoGameExtendedBaseContext.Component3());
            }
        }
    }
}

using System;
using BenchmarkDotNet.Attributes;
using MonoGame.Extended.Entities;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithThreeComponents
    {
        private class MonoGameExtendedContext : IDisposable
        {
            public class Component1
            {
                public int Value;
            }

            public class Component2
            {
                public int Value;
            }

            public class Component3
            {
                public int Value;
            }

            public World World { get; }

            public MonoGameExtendedContext()
            {
                World = new WorldBuilder().Build();
            }

            public void Dispose()
            {
                World.Dispose();
            }
        }

        private MonoGameExtendedContext _monoGameExtended;

        [Benchmark]
        public void MonoGameExtended()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = _monoGameExtended.World.CreateEntity();
                entity.Attach(new MonoGameExtendedContext.Component1());
                entity.Attach(new MonoGameExtendedContext.Component2());
                entity.Attach(new MonoGameExtendedContext.Component3());
            }
        }
    }
}

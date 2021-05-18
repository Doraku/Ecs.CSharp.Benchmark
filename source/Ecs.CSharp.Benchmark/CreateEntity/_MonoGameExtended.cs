using System;
using BenchmarkDotNet.Attributes;
using MonoGame.Extended.Entities;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntity
    {
        private class MonoGameExtendedContext : IDisposable
        {
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
                _monoGameExtended.World.CreateEntity();
            }
        }
    }
}

using System;
using System.Numerics;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Contexts;
using Ecs.CSharp.Benchmark.Contexts.Myriad_Components;
using Myriad.ECS;
using Myriad.ECS.Collections;
using Myriad.ECS.Command;
using Myriad.ECS.Queries;
using Myriad.ECS.Worlds;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithOneComponent
    {
        private struct MyriadForEach1
            : IQuery<Component1>, IChunkQuery<Component1>
        {
            public void Execute(Entity entity, ref Component1 t0)
            {
                ++t0.Value;
            }

            public void Execute(ChunkHandle chunk, ReadOnlySpan<Entity> e, Span<Component1> t0)
            {
                for (int i = 0; i < t0.Length; i++)
                {
                    t0[i].Value++;
                }
            }
        }

        private struct MyriadVectorForEach1
            : IVectorChunkQuery<int>
        {
            private static readonly Vector<int> _one = Vector<int>.One;

            public void Execute(Span<Vector<int>> t0, int offset, int padding)
            {
                for (int i = 0; i < t0.Length; i++)
                {
                    t0[i] += _one;
                }
            }
        }

        private sealed class MyriadContext : MyriadBaseContext
        {
            // Myriad stores components as arrays of structs, so all structs of the same type are 
            // always sequential in memory no matter what else is attached to the entity. So no need to respect
            // the padding input
            public MyriadContext(int entityCount, int _)
                : base()
            {
                CommandBuffer cmd = new CommandBuffer(World);
                for (int i = 0; i < entityCount; i++)
                {
                    CommandBuffer.BufferedEntity e = cmd.Create().Set(new Component1());
                }

                cmd.Playback().Dispose();
            }
        }

        [Context] private readonly MyriadContext _myriad;

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_SingleThread()
        {
            World world = _myriad.World;
            world.Execute<MyriadForEach1, Component1>(new MyriadForEach1());
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_MultiThread()
        {
            World world = _myriad.World;
            world.ExecuteParallel<MyriadForEach1, Component1>(new MyriadForEach1());
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_SingleThreadChunk()
        {
            World world = _myriad.World;
            world.ExecuteChunk<MyriadForEach1, Component1>(new MyriadForEach1());
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_MultiThreadChunk()
        {
            World world = _myriad.World;
            world.ExecuteChunkParallel<MyriadForEach1, Component1>(new MyriadForEach1());
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_Enumerable()
        {
            World world = _myriad.World;

            foreach ((Entity _, RefT<Component1> c) in world.Query<Component1>())
            {
                c.Ref.Value++;
            }
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_Delegate()
        {
            World world = _myriad.World;

            world.Query((ref Component1 c) =>
            {
                c.Value++;
            });
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_SingleThreadChunk_SIMD()
        {
            World world = _myriad.World;

            world.ExecuteVectorChunk<MyriadVectorForEach1, Component1, int>(new MyriadVectorForEach1());
        }
    }
}

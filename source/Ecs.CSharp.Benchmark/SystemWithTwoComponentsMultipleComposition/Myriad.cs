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
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        private struct MyriadForEach2
            : IQuery<Component1, Component2>, IChunkQuery<Component1, Component2>
        {
            public void Execute(Entity entity, ref Component1 t0, ref Component2 t1)
            {
                t0.Value += t1.Value;
            }

            public void Execute(ChunkHandle chunk, ReadOnlySpan<Entity> e, Span<Component1> t0, Span<Component2> t1)
            {
                for (int i = 0; i < t0.Length; i++)
                {
                    t0[i].Value += t1[i].Value;
                }
            }
        }

        private struct MyriadVectorForEach2
            : IVectorChunkQuery<int, int>
        {
            public void Execute(Span<Vector<int>> t0, Span<Vector<int>> t1, int offset, int padding)
            {
                for (int i = 0; i < t0.Length; i++)
                {
                    t0[i] += t1[i];
                }
            }
        }

        private sealed class MyriadContext : MyriadBaseContext
        {
            public MyriadContext(int entityCount)
                : base()
            {
                CommandBuffer cmd = new CommandBuffer(World);
                for (int i = 0; i < entityCount; i++)
                {
                    CommandBuffer.BufferedEntity entity = cmd.Create().Set(new Component1()).Set(new Component2());

                    switch (i % 4)
                    {
                        case 0:
                            entity.Set(new Padding1());
                            break;

                        case 1:
                            entity.Set(new Padding2());
                            break;

                        case 2:
                            entity.Set(new Padding3());
                            break;

                        case 3:
                            entity.Set(new Padding4());
                            break;
                    }
                }

                cmd.Playback().Dispose();
            }
        }

        [Context]
        private readonly MyriadContext _myriad;

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_SingleThread()
        {
            World world = _myriad.World;
            world.Execute<MyriadForEach2, Component1, Component2>(new MyriadForEach2());
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_MultiThread()
        {
            World world = _myriad.World;
            world.ExecuteParallel<MyriadForEach2, Component1, Component2>(new MyriadForEach2());
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_SingleThreadChunk()
        {
            World world = _myriad.World;
            world.ExecuteChunk<MyriadForEach2, Component1, Component2>(new MyriadForEach2());
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_MultiThreadChunk()
        {
            World world = _myriad.World;
            world.ExecuteChunkParallel<MyriadForEach2, Component1, Component2>(new MyriadForEach2());
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_Enumerable()
        {
            World world = _myriad.World;

            foreach ((Entity _, RefT<Component1> c1, RefT<Component2> c2) in world.Query<Component1, Component2>())
            {
                c1.Ref.Value += c2.Ref.Value;
            }
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_Delegate()
        {
            World world = _myriad.World;

            world.Query((ref Component1 c1, ref Component1 c2) =>
            {
                c1.Value += c2.Value;
            });
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_SingleThreadChunk_SIMD()
        {
            World world = _myriad.World;

            world.ExecuteVectorChunk<MyriadVectorForEach2, Component1, int, Component2, int>(new MyriadVectorForEach2());
        }
    }
}

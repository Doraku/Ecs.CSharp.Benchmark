using System;
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
    public partial class SystemWithThreeComponents
    {
        private struct MyriadForEach3
            : IQuery<Component1, Component2, Component3>, IChunkQuery<Component1, Component2, Component3>
        {
            public void Execute(Entity entity, ref Component1 t0, ref Component2 t1, ref Component3 t2)
            {
                t0.Value += t1.Value + t2.Value;
            }

            public void Execute(ChunkHandle chunk, ReadOnlySpan<Entity> e, Span<Component1> t0, Span<Component2> t1, Span<Component3> t2)
            {
                for (int i = 0; i < t0.Length; i++)
                {
                    t0[i].Value += t1[i].Value + t2[i].Value;
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
                    CommandBuffer.BufferedEntity e = cmd.Create().Set(new Component1()).Set(new Component2()).Set(new Component3());
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
            world.Execute<MyriadForEach3, Component1, Component2, Component3>(new MyriadForEach3());
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_MultiThread()
        {
            World world = _myriad.World;
            world.ExecuteParallel<MyriadForEach3, Component1, Component2, Component3>(new MyriadForEach3());
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_SingleThreadChunk()
        {
            World world = _myriad.World;
            world.ExecuteChunk<MyriadForEach3, Component1, Component2, Component3>(new MyriadForEach3());
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_MultiThreadChunk()
        {
            World world = _myriad.World;
            world.ExecuteChunkParallel<MyriadForEach3, Component1, Component2, Component3>(new MyriadForEach3());
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_Enumerable()
        {
            World world = _myriad.World;

            foreach ((Entity _, RefT<Component1> c1, RefT<Component2> c2, RefT<Component3> c3) in world.Query<Component1, Component2, Component3>())
            {
                c1.Ref.Value += c2.Ref.Value + c3.Ref.Value;
            }
        }

        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_Delegate()
        {
            World world = _myriad.World;

            world.Query((ref Component1 c1, ref Component1 c2, ref Component1 c3) =>
            {
                c1.Value += c2.Value + c3.Value;
            });
        }
    }
}

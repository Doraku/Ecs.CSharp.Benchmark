using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BenchmarkDotNet.Filters;
using BenchmarkDotNet.Running;

namespace Ecs.CSharp.Benchmark
{
    /// <summary>
    /// Prefixes / ECS package names for benchmarks, used as BenchMarkDotNet categories.
    /// </summary>
    internal static class Categories
    {
        public const string Arch = "Arch";
        public const string DefaultEcs = "DefaultEcs";
        public const string FrifloEngineEcs = "FrifloEngineEcs";
        public const string HypEcs = "HypEcs";
        public const string LeopotamEcs = "Leopotam.Ecs";
        public const string LeopotamEcsLite = "Leopotam.EcsLite";
        public const string MonoGameExtended = "MonoGame.Extended";
        public const string Myriad = "Myriad.ECS";
        public const string RelEcs = "RelEcs";
        public const string SveltoECS = "Svelto.ECS";
        public const string Morpeh = "Morpeh";
        public const string FlecsNet = "FlecsNet";
        public const string Fennecs = "fennecs";
        public const string TinyEcs = "TinyEcs";

        public const string CreateEntity = "CreateEntity";
        public const string System = "System";
    }

    /// <summary>
    /// Excludes a given category from benchmarks.
    /// (used by Program.cs)
    /// </summary>
    /// <remarks>
    /// When an exclusion is PRESENT, then all benchmarks that HAVE the category will be EXCLUDED.
    /// </remarks>
    /// <example>
    /// <c>CategoryExclusion("foo")</c> will exclude all benchmarks that have the "foo" category.
    /// </example>
    public class CategoryExclusion(string category) : IFilter
    {
        public bool Predicate([NotNull] BenchmarkCase benchmarkCase)
        {
            return !benchmarkCase.Descriptor.Categories.Contains(category);
        }
    }    
}

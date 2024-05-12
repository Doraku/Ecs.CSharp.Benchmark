using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BenchmarkDotNet.Configs;
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
    /// Capability Requirements for specific tests.
    /// Add your own intrinsics or other system dependencies here.
    /// </summary>
    /// <remarks>
    /// Usage: Add a category to it and apply exclusions in the ApplyExclusions method.
    /// (this is an EXCLUSIVE category filter, it turns OFF all categories it matches)
    /// Then, set your own BenchmarkCategory to include the CapabilityCategory string.
    /// </remarks>
    /// <example>
    /// <code>
    /// [BenchmarkCategory(
    ///     Categories.Fennecs,
    ///     Capabilities.Avx2
    /// )]
    /// public void Raw_AVX2()
    /// </code>
    /// </example>
    internal static class Capabilities
    {
        // These are common vectorized instruction set categories.
        // x86/x64
        public const string Avx2 = nameof(System.Runtime.Intrinsics.X86.Avx2);
        public const string Avx = nameof(System.Runtime.Intrinsics.X86.Avx);
        public const string Sse3 = nameof(System.Runtime.Intrinsics.X86.Sse3);
        public const string Sse2 = nameof(System.Runtime.Intrinsics.X86.Sse2);
        
        // Arm
        public const string AdvSimd = nameof(System.Runtime.Intrinsics.Arm.AdvSimd);
        
        /// <summary>
        /// This applies capability-based exclusions as filters to the config.
        /// </summary>
        /// <param name="self">a Benchmark Config, e.g. as used in Program.cs</param>
        public static IConfig WithCapabilityExclusions(this IConfig self)
        {
            if (!System.Runtime.Intrinsics.X86.Avx2.IsSupported)
            {
                self = self.AddFilter(new CategoryExclusion(Avx2));
            }

            if (!System.Runtime.Intrinsics.X86.Avx.IsSupported)
            {
                self = self.AddFilter(new CategoryExclusion(Avx));
            }

            if (!System.Runtime.Intrinsics.X86.Sse3.IsSupported)
            {
                self = self.AddFilter(new CategoryExclusion(Sse3));
            }

            if (!System.Runtime.Intrinsics.X86.Sse2.IsSupported)
            {
                self = self.AddFilter(new CategoryExclusion(Sse2));
            }

            if (!System.Runtime.Intrinsics.Arm.AdvSimd.IsSupported)
            {
                self = self.AddFilter(new CategoryExclusion(AdvSimd));
            }

            return self;
        }
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

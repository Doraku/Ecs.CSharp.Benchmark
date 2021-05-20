using BenchmarkDotNet.Running;

namespace Ecs.CSharp.Benchmark
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkSwitcher benchmark = BenchmarkSwitcher.FromTypes(new[]
            {
                typeof(CreateEntityWithNoComponent),
                typeof(CreateEntityWithOneComponent),
                typeof(CreateEntityWithTwoComponents),
                typeof(CreateEntityWithThreeComponents),

                typeof(SystemWithOneComponent),
                typeof(SystemWithTwoComponents),
                typeof(SystemWithThreeComponents),
            });

            if (args.Length > 0)
            {
                benchmark.Run(args);
            }
            else
            {
                benchmark.RunAll();
            }
        }
    }
}

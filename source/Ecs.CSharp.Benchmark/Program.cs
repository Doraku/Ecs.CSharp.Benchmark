using BenchmarkDotNet.Running;

namespace Ecs.CSharp.Benchmark
{
    internal static class Program
    {
        private static void Main()
        {
            BenchmarkSwitcher.FromTypes(new[]
            {
                typeof(CreateEntityWithNoComponent),
                typeof(CreateEntityWithOneComponent),
                typeof(CreateEntityWithTwoComponents),
            }).RunAll();
        }
    }
}

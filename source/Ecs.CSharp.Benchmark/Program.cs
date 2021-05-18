using BenchmarkDotNet.Running;

namespace Ecs.CSharp.Benchmark
{
    internal static class Program
    {
        private static void Main()
        {
            BenchmarkSwitcher.FromTypes(new[]
            {
                typeof(CreateEntity),
            }).RunAll();
        }
    }
}

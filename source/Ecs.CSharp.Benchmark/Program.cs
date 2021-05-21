using System.Globalization;
using BenchmarkDotNet.Running;

namespace Ecs.CSharp.Benchmark
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            CultureInfo cultureInfo = new("en-US");

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

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

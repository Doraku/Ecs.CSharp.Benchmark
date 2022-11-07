using System.Globalization;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Ecs.CSharp.Benchmark;

CultureInfo cultureInfo = new("en-US");

CultureInfo.CurrentCulture = cultureInfo;
CultureInfo.CurrentUICulture = cultureInfo;
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

BenchmarkSwitcher benchmark = BenchmarkSwitcher.FromTypes(new[]
{
    typeof(CreateEntityWithOneComponent),
    typeof(CreateEntityWithTwoComponents),
    typeof(CreateEntityWithThreeComponents),

    typeof(SystemWithOneComponent),
    typeof(SystemWithTwoComponents),
    typeof(SystemWithThreeComponents),

    typeof(SystemWithTwoComponentsMultipleComposition)
});

IConfig configuration = DefaultConfig.Instance.WithOptions(ConfigOptions.DisableOptimizationsValidator);

if (args.Length > 0)
{
    benchmark.Run(args, configuration);
}
else
{
    benchmark.RunAll(configuration);
}

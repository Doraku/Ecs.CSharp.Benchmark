#pragma warning disable CA1852 // Seal internal types

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using Ecs.CSharp.Benchmark;

CultureInfo cultureInfo = new("en-US");

CultureInfo.CurrentCulture = cultureInfo;
CultureInfo.CurrentUICulture = cultureInfo;
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

BenchmarkSwitcher benchmark = BenchmarkSwitcher.FromTypes(new[]
{
    typeof(SystemWithOneComponent),
    typeof(SystemWithTwoComponents),
    typeof(SystemWithThreeComponents),

    typeof(SystemWithTwoComponentsMultipleComposition),

    //Moving lighter tests to the back makes the estimated time display more reliable 
    typeof(CreateEntityWithOneComponent),
    typeof(CreateEntityWithTwoComponents),
    typeof(CreateEntityWithThreeComponents),
});


IConfig configuration = DefaultConfig.Instance
    .WithOptions(ConfigOptions.DisableOptimizationsValidator)
    .WithCapabilityExclusions();

if (args.Length > 0)
{
    // There's no orderer commandline arg, so let's pretend there is one.
    if (args.Contains("--ranking"))
    {
        List<string> argList = args.ToList();
        argList.Remove("--ranking");
        args = argList.ToArray();
        configuration = configuration.WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest));
    }

    benchmark.Run(args, configuration);
}
else
{
    benchmark.RunAll(configuration);
}

﻿#pragma warning disable CA1852 // Seal internal types

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
    benchmark.Run(args, configuration);
}
else
{
    benchmark.RunAll(configuration);
}

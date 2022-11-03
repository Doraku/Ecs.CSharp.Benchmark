``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.18363.2274/1909/November2019Update/19H2)
Intel Xeon W-2135 CPU 3.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


```
|                 Method | EntityCount | EntityPadding |         Mean |      Error |     StdDev | Ratio | RatioSD | CacheMisses/Op | Allocated | Alloc Ratio |
|----------------------- |------------ |-------------- |-------------:|-----------:|-----------:|------:|--------:|---------------:|----------:|------------:|
|                   Arch |      100000 |             0 |    203.17 μs |   3.976 μs |   4.733 μs |  0.89 |    0.02 |             26 |       1 B |        1.00 |
|  DefaultEcs_MonoThread |      100000 |             0 |    229.45 μs |   1.728 μs |   1.616 μs |  1.00 |    0.00 |             72 |       1 B |        1.00 |
| DefaultEcs_MultiThread |      100000 |             0 |     65.84 μs |   1.307 μs |   3.374 μs |  0.29 |    0.01 |            121 |         - |        0.00 |
|     Entitas_MonoThread |      100000 |             0 |  4,852.70 μs |  88.526 μs | 161.874 μs | 21.20 |    0.76 |        768,940 |     115 B |      115.00 |
|    Entitas_MultiThread |      100000 |             0 |  1,762.72 μs |  12.491 μs |  11.073 μs |  7.68 |    0.07 |        768,436 |    1157 B |    1,157.00 |
|        LeopotamEcsLite |      100000 |             0 |  3,829.86 μs |  76.187 μs | 111.673 μs | 16.53 |    0.46 |          4,659 |       8 B |        8.00 |
|            LeopotamEcs |      100000 |             0 |    291.73 μs |   1.848 μs |   1.729 μs |  1.27 |    0.01 |             62 |       1 B |        1.00 |
|       MonoGameExtended |      100000 |             0 |  1,007.77 μs |   7.936 μs |   7.035 μs |  4.39 |    0.05 |        105,567 |     164 B |      164.00 |
|              SveltoECS |      100000 |             0 |    442.47 μs |   3.649 μs |   3.235 μs |  1.93 |    0.01 |             40 |       1 B |        1.00 |
|                        |             |               |              |            |            |       |         |                |           |             |
|                   Arch |      100000 |            10 |    191.27 μs |   1.575 μs |   1.315 μs |  0.17 |    0.00 |             44 |       1 B |        0.25 |
|  DefaultEcs_MonoThread |      100000 |            10 |  1,102.82 μs |   6.243 μs |   5.213 μs |  1.00 |    0.00 |        192,032 |       4 B |        1.00 |
| DefaultEcs_MultiThread |      100000 |            10 |    582.51 μs |  13.799 μs |  39.369 μs |  0.53 |    0.03 |        173,275 |       1 B |        0.25 |
|     Entitas_MonoThread |      100000 |            10 | 40,427.19 μs | 778.725 μs | 764.812 μs | 36.60 |    0.70 |        681,670 |     248 B |       62.00 |
|    Entitas_MultiThread |      100000 |            10 |  5,412.41 μs |  54.598 μs |  51.071 μs |  4.90 |    0.06 |        690,446 |    1171 B |      292.75 |
|        LeopotamEcsLite |      100000 |            10 | 10,980.33 μs | 217.226 μs | 318.407 μs |  9.90 |    0.30 |        544,379 |      33 B |        8.25 |
|            LeopotamEcs |      100000 |            10 |    283.61 μs |   3.255 μs |   3.044 μs |  0.26 |    0.00 |          3,547 |       1 B |        0.25 |
|       MonoGameExtended |      100000 |            10 |  4,331.53 μs |  18.075 μs |  15.093 μs |  3.93 |    0.03 |        795,364 |     177 B |       44.25 |
|              SveltoECS |      100000 |            10 |           NA |         NA |         NA |     ? |       ? |              - |         - |           ? |

Benchmarks with issues:
  SystemWithThreeComponents.SveltoECS: DefaultJob [EntityCount=100000, EntityPadding=10]

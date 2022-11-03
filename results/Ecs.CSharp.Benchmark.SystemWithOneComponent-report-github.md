``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.18363.2274/1909/November2019Update/19H2)
Intel Xeon W-2135 CPU 3.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


```
|                                 Method | EntityCount | EntityPadding |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD | CacheMisses/Op | Allocated | Alloc Ratio |
|--------------------------------------- |------------ |-------------- |-------------:|-----------:|-----------:|-------------:|-------:|--------:|---------------:|----------:|------------:|
|                                   Arch |      100000 |             0 |    183.94 μs |   0.659 μs |   0.584 μs |    183.81 μs |   3.77 |    0.06 |             23 |         - |          NA |
|  DefaultEcs_ComponentSystem_MonoThread |      100000 |             0 |     48.74 μs |   0.877 μs |   0.732 μs |     48.57 μs |   1.00 |    0.00 |              3 |         - |          NA |
| DefaultEcs_ComponentSystem_MultiThread |      100000 |             0 |     49.77 μs |   2.814 μs |   7.983 μs |     48.14 μs |   1.10 |    0.21 |             22 |         - |          NA |
|  DefaultEcs_EntitySetSystem_MonoThread |      100000 |             0 |    111.80 μs |   2.230 μs |   2.479 μs |    111.53 μs |   2.30 |    0.08 |             13 |         - |          NA |
| DefaultEcs_EntitySetSystem_MultiThread |      100000 |             0 |    104.45 μs |   4.072 μs |  11.552 μs |    101.96 μs |   2.12 |    0.30 |             92 |         - |          NA |
|                     Entitas_MonoThread |      100000 |             0 |  7,113.32 μs | 125.106 μs | 117.024 μs |  7,155.88 μs | 145.79 |    3.60 |        642,582 |     109 B |          NA |
|                    Entitas_MultiThread |      100000 |             0 |  1,560.25 μs |  24.400 μs |  22.824 μs |  1,563.59 μs |  31.98 |    0.57 |        633,362 |    1155 B |          NA |
|                        LeopotamEcsLite |      100000 |             0 |  1,276.47 μs |  24.340 μs |  29.891 μs |  1,277.13 μs |  26.19 |    0.77 |            433 |       3 B |          NA |
|                            LeopotamEcs |      100000 |             0 |     90.81 μs |   1.677 μs |   2.239 μs |     91.06 μs |   1.87 |    0.05 |              9 |         - |          NA |
|                       MonoGameExtended |      100000 |             0 |    675.71 μs |   4.278 μs |   4.001 μs |    676.21 μs |  13.86 |    0.24 |         12,855 |     162 B |          NA |
|                              SveltoECS |      100000 |             0 |    181.96 μs |   0.618 μs |   0.578 μs |    181.70 μs |   3.73 |    0.06 |             14 |         - |          NA |
|                                        |             |               |              |            |            |              |        |         |                |           |             |
|                                   Arch |      100000 |            10 |    148.62 μs |   2.939 μs |   5.936 μs |    148.54 μs |   3.02 |    0.17 |             19 |         - |          NA |
|  DefaultEcs_ComponentSystem_MonoThread |      100000 |            10 |     49.37 μs |   0.960 μs |   1.706 μs |     49.04 μs |   1.00 |    0.00 |              4 |         - |          NA |
| DefaultEcs_ComponentSystem_MultiThread |      100000 |            10 |     51.81 μs |   4.506 μs |  12.927 μs |     50.88 μs |   1.09 |    0.25 |             19 |         - |          NA |
|  DefaultEcs_EntitySetSystem_MonoThread |      100000 |            10 |    224.92 μs |   4.374 μs |   5.038 μs |    225.00 μs |   4.49 |    0.11 |          1,318 |         - |          NA |
| DefaultEcs_EntitySetSystem_MultiThread |      100000 |            10 |    138.98 μs |   7.673 μs |  21.766 μs |    136.77 μs |   2.77 |    0.54 |          1,303 |         - |          NA |
|                     Entitas_MonoThread |      100000 |            10 | 27,539.43 μs | 335.745 μs | 314.056 μs | 27,572.40 μs | 546.64 |   19.49 |        351,497 |     148 B |          NA |
|                    Entitas_MultiThread |      100000 |            10 |  4,221.82 μs |  50.707 μs |  44.950 μs |  4,219.27 μs |  83.58 |    2.26 |        289,693 |    1165 B |          NA |
|                        LeopotamEcsLite |      100000 |            10 |  3,771.94 μs |  73.889 μs | 140.581 μs |  3,780.66 μs |  76.65 |    3.92 |        306,618 |      11 B |          NA |
|                            LeopotamEcs |      100000 |            10 |     87.91 μs |   1.740 μs |   3.963 μs |     85.81 μs |   1.82 |    0.09 |             12 |         - |          NA |
|                       MonoGameExtended |      100000 |            10 |  2,482.25 μs |  26.660 μs |  23.634 μs |  2,480.63 μs |  49.15 |    1.53 |        338,954 |     165 B |          NA |
|                              SveltoECS |      100000 |            10 |    171.79 μs |   1.323 μs |   1.033 μs |    172.05 μs |   3.42 |    0.10 |             15 |         - |          NA |

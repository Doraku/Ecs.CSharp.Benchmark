``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.18363.2274/1909/November2019Update/19H2)
Intel Xeon W-2135 CPU 3.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|                                 Method | EntityCount | EntityPadding |         Mean |      Error |     StdDev |  Ratio | RatioSD | CacheMisses/Op | Allocated | Alloc Ratio |
|--------------------------------------- |------------ |-------------- |-------------:|-----------:|-----------:|-------:|--------:|---------------:|----------:|------------:|
|                                   Arch |      100000 |             0 |     47.29 μs |   0.146 μs |   0.129 μs |   0.96 |    0.03 |              5 |         - |          NA |
|  DefaultEcs_ComponentSystem_MonoThread |      100000 |             0 |     48.81 μs |   0.976 μs |   1.833 μs |   1.00 |    0.00 |              3 |         - |          NA |
| DefaultEcs_ComponentSystem_MultiThread |      100000 |             0 |     49.11 μs |   0.976 μs |   1.603 μs |   1.01 |    0.06 |              3 |         - |          NA |
|  DefaultEcs_EntitySetSystem_MonoThread |      100000 |             0 |     97.52 μs |   0.329 μs |   0.308 μs |   1.98 |    0.06 |             16 |         - |          NA |
| DefaultEcs_EntitySetSystem_MultiThread |      100000 |             0 |     56.92 μs |   1.087 μs |   1.116 μs |   1.16 |    0.04 |             48 |         - |          NA |
|                     Entitas_MonoThread |      100000 |             0 |  7,731.18 μs | 154.481 μs | 151.721 μs | 157.85 |    5.95 |        656,836 |     109 B |          NA |
|                    Entitas_MultiThread |      100000 |             0 |  1,731.07 μs |  14.332 μs |  12.705 μs |  35.25 |    1.09 |        659,308 |    1155 B |          NA |
|                        LeopotamEcsLite |      100000 |             0 |  1,216.38 μs |  24.296 μs |  41.909 μs |  24.96 |    1.38 |            403 |       3 B |          NA |
|                            LeopotamEcs |      100000 |             0 |     88.80 μs |   1.409 μs |   2.681 μs |   1.82 |    0.09 |              8 |         - |          NA |
|                       MonoGameExtended |      100000 |             0 |    724.49 μs |  14.143 μs |  19.826 μs |  14.82 |    0.63 |         10,379 |     161 B |          NA |
|                                 RelEcs |      100000 |             0 |    441.76 μs |   8.687 μs |  18.133 μs |   9.06 |    0.53 |         19,148 |     121 B |          NA |
|                              SveltoECS |      100000 |             0 |    122.66 μs |   2.437 μs |   5.598 μs |   2.53 |    0.17 |             11 |         - |          NA |
|                                        |             |               |              |            |            |        |         |                |           |             |
|                                   Arch |      100000 |            10 |     50.22 μs |   0.988 μs |   1.782 μs |   1.10 |    0.03 |              5 |         - |          NA |
|  DefaultEcs_ComponentSystem_MonoThread |      100000 |            10 |     45.36 μs |   0.099 μs |   0.083 μs |   1.00 |    0.00 |              3 |         - |          NA |
| DefaultEcs_ComponentSystem_MultiThread |      100000 |            10 |     48.77 μs |   0.966 μs |   2.314 μs |   1.04 |    0.05 |              3 |         - |          NA |
|  DefaultEcs_EntitySetSystem_MonoThread |      100000 |            10 |    217.01 μs |   4.259 μs |   8.103 μs |   4.73 |    0.10 |            949 |         - |          NA |
| DefaultEcs_EntitySetSystem_MultiThread |      100000 |            10 |    110.47 μs |   4.168 μs |  11.825 μs |   2.28 |    0.18 |          1,197 |         - |          NA |
|                     Entitas_MonoThread |      100000 |            10 | 27,109.23 μs | 423.937 μs | 354.007 μs | 597.68 |    8.35 |        355,772 |     148 B |          NA |
|                    Entitas_MultiThread |      100000 |            10 |  3,711.01 μs |  72.752 μs |  64.493 μs |  81.82 |    1.44 |        298,173 |    1159 B |          NA |
|                        LeopotamEcsLite |      100000 |            10 |  3,684.60 μs |  73.366 μs |  81.546 μs |  81.20 |    2.05 |        296,765 |       5 B |          NA |
|                            LeopotamEcs |      100000 |            10 |     88.92 μs |   1.728 μs |   2.840 μs |   1.97 |    0.06 |              7 |         - |          NA |
|                       MonoGameExtended |      100000 |            10 |  2,867.97 μs |  51.590 μs |  68.871 μs |  63.31 |    1.69 |        345,912 |     165 B |          NA |
|                                 RelEcs |      100000 |            10 |  1,404.83 μs |  27.577 μs |  45.309 μs |  31.33 |    1.24 |        162,074 |     123 B |          NA |
|                              SveltoECS |      100000 |            10 |    122.13 μs |   2.428 μs |   3.989 μs |   2.66 |    0.07 |              7 |         - |          NA |

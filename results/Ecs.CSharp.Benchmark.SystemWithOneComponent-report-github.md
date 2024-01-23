```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3930/22H2/2022Update)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX


```
| Method                                 | EntityCount | EntityPadding | Mean        | Error     | StdDev    | Gen0   | CacheMisses/Op | Allocated |
|--------------------------------------- |------------ |-------------- |------------:|----------:|----------:|-------:|---------------:|----------:|
| Arch_MonoThread                        | 100000      | 0             |    61.77 μs |  0.013 μs |  0.011 μs |      - |              2 |         - |
| Arch_MultiThread                       | 100000      | 0             |    29.30 μs |  0.012 μs |  0.011 μs |      - |              1 |         - |
| DefaultEcs_ComponentSystem_MonoThread  | 100000      | 0             |    56.25 μs |  0.008 μs |  0.008 μs |      - |              1 |         - |
| DefaultEcs_ComponentSystem_MultiThread | 100000      | 0             |    15.21 μs |  0.067 μs |  0.060 μs |      - |              1 |         - |
| DefaultEcs_EntitySetSystem_MonoThread  | 100000      | 0             |   118.02 μs |  0.021 μs |  0.020 μs |      - |              3 |         - |
| DefaultEcs_EntitySetSystem_MultiThread | 100000      | 0             |    31.55 μs |  0.137 μs |  0.107 μs |      - |              3 |         - |
| FrifloEngineEcs_MonoThread             | 100000      | 0             |    56.43 μs |  0.021 μs |  0.018 μs | 0.0610 |              3 |     208 B |
| FrifloEngineEcs_SIMD_MonoThread        | 100000      | 0             |    28.78 μs |  0.020 μs |  0.015 μs | 0.0610 |              2 |     208 B |
| HypEcs_MonoThread                      | 100000      | 0             |    56.46 μs |  0.006 μs |  0.005 μs |      - |              1 |      72 B |
| HypEcs_MultiThread                     | 100000      | 0             |    58.95 μs |  0.052 μs |  0.046 μs | 0.4883 |             15 |    1832 B |
| LeopotamEcs                            | 100000      | 0             |   135.90 μs |  0.025 μs |  0.022 μs |      - |              5 |         - |
| LeopotamEcsLite                        | 100000      | 0             | 1,850.38 μs |  0.312 μs |  0.276 μs |      - |            124 |       3 B |
| MonoGameExtended                       | 100000      | 0             |   536.11 μs |  1.050 μs |  0.931 μs |      - |         10,860 |     161 B |
| Morpeh_Direct                          | 100000      | 0             | 2,872.35 μs |  1.397 μs |  1.239 μs |      - |          4,500 |       6 B |
| Morpeh_Stash                           | 100000      | 0             | 1,034.99 μs |  0.379 μs |  0.336 μs |      - |          4,665 |       3 B |
| RelEcs                                 | 100000      | 0             |   567.56 μs |  2.466 μs |  2.307 μs |      - |         16,088 |     121 B |
| SveltoECS                              | 100000      | 0             |   197.01 μs |  0.022 μs |  0.018 μs |      - |              4 |         - |
|                                        |             |               |             |           |           |        |                |           |
| Arch_MonoThread                        | 100000      | 10            |    61.75 μs |  0.033 μs |  0.029 μs |      - |              2 |         - |
| Arch_MultiThread                       | 100000      | 10            |    29.50 μs |  0.018 μs |  0.014 μs |      - |              1 |         - |
| DefaultEcs_ComponentSystem_MonoThread  | 100000      | 10            |    56.25 μs |  0.008 μs |  0.007 μs |      - |              1 |         - |
| DefaultEcs_ComponentSystem_MultiThread | 100000      | 10            |    15.31 μs |  0.044 μs |  0.039 μs |      - |              1 |         - |
| DefaultEcs_EntitySetSystem_MonoThread  | 100000      | 10            |   244.32 μs |  0.188 μs |  0.176 μs |      - |          6,200 |       1 B |
| DefaultEcs_EntitySetSystem_MultiThread | 100000      | 10            |    83.35 μs |  0.318 μs |  0.298 μs |      - |          6,806 |         - |
| FrifloEngineEcs_MonoThread             | 100000      | 10            |    56.78 μs |  0.107 μs |  0.100 μs | 0.0610 |              2 |     208 B |
| FrifloEngineEcs_SIMD_MonoThread        | 100000      | 10            |    27.18 μs |  0.002 μs |  0.002 μs | 0.0610 |              2 |     208 B |
| HypEcs_MonoThread                      | 100000      | 10            |    56.78 μs |  0.170 μs |  0.159 μs |      - |              1 |      72 B |
| HypEcs_MultiThread                     | 100000      | 10            |    60.34 μs |  0.101 μs |  0.094 μs | 0.4883 |             12 |    1832 B |
| LeopotamEcs                            | 100000      | 10            |   136.22 μs |  0.022 μs |  0.020 μs |      - |              3 |         - |
| LeopotamEcsLite                        | 100000      | 10            | 4,020.44 μs |  2.468 μs |  2.061 μs |      - |         93,943 |      11 B |
| MonoGameExtended                       | 100000      | 10            | 1,996.01 μs | 28.602 μs | 23.884 μs |      - |        105,699 |     166 B |
| Morpeh_Direct                          | 100000      | 10            | 6,109.28 μs | 25.304 μs | 23.669 μs |      - |        167,142 |      11 B |
| Morpeh_Stash                           | 100000      | 10            | 3,980.00 μs | 20.224 μs | 18.917 μs |      - |        179,288 |      11 B |
| RelEcs                                 | 100000      | 10            | 1,235.45 μs |  5.167 μs |  4.580 μs |      - |         53,159 |     123 B |
| SveltoECS                              | 100000      | 10            |   197.04 μs |  0.026 μs |  0.023 μs |      - |              3 |         - |

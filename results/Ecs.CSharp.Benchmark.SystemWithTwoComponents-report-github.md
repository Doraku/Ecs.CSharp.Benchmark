```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3930/22H2/2022Update)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX


```
| Method                          | EntityCount | EntityPadding | Mean        | Error     | StdDev    | Gen0   | CacheMisses/Op | Allocated |
|-------------------------------- |------------ |-------------- |------------:|----------:|----------:|-------:|---------------:|----------:|
| Arch_MonoThread                 | 100000      | 0             |   174.10 μs |  0.072 μs |  0.060 μs |      - |              6 |         - |
| Arch_MultiThread                | 100000      | 0             |    36.09 μs |  0.020 μs |  0.018 μs |      - |              3 |         - |
| DefaultEcs_MonoThread           | 100000      | 0             |   200.28 μs |  0.024 μs |  0.021 μs |      - |              8 |         - |
| DefaultEcs_MultiThread          | 100000      | 0             |    53.54 μs |  0.083 μs |  0.074 μs |      - |             32 |         - |
| FrifloEngineEcs_MonoThread      | 100000      | 0             |    84.63 μs |  0.098 μs |  0.092 μs |      - |              3 |     216 B |
| FrifloEngineEcs_SIMD_MonoThread | 100000      | 0             |    32.38 μs |  0.002 μs |  0.001 μs | 0.0610 |              3 |     216 B |
| HypEcs_MonoThread               | 100000      | 0             |    57.90 μs |  0.007 μs |  0.006 μs |      - |              2 |     112 B |
| HypEcs_MultiThread              | 100000      | 0             |    60.35 μs |  0.036 μs |  0.030 μs | 0.4883 |             13 |    1872 B |
| LeopotamEcs                     | 100000      | 0             |   231.52 μs |  0.033 μs |  0.028 μs |      - |              6 |         - |
| LeopotamEcsLite                 | 100000      | 0             | 3,865.86 μs |  1.004 μs |  0.890 μs |      - |            607 |       6 B |
| MonoGameExtended                | 100000      | 0             |   827.06 μs |  0.933 μs |  0.779 μs |      - |         23,761 |     161 B |
| Morpeh_Direct                   | 100000      | 0             | 4,653.57 μs |  2.505 μs |  2.220 μs |      - |          6,937 |      11 B |
| Morpeh_Stash                    | 100000      | 0             | 2,415.97 μs |  0.891 μs |  0.744 μs |      - |          7,613 |       6 B |
| RelEcs                          | 100000      | 0             |   628.46 μs |  1.983 μs |  1.758 μs |      - |         18,389 |     169 B |
| SveltoECS                       | 100000      | 0             |   309.20 μs |  0.047 μs |  0.042 μs |      - |             12 |       1 B |
|                                 |             |               |             |           |           |        |                |           |
| Arch_MonoThread                 | 100000      | 10            |   174.20 μs |  0.089 μs |  0.070 μs |      - |              4 |         - |
| Arch_MultiThread                | 100000      | 10            |    35.99 μs |  0.019 μs |  0.017 μs |      - |              2 |         - |
| DefaultEcs_MonoThread           | 100000      | 10            |   887.92 μs |  0.502 μs |  0.419 μs |      - |         59,358 |       1 B |
| DefaultEcs_MultiThread          | 100000      | 10            |   684.24 μs |  0.889 μs |  0.743 μs |      - |         79,813 |       1 B |
| FrifloEngineEcs_MonoThread      | 100000      | 10            |    85.35 μs |  0.197 μs |  0.184 μs |      - |              3 |     216 B |
| FrifloEngineEcs_SIMD_MonoThread | 100000      | 10            |    39.45 μs |  0.007 μs |  0.006 μs | 0.0610 |              3 |     216 B |
| HypEcs_MonoThread               | 100000      | 10            |    58.99 μs |  0.004 μs |  0.003 μs |      - |              2 |     112 B |
| HypEcs_MultiThread              | 100000      | 10            |    61.48 μs |  0.041 μs |  0.036 μs | 0.4883 |             13 |    1872 B |
| LeopotamEcs                     | 100000      | 10            |   241.93 μs |  0.063 μs |  0.056 μs |      - |            152 |         - |
| LeopotamEcsLite                 | 100000      | 10            | 8,285.54 μs |  3.982 μs |  3.530 μs |      - |        110,260 |      22 B |
| MonoGameExtended                | 100000      | 10            | 2,869.26 μs | 10.787 μs | 10.091 μs |      - |        177,309 |     166 B |
| Morpeh_Direct                   | 100000      | 10            | 7,882.32 μs | 27.665 μs | 25.878 μs |      - |        180,485 |      22 B |
| Morpeh_Stash                    | 100000      | 10            | 7,363.95 μs |  2.661 μs |  2.222 μs |      - |        193,726 |      11 B |
| RelEcs                          | 100000      | 10            | 1,782.27 μs |  1.008 μs |  0.894 μs |      - |        106,469 |     171 B |
| SveltoECS                       | 100000      | 10            | 1,868.02 μs |  0.625 μs |  0.554 μs |      - |            600 |       3 B |

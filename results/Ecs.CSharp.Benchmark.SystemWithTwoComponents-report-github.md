``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX


```
|                 Method | EntityCount | EntityPadding |         Mean |      Error |     StdDev | CacheMisses/Op |   Gen0 | Allocated |
|----------------------- |------------ |-------------- |-------------:|-----------:|-----------:|---------------:|-------:|----------:|
|                   Arch |      100000 |             0 |     92.67 μs |   0.011 μs |   0.010 μs |              3 |      - |         - |
|  DefaultEcs_MonoThread |      100000 |             0 |    254.98 μs |   0.070 μs |   0.062 μs |             17 |      - |       1 B |
| DefaultEcs_MultiThread |      100000 |             0 |     67.94 μs |   0.334 μs |   0.296 μs |              9 |      - |         - |
|     Entitas_MonoThread |      100000 |             0 |  4,494.22 μs |   6.044 μs |   5.047 μs |        318,174 |      - |     109 B |
|    Entitas_MultiThread |      100000 |             0 |  2,955.39 μs |   3.150 μs |   2.630 μs |        342,963 |      - |     391 B |
|      HypEcs_MonoThread |      100000 |             0 |     57.91 μs |   0.012 μs |   0.011 μs |              1 |      - |      32 B |
|     HypEcs_MultiThread |      100000 |             0 |     60.54 μs |   0.032 μs |   0.030 μs |             11 | 0.5493 |    1768 B |
|            LeopotamEcs |      100000 |             0 |    237.02 μs |   0.027 μs |   0.021 μs |              6 |      - |         - |
|        LeopotamEcsLite |      100000 |             0 |  3,636.00 μs |   0.981 μs |   0.918 μs |            553 |      - |       5 B |
|       MonoGameExtended |      100000 |             0 |  1,123.42 μs |   1.547 μs |   1.371 μs |         10,375 |      - |     163 B |
|                 RelEcs |      100000 |             0 |    722.21 μs |   1.196 μs |   1.060 μs |         21,993 |      - |     169 B |
|              SveltoECS |      100000 |             0 |    337.62 μs |   0.040 μs |   0.033 μs |              6 |      - |       1 B |
|                        |             |               |              |            |            |                |        |           |
|                   Arch |      100000 |            10 |     92.74 μs |   0.174 μs |   0.163 μs |              3 |      - |         - |
|  DefaultEcs_MonoThread |      100000 |            10 |    877.28 μs |   2.192 μs |   2.051 μs |         54,839 |      - |       1 B |
| DefaultEcs_MultiThread |      100000 |            10 |    690.97 μs |   3.071 μs |   2.873 μs |         77,094 |      - |       1 B |
|     Entitas_MonoThread |      100000 |            10 | 26,543.85 μs | 115.030 μs |  96.055 μs |        529,161 |      - |     148 B |
|    Entitas_MultiThread |      100000 |            10 | 12,538.19 μs | 131.537 μs | 116.605 μs |        522,332 |      - |     410 B |
|      HypEcs_MonoThread |      100000 |            10 |     57.91 μs |   0.010 μs |   0.008 μs |              1 |      - |      32 B |
|     HypEcs_MultiThread |      100000 |            10 |     60.37 μs |   0.040 μs |   0.037 μs |             11 | 0.5493 |    1768 B |
|            LeopotamEcs |      100000 |            10 |    273.84 μs |   0.580 μs |   0.514 μs |          2,712 |      - |       1 B |
|        LeopotamEcsLite |      100000 |            10 |  8,343.90 μs |  35.922 μs |  33.602 μs |        109,420 |      - |      22 B |
|       MonoGameExtended |      100000 |            10 |  3,485.78 μs |   7.650 μs |   6.782 μs |        162,094 |      - |     165 B |
|                 RelEcs |      100000 |            10 |  1,784.00 μs |   5.825 μs |   5.449 μs |        104,660 |      - |     171 B |
|              SveltoECS |      100000 |            10 |  2,036.52 μs |   0.700 μs |   0.584 μs |            712 |      - |       5 B |

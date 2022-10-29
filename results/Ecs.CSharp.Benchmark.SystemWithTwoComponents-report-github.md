``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.18363.2274/1909/November2019Update/19H2)
Intel Xeon W-2135 CPU 3.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


```
|                 Method | EntityCount | EntityPadding |        Mean |     Error |    StdDev | Ratio | RatioSD | CacheMisses/Op | Allocated | Alloc Ratio |
|----------------------- |------------ |-------------- |------------:|----------:|----------:|------:|--------:|---------------:|----------:|------------:|
|  **DefaultEcs_MonoThread** |      **100000** |             **0** |    **157.2 μs** |   **3.08 μs** |   **5.71 μs** |  **1.00** |    **0.00** |             **29** |         **-** |          **NA** |
| DefaultEcs_MultiThread |      100000 |             0 |    109.0 μs |   4.29 μs |  12.30 μs |  0.67 |    0.09 |            164 |         - |          NA |
|     Entitas_MonoThread |      100000 |             0 |  4,882.7 μs |  81.59 μs |  68.13 μs | 30.63 |    1.10 |        716,791 |     101 B |          NA |
|    Entitas_MultiThread |      100000 |             0 |  1,651.9 μs |   7.54 μs |   7.06 μs | 10.42 |    0.39 |        707,777 |    1153 B |          NA |
|        LeopotamEcsLite |      100000 |             0 |  2,378.2 μs |  31.80 μs |  26.55 μs | 14.92 |    0.61 |          1,343 |       2 B |          NA |
|            LeopotamEcs |      100000 |             0 |    164.9 μs |   2.23 μs |   1.86 μs |  1.03 |    0.04 |             21 |         - |          NA |
|       MonoGameExtended |      100000 |             0 |    886.3 μs |  16.96 μs |  20.83 μs |  5.61 |    0.19 |         56,613 |     160 B |          NA |
|              SveltoECS |      100000 |             0 |    313.6 μs |   5.36 μs |   4.75 μs |  1.97 |    0.06 |             40 |         - |          NA |
|                        |             |               |             |           |           |       |         |                |           |             |
|  **DefaultEcs_MonoThread** |      **100000** |            **10** |    **775.5 μs** |  **14.59 μs** |  **12.93 μs** |  **1.00** |    **0.00** |        **109,847** |         **-** |          **NA** |
| DefaultEcs_MultiThread |      100000 |            10 |    326.5 μs |  11.11 μs |  31.89 μs |  0.41 |    0.02 |         68,719 |         - |          NA |
|     Entitas_MonoThread |      100000 |            10 | 38,354.4 μs | 740.59 μs | 656.51 μs | 49.47 |    1.25 |        536,610 |     138 B |          NA |
|    Entitas_MultiThread |      100000 |            10 |  5,064.9 μs |  31.31 μs |  29.28 μs |  6.54 |    0.10 |        501,385 |    1157 B |          NA |
|        LeopotamEcsLite |      100000 |            10 |  9,286.8 μs | 182.83 μs | 171.02 μs | 11.97 |    0.27 |        470,942 |       6 B |          NA |
|            LeopotamEcs |      100000 |            10 |    225.4 μs |   4.40 μs |   3.68 μs |  0.29 |    0.01 |          1,166 |         - |          NA |
|       MonoGameExtended |      100000 |            10 |  3,620.4 μs |  68.98 μs |  64.52 μs |  4.67 |    0.10 |        571,439 |     162 B |          NA |
|              SveltoECS |      100000 |            10 |  1,777.5 μs |  16.42 μs |  15.36 μs |  2.29 |    0.05 |          1,881 |       1 B |          NA |

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.18363.2274/1909/November2019Update/19H2)
Intel Xeon W-2135 CPU 3.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


```
|                 Method | EntityCount | EntityPadding |        Mean |     Error |    StdDev | Ratio | RatioSD | CacheMisses/Op | Allocated | Alloc Ratio |
|----------------------- |------------ |-------------- |------------:|----------:|----------:|------:|--------:|---------------:|----------:|------------:|
|  **DefaultEcs_MonoThread** |      **100000** |             **0** |    **266.2 μs** |   **5.31 μs** |   **9.01 μs** |  **1.00** |    **0.00** |             **80** |       **1 B** |        **1.00** |
| DefaultEcs_MultiThread |      100000 |             0 |    133.0 μs |   5.13 μs |  14.73 μs |  0.50 |    0.05 |            269 |         - |        0.00 |
|     Entitas_MonoThread |      100000 |             0 |  4,680.6 μs |  73.68 μs |  90.49 μs | 17.53 |    0.52 |        773,434 |     107 B |      107.00 |
|    Entitas_MultiThread |      100000 |             0 |  1,765.5 μs |  13.59 μs |  12.71 μs |  6.60 |    0.19 |        766,733 |    1155 B |    1,155.00 |
|        LeopotamEcsLite |      100000 |             0 |  3,710.8 μs |  29.35 μs |  24.50 μs | 13.94 |    0.37 |          4,623 |       4 B |        4.00 |
|            LeopotamEcs |      100000 |             0 |    303.2 μs |   5.32 μs |   7.96 μs |  1.14 |    0.05 |             53 |       1 B |        1.00 |
|       MonoGameExtended |      100000 |             0 |  1,056.7 μs |  20.78 μs |  25.52 μs |  3.96 |    0.11 |        105,329 |     162 B |      162.00 |
|              SveltoECS |      100000 |             0 |    450.7 μs |   6.18 μs |   5.78 μs |  1.69 |    0.06 |             46 |         - |        0.00 |
|                        |             |               |             |           |           |       |         |                |           |             |
|  **DefaultEcs_MonoThread** |      **100000** |            **10** |  **1,136.5 μs** |  **22.47 μs** |  **23.07 μs** |  **1.00** |    **0.00** |        **193,566** |       **2 B** |        **1.00** |
| DefaultEcs_MultiThread |      100000 |            10 |    537.6 μs |  19.07 μs |  54.10 μs |  0.48 |    0.05 |        174,656 |       1 B |        0.50 |
|     Entitas_MonoThread |      100000 |            10 | 41,350.9 μs | 680.17 μs | 636.24 μs | 36.37 |    0.66 |        702,114 |     166 B |       83.00 |
|    Entitas_MultiThread |      100000 |            10 |  5,553.8 μs |  52.50 μs |  49.11 μs |  4.89 |    0.11 |        692,560 |    1171 B |      585.50 |
|        LeopotamEcsLite |      100000 |            10 | 10,812.7 μs | 163.26 μs | 152.71 μs |  9.51 |    0.20 |        548,422 |      18 B |        9.00 |
|            LeopotamEcs |      100000 |            10 |    339.9 μs |   6.59 μs |   6.17 μs |  0.30 |    0.01 |          4,142 |       1 B |        0.50 |
|       MonoGameExtended |      100000 |            10 |  4,651.7 μs |  89.52 μs | 125.50 μs |  4.12 |    0.11 |        805,983 |     169 B |       84.50 |
|              SveltoECS |      100000 |            10 |          NA |        NA |        NA |     ? |       ? |              - |         - |           ? |

Benchmarks with issues:
  SystemWithThreeComponents.SveltoECS: DefaultJob [EntityCount=100000, EntityPadding=10]

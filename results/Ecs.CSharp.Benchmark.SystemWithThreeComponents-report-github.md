``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.18363.2274/1909/November2019Update/19H2)
Intel Xeon W-2135 CPU 3.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|                 Method | EntityCount | EntityPadding |         Mean |      Error |       StdDev | Ratio | RatioSD | CacheMisses/Op | Allocated | Alloc Ratio |
|----------------------- |------------ |-------------- |-------------:|-----------:|-------------:|------:|--------:|---------------:|----------:|------------:|
|                   Arch |      100000 |             0 |     78.14 μs |   0.548 μs |     0.458 μs |  0.33 |    0.00 |             33 |         - |          NA |
|  DefaultEcs_MonoThread |      100000 |             0 |    233.59 μs |   0.798 μs |     0.666 μs |  1.00 |    0.00 |             41 |         - |          NA |
| DefaultEcs_MultiThread |      100000 |             0 |     59.88 μs |   0.511 μs |     0.399 μs |  0.26 |    0.00 |             86 |         - |          NA |
|     Entitas_MonoThread |      100000 |             0 |  4,776.95 μs |  56.392 μs |    52.749 μs | 20.44 |    0.22 |        801,780 |     109 B |          NA |
|    Entitas_MultiThread |      100000 |             0 |  1,800.59 μs |   3.902 μs |     3.046 μs |  7.71 |    0.03 |        798,973 |    1155 B |          NA |
|        LeopotamEcsLite |      100000 |             0 |  3,552.39 μs |   6.349 μs |     5.939 μs | 15.21 |    0.04 |          2,191 |       5 B |          NA |
|            LeopotamEcs |      100000 |             0 |    288.91 μs |   0.578 μs |     0.513 μs |  1.24 |    0.00 |             49 |       1 B |          NA |
|       MonoGameExtended |      100000 |             0 |  1,028.00 μs |   4.134 μs |     3.866 μs |  4.40 |    0.02 |         99,811 |     163 B |          NA |
|                 RelEcs |      100000 |             0 |    712.04 μs |   6.003 μs |     5.616 μs |  3.05 |    0.03 |         67,633 |     217 B |          NA |
|              SveltoECS |      100000 |             0 |    319.39 μs |   1.050 μs |     0.982 μs |  1.37 |    0.01 |             33 |       1 B |          NA |
|                        |             |               |              |            |              |       |         |                |           |             |
|                   Arch |      100000 |            10 |     78.50 μs |   0.819 μs |     0.726 μs |  0.07 |    0.00 |             28 |         - |        0.00 |
|  DefaultEcs_MonoThread |      100000 |            10 |  1,118.10 μs |  18.650 μs |    15.574 μs |  1.00 |    0.00 |        193,674 |       3 B |        1.00 |
| DefaultEcs_MultiThread |      100000 |            10 |    401.71 μs |   4.266 μs |     3.562 μs |  0.36 |    0.01 |        174,438 |       1 B |        0.33 |
|     Entitas_MonoThread |      100000 |            10 | 36,904.37 μs | 736.621 μs | 1,677.660 μs | 33.59 |    0.97 |        683,925 |     201 B |       67.00 |
|    Entitas_MultiThread |      100000 |            10 |  5,156.75 μs | 102.659 μs |   118.222 μs |  4.62 |    0.16 |        720,776 |    1165 B |      388.33 |
|        LeopotamEcsLite |      100000 |            10 | 10,092.54 μs |  65.730 μs |    58.268 μs |  9.03 |    0.14 |        532,576 |      22 B |        7.33 |
|            LeopotamEcs |      100000 |            10 |    285.90 μs |   5.655 μs |     7.353 μs |  0.26 |    0.01 |          2,966 |       1 B |        0.33 |
|       MonoGameExtended |      100000 |            10 |  4,462.76 μs |  31.159 μs |    27.621 μs |  3.99 |    0.06 |        799,893 |     171 B |       57.00 |
|                 RelEcs |      100000 |            10 |  2,364.44 μs |  11.175 μs |     9.906 μs |  2.11 |    0.03 |        392,563 |     221 B |       73.67 |
|              SveltoECS |      100000 |            10 |           NA |         NA |           NA |     ? |       ? |              - |         - |           ? |

Benchmarks with issues:
  SystemWithThreeComponents.SveltoECS: DefaultJob [EntityCount=100000, EntityPadding=10]

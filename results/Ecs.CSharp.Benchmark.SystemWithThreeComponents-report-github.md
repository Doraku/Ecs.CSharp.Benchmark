``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX


```
|                 Method | EntityCount | EntityPadding |         Mean |      Error |     StdDev | CacheMisses/Op | Allocated |
|----------------------- |------------ |-------------- |-------------:|-----------:|-----------:|---------------:|----------:|
|        Arch_MonoThread |      100000 |             0 |    111.44 μs |   0.025 μs |   0.022 μs |              8 |         - |
|       Arch_MultiThread |      100000 |             0 |     41.68 μs |   0.061 μs |   0.054 μs |              7 |         - |
|  DefaultEcs_MonoThread |      100000 |             0 |    388.85 μs |   0.182 μs |   0.142 μs |             36 |       1 B |
| DefaultEcs_MultiThread |      100000 |             0 |    104.02 μs |   0.399 μs |   0.333 μs |             40 |         - |
|     Entitas_MonoThread |      100000 |             0 |  4,341.06 μs |   7.976 μs |   7.460 μs |        344,337 |     109 B |
|    Entitas_MultiThread |      100000 |             0 |  3,107.05 μs |  10.689 μs |   8.926 μs |        401,718 |     391 B |
|      HypEcs_MonoThread |      100000 |             0 |     85.27 μs |   0.012 μs |   0.011 μs |              3 |      32 B |
|     HypEcs_MultiThread |      100000 |             0 |     88.09 μs |   0.049 μs |   0.043 μs |             14 |    1768 B |
|            LeopotamEcs |      100000 |             0 |    788.61 μs |   0.211 μs |   0.165 μs |             38 |       1 B |
|        LeopotamEcsLite |      100000 |             0 |  5,533.31 μs |   4.068 μs |   3.805 μs |          1,515 |      11 B |
|       MonoGameExtended |      100000 |             0 |  1,373.25 μs |  27.121 μs |  27.851 μs |         24,487 |     163 B |
|                 RelEcs |      100000 |             0 |    939.20 μs |   1.915 μs |   1.791 μs |         38,063 |     217 B |
|              SveltoECS |      100000 |             0 |    450.23 μs |   0.060 μs |   0.056 μs |             13 |       1 B |
|                        |             |               |              |            |            |                |           |
|        Arch_MonoThread |      100000 |            10 |    111.59 μs |   0.432 μs |   0.404 μs |              6 |         - |
|       Arch_MultiThread |      100000 |            10 |     42.05 μs |   0.029 μs |   0.025 μs |              7 |         - |
|  DefaultEcs_MonoThread |      100000 |            10 |  1,248.00 μs |   1.669 μs |   1.480 μs |         72,302 |       3 B |
| DefaultEcs_MultiThread |      100000 |            10 |    970.12 μs |   3.348 μs |   2.968 μs |        119,385 |       1 B |
|     Entitas_MonoThread |      100000 |            10 | 19,309.45 μs | 121.756 μs | 113.891 μs |        624,546 |     148 B |
|    Entitas_MultiThread |      100000 |            10 |  9,456.08 μs | 138.433 μs | 122.718 μs |        620,781 |     410 B |
|      HypEcs_MonoThread |      100000 |            10 |     84.80 μs |   0.009 μs |   0.008 μs |              2 |      32 B |
|     HypEcs_MultiThread |      100000 |            10 |     87.68 μs |   0.066 μs |   0.058 μs |             17 |    1768 B |
|            LeopotamEcs |      100000 |            10 |    364.92 μs |   0.946 μs |   0.838 μs |          1,857 |       1 B |
|        LeopotamEcsLite |      100000 |            10 | 11,141.80 μs |  44.407 μs |  41.538 μs |        113,341 |      17 B |
|       MonoGameExtended |      100000 |            10 |  4,032.95 μs |   9.810 μs |   8.697 μs |        219,729 |     171 B |
|                 RelEcs |      100000 |            10 |  2,270.26 μs |   4.858 μs |   4.306 μs |        175,250 |     221 B |
|              SveltoECS |      100000 |            10 |           NA |         NA |         NA |              - |         - |

Benchmarks with issues:
  SystemWithThreeComponents.SveltoECS: DefaultJob [EntityCount=100000, EntityPadding=10]

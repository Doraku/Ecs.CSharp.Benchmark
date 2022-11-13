``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.18363.2274/1909/November2019Update/19H2)
Intel Xeon W-2135 CPU 3.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|                 Method | EntityCount |        Mean |     Error |    StdDev | Ratio | RatioSD | CacheMisses/Op | Allocated | Alloc Ratio |
|----------------------- |------------ |------------:|----------:|----------:|------:|--------:|---------------:|----------:|------------:|
|                   Arch |      100000 |    59.28 μs |  0.156 μs |  0.146 μs |  0.42 |    0.00 |              9 |         - |          NA |
|  DefaultEcs_MonoThread |      100000 |   142.02 μs |  0.507 μs |  0.423 μs |  1.00 |    0.00 |             30 |         - |          NA |
| DefaultEcs_MultiThread |      100000 |    53.95 μs |  0.896 μs |  0.880 μs |  0.38 |    0.01 |             55 |         - |          NA |
|     Entitas_MonoThread |      100000 | 5,410.08 μs | 47.232 μs | 44.180 μs | 38.14 |    0.37 |        773,501 |     112 B |          NA |
|    Entitas_MultiThread |      100000 | 1,727.58 μs |  4.033 μs |  3.575 μs | 12.17 |    0.04 |        769,941 |    1156 B |          NA |
|        LeopotamEcsLite |      100000 | 2,356.25 μs |  8.669 μs |  7.685 μs | 16.59 |    0.07 |            968 |       7 B |          NA |
|            LeopotamEcs |      100000 |   159.14 μs |  0.872 μs |  0.773 μs |  1.12 |    0.01 |             19 |         - |          NA |
|       MonoGameExtended |      100000 | 1,055.43 μs |  5.102 μs |  4.523 μs |  7.43 |    0.03 |         89,283 |     163 B |          NA |
|                 RelEcs |      100000 | 1,433.91 μs | 25.450 μs | 33.092 μs | 10.15 |    0.30 |        103,761 |     491 B |          NA |
|              SveltoECS |      100000 |   227.20 μs |  0.720 μs |  0.562 μs |  1.60 |    0.00 |             21 |         - |          NA |

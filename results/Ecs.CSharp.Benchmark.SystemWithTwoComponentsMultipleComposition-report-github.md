``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX


```
|                 Method | EntityCount |        Mean |     Error |    StdDev | CacheMisses/Op | Allocated |
|----------------------- |------------ |------------:|----------:|----------:|---------------:|----------:|
|                   Arch |      100000 |    91.47 μs |  0.116 μs |  0.102 μs |              6 |         - |
|       Arch_MultiThread |      100000 |    59.92 μs |  0.126 μs |  0.118 μs |              9 |         - |
|  DefaultEcs_MonoThread |      100000 |   259.89 μs |  0.050 μs |  0.044 μs |              9 |       1 B |
| DefaultEcs_MultiThread |      100000 |    69.55 μs |  0.285 μs |  0.253 μs |              6 |         - |
|     Entitas_MonoThread |      100000 | 4,839.97 μs | 31.857 μs | 29.799 μs |        340,754 |     112 B |
|    Entitas_MultiThread |      100000 | 3,101.55 μs |  6.627 μs |  5.874 μs |        371,259 |     392 B |
|      HypEcs_MonoThread |      100000 |    57.99 μs |  0.008 μs |  0.007 μs |              1 |      32 B |
|     HypEcs_MultiThread |      100000 |    21.70 μs |  0.124 μs |  0.116 μs |             10 |    2294 B |
|            LeopotamEcs |      100000 |   241.88 μs |  0.038 μs |  0.035 μs |              4 |         - |
|        LeopotamEcsLite |      100000 | 3,630.12 μs |  1.905 μs |  1.782 μs |            566 |       7 B |
|       MonoGameExtended |      100000 | 1,230.32 μs |  1.309 μs |  1.161 μs |         24,422 |     163 B |
|                 RelEcs |      100000 | 1,581.50 μs |  3.828 μs |  3.196 μs |         83,004 |     491 B |
|              SveltoECS |      100000 |   337.63 μs |  0.057 μs |  0.054 μs |              6 |       1 B |

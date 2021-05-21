``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.985 (2004/May2020Update/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  DefaultJob : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT


```
|                                 Method | EntityCount | EntityPadding |         Mean |      Error |     StdDev |  Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------------- |------------ |-------------- |-------------:|-----------:|-----------:|-------:|--------:|------:|------:|------:|----------:|
|  **DefaultEcs_ComponentSystem_MonoThread** |      **100000** |             **0** |     **83.90 μs** |   **0.010 μs** |   **0.009 μs** |   **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| DefaultEcs_ComponentSystem_MultiThread |      100000 |             0 |     26.28 μs |   0.119 μs |   0.093 μs |   0.31 |    0.00 |     - |     - |     - |         - |
|  DefaultEcs_EntitySetSystem_MonoThread |      100000 |             0 |    192.73 μs |   0.220 μs |   0.184 μs |   2.30 |    0.00 |     - |     - |     - |         - |
| DefaultEcs_EntitySetSystem_MultiThread |      100000 |             0 |     50.96 μs |   0.202 μs |   0.169 μs |   0.61 |    0.00 |     - |     - |     - |         - |
|                     Entitas_MonoThread |      100000 |             0 |  4,469.70 μs |   6.761 μs |   5.279 μs |  53.27 |    0.06 |     - |     - |     - |     110 B |
|                    Entitas_MultiThread |      100000 |             0 |  2,706.82 μs |  13.668 μs |  12.785 μs |  32.25 |    0.16 |     - |     - |     - |     471 B |
|                 LeopotamEcs_MonoThread |      100000 |             0 |    149.98 μs |   0.005 μs |   0.004 μs |   1.79 |    0.00 |     - |     - |     - |         - |
|                LeopotamEcs_MultiThread |      100000 |             0 |     73.21 μs |   0.074 μs |   0.065 μs |   0.87 |    0.00 |     - |     - |     - |         - |
|             LeopotamEcsLite_MonoThread |      100000 |             0 |    130.60 μs |   0.017 μs |   0.015 μs |   1.56 |    0.00 |     - |     - |     - |         - |
|            LeopotamEcsLite_MultiThread |      100000 |             0 |     55.53 μs |   0.642 μs |   0.600 μs |   0.66 |    0.01 |     - |     - |     - |      96 B |
|                       MonoGameExtended |      100000 |             0 |    971.41 μs |   0.275 μs |   0.244 μs |  11.58 |    0.00 |     - |     - |     - |     168 B |
|                              SveltoECS |      100000 |             0 |     83.91 μs |   0.009 μs |   0.009 μs |   1.00 |    0.00 |     - |     - |     - |         - |
|                                        |             |               |              |            |            |        |         |       |       |       |           |
|  **DefaultEcs_ComponentSystem_MonoThread** |      **100000** |            **10** |     **83.97 μs** |   **0.020 μs** |   **0.018 μs** |   **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| DefaultEcs_ComponentSystem_MultiThread |      100000 |            10 |     25.91 μs |   0.091 μs |   0.071 μs |   0.31 |    0.00 |     - |     - |     - |         - |
|  DefaultEcs_EntitySetSystem_MonoThread |      100000 |            10 |    253.54 μs |   0.784 μs |   0.733 μs |   3.02 |    0.01 |     - |     - |     - |         - |
| DefaultEcs_EntitySetSystem_MultiThread |      100000 |            10 |     73.91 μs |   0.644 μs |   0.602 μs |   0.88 |    0.01 |     - |     - |     - |         - |
|                     Entitas_MonoThread |      100000 |            10 | 18,878.23 μs |  51.506 μs |  45.659 μs | 224.82 |    0.53 |     - |     - |     - |         - |
|                    Entitas_MultiThread |      100000 |            10 |  8,569.10 μs | 169.113 μs | 201.317 μs | 101.52 |    2.33 |     - |     - |     - |     512 B |
|                 LeopotamEcs_MonoThread |      100000 |            10 |    145.10 μs |   0.012 μs |   0.011 μs |   1.73 |    0.00 |     - |     - |     - |         - |
|                LeopotamEcs_MultiThread |      100000 |            10 |     73.71 μs |   0.098 μs |   0.087 μs |   0.88 |    0.00 |     - |     - |     - |         - |
|             LeopotamEcsLite_MonoThread |      100000 |            10 |    505.20 μs |   2.350 μs |   2.083 μs |   6.02 |    0.02 |     - |     - |     - |         - |
|            LeopotamEcsLite_MultiThread |      100000 |            10 |    319.45 μs |   1.224 μs |   1.085 μs |   3.80 |    0.01 |     - |     - |     - |     100 B |
|                       MonoGameExtended |      100000 |            10 |  2,686.39 μs |  12.512 μs |  11.704 μs |  31.99 |    0.15 |     - |     - |     - |     192 B |
|                              SveltoECS |      100000 |            10 |     83.91 μs |   0.017 μs |   0.013 μs |   1.00 |    0.00 |     - |     - |     - |         - |

``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  DefaultJob : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT


```
|                                 Method | EntityCount | EntityPadding |         Mean |      Error |    StdDev |  Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------------- |------------ |-------------- |-------------:|-----------:|----------:|-------:|--------:|------:|------:|------:|----------:|
|  **DefaultEcs_ComponentSystem_MonoThread** |      **100000** |             **0** |     **83.93 μs** |   **0.048 μs** |  **0.037 μs** |   **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| DefaultEcs_ComponentSystem_MultiThread |      100000 |             0 |     25.78 μs |   0.128 μs |  0.119 μs |   0.31 |    0.00 |     - |     - |     - |         - |
|  DefaultEcs_EntitySetSystem_MonoThread |      100000 |             0 |    190.61 μs |   0.052 μs |  0.044 μs |   2.27 |    0.00 |     - |     - |     - |         - |
| DefaultEcs_EntitySetSystem_MultiThread |      100000 |             0 |     51.86 μs |   0.108 μs |  0.101 μs |   0.62 |    0.00 |     - |     - |     - |         - |
|                     Entitas_MonoThread |      100000 |             0 |  4,520.46 μs |  81.463 μs | 87.164 μs |  54.16 |    1.18 |     - |     - |     - |     128 B |
|                    Entitas_MultiThread |      100000 |             0 |  2,719.71 μs |  17.769 μs | 15.751 μs |  32.41 |    0.19 |     - |     - |     - |     473 B |
|                 LeopotamEcs_MonoThread |      100000 |             0 |    145.29 μs |   0.020 μs |  0.017 μs |   1.73 |    0.00 |     - |     - |     - |         - |
|                LeopotamEcs_MultiThread |      100000 |             0 |     72.52 μs |   0.497 μs |  0.465 μs |   0.86 |    0.01 |     - |     - |     - |         - |
|             LeopotamEcsLite_MonoThread |      100000 |             0 |    131.87 μs |   0.008 μs |  0.007 μs |   1.57 |    0.00 |     - |     - |     - |         - |
|            LeopotamEcsLite_MultiThread |      100000 |             0 |     55.08 μs |   0.635 μs |  0.594 μs |   0.66 |    0.01 |     - |     - |     - |      96 B |
|                       MonoGameExtended |      100000 |             0 |    972.02 μs |   0.322 μs |  0.301 μs |  11.58 |    0.01 |     - |     - |     - |     168 B |
|                              SveltoECS |      100000 |             0 |     83.90 μs |   0.006 μs |  0.005 μs |   1.00 |    0.00 |     - |     - |     - |         - |
|                                        |             |               |              |            |           |        |         |       |       |       |           |
|  **DefaultEcs_ComponentSystem_MonoThread** |      **100000** |            **10** |     **83.97 μs** |   **0.023 μs** |  **0.021 μs** |   **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| DefaultEcs_ComponentSystem_MultiThread |      100000 |            10 |     25.72 μs |   0.117 μs |  0.104 μs |   0.31 |    0.00 |     - |     - |     - |         - |
|  DefaultEcs_EntitySetSystem_MonoThread |      100000 |            10 |    253.83 μs |   0.918 μs |  0.859 μs |   3.02 |    0.01 |     - |     - |     - |         - |
| DefaultEcs_EntitySetSystem_MultiThread |      100000 |            10 |     72.51 μs |   0.416 μs |  0.368 μs |   0.86 |    0.00 |     - |     - |     - |         - |
|                     Entitas_MonoThread |      100000 |            10 | 19,003.91 μs |  45.352 μs | 40.204 μs | 226.32 |    0.45 |     - |     - |     - |         - |
|                    Entitas_MultiThread |      100000 |            10 |  8,394.46 μs | 117.028 μs | 97.723 μs |  99.97 |    1.17 |     - |     - |     - |     512 B |
|                 LeopotamEcs_MonoThread |      100000 |            10 |    145.16 μs |   0.004 μs |  0.004 μs |   1.73 |    0.00 |     - |     - |     - |         - |
|                LeopotamEcs_MultiThread |      100000 |            10 |     73.03 μs |   0.503 μs |  0.471 μs |   0.87 |    0.01 |     - |     - |     - |         - |
|             LeopotamEcsLite_MonoThread |      100000 |            10 |    504.96 μs |   1.758 μs |  1.644 μs |   6.01 |    0.02 |     - |     - |     - |         - |
|            LeopotamEcsLite_MultiThread |      100000 |            10 |    318.61 μs |   0.585 μs |  0.519 μs |   3.79 |    0.01 |     - |     - |     - |     100 B |
|                       MonoGameExtended |      100000 |            10 |  2,689.39 μs |   7.625 μs |  6.759 μs |  32.03 |    0.08 |     - |     - |     - |     192 B |
|                              SveltoECS |      100000 |            10 |     83.90 μs |   0.005 μs |  0.004 μs |   1.00 |    0.00 |     - |     - |     - |         - |

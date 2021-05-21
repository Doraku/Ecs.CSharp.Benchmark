``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.985 (2004/May2020Update/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  DefaultJob : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT


```
|                      Method | EntityCount | EntityPadding |         Mean |      Error |       StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------------ |-------------- |-------------:|-----------:|-------------:|------:|--------:|------:|------:|------:|----------:|
|       **DefaultEcs_MonoThread** |      **100000** |             **0** |    **302.91 μs** |   **0.031 μs** |     **0.026 μs** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|      DefaultEcs_MultiThread |      100000 |             0 |     80.18 μs |   0.285 μs |     0.253 μs |  0.26 |    0.00 |     - |     - |     - |         - |
|          Entitas_MonoThread |      100000 |             0 |  4,150.86 μs |  14.779 μs |    13.824 μs | 13.70 |    0.05 |     - |     - |     - |     128 B |
|         Entitas_MultiThread |      100000 |             0 |  2,859.25 μs |  22.948 μs |    21.466 μs |  9.44 |    0.07 |     - |     - |     - |     480 B |
|      LeopotamEcs_MonoThread |      100000 |             0 |    235.29 μs |   0.015 μs |     0.012 μs |  0.78 |    0.00 |     - |     - |     - |         - |
|     LeopotamEcs_MultiThread |      100000 |             0 |    110.69 μs |   0.248 μs |     0.193 μs |  0.37 |    0.00 |     - |     - |     - |         - |
|  LeopotamEcsLite_MonoThread |      100000 |             0 |    187.98 μs |   0.013 μs |     0.012 μs |  0.62 |    0.00 |     - |     - |     - |         - |
| LeopotamEcsLite_MultiThread |      100000 |             0 |     63.55 μs |   0.036 μs |     0.030 μs |  0.21 |    0.00 |     - |     - |     - |     105 B |
|            MonoGameExtended |      100000 |             0 |  1,093.23 μs |   0.655 μs |     0.581 μs |  3.61 |    0.00 |     - |     - |     - |     176 B |
|                   SveltoECS |      100000 |             0 |     88.89 μs |   0.004 μs |     0.004 μs |  0.29 |    0.00 |     - |     - |     - |         - |
|                             |             |               |              |            |              |       |         |       |       |       |           |
|       **DefaultEcs_MonoThread** |      **100000** |            **10** |    **845.56 μs** |   **1.598 μs** |     **1.495 μs** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|      DefaultEcs_MultiThread |      100000 |            10 |    539.44 μs |   2.405 μs |     3.211 μs |  0.64 |    0.00 |     - |     - |     - |         - |
|          Entitas_MonoThread |      100000 |            10 | 21,959.14 μs | 680.831 μs | 2,007.445 μs | 25.69 |    1.94 |     - |     - |     - |         - |
|         Entitas_MultiThread |      100000 |            10 |  9,173.08 μs | 181.608 μs |   468.788 μs | 10.93 |    0.68 |     - |     - |     - |     512 B |
|      LeopotamEcs_MonoThread |      100000 |            10 |    269.31 μs |   0.775 μs |     0.725 μs |  0.32 |    0.00 |     - |     - |     - |         - |
|     LeopotamEcs_MultiThread |      100000 |            10 |    118.94 μs |   0.114 μs |     0.101 μs |  0.14 |    0.00 |     - |     - |     - |         - |
|  LeopotamEcsLite_MonoThread |      100000 |            10 |  1,110.05 μs |   2.853 μs |     2.529 μs |  1.31 |    0.00 |     - |     - |     - |         - |
| LeopotamEcsLite_MultiThread |      100000 |            10 |    361.47 μs |   0.442 μs |     0.345 μs |  0.43 |    0.00 |     - |     - |     - |     108 B |
|            MonoGameExtended |      100000 |            10 |  3,439.19 μs |   9.077 μs |     8.491 μs |  4.07 |    0.01 |     - |     - |     - |     192 B |
|                   SveltoECS |      100000 |            10 |    524.54 μs |   0.179 μs |     0.158 μs |  0.62 |    0.00 |     - |     - |     - |         - |

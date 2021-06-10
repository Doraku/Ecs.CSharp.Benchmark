``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  DefaultJob : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT


```
|                      Method | EntityCount | EntityPadding |         Mean |      Error |     StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------------ |-------------- |-------------:|-----------:|-----------:|------:|--------:|------:|------:|------:|----------:|
|       **DefaultEcs_MonoThread** |      **100000** |             **0** |    **691.82 μs** |   **0.106 μs** |   **0.099 μs** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|      DefaultEcs_MultiThread |      100000 |             0 |    183.92 μs |   1.577 μs |   1.398 μs |  0.27 |    0.00 |     - |     - |     - |         - |
|          Entitas_MonoThread |      100000 |             0 |  3,983.98 μs |  17.097 μs |  15.156 μs |  5.76 |    0.02 |     - |     - |     - |     128 B |
|         Entitas_MultiThread |      100000 |             0 |  2,959.12 μs |  14.792 μs |  13.837 μs |  4.28 |    0.02 |     - |     - |     - |     480 B |
|      LeopotamEcs_MonoThread |      100000 |             0 |    777.50 μs |   0.138 μs |   0.129 μs |  1.12 |    0.00 |     - |     - |     - |         - |
|     LeopotamEcs_MultiThread |      100000 |             0 |    278.20 μs |   0.616 μs |   0.576 μs |  0.40 |    0.00 |     - |     - |     - |         - |
|  LeopotamEcsLite_MonoThread |      100000 |             0 |    259.18 μs |   0.033 μs |   0.031 μs |  0.37 |    0.00 |     - |     - |     - |         - |
| LeopotamEcsLite_MultiThread |      100000 |             0 |     77.16 μs |   0.610 μs |   0.571 μs |  0.11 |    0.00 |     - |     - |     - |     113 B |
|            MonoGameExtended |      100000 |             0 |  1,265.21 μs |   0.944 μs |   0.883 μs |  1.83 |    0.00 |     - |     - |     - |     176 B |
|                   SveltoECS |      100000 |             0 |    119.53 μs |   0.011 μs |   0.009 μs |  0.17 |    0.00 |     - |     - |     - |         - |
|                             |             |               |              |            |            |       |         |       |       |       |           |
|       **DefaultEcs_MonoThread** |      **100000** |            **10** |  **1,165.21 μs** |   **3.080 μs** |   **2.572 μs** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
|      DefaultEcs_MultiThread |      100000 |            10 |    988.02 μs |  13.066 μs |  11.582 μs |  0.85 |    0.01 |     - |     - |     - |         - |
|          Entitas_MonoThread |      100000 |            10 | 18,372.99 μs |  70.911 μs |  66.330 μs | 15.76 |    0.05 |     - |     - |     - |         - |
|         Entitas_MultiThread |      100000 |            10 |  8,628.99 μs | 172.041 μs | 168.968 μs |  7.41 |    0.16 |     - |     - |     - |     512 B |
|      LeopotamEcs_MonoThread |      100000 |            10 |    355.00 μs |   0.330 μs |   0.309 μs |  0.30 |    0.00 |     - |     - |     - |         - |
|     LeopotamEcs_MultiThread |      100000 |            10 |    160.68 μs |   0.428 μs |   0.358 μs |  0.14 |    0.00 |     - |     - |     - |         - |
|  LeopotamEcsLite_MonoThread |      100000 |            10 |  1,739.08 μs |   2.775 μs |   2.317 μs |  1.49 |    0.00 |     - |     - |     - |         - |
| LeopotamEcsLite_MultiThread |      100000 |            10 |  1,274.74 μs |   3.418 μs |   3.197 μs |  1.09 |    0.00 |     - |     - |     - |     128 B |
|            MonoGameExtended |      100000 |            10 |  3,962.15 μs |  10.180 μs |   9.024 μs |  3.40 |    0.01 |     - |     - |     - |     192 B |
|                   SveltoECS |      100000 |            10 |    595.12 μs |   0.062 μs |   0.052 μs |  0.51 |    0.00 |     - |     - |     - |         - |

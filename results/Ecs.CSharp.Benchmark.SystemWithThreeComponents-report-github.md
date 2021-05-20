``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.985 (2004/?/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  DefaultJob : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT


```
|                      Method | EntityCount |        Mean |     Error |    StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------------ |------------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|       DefaultEcs_MonoThread |      100000 |   588.44 μs |  0.510 μs |  0.477 μs |  1.00 |    0.00 |     - |     - |     - |         - |
|      DefaultEcs_MultiThread |      100000 |   162.23 μs |  0.623 μs |  0.520 μs |  0.28 |    0.00 |     - |     - |     - |         - |
|          Entitas_MonoThread |      100000 | 4,001.79 μs | 10.722 μs | 10.029 μs |  6.80 |    0.02 |     - |     - |     - |     128 B |
|         Entitas_MultiThread |      100000 | 2,964.18 μs |  8.941 μs |  8.364 μs |  5.04 |    0.01 |     - |     - |     - |     480 B |
|      LeopotamEcs_MonoThread |      100000 |   777.55 μs |  0.162 μs |  0.151 μs |  1.32 |    0.00 |     - |     - |     - |         - |
|     LeopotamEcs_MultiThread |      100000 |   275.48 μs |  0.643 μs |  0.601 μs |  0.47 |    0.00 |     - |     - |     - |         - |
|  LeopotamEcsLite_MonoThread |      100000 |   258.01 μs |  0.045 μs |  0.040 μs |  0.44 |    0.00 |     - |     - |     - |         - |
| LeopotamEcsLite_MultiThread |      100000 |    77.08 μs |  0.204 μs |  0.191 μs |  0.13 |    0.00 |     - |     - |     - |     113 B |
|            MonoGameExtended |      100000 | 1,285.74 μs |  1.217 μs |  1.139 μs |  2.19 |    0.00 |     - |     - |     - |     176 B |
|                   SveltoECS |      100000 |   117.89 μs |  0.015 μs |  0.013 μs |  0.20 |    0.00 |     - |     - |     - |         - |

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.985 (2004/?/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  DefaultJob : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT


```
|                      Method | EntityCount |        Mean |     Error |    StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------------ |------------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|       DefaultEcs_MonoThread |      100000 |   302.91 μs |  0.033 μs |  0.026 μs |  1.00 |    0.00 |     - |     - |     - |         - |
|      DefaultEcs_MultiThread |      100000 |    85.74 μs |  0.431 μs |  0.382 μs |  0.28 |    0.00 |     - |     - |     - |         - |
|          Entitas_MonoThread |      100000 | 4,195.78 μs | 19.758 μs | 17.515 μs | 13.84 |    0.04 |     - |     - |     - |     128 B |
|         Entitas_MultiThread |      100000 | 2,854.20 μs |  8.614 μs |  8.058 μs |  9.42 |    0.03 |     - |     - |     - |     462 B |
|      LeopotamEcs_MonoThread |      100000 |   234.13 μs |  0.020 μs |  0.016 μs |  0.77 |    0.00 |     - |     - |     - |         - |
|     LeopotamEcs_MultiThread |      100000 |   111.49 μs |  0.121 μs |  0.114 μs |  0.37 |    0.00 |     - |     - |     - |         - |
|  LeopotamEcsLite_MonoThread |      100000 |   192.58 μs |  0.019 μs |  0.015 μs |  0.64 |    0.00 |     - |     - |     - |         - |
| LeopotamEcsLite_MultiThread |      100000 |    64.37 μs |  0.595 μs |  0.557 μs |  0.21 |    0.00 |     - |     - |     - |     105 B |
|            MonoGameExtended |      100000 | 1,131.08 μs |  1.016 μs |  0.901 μs |  3.73 |    0.00 |     - |     - |     - |     176 B |
|                   SveltoECS |      100000 |    89.05 μs |  0.025 μs |  0.019 μs |  0.29 |    0.00 |     - |     - |     - |         - |

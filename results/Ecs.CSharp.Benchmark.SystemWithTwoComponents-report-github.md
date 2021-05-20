``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.985 (2004/?/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  Job-FEFVFA : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|                      Method | EntityCount |        Mean |     Error |    StdDev |       Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------------ |------------:|----------:|----------:|-------------:|------:|--------:|------:|------:|------:|----------:|
|       DefaultEcs_MonoThread |      100000 |    310.5 μs |   5.92 μs |   5.25 μs |    310.45 μs |  1.00 |    0.00 |     - |     - |     - |         - |
|      DefaultEcs_MultiThread |      100000 |    209.1 μs |   3.81 μs |   6.97 μs |    208.60 μs |  0.68 |    0.02 |     - |     - |     - |         - |
|          Entitas_MonoThread |      100000 |  5,988.6 μs |  42.26 μs |  37.46 μs |  5,992.20 μs | 19.29 |    0.31 |     - |     - |     - |  808216 B |
|         Entitas_MultiThread |      100000 |  4,399.3 μs | 103.99 μs | 306.62 μs |  4,193.85 μs | 14.18 |    0.93 |     - |     - |     - |  808216 B |
|      LeopotamEcs_MonoThread |      100000 |    242.8 μs |   4.39 μs |   4.11 μs |    241.80 μs |  0.78 |    0.02 |     - |     - |     - |         - |
|     LeopotamEcs_MultiThread |      100000 |    154.9 μs |   3.07 μs |   2.72 μs |    154.60 μs |  0.50 |    0.01 |     - |     - |     - |         - |
|  LeopotamEcsLite_MonoThread |      100000 |    201.9 μs |   3.25 μs |   3.74 μs |    201.80 μs |  0.65 |    0.02 |     - |     - |     - |         - |
| LeopotamEcsLite_MultiThread |      100000 |    196.4 μs |   3.16 μs |   4.82 μs |    195.90 μs |  0.64 |    0.02 |     - |     - |     - |         - |
|            MonoGameExtended |      100000 | 17,815.2 μs |  39.51 μs |  30.84 μs | 17,824.15 μs | 57.31 |    1.04 |     - |     - |     - | 1520592 B |
|                   SveltoECS |      100000 |    100.2 μs |   1.62 μs |   1.43 μs |     99.80 μs |  0.32 |    0.01 |     - |     - |     - |         - |

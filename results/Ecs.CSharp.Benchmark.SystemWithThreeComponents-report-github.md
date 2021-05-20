``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.985 (2004/?/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  Job-FEFVFA : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|                      Method | EntityCount |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------------ |------------:|----------:|----------:|------------:|------:|--------:|------:|------:|------:|----------:|
|       DefaultEcs_MonoThread |      100000 |    398.4 μs |   7.95 μs |  20.38 μs |    393.4 μs |  1.00 |    0.00 |     - |     - |     - |         - |
|      DefaultEcs_MultiThread |      100000 |    272.5 μs |   5.39 μs |  12.71 μs |    273.1 μs |  0.68 |    0.04 |     - |     - |     - |         - |
|          Entitas_MonoThread |      100000 |  5,775.6 μs |  67.08 μs |  62.75 μs |  5,753.7 μs | 13.87 |    0.60 |     - |     - |     - |  808216 B |
|         Entitas_MultiThread |      100000 |  4,577.2 μs |  91.53 μs | 237.89 μs |  4,439.5 μs | 11.52 |    0.87 |     - |     - |     - |  808216 B |
|      LeopotamEcs_MonoThread |      100000 |    398.6 μs |  28.82 μs |  76.42 μs |    361.3 μs |  1.01 |    0.20 |     - |     - |     - |         - |
|     LeopotamEcs_MultiThread |      100000 |    240.1 μs |  14.33 μs |  40.64 μs |    229.5 μs |  0.60 |    0.10 |     - |     - |     - |         - |
|  LeopotamEcsLite_MonoThread |      100000 |    285.2 μs |   5.59 μs |   8.37 μs |    286.3 μs |  0.69 |    0.04 |     - |     - |     - |         - |
| LeopotamEcsLite_MultiThread |      100000 |    257.3 μs |   5.15 μs |   6.33 μs |    257.4 μs |  0.62 |    0.03 |     - |     - |     - |         - |
|            MonoGameExtended |      100000 | 35,894.2 μs | 237.07 μs | 221.76 μs | 35,774.5 μs | 86.17 |    3.68 |     - |     - |     - | 1520592 B |
|                   SveltoECS |      100000 |    136.1 μs |   2.34 μs |   2.40 μs |    135.4 μs |  0.33 |    0.01 |     - |     - |     - |         - |

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.985 (2004/?/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  Job-FEFVFA : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |         Mean |       Error |      StdDev | Ratio | RatioSD |     Gen 0 |     Gen 1 |     Gen 2 |  Allocated |
|----------------- |------------ |-------------:|------------:|------------:|------:|--------:|----------:|----------:|----------:|-----------:|
|       DefaultEcs |      100000 |   8,056.0 μs |    97.05 μs |    81.04 μs |  1.00 |    0.00 | 2000.0000 | 1000.0000 | 1000.0000 |  7408984 B |
|          Entitas |      100000 | 104,589.5 μs | 2,029.84 μs | 1,898.71 μs | 12.96 |    0.31 | 9000.0000 | 4000.0000 | 1000.0000 | 54984216 B |
|      LeopotamEcs |      100000 |   6,323.5 μs |   124.78 μs |   170.80 μs |  0.79 |    0.02 | 1000.0000 |         - |         - | 12987856 B |
|  LeopotamEcsLite |      100000 |     736.0 μs |     2.50 μs |     2.09 μs |  0.09 |    0.00 |         - |         - |         - |  1048840 B |
| MonoGameExtended |      100000 |   6,943.8 μs |   135.61 μs |   145.10 μs |  0.86 |    0.01 | 1000.0000 | 1000.0000 | 1000.0000 | 10068016 B |
|        SveltoECS |      100000 |  10,881.8 μs |    23.85 μs |    22.31 μs |  1.35 |    0.01 |         - |         - |         - |          - |

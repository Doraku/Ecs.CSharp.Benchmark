``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  Job-FEFVFA : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |         Mean |       Error |      StdDev |       Median | Ratio | RatioSD |     Gen 0 |     Gen 1 |     Gen 2 |    Allocated |
|----------------- |------------ |-------------:|------------:|------------:|-------------:|------:|--------:|----------:|----------:|----------:|-------------:|
|       DefaultEcs |      100000 |   7,918.1 μs |   144.92 μs |   128.47 μs |   7,876.7 μs |  1.00 |    0.00 | 2000.0000 | 1000.0000 | 1000.0000 |  7,406,664 B |
|          Entitas |      100000 | 100,876.4 μs | 2,000.63 μs | 5,476.70 μs | 103,336.8 μs | 12.67 |    0.81 | 9000.0000 | 4000.0000 | 1000.0000 | 54,981,936 B |
|      LeopotamEcs |      100000 |   6,109.0 μs |   120.98 μs |   188.35 μs |   6,120.8 μs |  0.77 |    0.03 | 1000.0000 |         - |         - | 12,993,752 B |
|  LeopotamEcsLite |      100000 |     736.9 μs |    11.00 μs |     8.59 μs |     734.0 μs |  0.09 |    0.00 |         - |         - |         - |  1,048,840 B |
| MonoGameExtended |      100000 |   6,721.0 μs |   128.54 μs |   148.03 μs |   6,652.3 μs |  0.85 |    0.03 | 1000.0000 | 1000.0000 | 1000.0000 | 10,065,744 B |
|        SveltoECS |      100000 |  11,157.1 μs |    70.55 μs |    65.99 μs |  11,158.0 μs |  1.41 |    0.03 |         - |         - |         - |            - |

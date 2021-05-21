``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.985 (2004/May2020Update/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  Job-FEFVFA : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |         Mean |       Error |      StdDev |       Median | Ratio | RatioSD |     Gen 0 |     Gen 1 |     Gen 2 |    Allocated |
|----------------- |------------ |-------------:|------------:|------------:|-------------:|------:|--------:|----------:|----------:|----------:|-------------:|
|       DefaultEcs |      100000 |   7,928.4 μs |    77.94 μs |    65.08 μs |   7,928.9 μs |  1.00 |    0.00 | 2000.0000 | 1000.0000 | 1000.0000 |  7,406,504 B |
|          Entitas |      100000 | 101,634.7 μs | 2,027.64 μs | 5,049.54 μs | 103,597.0 μs | 12.88 |    0.65 | 9000.0000 | 4000.0000 | 1000.0000 | 54,989,960 B |
|      LeopotamEcs |      100000 |   6,049.1 μs |   120.83 μs |   191.66 μs |   6,148.4 μs |  0.76 |    0.02 | 1000.0000 |         - |         - | 12,993,592 B |
|  LeopotamEcsLite |      100000 |     736.9 μs |    10.21 μs |     7.97 μs |     734.1 μs |  0.09 |    0.00 |         - |         - |         - |  1,048,840 B |
| MonoGameExtended |      100000 |   6,722.6 μs |   121.48 μs |   113.63 μs |   6,683.9 μs |  0.85 |    0.01 | 1000.0000 | 1000.0000 | 1000.0000 | 10,065,584 B |
|        SveltoECS |      100000 |  10,939.2 μs |    28.35 μs |    26.52 μs |  10,938.3 μs |  1.38 |    0.01 |         - |         - |         - |            - |

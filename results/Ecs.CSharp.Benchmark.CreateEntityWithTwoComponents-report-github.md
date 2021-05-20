``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.985 (2004/?/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  Job-FEFVFA : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |      Gen 0 |     Gen 1 |     Gen 2 |  Allocated |
|----------------- |------------ |-----------:|----------:|----------:|-----------:|------:|--------:|-----------:|----------:|----------:|-----------:|
|       DefaultEcs |      100000 |  15.491 ms | 0.1495 ms | 0.1325 ms |  15.509 ms |  1.00 |    0.00 |  2000.0000 | 2000.0000 | 2000.0000 | 15814840 B |
|          Entitas |      100000 | 115.599 ms | 2.0967 ms | 1.9612 ms | 115.750 ms |  7.46 |    0.16 | 10000.0000 | 4000.0000 | 1000.0000 | 59801072 B |
|      LeopotamEcs |      100000 |  21.165 ms | 0.4225 ms | 1.0678 ms |  21.372 ms |  1.36 |    0.07 |  2000.0000 | 1000.0000 | 1000.0000 | 15100976 B |
|  LeopotamEcsLite |      100000 |   5.662 ms | 0.0514 ms | 0.0401 ms |   5.668 ms |  0.37 |    0.00 |  1000.0000 | 1000.0000 | 1000.0000 |  5235528 B |
| MonoGameExtended |      100000 |  41.344 ms | 0.8135 ms | 1.6058 ms |  42.105 ms |  2.63 |    0.13 |  3000.0000 | 2000.0000 | 2000.0000 | 23980592 B |
|        SveltoECS |      100000 |  50.087 ms | 0.1677 ms | 0.1487 ms |  50.077 ms |  3.23 |    0.03 |          - |         - |         - |          - |

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.985 (2004/?/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  Job-FEFVFA : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |       Mean |     Error |    StdDev | Ratio | RatioSD |     Gen 0 |     Gen 1 |     Gen 2 |  Allocated |
|----------------- |------------ |-----------:|----------:|----------:|------:|--------:|----------:|----------:|----------:|-----------:|
|       DefaultEcs |      100000 |   9.772 ms | 0.1559 ms | 0.1382 ms |  1.00 |    0.00 | 2000.0000 | 2000.0000 | 2000.0000 | 11611232 B |
|          Entitas |      100000 | 108.580 ms | 2.0503 ms | 2.2789 ms | 11.17 |    0.35 | 9000.0000 | 4000.0000 | 1000.0000 | 57392592 B |
|      LeopotamEcs |      100000 |  13.864 ms | 0.2759 ms | 0.7460 ms |  1.42 |    0.08 | 2000.0000 | 1000.0000 | 1000.0000 | 14045784 B |
|  LeopotamEcsLite |      100000 |   2.817 ms | 0.0546 ms | 0.0584 ms |  0.29 |    0.01 |         - |         - |         - |  3146280 B |
| MonoGameExtended |      100000 |  19.145 ms | 0.1760 ms | 0.1646 ms |  1.96 |    0.03 | 3000.0000 | 2000.0000 | 2000.0000 | 16828912 B |
|        SveltoECS |      100000 |  29.476 ms | 0.1554 ms | 0.1454 ms |  3.02 |    0.05 |         - |         - |         - |          - |

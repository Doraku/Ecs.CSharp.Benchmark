``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.985 (2004/?/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  Job-FEFVFA : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |       Mean |     Error |    StdDev | Ratio | RatioSD |      Gen 0 |     Gen 1 |     Gen 2 |  Allocated |
|----------------- |------------ |-----------:|----------:|----------:|------:|--------:|-----------:|----------:|----------:|-----------:|
|       DefaultEcs |      100000 |  20.394 ms | 0.1575 ms | 0.1396 ms |  1.00 |    0.00 |  2000.0000 | 1000.0000 | 1000.0000 | 19997632 B |
|          Entitas |      100000 | 122.995 ms | 2.3443 ms | 2.8790 ms |  6.01 |    0.17 | 10000.0000 | 4000.0000 | 1000.0000 | 62209608 B |
|      LeopotamEcs |      100000 |  18.251 ms | 0.1228 ms | 0.1025 ms |  0.89 |    0.01 |  2000.0000 | 1000.0000 | 1000.0000 | 16148136 B |
|  LeopotamEcsLite |      100000 |   8.125 ms | 0.1038 ms | 0.0971 ms |  0.40 |    0.01 |  1000.0000 | 1000.0000 | 1000.0000 |  7332968 B |
| MonoGameExtended |      100000 |  68.438 ms | 1.3044 ms | 1.3957 ms |  3.35 |    0.08 |  5000.0000 | 3000.0000 | 3000.0000 | 30926528 B |
|        SveltoECS |      100000 |  70.324 ms | 0.1681 ms | 0.1404 ms |  3.45 |    0.02 |          - |         - |         - |          - |

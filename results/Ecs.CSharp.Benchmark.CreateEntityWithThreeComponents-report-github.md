``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  Job-FEFVFA : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |       Mean |     Error |    StdDev | Ratio | RatioSD |      Gen 0 |     Gen 1 |     Gen 2 |    Allocated |
|----------------- |------------ |-----------:|----------:|----------:|------:|--------:|-----------:|----------:|----------:|-------------:|
|       DefaultEcs |      100000 |  19.902 ms | 0.1389 ms | 0.1299 ms |  1.00 |    0.00 |  2000.0000 | 1000.0000 | 1000.0000 | 19,999,424 B |
|          Entitas |      100000 | 122.856 ms | 2.3781 ms | 3.5594 ms |  6.11 |    0.23 | 10000.0000 | 4000.0000 | 1000.0000 | 62,207,248 B |
|      LeopotamEcs |      100000 |  18.304 ms | 0.1678 ms | 0.1488 ms |  0.92 |    0.01 |  2000.0000 | 1000.0000 | 1000.0000 | 16,143,544 B |
|  LeopotamEcsLite |      100000 |   8.143 ms | 0.1587 ms | 0.1827 ms |  0.41 |    0.01 |  1000.0000 | 1000.0000 | 1000.0000 |  7,332,968 B |
| MonoGameExtended |      100000 |  67.507 ms | 1.3248 ms | 1.3012 ms |  3.39 |    0.08 |  5000.0000 | 3000.0000 | 3000.0000 | 30,925,568 B |
|        SveltoECS |      100000 |  70.538 ms | 0.2854 ms | 0.2669 ms |  3.54 |    0.03 |          - |         - |         - |            - |

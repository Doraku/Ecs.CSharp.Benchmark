``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.985 (2004/May2020Update/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  Job-FEFVFA : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |      Gen 0 |     Gen 1 |     Gen 2 |    Allocated |
|----------------- |------------ |-----------:|----------:|----------:|-----------:|------:|--------:|-----------:|----------:|----------:|-------------:|
|       DefaultEcs |      100000 |  15.176 ms | 0.2206 ms | 0.2064 ms |  15.150 ms |  1.00 |    0.00 |  2000.0000 | 2000.0000 | 2000.0000 | 15,816,480 B |
|          Entitas |      100000 | 115.901 ms | 2.2818 ms | 2.2410 ms | 116.382 ms |  7.63 |    0.20 | 10000.0000 | 4000.0000 | 1000.0000 | 59,798,608 B |
|      LeopotamEcs |      100000 |  21.696 ms | 0.4290 ms | 1.1671 ms |  21.888 ms |  1.42 |    0.15 |  2000.0000 | 1000.0000 | 1000.0000 | 15,096,064 B |
|  LeopotamEcsLite |      100000 |   5.592 ms | 0.0818 ms | 0.0725 ms |   5.579 ms |  0.37 |    0.01 |  1000.0000 | 1000.0000 | 1000.0000 |  5,235,528 B |
| MonoGameExtended |      100000 |  36.277 ms | 2.2090 ms | 6.5134 ms |  40.345 ms |  2.18 |    0.49 |  3000.0000 | 2000.0000 | 2000.0000 | 23,973,224 B |
|        SveltoECS |      100000 |  51.108 ms | 0.4998 ms | 0.4173 ms |  50.972 ms |  3.36 |    0.04 |          - |         - |         - |            - |

``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.985 (2004/May2020Update/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  Job-FEFVFA : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |     Gen 0 |     Gen 1 |     Gen 2 |    Allocated |
|----------------- |------------ |-----------:|----------:|----------:|-----------:|------:|--------:|----------:|----------:|----------:|-------------:|
|       DefaultEcs |      100000 |   9.240 ms | 0.1841 ms | 0.1808 ms |   9.208 ms |  1.00 |    0.00 | 2000.0000 | 2000.0000 | 2000.0000 | 11,612,848 B |
|          Entitas |      100000 | 108.259 ms | 2.1174 ms | 3.8180 ms | 109.308 ms | 11.59 |    0.52 | 9000.0000 | 4000.0000 | 1000.0000 | 57,390,144 B |
|      LeopotamEcs |      100000 |  14.167 ms | 0.2813 ms | 0.7887 ms |  14.419 ms |  1.52 |    0.10 | 2000.0000 | 1000.0000 | 1000.0000 | 14,049,040 B |
|  LeopotamEcsLite |      100000 |   2.783 ms | 0.0104 ms | 0.0087 ms |   2.781 ms |  0.30 |    0.01 |         - |         - |         - |  3,146,280 B |
| MonoGameExtended |      100000 |  18.824 ms | 0.1781 ms | 0.1666 ms |  18.884 ms |  2.04 |    0.05 | 3000.0000 | 2000.0000 | 2000.0000 | 16,829,712 B |
|        SveltoECS |      100000 |  29.222 ms | 0.1392 ms | 0.1302 ms |  29.277 ms |  3.17 |    0.06 |         - |         - |         - |            - |

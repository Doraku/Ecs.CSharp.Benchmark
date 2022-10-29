``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.18363.2274/1909/November2019Update/19H2)
Intel Xeon W-2135 CPU 3.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  Job-LFXTQC : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |     Mean |    Error |    StdDev |   Median | Ratio | RatioSD | CacheMisses/Op |      Gen0 |      Gen1 |      Gen2 |   Allocated | Alloc Ratio |
|----------------- |------------ |---------:|---------:|----------:|---------:|------:|--------:|---------------:|----------:|----------:|----------:|------------:|------------:|
|       DefaultEcs |      100000 | 10.44 ms | 0.130 ms |  0.121 ms | 10.44 ms |  1.00 |    0.00 |        234,701 | 2000.0000 | 2000.0000 | 2000.0000 | 15425.38 KB |       1.000 |
|          Entitas |      100000 | 81.85 ms | 2.571 ms |  6.950 ms | 81.45 ms |  7.90 |    0.79 |      3,842,294 | 9000.0000 | 4000.0000 | 1000.0000 | 56678.02 KB |       3.674 |
|  LeopotamEcsLite |      100000 | 11.16 ms | 0.161 ms |  0.134 ms | 11.14 ms |  1.07 |    0.02 |              - | 2000.0000 | 2000.0000 | 2000.0000 | 10219.22 KB |       0.662 |
|      LeopotamEcs |      100000 | 18.26 ms | 1.512 ms |  4.362 ms | 19.97 ms |  1.71 |    0.50 |        424,346 | 2000.0000 | 1000.0000 | 1000.0000 |  14709.4 KB |       0.954 |
| MonoGameExtended |      100000 | 28.64 ms | 3.644 ms | 10.743 ms | 23.41 ms |  3.21 |    1.13 |              - | 2000.0000 | 2000.0000 | 2000.0000 | 23372.43 KB |       1.515 |
|        SveltoECS |      100000 | 55.39 ms | 1.082 ms |  1.445 ms | 55.47 ms |  5.34 |    0.12 |        593,617 |         - |         - |         - |     2.16 KB |       0.000 |

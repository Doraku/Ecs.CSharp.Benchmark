``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.18363.2274/1909/November2019Update/19H2)
Intel Xeon W-2135 CPU 3.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  Job-LFXTQC : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |     Mean |    Error |    StdDev | Ratio | RatioSD | CacheMisses/Op |      Gen0 |      Gen1 |      Gen2 |   Allocated | Alloc Ratio |
|----------------- |------------ |---------:|---------:|----------:|------:|--------:|---------------:|----------:|----------:|----------:|------------:|------------:|
|       DefaultEcs |      100000 | 12.38 ms | 0.247 ms |  0.451 ms |  1.00 |    0.00 |              - | 2000.0000 | 2000.0000 | 2000.0000 | 19523.18 KB |       1.000 |
|          Entitas |      100000 | 81.99 ms | 2.144 ms |  6.116 ms |  6.55 |    0.46 |      3,490,161 | 9000.0000 | 4000.0000 | 1000.0000 | 59021.77 KB |       3.023 |
|  LeopotamEcsLite |      100000 | 15.53 ms | 0.294 ms |  0.260 ms |  1.24 |    0.05 |              - | 2000.0000 | 2000.0000 | 2000.0000 | 12268.15 KB |       0.628 |
|      LeopotamEcs |      100000 | 19.10 ms | 2.094 ms |  6.042 ms |  1.49 |    0.49 |              - | 2000.0000 | 2000.0000 | 2000.0000 | 15735.11 KB |       0.806 |
| MonoGameExtended |      100000 | 50.39 ms | 3.689 ms | 10.876 ms |  4.01 |    0.95 |              - | 4000.0000 | 3000.0000 | 3000.0000 | 30152.91 KB |       1.544 |
|        SveltoECS |      100000 | 73.45 ms | 1.439 ms |  1.768 ms |  5.92 |    0.27 |        934,442 |         - |         - |         - |     2.66 KB |       0.000 |

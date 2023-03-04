``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX
  Job-ZDIAMS : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |      Mean |     Error |    StdDev | CacheMisses/Op |   Allocated |
|----------------- |------------ |----------:|----------:|----------:|---------------:|------------:|
|             Arch |      100000 |  13.65 ms |  0.268 ms |  0.426 ms |         58,716 |     9.54 MB |
|       DefaultEcs |      100000 |  8.788 ms | 0.1754 ms | 0.1640 ms |        107,383 | 11324.52 KB |
|          Entitas |      100000 | 92.512 ms | 1.6030 ms | 1.4994 ms |      1,318,366 | 56677.68 KB |
|           HypEcs |      100000 | 23.080 ms | 0.2302 ms | 0.2041 ms |        266,240 | 25825.78 KB |
|      LeopotamEcs |      100000 | 19.749 ms | 0.3888 ms | 0.9088 ms |        250,549 | 13684.05 KB |
|  LeopotamEcsLite |      100000 | 11.290 ms | 0.1838 ms | 0.1719 ms |        106,496 |  8170.29 KB |
| MonoGameExtended |      100000 | 15.685 ms | 0.2394 ms | 0.2240 ms |        220,979 | 16408.29 KB |
|           RelEcs |      100000 | 58.611 ms | 1.1391 ms | 1.4406 ms |        735,294 | 29705.38 KB |
|        SveltoECS |      100000 | 41.710 ms | 0.7642 ms | 0.9097 ms |        707,863 |     1.23 KB |

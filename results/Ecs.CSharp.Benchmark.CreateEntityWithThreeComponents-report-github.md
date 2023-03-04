``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX
  Job-ZDIAMS : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |       Mean |     Error |    StdDev | CacheMisses/Op |   Allocated |
|----------------- |------------ |-----------:|----------:|----------:|---------------:|------------:|
|             Arch |      100000 |   14.03 ms |  0.273 ms |  0.400 ms |         63,986 |    10.16 MB |
|       DefaultEcs |      100000 |  19.569 ms | 0.1750 ms | 0.1946 ms |        232,325 | 19516.31 KB |
|          Entitas |      100000 | 103.717 ms | 0.5845 ms | 0.5181 ms |      1,386,701 | 61365.18 KB |
|           HypEcs |      100000 |  73.461 ms | 1.3983 ms | 1.6103 ms |        431,923 | 68751.98 KB |
| MonoGameExtended |      100000 |  57.772 ms | 1.1258 ms | 1.5781 ms |      1,134,281 |  30152.6 KB |
|      LeopotamEcs |      100000 |  27.863 ms | 0.5464 ms | 0.8667 ms |        266,159 | 15734.73 KB |
|  LeopotamEcsLite |      100000 |  26.626 ms | 0.3298 ms | 0.3085 ms |        155,375 |  12268.1 KB |
|           RelEcs |      100000 | 156.722 ms | 1.9037 ms | 1.7807 ms |      1,946,556 | 75704.95 KB |
|        SveltoECS |      100000 |  91.159 ms | 1.4635 ms | 1.3690 ms |      1,530,812 |     2.66 KB |

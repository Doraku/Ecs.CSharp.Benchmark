```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3447/23H2/2023Update/SunValley3)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2
  Job-AYWANY : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method           | EntityCount | Mean      | Error     | StdDev    | Gen0      | Gen1      | Gen2      | Allocated   |
|----------------- |------------ |----------:|----------:|----------:|----------:|----------:|----------:|------------:|
| Arch             | 100000      |  7.039 ms | 0.0727 ms | 0.0645 ms |         - |         - |         - |  3178.16 KB |
| DefaultEcs       | 100000      | 11.389 ms | 0.2068 ms | 0.1834 ms |         - |         - |         - | 11321.11 KB |
| Fennecs          | 100000      | 10.429 ms | 0.1862 ms | 0.3498 ms |         - |         - |         - | 13636.45 KB |
| FlecsNet         | 100000      |  6.431 ms | 0.1286 ms | 0.1844 ms |         - |         - |         - |     2.73 KB |
| FrifloEngineEcs  | 100000      |  2.837 ms | 0.1132 ms | 0.3247 ms | 1000.0000 | 1000.0000 | 1000.0000 |  5722.08 KB |
| LeopotamEcsLite  | 100000      |  3.608 ms | 0.1019 ms | 0.2956 ms |         - |         - |         - |  7151.08 KB |
| LeopotamEcs      | 100000      |  6.285 ms | 0.1963 ms | 0.5788 ms |         - |         - |         - | 13685.65 KB |
| MonoGameExtended | 100000      |  8.255 ms | 0.5311 ms | 1.5408 ms |         - |         - |         - | 16408.89 KB |
| Morpeh_Direct    | 100000      | 58.202 ms | 2.8245 ms | 8.1945 ms | 2000.0000 | 2000.0000 | 1000.0000 | 41305.76 KB |
| Morpeh_Stash     | 100000      | 45.100 ms | 1.4572 ms | 4.1339 ms | 2000.0000 | 2000.0000 | 1000.0000 | 41305.76 KB |
| Myriad           | 100000      | 10.845 ms | 0.2089 ms | 0.2996 ms |         - |         - |         - |  6914.67 KB |
| HypEcs           | 100000      |  9.897 ms | 0.1977 ms | 0.4462 ms |         - |         - |         - | 25827.05 KB |
| RelEcs           | 100000      | 14.758 ms | 0.2924 ms | 0.6834 ms | 1000.0000 |         - |         - | 29706.66 KB |
| SveltoECS        | 100000      | 21.747 ms | 0.4257 ms | 1.0680 ms |         - |         - |         - |     3.22 KB |
| TinyEcs          | 100000      |  7.454 ms | 0.1474 ms | 0.1306 ms |         - |         - |         - |  7834.44 KB |

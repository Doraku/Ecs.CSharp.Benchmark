```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3447/23H2/2023Update/SunValley3)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2
  Job-AYWANY : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
| Method           | EntityCount | Mean       | Error     | StdDev    | Gen0      | Gen1      | Gen2      | Allocated    |
|----------------- |------------ |-----------:|----------:|----------:|----------:|----------:|----------:|-------------:|
| Arch             | 100000      |   6.840 ms | 0.1024 ms | 0.0855 ms |         - |         - |         - |   3558.44 KB |
| DefaultEcs       | 100000      |   8.515 ms | 0.1698 ms | 0.2086 ms |         - |         - |         - |   15418.9 KB |
| Fennecs          | 100000      |  15.376 ms | 0.1777 ms | 0.1575 ms |         - |         - |         - |  15174.45 KB |
| FlecsNet         | 100000      |  11.082 ms | 0.1213 ms | 0.0947 ms |         - |         - |         - |      3.11 KB |
| FrifloEngineEcs  | 100000      |   2.522 ms | 0.0625 ms | 0.1804 ms | 1000.0000 | 1000.0000 | 1000.0000 |   6236.16 KB |
| HypEcs           | 100000      |  18.703 ms | 0.3537 ms | 0.3473 ms | 1000.0000 | 1000.0000 |         - |  45334.39 KB |
| LeopotamEcsLite  | 100000      |   5.162 ms | 0.1030 ms | 0.3004 ms |         - |         - |         - |   9199.61 KB |
| LeopotamEcs      | 100000      |   6.982 ms | 0.1535 ms | 0.4454 ms |         - |         - |         - |  14711.02 KB |
| MonoGameExtended | 100000      |  13.274 ms | 0.2631 ms | 0.6977 ms |         - |         - |         - |  23373.84 KB |
| Morpeh_Direct    | 100000      | 239.144 ms | 4.5725 ms | 4.4908 ms | 8000.0000 | 8000.0000 | 2000.0000 | 128867.66 KB |
| Morpeh_Stash     | 100000      |  39.734 ms | 0.8404 ms | 2.4779 ms | 2000.0000 | 1000.0000 | 1000.0000 |   48133.7 KB |
| Myriad           | 100000      |  15.280 ms | 0.1736 ms | 0.1624 ms |         - |         - |         - |   7309.77 KB |
| RelEcs           | 100000      |  36.776 ms | 0.7042 ms | 0.6916 ms | 2000.0000 | 1000.0000 |         - |  50749.86 KB |
| SveltoECS        | 100000      |  34.237 ms | 0.6083 ms | 0.6508 ms |         - |         - |         - |      4.14 KB |
| TinyEcs          | 100000      |  14.042 ms | 0.1534 ms | 0.1360 ms |         - |         - |         - |  13785.08 KB |

``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  Job-FEFVFA : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |      Gen 0 |     Gen 1 |     Gen 2 |    Allocated |
|----------------- |------------ |-----------:|----------:|----------:|-----------:|------:|--------:|-----------:|----------:|----------:|-------------:|
|       DefaultEcs |      100000 |  14.847 ms | 0.1865 ms | 0.1745 ms |  14.917 ms |  1.00 |    0.00 |  2000.0000 | 2000.0000 | 2000.0000 | 15,816,640 B |
|          Entitas |      100000 | 115.688 ms | 2.2121 ms | 2.4588 ms | 115.543 ms |  7.79 |    0.23 | 10000.0000 | 4000.0000 | 1000.0000 | 59,798,808 B |
|      LeopotamEcs |      100000 |  21.557 ms | 0.4305 ms | 0.8794 ms |  21.518 ms |  1.44 |    0.07 |  2000.0000 | 1000.0000 | 1000.0000 | 15,096,384 B |
|  LeopotamEcsLite |      100000 |   5.611 ms | 0.1087 ms | 0.0908 ms |   5.602 ms |  0.38 |    0.01 |  1000.0000 | 1000.0000 | 1000.0000 |  5,235,528 B |
| MonoGameExtended |      100000 |  36.852 ms | 2.1061 ms | 6.2099 ms |  40.322 ms |  2.59 |    0.33 |  3000.0000 | 2000.0000 | 2000.0000 | 23,973,704 B |
|        SveltoECS |      100000 |  50.522 ms | 0.3367 ms | 0.3149 ms |  50.475 ms |  3.40 |    0.05 |          - |         - |         - |            - |

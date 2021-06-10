``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  Job-FEFVFA : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |       Mean |     Error |    StdDev | Ratio | RatioSD |     Gen 0 |     Gen 1 |     Gen 2 |    Allocated |
|----------------- |------------ |-----------:|----------:|----------:|------:|--------:|----------:|----------:|----------:|-------------:|
|       DefaultEcs |      100000 |   9.164 ms | 0.1629 ms | 0.1524 ms |  1.00 |    0.00 | 2000.0000 | 2000.0000 | 2000.0000 | 11,613,008 B |
|          Entitas |      100000 | 108.438 ms | 2.1228 ms | 3.4878 ms | 11.81 |    0.49 | 9000.0000 | 4000.0000 | 1000.0000 | 57,390,296 B |
|      LeopotamEcs |      100000 |  13.890 ms | 0.2805 ms | 0.8271 ms |  1.53 |    0.10 | 2000.0000 | 1000.0000 | 1000.0000 | 14,049,360 B |
|  LeopotamEcsLite |      100000 |   2.807 ms | 0.0193 ms | 0.0150 ms |  0.31 |    0.00 |         - |         - |         - |  3,146,280 B |
| MonoGameExtended |      100000 |  18.789 ms | 0.1834 ms | 0.1716 ms |  2.05 |    0.04 | 3000.0000 | 2000.0000 | 2000.0000 | 16,830,192 B |
|        SveltoECS |      100000 |  29.280 ms | 0.1146 ms | 0.1016 ms |  3.19 |    0.05 |         - |         - |         - |            - |

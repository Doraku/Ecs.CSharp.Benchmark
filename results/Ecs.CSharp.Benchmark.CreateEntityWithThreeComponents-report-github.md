``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.985 (2004/May2020Update/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  Job-FEFVFA : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount |       Mean |     Error |    StdDev | Ratio | RatioSD |      Gen 0 |     Gen 1 |     Gen 2 |    Allocated |
|----------------- |------------ |-----------:|----------:|----------:|------:|--------:|-----------:|----------:|----------:|-------------:|
|       DefaultEcs |      100000 |  19.822 ms | 0.1416 ms | 0.1325 ms |  1.00 |    0.00 |  2000.0000 | 1000.0000 | 1000.0000 | 19,999,240 B |
|          Entitas |      100000 | 123.195 ms | 2.3869 ms | 3.5725 ms |  6.18 |    0.24 | 10000.0000 | 4000.0000 | 1000.0000 | 62,207,184 B |
|      LeopotamEcs |      100000 |  18.508 ms | 0.2025 ms | 0.1894 ms |  0.93 |    0.01 |  2000.0000 | 1000.0000 | 1000.0000 | 16,143,224 B |
|  LeopotamEcsLite |      100000 |   8.059 ms | 0.1018 ms | 0.0902 ms |  0.41 |    0.01 |  1000.0000 | 1000.0000 | 1000.0000 |  7,332,968 B |
| MonoGameExtended |      100000 |  68.348 ms | 1.3128 ms | 1.5118 ms |  3.46 |    0.08 |  5000.0000 | 3000.0000 | 3000.0000 | 30,924,984 B |
|        SveltoECS |      100000 |  70.719 ms | 0.2340 ms | 0.2075 ms |  3.57 |    0.03 |          - |         - |         - |            - |

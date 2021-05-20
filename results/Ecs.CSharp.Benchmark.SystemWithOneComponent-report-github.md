``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.985 (2004/?/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  Job-FEFVFA : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|                                 Method | EntityCount |         Mean |      Error |     StdDev |  Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------------- |------------ |-------------:|-----------:|-----------:|-------:|--------:|------:|------:|------:|----------:|
|  DefaultEcs_ComponentSystem_MonoThread |      100000 |     91.88 μs |   1.776 μs |   1.744 μs |   1.00 |    0.00 |     - |     - |     - |         - |
| DefaultEcs_ComponentSystem_MultiThread |      100000 |     67.62 μs |   2.504 μs |   7.382 μs |   0.74 |    0.08 |     - |     - |     - |         - |
|  DefaultEcs_EntitySetSystem_MonoThread |      100000 |    202.59 μs |   2.830 μs |   2.647 μs |   2.21 |    0.06 |     - |     - |     - |         - |
| DefaultEcs_EntitySetSystem_MultiThread |      100000 |    148.06 μs |   2.954 μs |   8.477 μs |   1.69 |    0.10 |     - |     - |     - |         - |
|                     Entitas_MonoThread |      100000 |  6,416.88 μs | 134.044 μs | 386.747 μs |  68.16 |    6.25 |     - |     - |     - |  808216 B |
|                    Entitas_MultiThread |      100000 |  4,102.27 μs | 113.459 μs | 327.356 μs |  43.26 |    3.53 |     - |     - |     - |  808216 B |
|                 LeopotamEcs_MonoThread |      100000 |    152.93 μs |   2.997 μs |   4.102 μs |   1.67 |    0.05 |     - |     - |     - |         - |
|                LeopotamEcs_MultiThread |      100000 |     92.10 μs |   1.789 μs |   4.039 μs |   1.02 |    0.05 |     - |     - |     - |         - |
|             LeopotamEcsLite_MonoThread |      100000 |    141.71 μs |   1.280 μs |   1.069 μs |   1.54 |    0.03 |     - |     - |     - |         - |
|            LeopotamEcsLite_MultiThread |      100000 |    139.46 μs |   2.780 μs |   5.356 μs |   1.52 |    0.06 |     - |     - |     - |         - |
|                       MonoGameExtended |      100000 | 11,969.09 μs |  62.914 μs |  52.536 μs | 130.45 |    2.44 |     - |     - |     - | 1520592 B |
|                              SveltoECS |      100000 |    100.67 μs |   1.985 μs |   3.871 μs |   1.07 |    0.04 |     - |     - |     - |         - |

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.985 (2004/?/20H1)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
  DefaultJob : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT


```
|                                 Method | EntityCount |        Mean |     Error |    StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------------- |------------ |------------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|  DefaultEcs_ComponentSystem_MonoThread |      100000 |    84.02 μs |  0.191 μs |  0.159 μs |  1.00 |    0.00 |     - |     - |     - |         - |
| DefaultEcs_ComponentSystem_MultiThread |      100000 |    28.82 μs |  0.504 μs |  0.895 μs |  0.35 |    0.01 |     - |     - |     - |         - |
|  DefaultEcs_EntitySetSystem_MonoThread |      100000 |   190.54 μs |  0.043 μs |  0.038 μs |  2.27 |    0.00 |     - |     - |     - |         - |
| DefaultEcs_EntitySetSystem_MultiThread |      100000 |    54.82 μs |  0.945 μs |  0.838 μs |  0.65 |    0.01 |     - |     - |     - |         - |
|                     Entitas_MonoThread |      100000 | 4,546.81 μs | 14.706 μs | 13.756 μs | 54.09 |    0.20 |     - |     - |     - |     128 B |
|                    Entitas_MultiThread |      100000 | 2,733.10 μs | 16.029 μs | 14.994 μs | 32.54 |    0.19 |     - |     - |     - |     472 B |
|                 LeopotamEcs_MonoThread |      100000 |   145.21 μs |  0.018 μs |  0.017 μs |  1.73 |    0.00 |     - |     - |     - |         - |
|                LeopotamEcs_MultiThread |      100000 |    72.94 μs |  0.128 μs |  0.120 μs |  0.87 |    0.00 |     - |     - |     - |         - |
|             LeopotamEcsLite_MonoThread |      100000 |   131.11 μs |  0.023 μs |  0.021 μs |  1.56 |    0.00 |     - |     - |     - |         - |
|            LeopotamEcsLite_MultiThread |      100000 |    52.32 μs |  0.208 μs |  0.162 μs |  0.62 |    0.00 |     - |     - |     - |      96 B |
|                       MonoGameExtended |      100000 |   978.13 μs |  0.383 μs |  0.358 μs | 11.64 |    0.02 |     - |     - |     - |     176 B |
|                              SveltoECS |      100000 |    83.92 μs |  0.007 μs |  0.006 μs |  1.00 |    0.00 |     - |     - |     - |         - |

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.18363.2274/1909/November2019Update/19H2)
Intel Xeon W-2135 CPU 3.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


```
|                                 Method | EntityCount | EntityPadding |         Mean |      Error |     StdDev |  Ratio | RatioSD | CacheMisses/Op | Allocated | Alloc Ratio |
|--------------------------------------- |------------ |-------------- |-------------:|-----------:|-----------:|-------:|--------:|---------------:|----------:|------------:|
|  **DefaultEcs_ComponentSystem_MonoThread** |      **100000** |             **0** |     **48.57 μs** |   **0.837 μs** |   **1.174 μs** |   **1.00** |    **0.00** |              **5** |         **-** |          **NA** |
| DefaultEcs_ComponentSystem_MultiThread |      100000 |             0 |     48.39 μs |   0.937 μs |   1.459 μs |   1.00 |    0.04 |              4 |         - |          NA |
|  DefaultEcs_EntitySetSystem_MonoThread |      100000 |             0 |    110.54 μs |   2.135 μs |   2.776 μs |   2.28 |    0.09 |             14 |         - |          NA |
| DefaultEcs_EntitySetSystem_MultiThread |      100000 |             0 |    101.80 μs |   4.792 μs |  13.359 μs |   2.10 |    0.28 |            104 |         - |          NA |
|                     Entitas_MonoThread |      100000 |             0 |  6,715.97 μs |  71.541 μs |  63.419 μs | 139.16 |    3.42 |        645,010 |     103 B |          NA |
|                    Entitas_MultiThread |      100000 |             0 |  1,513.33 μs |   4.998 μs |   4.174 μs |  31.32 |    0.76 |        629,221 |    1153 B |          NA |
|                        LeopotamEcsLite |      100000 |             0 |  1,173.18 μs |  18.625 μs |  17.422 μs |  24.34 |    0.62 |            388 |       1 B |          NA |
|                            LeopotamEcs |      100000 |             0 |     88.56 μs |   1.239 μs |   1.099 μs |   1.84 |    0.05 |             10 |         - |          NA |
|                       MonoGameExtended |      100000 |             0 |    682.21 μs |   4.131 μs |   3.662 μs |  14.14 |    0.37 |         12,350 |     160 B |          NA |
|                              SveltoECS |      100000 |             0 |    165.00 μs |   0.687 μs |   0.642 μs |   3.42 |    0.08 |             14 |         - |          NA |
|                                        |             |               |              |            |            |        |         |                |           |             |
|  **DefaultEcs_ComponentSystem_MonoThread** |      **100000** |            **10** |     **46.18 μs** |   **0.632 μs** |   **0.752 μs** |   **1.00** |    **0.00** |              **4** |         **-** |          **NA** |
| DefaultEcs_ComponentSystem_MultiThread |      100000 |            10 |     45.73 μs |   0.155 μs |   0.130 μs |   0.98 |    0.02 |              3 |         - |          NA |
|  DefaultEcs_EntitySetSystem_MonoThread |      100000 |            10 |    217.55 μs |   4.337 μs |   7.481 μs |   4.76 |    0.18 |            951 |         - |          NA |
| DefaultEcs_EntitySetSystem_MultiThread |      100000 |            10 |     70.50 μs |   1.204 μs |   2.141 μs |   1.53 |    0.05 |          1,120 |         - |          NA |
|                     Entitas_MonoThread |      100000 |            10 | 27,333.31 μs | 239.489 μs | 212.301 μs | 589.09 |   11.42 |        355,174 |     117 B |          NA |
|                    Entitas_MultiThread |      100000 |            10 |  4,161.25 μs |  43.287 μs |  40.491 μs |  89.76 |    1.66 |        291,592 |    1157 B |          NA |
|                        LeopotamEcsLite |      100000 |            10 |  4,775.85 μs |  91.788 μs | 128.675 μs | 103.48 |    3.37 |        316,693 |       3 B |          NA |
|                            LeopotamEcs |      100000 |            10 |     85.79 μs |   0.368 μs |   0.344 μs |   1.85 |    0.03 |             12 |         - |          NA |
|                       MonoGameExtended |      100000 |            10 |  2,480.45 μs |  12.070 μs |  10.079 μs |  53.40 |    1.12 |        344,869 |     162 B |          NA |
|                              SveltoECS |      100000 |            10 |    119.20 μs |   1.975 μs |   1.848 μs |   2.57 |    0.07 |             10 |         - |          NA |

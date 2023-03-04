``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX


```
|                                 Method | EntityCount | EntityPadding |         Mean |      Error |     StdDev | CacheMisses/Op | Allocated |
|--------------------------------------- |------------ |-------------- |-------------:|-----------:|-----------:|---------------:|----------:|
|                        Arch_MonoThread |      100000 |             0 |     61.74 μs |   0.009 μs |   0.008 μs |              3 |         - |
|                       Arch_MultiThread |      100000 |             0 |     30.25 μs |   0.020 μs |   0.018 μs |              3 |         - |
|  DefaultEcs_ComponentSystem_MonoThread |      100000 |             0 |     56.71 μs |   0.294 μs |   0.275 μs |              1 |         - |
| DefaultEcs_ComponentSystem_MultiThread |      100000 |             0 |     15.42 μs |   0.093 μs |   0.078 μs |              1 |         - |
|  DefaultEcs_EntitySetSystem_MonoThread |      100000 |             0 |    163.55 μs |   0.030 μs |   0.027 μs |              5 |         - |
| DefaultEcs_EntitySetSystem_MultiThread |      100000 |             0 |     43.85 μs |   0.205 μs |   0.192 μs |              4 |         - |
|                     Entitas_MonoThread |      100000 |             0 |  5,100.00 μs |  15.044 μs |  14.072 μs |        291,147 |     109 B |
|                    Entitas_MultiThread |      100000 |             0 |  3,006.45 μs |   6.255 μs |   5.545 μs |        292,430 |     391 B |
|                      HypEcs_MonoThread |      100000 |             0 |     56.55 μs |   0.013 μs |   0.011 μs |              1 |      32 B |
|                     HypEcs_MultiThread |      100000 |             0 |     60.98 μs |   0.639 μs |   0.598 μs |             13 |    1768 B |
|                       MonoGameExtended |      100000 |             0 |    991.82 μs |   0.901 μs |   0.799 μs |          3,864 |     163 B |
|                            LeopotamEcs |      100000 |             0 |    144.98 μs |   0.021 μs |   0.020 μs |              3 |         - |
|                        LeopotamEcsLite |      100000 |             0 |  1,841.54 μs |   0.161 μs |   0.134 μs |            110 |       2 B |
|                                 RelEcs |      100000 |             0 |    610.55 μs |   2.206 μs |   1.955 μs |         20,225 |     121 B |
|                              SveltoECS |      100000 |             0 |    197.15 μs |   0.019 μs |   0.017 μs |              3 |         - |
|                                        |             |               |              |            |            |                |           |
|                        Arch_MonoThread |      100000 |            10 |     61.75 μs |   0.022 μs |   0.018 μs |              2 |         - |
|                       Arch_MultiThread |      100000 |            10 |     30.18 μs |   0.034 μs |   0.032 μs |              3 |         - |
|  DefaultEcs_ComponentSystem_MonoThread |      100000 |            10 |     56.30 μs |   0.032 μs |   0.028 μs |              1 |         - |
| DefaultEcs_ComponentSystem_MultiThread |      100000 |            10 |     15.54 μs |   0.106 μs |   0.094 μs |              1 |         - |
|  DefaultEcs_EntitySetSystem_MonoThread |      100000 |            10 |    239.65 μs |   0.347 μs |   0.289 μs |          3,375 |         - |
| DefaultEcs_EntitySetSystem_MultiThread |      100000 |            10 |     85.18 μs |   1.075 μs |   1.006 μs |          6,398 |         - |
|                     Entitas_MonoThread |      100000 |            10 | 19,214.28 μs | 117.733 μs | 110.128 μs |        365,178 |     148 B |
|                    Entitas_MultiThread |      100000 |            10 |  9,197.42 μs | 110.879 μs | 103.716 μs |        354,771 |     410 B |
|                      HypEcs_MonoThread |      100000 |            10 |     56.58 μs |   0.059 μs |   0.053 μs |              1 |      32 B |
|                     HypEcs_MultiThread |      100000 |            10 |     59.34 μs |   0.038 μs |   0.035 μs |             13 |    1768 B |
|                       MonoGameExtended |      100000 |            10 |  2,367.73 μs |   8.416 μs |   7.460 μs |         99,607 |     165 B |
|                            LeopotamEcs |      100000 |            10 |    150.58 μs |   0.022 μs |   0.021 μs |              3 |         - |
|                        LeopotamEcsLite |      100000 |            10 |  3,170.74 μs |  15.986 μs |  14.171 μs |         92,669 |       5 B |
|                                 RelEcs |      100000 |            10 |  1,249.86 μs |   4.904 μs |   4.587 μs |         56,296 |     123 B |
|                              SveltoECS |      100000 |            10 |    197.13 μs |   0.032 μs |   0.025 μs |              4 |         - |

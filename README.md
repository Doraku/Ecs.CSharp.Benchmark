# ECS c# Benchmark
This repo contains benchmarks of some c# ECS frameworks. Feel free to add your own or correct usage of existing ones! Please make your framework available as a nuget package to ease referencing and updating versions.

The benchmarks are not representative of usage in real conditions but results can still be interesting to look at.

All results are obtained from the same toaster, with the same load, so comparison is fairer.

Tested frameworks:
- [Arch](https://github.com/genaray/Arch)
- [DefaultEcs](https://github.com/Doraku/DefaultEcs)
- [Entitas](https://github.com/sschmid/Entitas-CSharp)
- [HypEcs](https://github.com/Byteron/HypEcs)
- [Leopotam.Ecs](https://github.com/Leopotam/ecs) using what I believe is a nuget package not made by the actual author and compiled in debug...
- [Leopotam.EcsLite](https://github.com/Leopotam/ecslite) using what I believe is a nuget package not made by the actual author and compiled in debug...
- [MonoGame.Extended](https://github.com/craftworkgames/MonoGame.Extended)
- [RelEcs](https://github.com/Byteron/RelEcs)
- [Svelto.ECS](https://github.com/sebas77/Svelto.ECS)
- [Morpeh](https://github.com/scellecs/morpeh)

## [CreateEntityWithOneComponent](results/Ecs.CSharp.Benchmark.CreateEntityWithOneComponent-report-github.md)
Create entities with one component.

|           Method |      Mean | CacheMisses/Op |   Allocated |
|----------------- |----------:|---------------:|------------:|
|             Arch |  13.65 ms |         58,716 |     9.54 MB |
|       DefaultEcs |  8.788 ms |        107,383 | 11324.52 KB |
|          Entitas | 92.512 ms |      1,318,366 | 56677.68 KB |
|           HypEcs | 23.080 ms |        266,240 | 25825.78 KB |
|      LeopotamEcs | 19.749 ms |        250,549 | 13684.05 KB |
|  LeopotamEcsLite | 11.290 ms |        106,496 |  8170.29 KB |
| MonoGameExtended | 15.685 ms |        220,979 | 16408.29 KB |
|           RelEcs | 58.611 ms |        735,294 | 29705.38 KB |
|        SveltoECS | 41.710 ms |        707,863 |     1.23 KB |

## [CreateEntityWithTwoComponents](results/Ecs.CSharp.Benchmark.CreateEntityWithTwoComponents-report-github.md)
Create entities with two components.

|           Method |       Mean | CacheMisses/Op |   Allocated |
|----------------- |-----------:|---------------:|------------:|
|             Arch |   12.08 ms |         62,393 |      9.7 MB |
|       DefaultEcs |  14.638 ms |        174,816 | 15417.45 KB |
|          Entitas |  99.232 ms |      1,287,851 | 59021.43 KB |
|           HypEcs |  44.893 ms |        360,448 | 45333.15 KB |
|      LeopotamEcs |  31.291 ms |        254,225 | 14709.32 KB |
|  LeopotamEcsLite |  18.763 ms |        118,511 | 10219.15 KB |
| MonoGameExtended |  46.995 ms |        577,946 | 23372.73 KB |
|           RelEcs | 115.301 ms |      1,304,166 | 50750.64 KB |
|        SveltoECS |  67.121 ms |      1,149,821 |     2.16 KB |

## [CreateEntityWithThreeComponents](results/Ecs.CSharp.Benchmark.CreateEntityWithThreeComponents-report-github.md)
Create entities with three components.

|           Method |       Mean | CacheMisses/Op |   Allocated |
|----------------- |-----------:|---------------:|------------:|
|             Arch |   14.03 ms |         63,986 |    10.16 MB |
|       DefaultEcs |  19.569 ms |        232,325 | 19516.31 KB |
|          Entitas | 103.717 ms |      1,386,701 | 61365.18 KB |
|           HypEcs |  73.461 ms |        431,923 | 68751.98 KB |
|      LeopotamEcs |  27.863 ms |        266,159 | 15734.73 KB |
|  LeopotamEcsLite |  26.626 ms |        155,375 |  12268.1 KB |
| MonoGameExtended |  57.772 ms |      1,134,281 |  30152.6 KB |
|           RelEcs | 156.722 ms |      1,946,556 | 75704.95 KB |
|        SveltoECS |  91.159 ms |      1,530,812 |     2.66 KB |

## [SystemWithOneComponent](results/Ecs.CSharp.Benchmark.SystemWithOneComponent-report-github.md)
Modify entities with one component. The padding aims to simulate real situation when processed entities and their components are not sequential.

|                                 Method |         Mean | CacheMisses/Op | Allocated |
|--------------------------------------- |-------------:|---------------:|----------:|
|                        Arch_MonoThread |     61.74 μs |              3 |         - |
|                       Arch_MultiThread |     30.25 μs |              3 |         - |
|  DefaultEcs_ComponentSystem_MonoThread |     56.71 μs |              1 |         - |
| DefaultEcs_ComponentSystem_MultiThread |     15.42 μs |              1 |         - |
|  DefaultEcs_EntitySetSystem_MonoThread |    163.55 μs |              5 |         - |
| DefaultEcs_EntitySetSystem_MultiThread |     43.85 μs |              4 |         - |
|                     Entitas_MonoThread |  5,100.00 μs |        291,147 |     109 B |
|                    Entitas_MultiThread |  3,006.45 μs |        292,430 |     391 B |
|                      HypEcs_MonoThread |     56.55 μs |              1 |      32 B |
|                     HypEcs_MultiThread |     60.98 μs |             13 |    1768 B |
|                            LeopotamEcs |    144.98 μs |              3 |         - |
|                        LeopotamEcsLite |  1,841.54 μs |            110 |       2 B |
|                       MonoGameExtended |    991.82 μs |          3,864 |     163 B |
|                                 RelEcs |    610.55 μs |         20,225 |     121 B |
|                              SveltoECS |    197.15 μs |              3 |         - |

## [SystemWithTwoComponents](results/Ecs.CSharp.Benchmark.SystemWithTwoComponents-report-github.md)
Modify entities with two components. The padding aims to simulate real situation when processed entities and their components are not sequential.

|                 Method |         Mean | CacheMisses/Op | Allocated |
|----------------------- |-------------:|---------------:|----------:|
|        Arch_MonoThread |     91.48 μs |              3 |         - |
|       Arch_MultiThread |     36.82 μs |              5 |         - |
|  DefaultEcs_MonoThread |    254.98 μs |             17 |       1 B |
| DefaultEcs_MultiThread |     67.94 μs |              9 |         - |
|     Entitas_MonoThread |  4,494.22 μs |        318,174 |     109 B |
|    Entitas_MultiThread |  2,955.39 μs |        342,963 |     391 B |
|      HypEcs_MonoThread |     57.91 μs |              1 |      32 B |
|     HypEcs_MultiThread |     60.54 μs |             11 |    1768 B |
|            LeopotamEcs |    237.02 μs |              6 |         - |
|        LeopotamEcsLite |  3,636.00 μs |            553 |       5 B |
|       MonoGameExtended |  1,123.42 μs |         10,375 |     163 B |
|                 RelEcs |    722.21 μs |         21,993 |     169 B |
|              SveltoECS |    337.62 μs |              6 |       1 B |

## [SystemWithThreeComponents](results/Ecs.CSharp.Benchmark.SystemWithThreeComponents-report-github.md)
Modify entities with three components. The padding aims to simulate real situation when processed entities and their components are not sequential.

|                 Method |         Mean | CacheMisses/Op | Allocated |
|----------------------- |-------------:|---------------:|----------:|
|        Arch_MonoThread |    111.44 μs |              8 |         - |
|       Arch_MultiThread |     41.68 μs |              7 |         - |
|  DefaultEcs_MonoThread |    388.85 μs |             36 |       1 B |
| DefaultEcs_MultiThread |    104.02 μs |             40 |         - |
|     Entitas_MonoThread |  4,341.06 μs |        344,337 |     109 B |
|    Entitas_MultiThread |  3,107.05 μs |        401,718 |     391 B |
|      HypEcs_MonoThread |     85.27 μs |              3 |      32 B |
|     HypEcs_MultiThread |     88.09 μs |             14 |    1768 B |
|            LeopotamEcs |    788.61 μs |             38 |       1 B |
|        LeopotamEcsLite |  5,533.31 μs |          1,515 |      11 B |
|       MonoGameExtended |  1,373.25 μs |         24,487 |     163 B |
|                 RelEcs |    939.20 μs |         38,063 |     217 B |
|              SveltoECS |    450.23 μs |             13 |       1 B |

## [SystemWithTwoComponentsMultipleComposition](results/Ecs.CSharp.Benchmark.SystemWithTwoComponentsMultipleComposition-report-github.md)
Modify entities with two components while different entity compositions match the the components query.

|                 Method |        Mean | CacheMisses/Op | Allocated |
|----------------------- |------------:|---------------:|----------:|
|                   Arch |    91.47 μs |              6 |         - |
|       Arch_MultiThread |    59.92 μs |              9 |         - |
|  DefaultEcs_MonoThread |   259.89 μs |              9 |       1 B |
| DefaultEcs_MultiThread |    69.55 μs |              6 |         - |
|     Entitas_MonoThread | 4,839.97 μs |        340,754 |     112 B |
|    Entitas_MultiThread | 3,101.55 μs |        371,259 |     392 B |
|      HypEcs_MonoThread |    57.99 μs |              1 |      32 B |
|     HypEcs_MultiThread |    21.70 μs |             10 |    2294 B |
|            LeopotamEcs |   241.88 μs |              4 |         - |
|        LeopotamEcsLite | 3,630.12 μs |            566 |       7 B |
|       MonoGameExtended | 1,230.32 μs |         24,422 |     163 B |
|                 RelEcs | 1,581.50 μs |         83,004 |     491 B |
|              SveltoECS |   337.63 μs |              6 |       1 B |

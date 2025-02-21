# ECS c# Benchmark
This repo contains benchmarks of some c# ECS frameworks. Feel free to add your own or correct usage of existing ones! Please make your framework available as a nuget package to ease referencing and updating versions.

The benchmarks are not representative of usage in real conditions but results can still be interesting to look at.

All results are obtained from the same toaster, with the same load, so comparison is fairer.

Tested frameworks:
- [Arch](https://github.com/genaray/Arch)
- [DefaultEcs](https://github.com/Doraku/DefaultEcs)
- [Fennecs](https://github.com/thygrrr/fennecs)
- [Flecs.Net](https://github.com/BeanCheeseBurrito/Flecs.NET)
- [Frent](https://github.com/itsBuggingMe/Frent)
- [Friflo.Engine.ECS](https://github.com/friflo/Friflo.Engine.ECS)
- [Leopotam.Ecs](https://github.com/Leopotam/ecs) using what I believe is a nuget package not made by the actual author and compiled in debug...
- [Leopotam.EcsLite](https://github.com/Leopotam/ecslite) using what I believe is a nuget package not made by the actual author and compiled in debug...
- [MonoGame.Extended](https://github.com/craftworkgames/MonoGame.Extended)
- [Morpeh](https://github.com/scellecs/morpeh)
- [Myriad.ECS](https://github.com/martindevans/Myriad.ECS)
- [HypEcs](https://github.com/Byteron/HypEcs)
- [RelEcs](https://github.com/Byteron/RelEcs)
- [Svelto.ECS](https://github.com/sebas77/Svelto.ECS)
- [TinyEcs](https://github.com/andreakarasho/TinyEcs)

Removed frameworks:
- [Entitas](https://github.com/sschmid/Entitas) removed because it was taking forever to initialize in the later tests when moved to net8, you can check older benchmark results [here](https://github.com/Doraku/Ecs.CSharp.Benchmark/tree/3574b2dfb948e941a208f77eaf9e94b73d58e6bf)

Tested versions may not be latest available, that's because I'm lazy and new versions may introduce breaking changes, so feel free to create pull requests to update libs you are knowledgeable about.

## [CreateEntityWithOneComponent](results/Ecs.CSharp.Benchmark.CreateEntityWithOneComponent-report-github.md)
Create entities with one component.


| Method           | Mean        | StdDev      | Allocated   |
|----------------- |------------:|------------:|------------:|
| Frent_Bulk       |    768.6 μs |    24.45 μs |  3322.91 KB |
| Frent            |  1,038.5 μs |    15.93 μs |  3322.91 KB |
| FrifloEngineEcs  |  2,022.5 μs |    29.98 μs |  3381.74 KB |
| LeopotamEcsLite  |  2,863.2 μs |   284.50 μs |  7151.08 KB |
| Arch             |  3,694.8 μs |   124.75 μs |  3178.44 KB |
| DefaultEcs       |  7,103.9 μs |   281.95 μs | 11321.11 KB |
| FlecsNet         |  7,480.1 μs |   153.12 μs |     2.73 KB |
| MonoGameExtended |  8,282.6 μs |   592.85 μs | 16408.89 KB |
| LeopotamEcs      |  9,003.1 μs |   735.44 μs | 13685.65 KB |
| TinyEcs          | 11,316.8 μs |   242.01 μs |  7834.44 KB |
| HypEcs           | 11,542.5 μs |   672.16 μs | 25829.38 KB |
| Fennecs          | 12,146.8 μs |   460.88 μs | 13636.45 KB |
| Myriad           | 17,310.6 μs |   438.87 μs |  7633.45 KB |
| RelEcs           | 25,686.8 μs | 1,456.76 μs | 29706.66 KB |
| SveltoECS        | 26,330.5 μs |   598.68 μs |     3.22 KB |
| Morpeh_Stash     | 67,075.5 μs | 1,105.68 μs | 41305.76 KB |
| Morpeh_Direct    | 67,753.8 μs | 1,364.95 μs | 41305.76 KB |

## [CreateEntityWithTwoComponents](results/Ecs.CSharp.Benchmark.CreateEntityWithTwoComponents-report-github.md)
Create entities with two components.

| Method           | Mean       | StdDev     | Allocated    |
|----------------- |-----------:|-----------:|-------------:|
| Frent            |   1.188 ms |  0.0050 ms |   3713.63 KB |
| Frent_Bulk       |   1.263 ms |  0.0214 ms |   3713.63 KB |
| FrifloEngineEcs  |   2.933 ms |  0.1588 ms |   3898.13 KB |
| Arch             |   3.864 ms |  0.1820 ms |   3558.44 KB |
| LeopotamEcsLite  |   4.599 ms |  0.8319 ms |   9199.61 KB |
| DefaultEcs       |  10.217 ms |  0.4302 ms |   15418.9 KB |
| LeopotamEcs      |  10.451 ms |  0.8563 ms |  14711.02 KB |
| FlecsNet         |  14.295 ms |  0.2492 ms |      3.11 KB |
| MonoGameExtended |  17.426 ms |  1.1724 ms |  23373.84 KB |
| TinyEcs          |  19.518 ms |  1.4443 ms |  13785.08 KB |
| Fennecs          |  19.817 ms |  0.4584 ms |  15174.45 KB |
| HypEcs           |  21.669 ms |  0.3002 ms |  45336.69 KB |
| Myriad           |  23.799 ms |  0.4402 ms |   8028.55 KB |
| SveltoECS        |  39.648 ms |  1.8089 ms |      4.14 KB |
| RelEcs           |  60.414 ms |  2.5217 ms |  50749.86 KB |
| Morpeh_Stash     |  75.880 ms |  2.4763 ms |   48133.7 KB |
| Morpeh_Direct    | 271.755 ms | 16.5622 ms | 128861.64 KB |

## [CreateEntityWithThreeComponents](results/Ecs.CSharp.Benchmark.CreateEntityWithThreeComponents-report-github.md)
Create entities with three components.

| Method           | Mean       | StdDev    | Allocated   |
|----------------- |-----------:|----------:|------------:|
| Frent            |   1.335 ms | 0.0065 ms |  4104.34 KB |
| Frent_Bulk       |   1.346 ms | 0.0273 ms |  4104.34 KB |
| FrifloEngineEcs  |   3.067 ms | 0.0878 ms |  4412.23 KB |
| LeopotamEcsLite  |   4.917 ms | 0.2248 ms | 11248.14 KB |
| Arch             |   8.351 ms | 0.1357 ms |  3947.67 KB |
| LeopotamEcs      |  11.649 ms | 0.6685 ms |  15736.4 KB |
| DefaultEcs       |  11.982 ms | 0.4362 ms | 19516.68 KB |
| FlecsNet         |  21.084 ms | 0.1698 ms |     3.48 KB |
| Myriad           |  26.959 ms | 0.3333 ms |  8423.66 KB |
| Fennecs          |  29.525 ms | 0.3057 ms | 16713.12 KB |
| TinyEcs          |  33.582 ms | 0.5317 ms | 21316.55 KB |
| HypEcs           |  35.524 ms | 1.5668 ms | 68748.41 KB |
| MonoGameExtended |  39.518 ms | 1.6480 ms | 30154.05 KB |
| SveltoECS        |  52.785 ms | 1.8500 ms |     4.64 KB |
| Morpeh_Stash     |  70.168 ms | 1.6399 ms | 44719.73 KB |
| RelEcs           |  83.031 ms | 1.9343 ms | 75699.76 KB |
| Morpeh_Direct    | 179.589 ms | 3.6865 ms | 83804.58 KB |


## [SystemWithOneComponent](results/Ecs.CSharp.Benchmark.SystemWithOneComponent-report-github.md)
Modify entities with one component. The padding aims to simulate real situation when processed entities and their components are not sequential.

> Note: Padding tests were removed for libraries that use archetypes to save space as padding makes no difference in their results

| Method                                 | EntityPadding | Mean         | StdDev      | Allocated |
|--------------------------------------- |-------------- |-------------:|------------:|----------:|
| Frent_Simd                             | 0             |     8.001 μs |   0.0707 μs |         - |
| FrifloEngineEcs_SIMD_MonoThread        | 0             |     8.832 μs |   0.1063 μs |         - |
| FrifloEngineEcs_MultiThread            | 0             |     9.687 μs |   0.4677 μs |         - |
| Myriad_SingleThreadChunk_SIMD          | 0             |    11.607 μs |   0.1431 μs |         - |
| Myriad_MultiThreadChunk                | 0             |    17.138 μs |   0.1526 μs |    9216 B |
| TinyEcs_EachJob                        | 0             |    19.308 μs |   0.3354 μs |    1552 B |
| Fennecs_Job                            | 0             |    26.045 μs |   0.8157 μs |         - |
| TinyEcs_Each                           | 0             |    29.781 μs |   0.1316 μs |         - |
| Arch_MultiThread                       | 0             |    32.913 μs |   0.2353 μs |         - |
| Frent_QueryInline                      | 0             |    33.690 μs |   0.1638 μs |         - |
| HypEcs_MonoThread                      | 0             |    44.341 μs |   0.0620 μs |      72 B |
| FrifloEngineEcs_MonoThread             | 0             |    44.977 μs |   0.2093 μs |         - |
| Fennecs_ForEach                        | 0             |    45.015 μs |   0.2813 μs |         - |
| DefaultEcs_ComponentSystem_MonoThread  | 0             |    45.579 μs |   1.0413 μs |         - |
| Fennecs_Raw                            | 0             |    45.949 μs |   0.2371 μs |         - |
| Arch_MonoThread                        | 0             |    46.696 μs |   0.2203 μs |         - |
| Arch_MonoThread_SourceGenerated        | 0             |    47.506 μs |   0.3456 μs |         - |
| Myriad_SingleThreadChunk               | 0             |    47.526 μs |   0.2036 μs |         - |
| HypEcs_MultiThread                     | 0             |    49.295 μs |   0.3248 μs |    1832 B |
| DefaultEcs_ComponentSystem_MultiThread | 0             |    49.427 μs |   8.2200 μs |         - |
| Myriad_SingleThread                    | 0             |    49.564 μs |   0.2483 μs |         - |
| Frent_QueryDelegate                    | 0             |    53.680 μs |   1.4546 μs |         - |
| FlecsNet_Iter                          | 0             |    56.540 μs |   0.1969 μs |         - |
| Myriad_MultiThread                     | 0             |    71.270 μs |   0.3873 μs |   16213 B |
| DefaultEcs_EntitySetSystem_MonoThread  | 0             |    71.717 μs |   0.5674 μs |         - |
| LeopotamEcs                            | 0             |    83.138 μs |   0.5633 μs |         - |
| FlecsNet_Each                          | 0             |    90.498 μs |   0.4793 μs |         - |
| Myriad_Delegate                        | 0             |    91.233 μs |   0.5065 μs |         - |
| DefaultEcs_EntitySetSystem_MultiThread | 0             |   100.011 μs |   2.0387 μs |         - |
| LeopotamEcsLite                        | 0             |   101.708 μs |   0.4140 μs |         - |
| SveltoECS                              | 0             |   111.771 μs |   0.4182 μs |         - |
| Myriad_Enumerable                      | 0             |   198.400 μs |   0.7397 μs |         - |
| RelEcs                                 | 0             |   203.954 μs |   2.0630 μs |     121 B |
| MonoGameExtended                       | 0             |   305.970 μs |   4.1697 μs |     161 B |
| Morpeh_Stash                           | 0             | 2,354.802 μs |  55.0717 μs |       4 B |
| Morpeh_Direct                          | 0             | 2,906.300 μs |  36.9789 μs |       4 B |
|                                        |               |              |             |           |
| DefaultEcs_ComponentSystem_MonoThread  | 10            |    44.760 μs |   0.6112 μs |         - |
| DefaultEcs_ComponentSystem_MultiThread | 10            |    55.017 μs |  12.3385 μs |         - |
| LeopotamEcs                            | 10            |    82.681 μs |   0.4651 μs |         - |
| DefaultEcs_EntitySetSystem_MultiThread | 10            |   108.222 μs |   1.4470 μs |         - |
| DefaultEcs_EntitySetSystem_MonoThread  | 10            |   109.532 μs |   3.1273 μs |         - |
| LeopotamEcsLite                        | 10            |   122.782 μs |   1.7006 μs |         - |
| SveltoECS                              | 10            |   133.520 μs |   0.7607 μs |         - |
| RelEcs                                 | 10            |   506.912 μs |  13.9889 μs |     121 B |
| MonoGameExtended                       | 10            | 1,456.219 μs |  45.6079 μs |     162 B |
| Morpeh_Stash                           | 10            | 7,824.125 μs | 172.3176 μs |       8 B |
| Morpeh_Direct                          | 10            | 8,998.948 μs | 187.5417 μs |      17 B |


## [SystemWithTwoComponents](results/Ecs.CSharp.Benchmark.SystemWithTwoComponents-report-github.md)
Modify entities with two components. The padding aims to simulate real situation when processed entities and their components are not sequential.

| Method                          | EntityPadding | Mean        | StdDev     | Allocated |
|-------------------------------- |-------------- |------------:|-----------:|----------:|
| FrifloEngineEcs_MultiThread     | 0             |    12.43 μs |   1.049 μs |         - |
| Frent_Simd                      | 0             |    14.03 μs |   0.122 μs |         - |
| FrifloEngineEcs_SIMD_MonoThread | 0             |    14.34 μs |   0.058 μs |         - |
| Myriad_SingleThreadChunk_SIMD   | 0             |    16.32 μs |   0.128 μs |         - |
| Myriad_MultiThreadChunk         | 0             |    17.14 μs |   0.115 μs |    9216 B |
| TinyEcs_EachJob                 | 0             |    23.85 μs |   1.105 μs |    1552 B |
| Arch_MultiThread                | 0             |    32.02 μs |   0.144 μs |         - |
| TinyEcs_Each                    | 0             |    33.41 μs |   0.314 μs |         - |
| HypEcs_MonoThread               | 0             |    44.68 μs |   0.205 μs |     112 B |
| Frent_QueryInline               | 0             |    44.93 μs |   0.172 μs |         - |
| Arch_MonoThread_SourceGenerated | 0             |    47.84 μs |   0.226 μs |         - |
| Myriad_SingleThreadChunk        | 0             |    48.31 μs |   0.189 μs |         - |
| HypEcs_MultiThread              | 0             |    49.12 μs |   0.274 μs |    1872 B |
| Frent_QueryDelegate             | 0             |    51.48 μs |   0.174 μs |         - |
| Myriad_SingleThread             | 0             |    52.64 μs |   0.246 μs |         - |
| FrifloEngineEcs_MonoThread      | 0             |    56.93 μs |   0.327 μs |         - |
| Arch_MonoThread                 | 0             |    57.47 μs |   0.314 μs |         - |
| Fennecs_Raw                     | 0             |    58.86 μs |   0.215 μs |         - |
| Fennecs_ForEach                 | 0             |    63.21 μs |   0.372 μs |         - |
| Myriad_MultiThread              | 0             |    68.27 μs |   0.339 μs |   20865 B |
| FlecsNet_Iter                   | 0             |    79.81 μs |   0.420 μs |         - |
| Fennecs_Job                     | 0             |    94.79 μs |   1.576 μs |         - |
| DefaultEcs_MultiThread          | 0             |   108.93 μs |   3.569 μs |         - |
| Myriad_Delegate                 | 0             |   113.14 μs |   0.362 μs |         - |
| DefaultEcs_MonoThread           | 0             |   124.09 μs |   0.978 μs |         - |
| FlecsNet_Each                   | 0             |   134.08 μs |   0.238 μs |         - |
| LeopotamEcs                     | 0             |   158.35 μs |   1.551 μs |         - |
| Myriad_Enumerable               | 0             |   200.01 μs |   3.006 μs |         - |
| LeopotamEcsLite                 | 0             |   216.20 μs |   1.068 μs |         - |
| SveltoECS                       | 0             |   223.22 μs |   0.700 μs |         - |
| RelEcs                          | 0             |   355.92 μs |   7.512 μs |     169 B |
| MonoGameExtended                | 0             |   534.19 μs |  10.930 μs |     161 B |
| Morpeh_Stash                    | 0             | 2,380.69 μs |  40.379 μs |       4 B |
| Morpeh_Direct                   | 0             | 3,934.95 μs |  63.272 μs |       8 B |
|                                 |               |             |            |           |
| LeopotamEcs                     | 10            |   176.98 μs |   2.752 μs |         - |
| DefaultEcs_MultiThread          | 10            |   209.11 μs |  10.346 μs |       1 B |
| LeopotamEcsLite                 | 10            |   531.99 μs |  10.283 μs |       1 B |
| DefaultEcs_MonoThread           | 10            |   571.35 μs |  12.808 μs |      97 B |
| RelEcs                          | 10            | 1,138.55 μs |  35.671 μs |     170 B |
| SveltoECS                       | 10            | 1,204.02 μs |   6.929 μs |       2 B |
| MonoGameExtended                | 10            | 2,437.67 μs |  38.901 μs |     164 B |
| Morpeh_Stash                    | 10            | 8,713.33 μs | 169.092 μs |      17 B |
| Morpeh_Direct                   | 10            | 9,810.58 μs | 126.514 μs |      17 B |

## [SystemWithThreeComponents](results/Ecs.CSharp.Benchmark.SystemWithThreeComponents-report-github.md)
Modify entities with three components. The padding aims to simulate real situation when processed entities and their components are not sequential.

| Method                          | EntityPadding | Mean         | StdDev     | Allocated |
|-------------------------------- |-------------- |-------------:|-----------:|----------:|
| FrifloEngineEcs_MultiThread     | 0             |     15.47 μs |   0.288 μs |         - |
| Frent_Simd                      | 0             |     19.48 μs |   0.083 μs |         - |
| Myriad_MultiThreadChunk         | 0             |     20.14 μs |   0.143 μs |    9216 B |
| FrifloEngineEcs_SIMD_MonoThread | 0             |     20.36 μs |   0.082 μs |         - |
| TinyEcs_EachJob                 | 0             |     30.24 μs |   2.122 μs |    1560 B |
| Arch_MultiThread                | 0             |     35.89 μs |   0.475 μs |         - |
| HypEcs_MonoThread               | 0             |     53.08 μs |   0.415 μs |     152 B |
| Frent_QueryInline               | 0             |     53.71 μs |   0.341 μs |         - |
| TinyEcs_Each                    | 0             |     54.13 μs |   0.134 μs |         - |
| HypEcs_MultiThread              | 0             |     56.12 μs |   0.281 μs |    1912 B |
| Myriad_SingleThread             | 0             |     62.23 μs |   0.304 μs |         - |
| Myriad_SingleThreadChunk        | 0             |     63.69 μs |   0.366 μs |         - |
| Arch_MonoThread                 | 0             |     71.83 μs |   0.581 μs |         - |
| Fennecs_Raw                     | 0             |     75.16 μs |   0.281 μs |         - |
| FrifloEngineEcs_MonoThread      | 0             |     76.40 μs |   0.464 μs |         - |
| Myriad_MultiThread              | 0             |     77.50 μs |   0.426 μs |   25560 B |
| Fennecs_ForEach                 | 0             |     87.11 μs |   0.486 μs |         - |
| Frent_QueryDelegate             | 0             |     88.61 μs |   0.468 μs |         - |
| Myriad_Delegate                 | 0             |     93.16 μs |   0.483 μs |         - |
| Fennecs_Job                     | 0             |    108.20 μs |   0.412 μs |         - |
| FlecsNet_Iter                   | 0             |    114.56 μs |   1.236 μs |         - |
| DefaultEcs_MultiThread          | 0             |    123.82 μs |   2.006 μs |         - |
| FlecsNet_Each                   | 0             |    164.39 μs |   1.348 μs |         - |
| Arch_MonoThread_SourceGenerated | 0             |    192.44 μs |   0.719 μs |         - |
| DefaultEcs_MonoThread           | 0             |    233.46 μs |   1.049 μs |         - |
| LeopotamEcs                     | 0             |    259.06 μs |   1.430 μs |       1 B |
| Myriad_Enumerable               | 0             |    263.68 μs |   1.395 μs |       1 B |
| SveltoECS                       | 0             |    310.69 μs |   0.254 μs |       1 B |
| LeopotamEcsLite                 | 0             |    347.98 μs |   1.823 μs |       1 B |
| RelEcs                          | 0             |    573.73 μs |  12.679 μs |     217 B |
| MonoGameExtended                | 0             |    799.64 μs |   6.366 μs |     161 B |
| Morpeh_Stash                    | 0             |  2,837.66 μs |  19.817 μs |       4 B |
| Morpeh_Direct                   | 0             |  4,587.78 μs |  39.342 μs |       8 B |
|                                 | 0             |              |            |           |
| LeopotamEcs                     | 10            |    275.19 μs |   1.071 μs |       1 B |
| DefaultEcs_MultiThread          | 10            |    768.71 μs |  17.955 μs |       1 B |
| DefaultEcs_MonoThread           | 10            |    781.55 μs |   8.936 μs |       1 B |
| LeopotamEcsLite                 | 10            |    819.39 μs |  10.878 μs |       1 B |
| RelEcs                          | 10            |  1,701.47 μs |  54.946 μs |     218 B |
| MonoGameExtended                | 10            |  3,126.94 μs |  30.319 μs |     164 B |
| Morpeh_Stash                    | 10            |  9,875.96 μs | 129.094 μs |      17 B |
| Morpeh_Direct                   | 10            | 11,816.66 μs | 106.962 μs |      17 B |
| SveltoECS                       | 10            |           NA |         NA |        NA |


## [SystemWithTwoComponentsMultipleComposition](results/Ecs.CSharp.Benchmark.SystemWithTwoComponentsMultipleComposition-report-github.md)
Modify entities with two components while different entity compositions match the the components query.

| Method                          | Mean        | StdDev     | Allocated |
|-------------------------------- |------------:|-----------:|----------:|
| FrifloEngineEcs_MultiThread     |    12.43 μs |   1.049 μs |         - |
| Frent_Simd                      |    14.03 μs |   0.122 μs |         - |
| FrifloEngineEcs_SIMD_MonoThread |    14.34 μs |   0.058 μs |         - |
| Myriad_SingleThreadChunk_SIMD   |    16.32 μs |   0.128 μs |         - |
| Myriad_MultiThreadChunk         |    17.14 μs |   0.115 μs |    9216 B |
| TinyEcs_EachJob                 |    23.85 μs |   1.105 μs |    1552 B |
| Arch_MultiThread                |    32.02 μs |   0.144 μs |         - |
| TinyEcs_Each                    |    33.41 μs |   0.314 μs |         - |
| HypEcs_MonoThread               |    44.68 μs |   0.205 μs |     112 B |
| Frent_QueryInline               |    44.93 μs |   0.172 μs |         - |
| Arch_MonoThread_SourceGenerated |    47.84 μs |   0.226 μs |         - |
| Myriad_SingleThreadChunk        |    48.31 μs |   0.189 μs |         - |
| HypEcs_MultiThread              |    49.12 μs |   0.274 μs |    1872 B |
| Frent_QueryDelegate             |    51.48 μs |   0.174 μs |         - |
| Myriad_SingleThread             |    52.64 μs |   0.246 μs |         - |
| FrifloEngineEcs_MonoThread      |    56.93 μs |   0.327 μs |         - |
| Arch_MonoThread                 |    57.47 μs |   0.314 μs |         - |
| Fennecs_Raw                     |    58.86 μs |   0.215 μs |         - |
| Fennecs_ForEach                 |    63.21 μs |   0.372 μs |         - |
| Myriad_MultiThread              |    68.27 μs |   0.339 μs |   20865 B |
| FlecsNet_Iter                   |    79.81 μs |   0.420 μs |         - |
| Fennecs_Job                     |    94.79 μs |   1.576 μs |         - |
| DefaultEcs_MultiThread          |   108.93 μs |   3.569 μs |         - |
| Myriad_Delegate                 |   113.14 μs |   0.362 μs |         - |
| DefaultEcs_MonoThread           |   124.09 μs |   0.978 μs |         - |
| FlecsNet_Each                   |   134.08 μs |   0.238 μs |         - |
| LeopotamEcs                     |   158.35 μs |   1.551 μs |         - |
| Myriad_Enumerable               |   200.01 μs |   3.006 μs |         - |
| LeopotamEcsLite                 |   216.20 μs |   1.068 μs |         - |
| SveltoECS                       |   223.22 μs |   0.700 μs |         - |
| RelEcs                          |   355.92 μs |   7.512 μs |     169 B |
| MonoGameExtended                |   534.19 μs |  10.930 μs |     161 B |
| Morpeh_Stash                    | 2,380.69 μs |  40.379 μs |       4 B |
| Morpeh_Direct                   | 3,934.95 μs |  63.272 μs |       8 B |


# Other benchmarks

While we are only looking at c# libs here, you may want to check other benchmarks for different langage. This list is not exaustive obviously, feel free to open a MR to add more if you are interested.
- https://github.com/abeimler/ecs_benchmark

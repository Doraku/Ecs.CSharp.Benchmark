# ECS c# Benchmark
This repo contains benchmarks of some c# ECS frameworks. Feel free to add your own or correct usage of existing ones! Please make your framework available as a nuget package to ease referencing and updating versions.

The benchmarks are not representative of usage in real conditions but results can still be interesting to look at.

All results are obtained from the same toaster, with the same load, so comparison is fairer.

Tested frameworks:
- [Arch](https://github.com/genaray/Arch)
- [DefaultEcs](https://github.com/Doraku/DefaultEcs)
- [Fennecs](https://github.com/thygrrr/fennecs)
- [Flecs.Net](https://github.com/BeanCheeseBurrito/Flecs.NET)
- [Friflo.Engine.ECS](https://github.com/friflo/Friflo.Json.Fliox/blob/main/Engine/README.md)
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


| Method           | Mean      | StdDev    | Allocated   |
|----------------- |----------:|----------:|------------:|
| Arch             |  7.039 ms | 0.0645 ms |  3178.16 KB |
| DefaultEcs       | 11.389 ms | 0.1834 ms | 11321.11 KB |
| Fennecs          | 10.429 ms | 0.3498 ms | 13636.45 KB |
| FlecsNet         |  6.431 ms | 0.1844 ms |     2.73 KB |
| FrifloEngineEcs  |  2.837 ms | 0.3247 ms |  5722.08 KB |
| LeopotamEcsLite  |  3.608 ms | 0.2956 ms |  7151.08 KB |
| LeopotamEcs      |  6.285 ms | 0.5788 ms | 13685.65 KB |
| MonoGameExtended |  8.255 ms | 1.5408 ms | 16408.89 KB |
| Morpeh_Direct    | 58.202 ms | 8.1945 ms | 41305.76 KB |
| Morpeh_Stash     | 45.100 ms | 4.1339 ms | 41305.76 KB |
| Myriad           | 10.845 ms | 0.2996 ms |  6914.67 KB |
| HypEcs           |  9.897 ms | 0.4462 ms | 25827.05 KB |
| RelEcs           | 14.758 ms | 0.6834 ms | 29706.66 KB |
| SveltoECS        | 21.747 ms | 1.0680 ms |     3.22 KB |
| TinyEcs          |  7.454 ms | 0.1306 ms |  7834.44 KB |

## [CreateEntityWithTwoComponents](results/Ecs.CSharp.Benchmark.CreateEntityWithTwoComponents-report-github.md)
Create entities with two components.

| Method           | Mean       | StdDev    | Allocated    |
|----------------- |-----------:|----------:|-------------:|
| Arch             |   6.840 ms | 0.0855 ms |   3558.44 KB |
| DefaultEcs       |   8.515 ms | 0.2086 ms |   15418.9 KB |
| Fennecs          |  15.376 ms | 0.1575 ms |  15174.45 KB |
| FlecsNet         |  11.082 ms | 0.0947 ms |      3.11 KB |
| FrifloEngineEcs  |   2.522 ms | 0.1804 ms |   6236.16 KB |
| HypEcs           |  18.703 ms | 0.3473 ms |  45334.39 KB |
| LeopotamEcsLite  |   5.162 ms | 0.3004 ms |   9199.61 KB |
| LeopotamEcs      |   6.982 ms | 0.4454 ms |  14711.02 KB |
| MonoGameExtended |  13.274 ms | 0.6977 ms |  23373.84 KB |
| Morpeh_Direct    | 239.144 ms | 4.4908 ms | 128867.66 KB |
| Morpeh_Stash     |  39.734 ms | 2.4779 ms |   48133.7 KB |
| Myriad           |  15.280 ms | 0.1624 ms |   7309.77 KB |
| RelEcs           |  36.776 ms | 0.6916 ms |  50749.86 KB |
| SveltoECS        |  34.237 ms | 0.6508 ms |      4.14 KB |
| TinyEcs          |  14.042 ms | 0.1360 ms |  13785.08 KB |


## [CreateEntityWithThreeComponents](results/Ecs.CSharp.Benchmark.CreateEntityWithThreeComponents-report-github.md)
Create entities with three components.

| Method           | Mean       | StdDev    | Allocated   |
|----------------- |-----------:|----------:|------------:|
| Arch             |   3.316 ms | 0.0901 ms |  3947.67 KB |
| SveltoECS        |  46.643 ms | 2.0437 ms |     4.64 KB |
| DefaultEcs       |  10.885 ms | 0.4542 ms | 19516.68 KB |
| Fennecs          |  24.621 ms | 0.2685 ms | 16713.12 KB |
| FlecsNet         |  16.746 ms | 0.2291 ms |     3.48 KB |
| FrifloEngineEcs  |   2.525 ms | 0.1481 ms |  6750.23 KB |
| HypEcs           |  30.509 ms | 0.8438 ms |  68750.7 KB |
| LeopotamEcsLite  |   5.995 ms | 0.5505 ms | 11248.14 KB |
| LeopotamEcs      |   8.869 ms | 0.5571 ms |  15736.4 KB |
| MonoGameExtended |  21.133 ms | 0.9090 ms | 30154.05 KB |
| Morpeh_Direct    | 147.879 ms | 2.6211 ms | 83802.09 KB |
| Morpeh_Stash     |  52.206 ms | 1.7453 ms |  44724.3 KB |
| Myriad           |  22.632 ms | 0.1896 ms |  7704.88 KB |
| RelEcs           |  65.055 ms | 1.1498 ms | 75699.76 KB |
| TinyEcs          |  23.599 ms | 0.1396 ms | 21314.25 KB |


## [SystemWithOneComponent](results/Ecs.CSharp.Benchmark.SystemWithOneComponent-report-github.md)
Modify entities with one component. The padding aims to simulate real situation when processed entities and their components are not sequential.

> Note: Padding tests were removed for libraries that use archetypes to save space as padding makes no difference in their results

| Method                                 | EntityPadding | Mean         | StdDev     | Allocated |
|--------------------------------------- |-------------- |-------------:|-----------:|----------:|
| Arch_MonoThread                        | 0             |    23.420 μs |  0.0915 μs |         - |
| Arch_MonoThread_SourceGenerated        | 0             |    23.251 μs |  0.0572 μs |         - |
| Arch_MultiThread                       | 0             |    49.880 μs |  0.1314 μs |         - |
| DefaultEcs_ComponentSystem_MonoThread  | 0             |    21.602 μs |  0.0286 μs |         - |
| DefaultEcs_ComponentSystem_MultiThread | 0             |     5.319 μs |  0.2135 μs |         - |
| DefaultEcs_EntitySetSystem_MonoThread  | 0             |    95.132 μs |  0.4925 μs |         - |
| DefaultEcs_EntitySetSystem_MultiThread | 0             |    11.450 μs |  0.3505 μs |         - |
| Fennecs_ForEach                        | 0             |    21.648 μs |  0.0110 μs |         - |
| Fennecs_Job                            | 0             |    53.325 μs |  0.1703 μs |         - |
| Fennecs_Raw                            | 0             |    43.673 μs |  0.4105 μs |         - |
| FlecsNet_Each                          | 0             |    71.867 μs |  0.8808 μs |         - |
| FlecsNet_Iter                          | 0             |    50.694 μs |  0.0579 μs |         - |
| FrifloEngineEcs_MonoThread             | 0             |    21.537 μs |  0.0918 μs |         - |
| FrifloEngineEcs_MultiThread            | 0             |     5.991 μs |  0.2777 μs |         - |
| FrifloEngineEcs_SIMD_MonoThread        | 0             |     6.411 μs |  0.0190 μs |         - |
| HypEcs_MonoThread                      | 0             |    38.163 μs |  0.1295 μs |      72 B |
| HypEcs_MultiThread                     | 0             |    39.918 μs |  0.1593 μs |    1832 B |
| LeopotamEcsLite                        | 0             |   111.991 μs |  0.0694 μs |         - |
| LeopotamEcs                            | 0             |    83.299 μs |  0.2094 μs |         - |
| MonoGameExtended                       | 0             |   253.155 μs |  1.1879 μs |     160 B |
| Morpeh_Direct                          | 0             | 1,043.726 μs |  1.3991 μs |       2 B |
| Morpeh_Stash                           | 0             |   568.116 μs |  2.5755 μs |       1 B |
| Myriad_SingleThread                    | 0             |    51.304 μs |  0.3035 μs |         - |
| Myriad_MultiThread                     | 0             |   837.895 μs |  8.5220 μs |  442063 B |
| Myriad_SingleThreadChunk               | 0             |    23.897 μs |  0.1584 μs |         - |
| Myriad_MultiThreadChunk                | 0             |    21.416 μs |  0.0731 μs |    5411 B |
| Myriad_Enumerable                      | 0             |   112.296 μs |  0.0526 μs |         - |
| Myriad_Delegate                        | 0             |    67.135 μs |  0.1576 μs |         - |
| Myriad_SingleThreadChunk_SIMD          | 0             |     9.227 μs |  0.0390 μs |         - |
| RelEcs                                 | 0             |   183.712 μs |  0.2183 μs |     120 B |
| SveltoECS                              | 0             |   108.539 μs |  0.4199 μs |         - |
| TinyEcs_Each                           | 0             |    29.126 μs |  0.0905 μs |         - |
| TinyEcs_EachJob                        | 0             |    18.492 μs |  0.0333 μs |    1552 B |


## [SystemWithTwoComponents](results/Ecs.CSharp.Benchmark.SystemWithTwoComponents-report-github.md)
Modify entities with two components. The padding aims to simulate real situation when processed entities and their components are not sequential.

| Method                          | EntityPadding | Mean         | StdDev      | Allocated |
|-------------------------------- |-------------- |-------------:|------------:|----------:|
| Arch_MonoThread                 | 0             |    45.308 μs |   0.1236 μs |         - |
| Arch_MonoThread_SourceGenerated | 0             |    28.794 μs |   0.0600 μs |         - |
| Arch_MultiThread                | 0             |    57.264 μs |   0.0727 μs |         - |
| DefaultEcs_MonoThread           | 0             |   110.189 μs |   0.0846 μs |         - |
| DefaultEcs_MultiThread          | 0             |    16.247 μs |   0.8215 μs |         - |
| Fennecs_ForEach                 | 0             |    44.249 μs |   0.1111 μs |         - |
| Fennecs_Job                     | 0             |    50.736 μs |   0.1419 μs |         - |
| Fennecs_Raw                     | 0             |    43.445 μs |   0.2376 μs |         - |
| FlecsNet_Each                   | 0             |   196.370 μs |  17.8606 μs |         - |
| FlecsNet_Iter                   | 0             |    62.017 μs |   0.2454 μs |         - |
| FrifloEngineEcs_MonoThread      | 0             |    45.461 μs |   0.0384 μs |         - |
| FrifloEngineEcs_MultiThread     | 0             |     8.368 μs |   0.4414 μs |         - |
| FrifloEngineEcs_SIMD_MonoThread | 0             |     8.607 μs |   0.0630 μs |         - |
| HypEcs_MonoThread               | 0             |    32.666 μs |   0.0306 μs |     112 B |
| HypEcs_MultiThread              | 0             |    34.746 μs |   0.1640 μs |    1872 B |
| LeopotamEcsLite                 | 0             |   155.337 μs |   0.4928 μs |         - |
| LeopotamEcs                     | 0             |   125.247 μs |   0.3555 μs |         - |
| MonoGameExtended                | 0             |   300.108 μs |   0.2734 μs |     160 B |
| Morpeh_Direct                   | 0             | 1,842.942 μs |  31.7401 μs |       2 B |
| Morpeh_Stash                    | 0             |   836.561 μs |   3.2319 μs |       1 B |
| Myriad_SingleThread             | 0             |    54.268 μs |   0.2703 μs |         - |
| Myriad_MultiThread              | 0             |   982.415 μs |   8.7288 μs |  472799 B |
| Myriad_SingleThreadChunk        | 0             |    39.777 μs |   0.0332 μs |         - |
| Myriad_MultiThreadChunk         | 0             |    22.829 μs |   0.0407 μs |    5464 B |
| Myriad_Enumerable               | 0             |   234.799 μs |   0.9445 μs |         - |
| Myriad_Delegate                 | 0             |    87.757 μs |   0.3752 μs |         - |
| Myriad_SingleThreadChunk_SIMD   | 0             |    12.391 μs |   0.0837 μs |         - |
| RelEcs                          | 0             |   204.882 μs |   0.2625 μs |     168 B |
| SveltoECS                       | 0             |   217.040 μs |   0.6463 μs |         - |
| TinyEcs_Each                    | 0             |    26.479 μs |   0.0787 μs |         - |
| TinyEcs_EachJob                 | 0             |    18.590 μs |   0.0992 μs |    1552 B |

## [SystemWithThreeComponents](results/Ecs.CSharp.Benchmark.SystemWithThreeComponents-report-github.md)
Modify entities with three components. The padding aims to simulate real situation when processed entities and their components are not sequential.

| Method                          | EntityPadding | Mean          | StdDev      | Allocated |
|-------------------------------- |-------------- |--------------:|------------:|----------:|
| Arch_MonoThread                 | 0             |     51.312 μs |   0.1633 μs |         - |
| Arch_MonoThread_SourceGenerated | 0             |    135.426 μs |   0.6915 μs |         - |
| Arch_MultiThread                | 0             |     61.860 μs |   0.4861 μs |         - |
| DefaultEcs_MonoThread           | 0             |    141.616 μs |   0.4521 μs |         - |
| DefaultEcs_MultiThread          | 0             |     23.877 μs |   1.1962 μs |         - |
| Fennecs_ForEach                 | 0             |     64.932 μs |   0.2161 μs |         - |
| Fennecs_Job                     | 0             |     53.470 μs |   0.0521 μs |         - |
| Fennecs_Raw                     | 0             |     65.706 μs |   0.3044 μs |         - |
| FlecsNet_Each                   | 0             |    220.183 μs |   0.4932 μs |         - |
| FlecsNet_Iter                   | 0             |     76.079 μs |   0.4874 μs |         - |
| FrifloEngineEcs_MonoThread      | 0             |     44.047 μs |   0.0184 μs |         - |
| FrifloEngineEcs_MultiThread     | 0             |      9.069 μs |   0.3902 μs |         - |
| FrifloEngineEcs_SIMD_MonoThread | 0             |     10.892 μs |   0.0844 μs |         - |
| HypEcs_MonoThread               | 0             |     44.443 μs |   0.0298 μs |     152 B |
| HypEcs_MultiThread              | 0             |     46.400 μs |   0.1855 μs |    1912 B |
| LeopotamEcsLite                 | 0             |    234.923 μs |   0.3102 μs |         - |
| LeopotamEcs                     | 0             |    184.047 μs |   0.6268 μs |         - |
| MonoGameExtended                | 0             |    389.794 μs |   0.4324 μs |     160 B |
| Morpeh_Direct                   | 0             |  2,346.662 μs |  10.2549 μs |       3 B |
| Morpeh_Stash                    | 0             |    985.408 μs |   6.0252 μs |       2 B |
| Myriad_SingleThread             | 0             |     55.562 μs |   0.3409 μs |         - |
| Myriad_MultiThread              | 0             |  1,094.648 μs |   7.6782 μs |  490610 B |
| Myriad_SingleThreadChunk        | 0             |     48.025 μs |   0.1687 μs |         - |
| Myriad_MultiThreadChunk         | 0             |     24.359 μs |   0.0986 μs |    5515 B |
| Myriad_Enumerable               | 0             |    245.209 μs |   1.3090 μs |         - |
| Myriad_Delegate                 | 0             |     90.019 μs |   0.0226 μs |         - |
| RelEcs                          | 0             |    247.398 μs |   0.6877 μs |     217 B |
| SveltoECS                       | 0             |    322.910 μs |   2.8128 μs |         - |
| TinyEcs_Each                    | 0             |     39.623 μs |   0.1817 μs |         - |
| TinyEcs_EachJob                 | 0             |     20.120 μs |   0.0635 μs |    1560 B |


## [SystemWithTwoComponentsMultipleComposition](results/Ecs.CSharp.Benchmark.SystemWithTwoComponentsMultipleComposition-report-github.md)
Modify entities with two components while different entity compositions match the the components query.

| Method                          | Mean         | StdDev     | Allocated |
|-------------------------------- |-------------:|-----------:|----------:|
| Arch                            |    45.588 μs |  0.1559 μs |         - |
| Arch_MonoThread_SourceGenerated |    28.864 μs |  0.1477 μs |         - |
| Arch_MultiThread                |   216.326 μs |  0.4440 μs |         - |
| DefaultEcs_MonoThread           |   111.634 μs |  0.2742 μs |         - |
| DefaultEcs_MultiThread          |    17.336 μs |  0.7883 μs |         - |
| Fennecs_ForEach                 |    45.614 μs |  0.2408 μs |         - |
| Fennecs_Job                     |    54.985 μs |  0.1906 μs |         - |
| Fennecs_Raw                     |    44.672 μs |  0.2179 μs |         - |
| FlecsNet_Each                   |   206.724 μs |  0.1340 μs |         - |
| FlecsNet_Iter                   |    58.126 μs |  0.2709 μs |         - |
| FrifloEngineEcs_MonoThread      |    45.401 μs |  0.2210 μs |         - |
| FrifloEngineEcs_MultiThread     |    21.822 μs |  0.9865 μs |         - |
| FrifloEngineEcs_SIMD_MonoThread |     9.130 μs |  0.0388 μs |         - |
| HypEcs_MonoThread               |    33.012 μs |  0.1687 μs |     352 B |
| HypEcs_MultiThread              |    11.779 μs |  0.3269 μs |    2826 B |
| LeopotamEcsLite                 |   155.412 μs |  0.0566 μs |         - |
| LeopotamEcs                     |   124.123 μs |  0.5029 μs |         - |
| MonoGameExtended                |   301.107 μs |  1.0381 μs |     160 B |
| Morpeh_Direct                   | 1,518.622 μs | 11.4268 μs |       2 B |
| Morpeh_Stash                    |   862.835 μs |  6.5229 μs |       1 B |
| Myriad_SingleThread             |    54.953 μs |  0.1836 μs |         - |
| Myriad_MultiThread              |   985.841 μs | 10.3412 μs |  477241 B |
| Myriad_SingleThreadChunk        |    40.976 μs |  0.0621 μs |         - |
| Myriad_MultiThreadChunk         |    54.084 μs |  0.2662 μs |   19365 B |
| Myriad_Enumerable               |   241.300 μs |  1.0275 μs |         - |
| Myriad_Delegate                 |    67.886 μs |  0.2663 μs |         - |
| Myriad_SingleThreadChunk_SIMD   |    12.698 μs |  0.0845 μs |         - |
| RelEcs                          |   327.387 μs |  5.2210 μs |     488 B |
| SveltoECS                       |   195.377 μs |  0.8394 μs |         - |
| TinyEcs_Each                    |    26.289 μs |  0.0699 μs |         - |
| TinyEcs_EachJob                 |    18.676 μs |  0.0397 μs |    2080 B |


# Other benchmarks

While we are only looking at c# libs here, you may want to check other benchmarks for different langage. This list is not exaustive obviously, feel free to open a MR to add more if you are interested.
- https://github.com/abeimler/ecs_benchmark

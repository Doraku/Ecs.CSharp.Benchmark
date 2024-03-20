# ECS c# Benchmark
This repo contains benchmarks of some c# ECS frameworks. Feel free to add your own or correct usage of existing ones! Please make your framework available as a nuget package to ease referencing and updating versions.

The benchmarks are not representative of usage in real conditions but results can still be interesting to look at.

All results are obtained from the same toaster, with the same load, so comparison is fairer.

Tested frameworks:
- [Arch](https://github.com/genaray/Arch)
- [DefaultEcs](https://github.com/Doraku/DefaultEcs)
- [Friflo.Engine.ECS](https://github.com/friflo/Friflo.Json.Fliox/blob/main/Engine/README.md)
- [HypEcs](https://github.com/Byteron/HypEcs)
- [Leopotam.Ecs](https://github.com/Leopotam/ecs) using what I believe is a nuget package not made by the actual author and compiled in debug...
- [Leopotam.EcsLite](https://github.com/Leopotam/ecslite) using what I believe is a nuget package not made by the actual author and compiled in debug...
- [MonoGame.Extended](https://github.com/craftworkgames/MonoGame.Extended)
- [Morpeh](https://github.com/scellecs/morpeh)
- [Myriad.ECS](https://github.com/martindevans/Myriad.ECS)
- [RelEcs](https://github.com/Byteron/RelEcs)
- [Svelto.ECS](https://github.com/sebas77/Svelto.ECS)

Removed frameworks:
- [Entitas](https://github.com/sschmid/Entitas) removed because it was taking forever to initialize in the later tests when moved to net8, you can check older benchmark results [here](https://github.com/Doraku/Ecs.CSharp.Benchmark/tree/3574b2dfb948e941a208f77eaf9e94b73d58e6bf)

Tested versions may not be latest available, that's because I'm lazy and new versions may introduce breaking changes, so feel free to create pull requests to update libs you are knowledgeable about.

## [CreateEntityWithOneComponent](results/Ecs.CSharp.Benchmark.CreateEntityWithOneComponent-report-github.md)
Create entities with one component.

| Method           | Mean      | CacheMisses/Op | Allocated   |
|----------------- |----------:|---------------:|------------:|
| Arch             | 18.022 ms |         78,889 |  9725.83 KB |
| DefaultEcs       |  8.520 ms |        105,229 | 11324.68 KB |
| FrifloEngineEcs  |  3.467 ms |         45,714 |  5724.16 KB |
| HypEcs           | 15.946 ms |        238,660 | 25825.74 KB |
| LeopotamEcs      | 20.304 ms |        257,024 | 13684.03 KB |
| LeopotamEcsLite  | 11.568 ms |        100,489 |  8170.31 KB |
| MonoGameExtended | 28.082 ms |        254,089 | 16412.13 KB |
| Morpeh_Direct    | 13.625 ms |        133,698 | 12481.63 KB |
| Morpeh_Stash     | 13.183 ms |        132,164 | 12481.63 KB |
| RelEcs           | 43.917 ms |        744,480 | 29705.35 KB |
| SveltoECS        | 36.594 ms |        751,995 |     1.25 KB |

## [CreateEntityWithTwoComponents](results/Ecs.CSharp.Benchmark.CreateEntityWithTwoComponents-report-github.md)
Create entities with two components.

| Method           | Mean      | CacheMisses/Op | Allocated   |
|----------------- |----------:|---------------:|------------:|
| Arch             |  11.17 ms |         64,717 |  9891.36 KB |
| DefaultEcs       |  13.93 ms |        167,855 | 15417.46 KB |
| FrifloEngineEcs  |   3.40 ms |         43,128 |  6236.16 KB |
| HypEcs           |  31.64 ms |        348,540 | 45333.08 KB |
| LeopotamEcs      |  18.57 ms |        261,029 | 14709.41 KB |
| LeopotamEcsLite  |  18.97 ms |        114,688 | 10219.18 KB |
| MonoGameExtended |  46.98 ms |        578,387 | 23372.71 KB |
| Morpeh_Direct    |  68.96 ms |        688,518 | 42308.41 KB |
| Morpeh_Stash     |  24.12 ms |        202,301 | 19310.76 KB |
| RelEcs           | 102.98 ms |      1,332,887 | 50755.08 KB |
| SveltoECS        |  58.31 ms |      1,274,636 |     2.17 KB |

## [CreateEntityWithThreeComponents](results/Ecs.CSharp.Benchmark.CreateEntityWithThreeComponents-report-github.md)
Create entities with three components.

| Method           | Mean      | CacheMisses/Op | Allocated   |
|----------------- |----------:|---------------:|------------:|
| Arch             |  12.87 ms |         65,081 | 10381.21 KB |
| DefaultEcs       |  17.90 ms |        226,834 | 19515.29 KB |
| FrifloEngineEcs  |  3.421 ms |         42,792 |  6758.40 KB |
| HypEcs           |  50.00 ms |        513,928 | 68747.41 KB |
| LeopotamEcs      |  28.95 ms |        249,774 | 15734.71 KB |
| LeopotamEcsLite  |  26.25 ms |        150,733 | 12268.14 KB |
| MonoGameExtended |  57.80 ms |      1,216,620 | 30152.63 KB |
| Morpeh_Direct    |  34.79 ms |        304,068 | 26114.95 KB |
| Morpeh_Stash     |  16.57 ms |        151,006 | 15896.18 KB |
| RelEcs           | 129.63 ms |      1,929,645 | 75704.51 KB |
| SveltoECS        |  78.32 ms |      1,592,638 |     2.67 KB |

## [SystemWithOneComponent](results/Ecs.CSharp.Benchmark.SystemWithOneComponent-report-github.md)
Modify entities with one component. The padding aims to simulate real situation when processed entities and their components are not sequential.

| Method                                 | EntityPadding | Mean        | CacheMisses/Op | Allocated |
|--------------------------------------- |-------------- |------------:|---------------:|----------:|
| Arch_MonoThread                        | 0             |    61.77 μs |              2 |         - |
| Arch_MultiThread                       | 0             |    29.30 μs |              1 |         - |
| DefaultEcs_ComponentSystem_MonoThread  | 0             |    56.25 μs |              1 |         - |
| DefaultEcs_ComponentSystem_MultiThread | 0             |    15.21 μs |              1 |         - |
| DefaultEcs_EntitySetSystem_MonoThread  | 0             |   118.02 μs |              3 |         - |
| DefaultEcs_EntitySetSystem_MultiThread | 0             |    31.55 μs |              3 |         - |
| FrifloEngineEcs_MonoThread             | 0             |    56.43 μs |              3 |     208 B |
| FrifloEngineEcs_SIMD_MonoThread        | 0             |    28.78 μs |              2 |     208 B |
| HypEcs_MonoThread                      | 0             |    56.46 μs |              1 |      72 B |
| HypEcs_MultiThread                     | 0             |    58.95 μs |             15 |    1832 B |
| LeopotamEcs                            | 0             |   135.90 μs |              5 |         - |
| LeopotamEcsLite                        | 0             | 1,850.38 μs |            124 |       3 B |
| MonoGameExtended                       | 0             |   536.11 μs |         10,860 |     161 B |
| Morpeh_Direct                          | 0             | 2,872.35 μs |          4,500 |       6 B |
| Morpeh_Stash                           | 0             | 1,034.99 μs |          4,665 |       3 B |
| RelEcs                                 | 0             |   567.56 μs |         16,088 |     121 B |
| SveltoECS                              | 0             |   197.01 μs |              4 |         - |
|                                        |               |             |                |           |
| Arch_MonoThread                        | 10            |    61.75 μs |              2 |         - |
| Arch_MultiThread                       | 10            |    29.50 μs |              1 |         - |
| DefaultEcs_ComponentSystem_MonoThread  | 10            |    56.25 μs |              1 |         - |
| DefaultEcs_ComponentSystem_MultiThread | 10            |    15.31 μs |              1 |         - |
| DefaultEcs_EntitySetSystem_MonoThread  | 10            |   244.32 μs |          6,200 |       1 B |
| DefaultEcs_EntitySetSystem_MultiThread | 10            |    83.35 μs |          6,806 |         - |
| FrifloEngineEcs_MonoThread             | 10            |    56.78 μs |              2 |     208 B |
| FrifloEngineEcs_SIMD_MonoThread        | 10            |    27.18 μs |              2 |     208 B |
| HypEcs_MonoThread                      | 10            |    56.78 μs |              1 |      72 B |
| HypEcs_MultiThread                     | 10            |    60.34 μs |             12 |    1832 B |
| LeopotamEcs                            | 10            |   136.22 μs |              3 |         - |
| LeopotamEcsLite                        | 10            | 4,020.44 μs |         93,943 |      11 B |
| MonoGameExtended                       | 10            | 1,996.01 μs |        105,699 |     166 B |
| Morpeh_Direct                          | 10            | 6,109.28 μs |        167,142 |      11 B |
| Morpeh_Stash                           | 10            | 3,980.00 μs |        179,288 |      11 B |
| RelEcs                                 | 10            | 1,235.45 μs |         53,159 |     123 B |
| SveltoECS                              | 10            |   197.04 μs |              3 |         - |


## [SystemWithTwoComponents](results/Ecs.CSharp.Benchmark.SystemWithTwoComponents-report-github.md)
Modify entities with two components. The padding aims to simulate real situation when processed entities and their components are not sequential.

| Method                          | EntityPadding | Mean        | CacheMisses/Op | Allocated |
|-------------------------------- |-------------- |------------:|---------------:|----------:|
| Arch_MonoThread                 | 0             |   174.10 μs |              6 |         - |
| Arch_MultiThread                | 0             |    36.09 μs |              3 |         - |
| DefaultEcs_MonoThread           | 0             |   200.28 μs |              8 |         - |
| DefaultEcs_MultiThread          | 0             |    53.54 μs |             32 |         - |
| FrifloEngineEcs_MonoThread      | 0             |    84.63 μs |              3 |     216 B |
| FrifloEngineEcs_SIMD_MonoThread | 0             |    32.38 μs |              3 |     216 B |
| HypEcs_MonoThread               | 0             |    57.90 μs |              2 |     112 B |
| HypEcs_MultiThread              | 0             |    60.35 μs |             13 |    1872 B |
| LeopotamEcs                     | 0             |   231.52 μs |              6 |         - |
| LeopotamEcsLite                 | 0             | 3,865.86 μs |            607 |       6 B |
| MonoGameExtended                | 0             |   827.06 μs |         23,761 |     161 B |
| Morpeh_Direct                   | 0             | 4,653.57 μs |          6,937 |      11 B |
| Morpeh_Stash                    | 0             | 2,415.97 μs |          7,613 |       6 B |
| RelEcs                          | 0             |   628.46 μs |         18,389 |     169 B |
| SveltoECS                       | 0             |   309.20 μs |             12 |       1 B |
|                                 |               |             |                |           |
| Arch_MonoThread                 | 10            |   174.20 μs |              4 |         - |
| Arch_MultiThread                | 10            |    35.99 μs |              2 |         - |
| DefaultEcs_MonoThread           | 10            |   887.92 μs |         59,358 |       1 B |
| DefaultEcs_MultiThread          | 10            |   684.24 μs |         79,813 |       1 B |
| FrifloEngineEcs_MonoThread      | 10            |    85.35 μs |              3 |     216 B |
| FrifloEngineEcs_SIMD_MonoThread | 10            |    39.45 μs |              3 |     216 B |
| HypEcs_MonoThread               | 10            |    58.99 μs |              2 |     112 B |
| HypEcs_MultiThread              | 10            |    61.48 μs |             13 |    1872 B |
| LeopotamEcs                     | 10            |   241.93 μs |            152 |         - |
| LeopotamEcsLite                 | 10            | 8,285.54 μs |        110,260 |      22 B |
| MonoGameExtended                | 10            | 2,869.26 μs |        177,309 |     166 B |
| Morpeh_Direct                   | 10            | 7,882.32 μs |        180,485 |      22 B |
| Morpeh_Stash                    | 10            | 7,363.95 μs |        193,726 |      11 B |
| RelEcs                          | 10            | 1,782.27 μs |        106,469 |     171 B |
| SveltoECS                       | 10            | 1,868.02 μs |            600 |       3 B |


## [SystemWithThreeComponents](results/Ecs.CSharp.Benchmark.SystemWithThreeComponents-report-github.md)
Modify entities with three components. The padding aims to simulate real situation when processed entities and their components are not sequential.

| Method                          | EntityPadding | Mean         | CacheMisses/Op | Allocated |
|-------------------------------- |-------------- |-------------:|---------------:|----------:|
| Arch_MonoThread                 | 0             |    110.90 μs |              6 |         - |
| Arch_MultiThread                | 0             |     40.42 μs |              4 |         - |
| DefaultEcs_MonoThread           | 0             |    315.25 μs |             30 |       1 B |
| DefaultEcs_MultiThread          | 0             |     87.33 μs |             84 |         - |
| FrifloEngineEcs_MonoThread      | 0             |     70.08 ns |              0 |     168 B |
| FrifloEngineEcs_SIMD_MonoThread | 0             |     68.65 ns |              0 |     168 B |
| HypEcs_MonoThread               | 0             |     85.20 μs |              4 |     152 B |
| HypEcs_MultiThread              | 0             |     87.86 μs |             16 |    1912 B |
| LeopotamEcs                     | 0             |    337.48 μs |             15 |       1 B |
| LeopotamEcsLite                 | 0             |  5,846.36 μs |          1,855 |      11 B |
| MonoGameExtended                | 0             |  1,078.86 μs |         36,031 |     163 B |
| Morpeh_Direct                   | 0             |  6,529.41 μs |          8,788 |      22 B |
| Morpeh_Stash                    | 0             |  3,111.72 μs |          9,658 |       6 B |
| RelEcs                          | 0             |    903.30 μs |         35,170 |     217 B |
| SveltoECS                       | 0             |    478.11 μs |             13 |       1 B |
|                                 |               |              |                |           |
| Arch_MonoThread                 | 10            |    111.05 μs |              6 |         - |
| Arch_MultiThread                | 10            |     40.22 μs |              3 |         - |
| DefaultEcs_MonoThread           | 10            |  1,087.29 μs |         52,219 |       3 B |
| DefaultEcs_MultiThread          | 10            |    966.01 μs |        123,190 |       1 B |
| FrifloEngineEcs_MonoThread      | 10            |     69.85 ns |              0 |     168 B |
| FrifloEngineEcs_SIMD_MonoThread | 10            |     71.10 ns |              0 |     168 B |
| HypEcs_MonoThread               | 10            |     84.86 μs |              4 |     152 B |
| HypEcs_MultiThread              | 10            |     87.58 μs |             15 |    1912 B |
| LeopotamEcs                     | 10            |    503.75 μs |          1,841 |       1 B |
| LeopotamEcsLite                 | 10            | 11,357.17 μs |        111,617 |      22 B |
| MonoGameExtended                | 10            |  3,491.99 μs |        242,196 |     166 B |
| Morpeh_Direct                   | 10            |  9,850.22 μs |        204,342 |      22 B |
| Morpeh_Stash                    | 10            |  8,283.08 μs |        186,510 |      22 B |
| RelEcs                          | 10            |  2,236.64 μs |        164,969 |     222 B |
| SveltoECS                       | 10            |           NA |             NA |        NA |

## [SystemWithTwoComponentsMultipleComposition](results/Ecs.CSharp.Benchmark.SystemWithTwoComponentsMultipleComposition-report-github.md)
Modify entities with two components while different entity compositions match the the components query.

| Method                          | Mean        | CacheMisses/Op | Allocated |
|-------------------------------- |------------:|---------------:|----------:|
| Arch                            |    90.87 μs |              2 |         - |
| Arch_MultiThread                |    55.64 μs |              3 |         - |
| DefaultEcs_MonoThread           |   197.71 μs |              5 |         - |
| DefaultEcs_MultiThread          |    52.81 μs |              4 |         - |
| FrifloEngineEcs_MonoThread      |    84.88 μs |              3 |     304 B |
| FrifloEngineEcs_SIMD_MonoThread |    38.22 μs |              3 |     304 B |
| HypEcs_MonoThread               |    58.38 μs |              3 |     352 B |
| HypEcs_MultiThread              |    21.73 μs |             11 |    2655 B |
| LeopotamEcs                     |   235.56 μs |              5 |         - |
| LeopotamEcsLite                 | 3,703.18 μs |            594 |       7 B |
| MonoGameExtended                | 1,015.73 μs |         40,470 |     163 B |
| Morpeh_Direct                   | 5,087.22 μs |        114,642 |      14 B |
| Morpeh_Stash                    | 3,863.37 μs |        116,809 |       7 B |
| RelEcs                          | 1,564.69 μs |         83,810 |     491 B |
| SveltoECS                       |   309.39 μs |              7 |       1 B |

# Other benchmarks

While we are only looking at c# libs here, you may want to check other benchmarks for different langage. This list is not exaustive obviously, feel free to open a MR to add more if you are interested.
- https://github.com/abeimler/ecs_benchmark

```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3930/22H2/2022Update)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX


```
| Method                          | EntityCount | EntityPadding | Mean         | Error     | StdDev   | Gen0   | CacheMisses/Op | Allocated |
|-------------------------------- |------------ |-------------- |-------------:|----------:|---------:|-------:|---------------:|----------:|
| Arch_MonoThread                 | 100000      | 0             |    110.90 μs |  0.020 μs | 0.017 μs |      - |              6 |         - |
| Arch_MultiThread                | 100000      | 0             |     40.42 μs |  0.033 μs | 0.029 μs |      - |              4 |         - |
| DefaultEcs_MonoThread           | 100000      | 0             |    315.25 μs |  0.078 μs | 0.070 μs |      - |             30 |       1 B |
| DefaultEcs_MultiThread          | 100000      | 0             |     87.33 μs |  0.438 μs | 0.366 μs |      - |             84 |         - |
| FrifloEngineEcs_MonoThread      | 100000      | 0             |     70.08 ns |  0.524 ns | 0.465 ns | 0.0535 |              0 |     168 B |
| FrifloEngineEcs_SIMD_MonoThread | 100000      | 0             |     68.65 ns |  0.072 ns | 0.064 ns | 0.0535 |              0 |     168 B |
| HypEcs_MonoThread               | 100000      | 0             |     85.20 μs |  0.011 μs | 0.010 μs |      - |              4 |     152 B |
| HypEcs_MultiThread              | 100000      | 0             |     87.86 μs |  0.033 μs | 0.029 μs | 0.6104 |             16 |    1912 B |
| LeopotamEcs                     | 100000      | 0             |    337.48 μs |  0.068 μs | 0.060 μs |      - |             15 |       1 B |
| LeopotamEcsLite                 | 100000      | 0             |  5,846.36 μs |  3.651 μs | 3.237 μs |      - |          1,855 |      11 B |
| MonoGameExtended                | 100000      | 0             |  1,078.86 μs |  0.869 μs | 0.679 μs |      - |         36,031 |     163 B |
| Morpeh_Direct                   | 100000      | 0             |  6,529.41 μs |  8.381 μs | 7.840 μs |      - |          8,788 |      22 B |
| Morpeh_Stash                    | 100000      | 0             |  3,111.72 μs |  1.814 μs | 1.608 μs |      - |          9,658 |       6 B |
| RelEcs                          | 100000      | 0             |    903.30 μs |  3.331 μs | 2.953 μs |      - |         35,170 |     217 B |
| SveltoECS                       | 100000      | 0             |    478.11 μs |  0.045 μs | 0.040 μs |      - |             13 |       1 B |
|                                 |             |               |              |           |          |        |                |           |
| Arch_MonoThread                 | 100000      | 10            |    111.05 μs |  0.013 μs | 0.012 μs |      - |              6 |         - |
| Arch_MultiThread                | 100000      | 10            |     40.22 μs |  0.018 μs | 0.014 μs |      - |              3 |         - |
| DefaultEcs_MonoThread           | 100000      | 10            |  1,087.29 μs |  0.407 μs | 0.381 μs |      - |         52,219 |       3 B |
| DefaultEcs_MultiThread          | 100000      | 10            |    966.01 μs |  0.827 μs | 0.774 μs |      - |        123,190 |       1 B |
| FrifloEngineEcs_MonoThread      | 100000      | 10            |     69.85 ns |  0.311 ns | 0.291 ns | 0.0535 |              0 |     168 B |
| FrifloEngineEcs_SIMD_MonoThread | 100000      | 10            |     71.10 ns |  1.438 ns | 1.476 ns | 0.0535 |              0 |     168 B |
| HypEcs_MonoThread               | 100000      | 10            |     84.86 μs |  0.017 μs | 0.014 μs |      - |              4 |     152 B |
| HypEcs_MultiThread              | 100000      | 10            |     87.58 μs |  0.049 μs | 0.043 μs | 0.6104 |             15 |    1912 B |
| LeopotamEcs                     | 100000      | 10            |    503.75 μs |  0.354 μs | 0.276 μs |      - |          1,841 |       1 B |
| LeopotamEcsLite                 | 100000      | 10            | 11,357.17 μs |  1.541 μs | 1.366 μs |      - |        111,617 |      22 B |
| MonoGameExtended                | 100000      | 10            |  3,491.99 μs |  8.411 μs | 7.456 μs |      - |        242,196 |     166 B |
| Morpeh_Direct                   | 100000      | 10            |  9,850.22 μs |  6.149 μs | 5.135 μs |      - |        204,342 |      22 B |
| Morpeh_Stash                    | 100000      | 10            |  8,283.08 μs | 10.876 μs | 8.491 μs |      - |        186,510 |      22 B |
| RelEcs                          | 100000      | 10            |  2,236.64 μs |  5.558 μs | 4.641 μs |      - |        164,969 |     222 B |
| SveltoECS                       | 100000      | 10            |           NA |        NA |       NA |     NA |             NA |        NA |

Benchmarks with issues:
  SystemWithThreeComponents.SveltoECS: DefaultJob [EntityCount=100000, EntityPadding=10]

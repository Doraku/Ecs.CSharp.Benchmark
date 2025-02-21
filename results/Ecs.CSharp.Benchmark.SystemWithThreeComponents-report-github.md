```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26100.3194)
Intel Core i5-10505 CPU 3.20GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX2


```
| Method                          | EntityCount | EntityPadding | Mean         | Error      | StdDev     | Gen0   | Gen1   | Allocated |
|-------------------------------- |------------ |-------------- |-------------:|-----------:|-----------:|-------:|-------:|----------:|
| SveltoECS                       | 100000      | 10            |           NA |         NA |         NA |     NA |     NA |        NA |
| FrifloEngineEcs_MultiThread     | 100000      | 0             |     15.47 μs |   0.294 μs |   0.288 μs |      - |      - |         - |
| FrifloEngineEcs_MultiThread     | 100000      | 10            |     15.97 μs |   0.163 μs |   0.153 μs |      - |      - |         - |
| Frent_Simd                      | 100000      | 10            |     17.93 μs |   0.215 μs |   0.180 μs |      - |      - |         - |
| Frent_Simd                      | 100000      | 0             |     19.48 μs |   0.093 μs |   0.083 μs |      - |      - |         - |
| FrifloEngineEcs_SIMD_MonoThread | 100000      | 10            |     19.80 μs |   0.267 μs |   0.250 μs |      - |      - |         - |
| Myriad_MultiThreadChunk         | 100000      | 0             |     20.14 μs |   0.152 μs |   0.143 μs | 1.4648 | 0.0305 |    9216 B |
| FrifloEngineEcs_SIMD_MonoThread | 100000      | 0             |     20.36 μs |   0.093 μs |   0.082 μs |      - |      - |         - |
| Myriad_MultiThreadChunk         | 100000      | 10            |     21.02 μs |   0.163 μs |   0.152 μs | 1.4648 | 0.0305 |    9216 B |
| TinyEcs_EachJob                 | 100000      | 0             |     30.24 μs |   0.770 μs |   2.122 μs | 0.2441 |      - |    1560 B |
| TinyEcs_EachJob                 | 100000      | 10            |     33.89 μs |   0.648 μs |   0.796 μs | 0.2441 |      - |    1560 B |
| Arch_MultiThread                | 100000      | 0             |     35.89 μs |   0.507 μs |   0.475 μs |      - |      - |         - |
| Arch_MultiThread                | 100000      | 10            |     36.16 μs |   0.700 μs |   0.687 μs |      - |      - |         - |
| HypEcs_MonoThread               | 100000      | 10            |     50.34 μs |   0.310 μs |   0.290 μs |      - |      - |     152 B |
| Frent_QueryInline               | 100000      | 10            |     50.50 μs |   0.290 μs |   0.272 μs |      - |      - |         - |
| HypEcs_MonoThread               | 100000      | 0             |     53.08 μs |   0.444 μs |   0.415 μs |      - |      - |     152 B |
| Frent_QueryInline               | 100000      | 0             |     53.71 μs |   0.364 μs |   0.341 μs |      - |      - |         - |
| TinyEcs_Each                    | 100000      | 0             |     54.13 μs |   0.152 μs |   0.134 μs |      - |      - |         - |
| HypEcs_MultiThread              | 100000      | 10            |     54.42 μs |   0.382 μs |   0.358 μs | 0.3052 |      - |    1912 B |
| TinyEcs_Each                    | 100000      | 10            |     55.40 μs |   0.177 μs |   0.166 μs |      - |      - |         - |
| HypEcs_MultiThread              | 100000      | 0             |     56.12 μs |   0.300 μs |   0.281 μs | 0.3052 |      - |    1912 B |
| Myriad_SingleThread             | 100000      | 10            |     61.91 μs |   0.149 μs |   0.116 μs |      - |      - |         - |
| Myriad_SingleThread             | 100000      | 0             |     62.23 μs |   0.325 μs |   0.304 μs |      - |      - |         - |
| Myriad_SingleThreadChunk        | 100000      | 10            |     62.78 μs |   0.215 μs |   0.201 μs |      - |      - |         - |
| Myriad_SingleThreadChunk        | 100000      | 0             |     63.69 μs |   0.391 μs |   0.366 μs |      - |      - |         - |
| Arch_MonoThread                 | 100000      | 10            |     69.89 μs |   0.526 μs |   0.467 μs |      - |      - |         - |
| Arch_MonoThread                 | 100000      | 0             |     71.83 μs |   0.621 μs |   0.581 μs |      - |      - |         - |
| Fennecs_Raw                     | 100000      | 10            |     72.37 μs |   0.349 μs |   0.310 μs |      - |      - |         - |
| Fennecs_Raw                     | 100000      | 0             |     75.16 μs |   0.317 μs |   0.281 μs |      - |      - |         - |
| FrifloEngineEcs_MonoThread      | 100000      | 10            |     76.00 μs |   0.800 μs |   0.748 μs |      - |      - |         - |
| FrifloEngineEcs_MonoThread      | 100000      | 0             |     76.40 μs |   0.496 μs |   0.464 μs |      - |      - |         - |
| Myriad_MultiThread              | 100000      | 10            |     76.84 μs |   1.074 μs |   0.952 μs | 4.0283 | 0.3662 |   25474 B |
| Myriad_MultiThread              | 100000      | 0             |     77.50 μs |   0.455 μs |   0.426 μs | 4.0283 | 0.3662 |   25560 B |
| Fennecs_ForEach                 | 100000      | 10            |     84.68 μs |   1.117 μs |   0.990 μs |      - |      - |         - |
| Fennecs_ForEach                 | 100000      | 0             |     87.11 μs |   0.519 μs |   0.486 μs |      - |      - |         - |
| Frent_QueryDelegate             | 100000      | 10            |     88.20 μs |   0.281 μs |   0.262 μs |      - |      - |         - |
| Frent_QueryDelegate             | 100000      | 0             |     88.61 μs |   0.500 μs |   0.468 μs |      - |      - |         - |
| Myriad_Delegate                 | 100000      | 10            |     92.93 μs |   0.363 μs |   0.322 μs |      - |      - |         - |
| Myriad_Delegate                 | 100000      | 0             |     93.16 μs |   0.516 μs |   0.483 μs |      - |      - |         - |
| Fennecs_Job                     | 100000      | 0             |    108.20 μs |   0.465 μs |   0.412 μs |      - |      - |         - |
| Fennecs_Job                     | 100000      | 10            |    109.36 μs |   0.464 μs |   0.412 μs |      - |      - |         - |
| FlecsNet_Iter                   | 100000      | 10            |    113.36 μs |   0.590 μs |   0.552 μs |      - |      - |         - |
| FlecsNet_Iter                   | 100000      | 0             |    114.56 μs |   1.394 μs |   1.236 μs |      - |      - |         - |
| DefaultEcs_MultiThread          | 100000      | 0             |    123.82 μs |   2.145 μs |   2.006 μs |      - |      - |         - |
| FlecsNet_Each                   | 100000      | 10            |    163.85 μs |   0.940 μs |   0.879 μs |      - |      - |         - |
| FlecsNet_Each                   | 100000      | 0             |    164.39 μs |   1.441 μs |   1.348 μs |      - |      - |         - |
| Arch_MonoThread_SourceGenerated | 100000      | 0             |    192.44 μs |   0.769 μs |   0.719 μs |      - |      - |         - |
| Arch_MonoThread_SourceGenerated | 100000      | 10            |    192.46 μs |   0.983 μs |   0.920 μs |      - |      - |         - |
| DefaultEcs_MonoThread           | 100000      | 0             |    233.46 μs |   1.122 μs |   1.049 μs |      - |      - |         - |
| LeopotamEcs                     | 100000      | 0             |    259.06 μs |   1.529 μs |   1.430 μs |      - |      - |       1 B |
| Myriad_Enumerable               | 100000      | 10            |    262.93 μs |   0.446 μs |   0.396 μs |      - |      - |       1 B |
| Myriad_Enumerable               | 100000      | 0             |    263.68 μs |   1.491 μs |   1.395 μs |      - |      - |       1 B |
| LeopotamEcs                     | 100000      | 10            |    275.19 μs |   1.208 μs |   1.071 μs |      - |      - |       1 B |
| SveltoECS                       | 100000      | 0             |    310.69 μs |   0.305 μs |   0.254 μs |      - |      - |       1 B |
| LeopotamEcsLite                 | 100000      | 0             |    347.98 μs |   1.948 μs |   1.823 μs |      - |      - |       1 B |
| RelEcs                          | 100000      | 0             |    573.73 μs |  11.407 μs |  12.679 μs |      - |      - |     217 B |
| DefaultEcs_MultiThread          | 100000      | 10            |    768.71 μs |  15.082 μs |  17.955 μs |      - |      - |       1 B |
| DefaultEcs_MonoThread           | 100000      | 10            |    781.55 μs |   9.553 μs |   8.936 μs |      - |      - |       1 B |
| MonoGameExtended                | 100000      | 0             |    799.64 μs |   6.806 μs |   6.366 μs |      - |      - |     161 B |
| LeopotamEcsLite                 | 100000      | 10            |    819.39 μs |  12.271 μs |  10.878 μs |      - |      - |       1 B |
| RelEcs                          | 100000      | 10            |  1,701.47 μs |  31.853 μs |  54.946 μs |      - |      - |     218 B |
| Morpeh_Stash                    | 100000      | 0             |  2,837.66 μs |  22.355 μs |  19.817 μs |      - |      - |       4 B |
| MonoGameExtended                | 100000      | 10            |  3,126.94 μs |  32.413 μs |  30.319 μs |      - |      - |     164 B |
| Morpeh_Direct                   | 100000      | 0             |  4,587.78 μs |  44.380 μs |  39.342 μs |      - |      - |       8 B |
| Morpeh_Stash                    | 100000      | 10            |  9,875.96 μs | 145.627 μs | 129.094 μs |      - |      - |      17 B |
| Morpeh_Direct                   | 100000      | 10            | 11,816.66 μs | 114.349 μs | 106.962 μs |      - |      - |      17 B |

Benchmarks with issues:
  SystemWithThreeComponents.SveltoECS: DefaultJob [EntityCount=100000, EntityPadding=10]

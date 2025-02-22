```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26100.3194)
Intel Core i5-10505 CPU 3.20GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX2


```
| Method                                 | EntityCount | EntityPadding | Mean         | Error       | StdDev      | Median       | Gen0   | Gen1   | Allocated |
|--------------------------------------- |------------ |-------------- |-------------:|------------:|------------:|-------------:|-------:|-------:|----------:|
| Frent_Simd                             | 100000      | 0             |     8.001 μs |   0.0756 μs |   0.0707 μs |     8.014 μs |      - |      - |         - |
| Frent_Simd                             | 100000      | 10            |     8.052 μs |   0.1085 μs |   0.1015 μs |     8.041 μs |      - |      - |         - |
| FrifloEngineEcs_SIMD_MonoThread        | 100000      | 10            |     8.683 μs |   0.1098 μs |   0.0916 μs |     8.700 μs |      - |      - |         - |
| FrifloEngineEcs_SIMD_MonoThread        | 100000      | 0             |     8.832 μs |   0.1136 μs |   0.1063 μs |     8.830 μs |      - |      - |         - |
| FrifloEngineEcs_MultiThread            | 100000      | 0             |     9.687 μs |   0.1937 μs |   0.4677 μs |     9.498 μs |      - |      - |         - |
| FrifloEngineEcs_MultiThread            | 100000      | 10            |    10.711 μs |   0.5310 μs |   1.5064 μs |    10.090 μs |      - |      - |         - |
| Myriad_SingleThreadChunk_SIMD          | 100000      | 10            |    11.581 μs |   0.1014 μs |   0.0792 μs |    11.584 μs |      - |      - |         - |
| Myriad_SingleThreadChunk_SIMD          | 100000      | 0             |    11.607 μs |   0.1530 μs |   0.1431 μs |    11.636 μs |      - |      - |         - |
| Myriad_MultiThreadChunk                | 100000      | 0             |    17.138 μs |   0.1722 μs |   0.1526 μs |    17.076 μs | 1.4648 | 0.0305 |    9216 B |
| Myriad_MultiThreadChunk                | 100000      | 10            |    19.012 μs |   0.1216 μs |   0.1078 μs |    19.002 μs | 1.4648 | 0.0305 |    9216 B |
| TinyEcs_EachJob                        | 100000      | 0             |    19.308 μs |   0.3784 μs |   0.3354 μs |    19.232 μs | 0.2441 |      - |    1552 B |
| TinyEcs_EachJob                        | 100000      | 10            |    19.652 μs |   0.3862 μs |   0.4597 μs |    19.562 μs | 0.2441 |      - |    1552 B |
| Fennecs_Job                            | 100000      | 0             |    26.045 μs |   0.5143 μs |   0.8157 μs |    26.104 μs |      - |      - |         - |
| Fennecs_Job                            | 100000      | 10            |    27.065 μs |   0.5252 μs |   0.7190 μs |    27.046 μs |      - |      - |         - |
| TinyEcs_Each                           | 100000      | 0             |    29.781 μs |   0.1484 μs |   0.1316 μs |    29.811 μs |      - |      - |         - |
| TinyEcs_Each                           | 100000      | 10            |    29.921 μs |   0.1810 μs |   0.1693 μs |    29.918 μs |      - |      - |         - |
| Arch_MultiThread                       | 100000      | 10            |    32.199 μs |   0.6282 μs |   1.0144 μs |    31.648 μs |      - |      - |         - |
| Arch_MultiThread                       | 100000      | 0             |    32.913 μs |   0.2654 μs |   0.2353 μs |    32.891 μs |      - |      - |         - |
| Frent_QueryInline                      | 100000      | 0             |    33.690 μs |   0.1751 μs |   0.1638 μs |    33.706 μs |      - |      - |         - |
| Frent_QueryInline                      | 100000      | 10            |    33.736 μs |   0.1750 μs |   0.1637 μs |    33.688 μs |      - |      - |         - |
| HypEcs_MonoThread                      | 100000      | 0             |    44.341 μs |   0.0743 μs |   0.0620 μs |    44.333 μs |      - |      - |      72 B |
| DefaultEcs_ComponentSystem_MonoThread  | 100000      | 10            |    44.760 μs |   0.6895 μs |   0.6112 μs |    44.612 μs |      - |      - |         - |
| Frent_QueryDelegate                    | 100000      | 10            |    44.824 μs |   0.3001 μs |   0.2807 μs |    44.763 μs |      - |      - |         - |
| FrifloEngineEcs_MonoThread             | 100000      | 0             |    44.977 μs |   0.2237 μs |   0.2093 μs |    45.005 μs |      - |      - |         - |
| FrifloEngineEcs_MonoThread             | 100000      | 10            |    44.981 μs |   0.2743 μs |   0.2565 μs |    44.951 μs |      - |      - |         - |
| Fennecs_ForEach                        | 100000      | 10            |    45.012 μs |   0.2045 μs |   0.1812 μs |    45.057 μs |      - |      - |         - |
| Fennecs_ForEach                        | 100000      | 0             |    45.015 μs |   0.3007 μs |   0.2813 μs |    44.967 μs |      - |      - |         - |
| HypEcs_MonoThread                      | 100000      | 10            |    45.170 μs |   0.7131 μs |   0.5955 μs |    45.362 μs |      - |      - |      72 B |
| DefaultEcs_ComponentSystem_MonoThread  | 100000      | 0             |    45.579 μs |   0.8747 μs |   1.0413 μs |    45.271 μs |      - |      - |         - |
| Fennecs_Raw                            | 100000      | 10            |    45.732 μs |   0.2673 μs |   0.2500 μs |    45.698 μs |      - |      - |         - |
| Fennecs_Raw                            | 100000      | 0             |    45.949 μs |   0.2535 μs |   0.2371 μs |    45.894 μs |      - |      - |         - |
| Arch_MonoThread_SourceGenerated        | 100000      | 10            |    46.445 μs |   0.1907 μs |   0.1784 μs |    46.404 μs |      - |      - |         - |
| Arch_MonoThread                        | 100000      | 10            |    46.464 μs |   0.2703 μs |   0.2528 μs |    46.434 μs |      - |      - |         - |
| Arch_MonoThread                        | 100000      | 0             |    46.696 μs |   0.2822 μs |   0.2203 μs |    46.689 μs |      - |      - |         - |
| Myriad_SingleThreadChunk               | 100000      | 10            |    47.348 μs |   0.2602 μs |   0.2434 μs |    47.295 μs |      - |      - |         - |
| Arch_MonoThread_SourceGenerated        | 100000      | 0             |    47.506 μs |   0.3695 μs |   0.3456 μs |    47.481 μs |      - |      - |         - |
| Myriad_SingleThreadChunk               | 100000      | 0             |    47.526 μs |   0.2297 μs |   0.2036 μs |    47.470 μs |      - |      - |         - |
| HypEcs_MultiThread                     | 100000      | 10            |    49.058 μs |   0.1972 μs |   0.1748 μs |    49.027 μs | 0.2441 |      - |    1832 B |
| HypEcs_MultiThread                     | 100000      | 0             |    49.295 μs |   0.3472 μs |   0.3248 μs |    49.472 μs | 0.2441 |      - |    1832 B |
| DefaultEcs_ComponentSystem_MultiThread | 100000      | 0             |    49.427 μs |   2.8333 μs |   8.2200 μs |    49.872 μs |      - |      - |         - |
| Myriad_SingleThread                    | 100000      | 0             |    49.564 μs |   0.2655 μs |   0.2483 μs |    49.457 μs |      - |      - |         - |
| Myriad_SingleThread                    | 100000      | 10            |    49.905 μs |   0.2074 μs |   0.1839 μs |    49.874 μs |      - |      - |         - |
| Frent_QueryDelegate                    | 100000      | 0             |    53.680 μs |   1.0627 μs |   1.4546 μs |    54.041 μs |      - |      - |         - |
| DefaultEcs_ComponentSystem_MultiThread | 100000      | 10            |    55.017 μs |   4.2070 μs |  12.3385 μs |    54.529 μs |      - |      - |         - |
| FlecsNet_Iter                          | 100000      | 10            |    56.515 μs |   0.2122 μs |   0.1985 μs |    56.465 μs |      - |      - |         - |
| FlecsNet_Iter                          | 100000      | 0             |    56.540 μs |   0.2105 μs |   0.1969 μs |    56.509 μs |      - |      - |         - |
| Myriad_MultiThread                     | 100000      | 10            |    70.614 μs |   0.7574 μs |   0.7085 μs |    70.372 μs | 2.5635 | 0.1221 |   16231 B |
| Myriad_MultiThread                     | 100000      | 0             |    71.270 μs |   0.4140 μs |   0.3873 μs |    71.296 μs | 2.5635 | 0.1221 |   16213 B |
| DefaultEcs_EntitySetSystem_MonoThread  | 100000      | 0             |    71.717 μs |   0.6066 μs |   0.5674 μs |    71.647 μs |      - |      - |         - |
| LeopotamEcs                            | 100000      | 10            |    82.681 μs |   0.4972 μs |   0.4651 μs |    82.847 μs |      - |      - |         - |
| LeopotamEcs                            | 100000      | 0             |    83.138 μs |   0.6354 μs |   0.5633 μs |    83.100 μs |      - |      - |         - |
| FlecsNet_Each                          | 100000      | 0             |    90.498 μs |   0.5124 μs |   0.4793 μs |    90.751 μs |      - |      - |         - |
| Myriad_Delegate                        | 100000      | 0             |    91.233 μs |   0.5714 μs |   0.5065 μs |    91.085 μs |      - |      - |         - |
| Myriad_Delegate                        | 100000      | 10            |    92.347 μs |   0.7312 μs |   0.6839 μs |    92.430 μs |      - |      - |         - |
| FlecsNet_Each                          | 100000      | 10            |    95.305 μs |   0.5624 μs |   0.5260 μs |    95.004 μs |      - |      - |         - |
| DefaultEcs_EntitySetSystem_MultiThread | 100000      | 0             |   100.011 μs |   1.9853 μs |   2.0387 μs |    99.106 μs |      - |      - |         - |
| LeopotamEcsLite                        | 100000      | 0             |   101.708 μs |   0.4426 μs |   0.4140 μs |   101.712 μs |      - |      - |         - |
| DefaultEcs_EntitySetSystem_MultiThread | 100000      | 10            |   108.222 μs |   1.6323 μs |   1.4470 μs |   107.929 μs |      - |      - |         - |
| DefaultEcs_EntitySetSystem_MonoThread  | 100000      | 10            |   109.532 μs |   2.0478 μs |   3.1273 μs |   110.893 μs |      - |      - |         - |
| SveltoECS                              | 100000      | 0             |   111.771 μs |   0.4470 μs |   0.4182 μs |   111.682 μs |      - |      - |         - |
| LeopotamEcsLite                        | 100000      | 10            |   122.782 μs |   1.9184 μs |   1.7006 μs |   122.809 μs |      - |      - |         - |
| SveltoECS                              | 100000      | 10            |   133.520 μs |   0.8133 μs |   0.7607 μs |   133.523 μs |      - |      - |         - |
| Myriad_Enumerable                      | 100000      | 0             |   198.400 μs |   0.7908 μs |   0.7397 μs |   198.400 μs |      - |      - |         - |
| Myriad_Enumerable                      | 100000      | 10            |   198.848 μs |   0.9083 μs |   0.8052 μs |   198.736 μs |      - |      - |         - |
| RelEcs                                 | 100000      | 0             |   203.954 μs |   2.3272 μs |   2.0630 μs |   203.512 μs |      - |      - |     121 B |
| MonoGameExtended                       | 100000      | 0             |   305.970 μs |   4.4577 μs |   4.1697 μs |   305.474 μs |      - |      - |     161 B |
| RelEcs                                 | 100000      | 10            |   506.912 μs |   9.7540 μs |  13.9889 μs |   503.349 μs |      - |      - |     121 B |
| MonoGameExtended                       | 100000      | 10            | 1,456.219 μs |  26.8586 μs |  45.6079 μs | 1,462.517 μs |      - |      - |     162 B |
| Morpeh_Stash                           | 100000      | 0             | 2,354.802 μs |  44.8434 μs |  55.0717 μs | 2,346.409 μs |      - |      - |       4 B |
| Morpeh_Direct                          | 100000      | 0             | 2,906.300 μs |  39.5326 μs |  36.9789 μs | 2,899.226 μs |      - |      - |       4 B |
| Morpeh_Stash                           | 100000      | 10            | 7,824.125 μs | 149.6330 μs | 172.3176 μs | 7,842.959 μs |      - |      - |       8 B |
| Morpeh_Direct                          | 100000      | 10            | 8,998.948 μs | 168.7289 μs | 187.5417 μs | 8,951.641 μs |      - |      - |      17 B |

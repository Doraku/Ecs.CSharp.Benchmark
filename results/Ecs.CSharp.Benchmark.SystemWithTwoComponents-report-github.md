```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26100.3194)
Intel Core i5-10505 CPU 3.20GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX2


```
| Method                          | EntityCount | EntityPadding | Mean        | Error      | StdDev     | Median      | Gen0   | Gen1   | Allocated |
|-------------------------------- |------------ |-------------- |------------:|-----------:|-----------:|------------:|-------:|-------:|----------:|
| FrifloEngineEcs_MultiThread     | 100000      | 0             |    12.43 μs |   0.372 μs |   1.049 μs |    11.96 μs |      - |      - |         - |
| FrifloEngineEcs_MultiThread     | 100000      | 10            |    13.55 μs |   0.311 μs |   0.883 μs |    13.47 μs |      - |      - |         - |
| Frent_Simd                      | 100000      | 10            |    13.94 μs |   0.148 μs |   0.138 μs |    13.89 μs |      - |      - |         - |
| Frent_Simd                      | 100000      | 0             |    14.03 μs |   0.130 μs |   0.122 μs |    14.09 μs |      - |      - |         - |
| FrifloEngineEcs_SIMD_MonoThread | 100000      | 0             |    14.34 μs |   0.074 μs |   0.058 μs |    14.34 μs |      - |      - |         - |
| FrifloEngineEcs_SIMD_MonoThread | 100000      | 10            |    14.91 μs |   0.244 μs |   0.228 μs |    14.84 μs |      - |      - |         - |
| Myriad_SingleThreadChunk_SIMD   | 100000      | 0             |    16.32 μs |   0.145 μs |   0.128 μs |    16.31 μs |      - |      - |         - |
| Myriad_SingleThreadChunk_SIMD   | 100000      | 10            |    16.35 μs |   0.216 μs |   0.192 μs |    16.35 μs |      - |      - |         - |
| Myriad_MultiThreadChunk         | 100000      | 0             |    17.14 μs |   0.123 μs |   0.115 μs |    17.13 μs | 1.4648 | 0.0305 |    9216 B |
| Myriad_MultiThreadChunk         | 100000      | 10            |    18.06 μs |   0.104 μs |   0.097 μs |    18.05 μs | 1.4648 | 0.0305 |    9219 B |
| TinyEcs_EachJob                 | 100000      | 0             |    23.85 μs |   0.477 μs |   1.105 μs |    24.00 μs | 0.2441 |      - |    1552 B |
| TinyEcs_EachJob                 | 100000      | 10            |    24.21 μs |   0.484 μs |   1.215 μs |    24.21 μs | 0.2441 |      - |    1552 B |
| Arch_MultiThread                | 100000      | 0             |    32.02 μs |   0.154 μs |   0.144 μs |    32.06 μs |      - |      - |         - |
| TinyEcs_Each                    | 100000      | 10            |    33.21 μs |   0.270 μs |   0.239 μs |    33.14 μs |      - |      - |         - |
| TinyEcs_Each                    | 100000      | 0             |    33.41 μs |   0.336 μs |   0.314 μs |    33.40 μs |      - |      - |         - |
| Arch_MultiThread                | 100000      | 10            |    33.41 μs |   0.417 μs |   0.390 μs |    33.19 μs |      - |      - |         - |
| HypEcs_MonoThread               | 100000      | 10            |    44.62 μs |   0.239 μs |   0.212 μs |    44.57 μs |      - |      - |     112 B |
| HypEcs_MonoThread               | 100000      | 0             |    44.68 μs |   0.232 μs |   0.205 μs |    44.67 μs |      - |      - |     112 B |
| Frent_QueryInline               | 100000      | 10            |    44.75 μs |   0.299 μs |   0.280 μs |    44.71 μs |      - |      - |         - |
| Frent_QueryInline               | 100000      | 0             |    44.93 μs |   0.194 μs |   0.172 μs |    44.96 μs |      - |      - |         - |
| Arch_MonoThread_SourceGenerated | 100000      | 10            |    47.81 μs |   0.360 μs |   0.319 μs |    47.70 μs |      - |      - |         - |
| Arch_MonoThread_SourceGenerated | 100000      | 0             |    47.84 μs |   0.255 μs |   0.226 μs |    47.80 μs |      - |      - |         - |
| Myriad_SingleThreadChunk        | 100000      | 0             |    48.31 μs |   0.213 μs |   0.189 μs |    48.25 μs |      - |      - |         - |
| Myriad_SingleThreadChunk        | 100000      | 10            |    48.64 μs |   0.286 μs |   0.268 μs |    48.62 μs |      - |      - |         - |
| HypEcs_MultiThread              | 100000      | 0             |    49.12 μs |   0.293 μs |   0.274 μs |    49.17 μs | 0.2441 |      - |    1872 B |
| HypEcs_MultiThread              | 100000      | 10            |    49.84 μs |   0.329 μs |   0.292 μs |    49.86 μs | 0.2441 |      - |    1872 B |
| Frent_QueryDelegate             | 100000      | 0             |    51.48 μs |   0.186 μs |   0.174 μs |    51.45 μs |      - |      - |         - |
| Myriad_SingleThread             | 100000      | 10            |    52.52 μs |   0.373 μs |   0.349 μs |    52.49 μs |      - |      - |         - |
| Myriad_SingleThread             | 100000      | 0             |    52.64 μs |   0.263 μs |   0.246 μs |    52.60 μs |      - |      - |         - |
| Frent_QueryDelegate             | 100000      | 10            |    56.55 μs |   0.230 μs |   0.203 μs |    56.56 μs |      - |      - |         - |
| FrifloEngineEcs_MonoThread      | 100000      | 0             |    56.93 μs |   0.369 μs |   0.327 μs |    56.87 μs |      - |      - |         - |
| FrifloEngineEcs_MonoThread      | 100000      | 10            |    57.16 μs |   0.252 μs |   0.223 μs |    57.13 μs |      - |      - |         - |
| Arch_MonoThread                 | 100000      | 0             |    57.47 μs |   0.336 μs |   0.314 μs |    57.48 μs |      - |      - |         - |
| Arch_MonoThread                 | 100000      | 10            |    57.55 μs |   0.276 μs |   0.245 μs |    57.55 μs |      - |      - |         - |
| Fennecs_Raw                     | 100000      | 10            |    57.89 μs |   0.249 μs |   0.233 μs |    57.96 μs |      - |      - |         - |
| Fennecs_Raw                     | 100000      | 0             |    58.86 μs |   0.229 μs |   0.215 μs |    58.87 μs |      - |      - |         - |
| Fennecs_ForEach                 | 100000      | 0             |    63.21 μs |   0.398 μs |   0.372 μs |    63.30 μs |      - |      - |         - |
| Fennecs_ForEach                 | 100000      | 10            |    68.15 μs |   0.370 μs |   0.328 μs |    68.09 μs |      - |      - |      12 B |
| Myriad_MultiThread              | 100000      | 0             |    68.27 μs |   0.406 μs |   0.339 μs |    68.18 μs | 3.2959 | 0.2441 |   20865 B |
| Myriad_MultiThread              | 100000      | 10            |    70.62 μs |   0.484 μs |   0.404 μs |    70.67 μs | 3.2959 | 0.2441 |   20910 B |
| FlecsNet_Iter                   | 100000      | 10            |    79.39 μs |   0.558 μs |   0.494 μs |    79.27 μs |      - |      - |         - |
| FlecsNet_Iter                   | 100000      | 0             |    79.81 μs |   0.449 μs |   0.420 μs |    79.68 μs |      - |      - |         - |
| Fennecs_Job                     | 100000      | 0             |    94.79 μs |   1.685 μs |   1.576 μs |    95.35 μs |      - |      - |         - |
| Fennecs_Job                     | 100000      | 10            |    96.64 μs |   1.565 μs |   1.464 μs |    97.18 μs |      - |      - |         - |
| DefaultEcs_MultiThread          | 100000      | 0             |   108.93 μs |   2.172 μs |   3.569 μs |   107.12 μs |      - |      - |         - |
| Myriad_Delegate                 | 100000      | 0             |   113.14 μs |   0.387 μs |   0.362 μs |   113.19 μs |      - |      - |         - |
| Myriad_Delegate                 | 100000      | 10            |   113.50 μs |   0.937 μs |   0.783 μs |   113.36 μs |      - |      - |         - |
| DefaultEcs_MonoThread           | 100000      | 0             |   124.09 μs |   1.103 μs |   0.978 μs |   124.09 μs |      - |      - |         - |
| FlecsNet_Each                   | 100000      | 0             |   134.08 μs |   0.286 μs |   0.238 μs |   134.07 μs |      - |      - |         - |
| FlecsNet_Each                   | 100000      | 10            |   134.54 μs |   0.929 μs |   0.824 μs |   134.58 μs |      - |      - |         - |
| LeopotamEcs                     | 100000      | 0             |   158.35 μs |   1.658 μs |   1.551 μs |   157.83 μs |      - |      - |         - |
| LeopotamEcs                     | 100000      | 10            |   176.98 μs |   2.942 μs |   2.752 μs |   177.01 μs |      - |      - |         - |
| Myriad_Enumerable               | 100000      | 10            |   199.27 μs |   2.223 μs |   1.971 μs |   198.64 μs |      - |      - |         - |
| Myriad_Enumerable               | 100000      | 0             |   200.01 μs |   3.214 μs |   3.006 μs |   198.11 μs |      - |      - |         - |
| DefaultEcs_MultiThread          | 100000      | 10            |   209.11 μs |   4.154 μs |  10.346 μs |   206.63 μs |      - |      - |       1 B |
| LeopotamEcsLite                 | 100000      | 0             |   216.20 μs |   1.205 μs |   1.068 μs |   216.25 μs |      - |      - |         - |
| SveltoECS                       | 100000      | 0             |   223.22 μs |   0.749 μs |   0.700 μs |   223.29 μs |      - |      - |         - |
| RelEcs                          | 100000      | 0             |   355.92 μs |   6.758 μs |   7.512 μs |   354.06 μs |      - |      - |     169 B |
| LeopotamEcsLite                 | 100000      | 10            |   531.99 μs |  10.470 μs |  10.283 μs |   532.33 μs |      - |      - |       1 B |
| MonoGameExtended                | 100000      | 0             |   534.19 μs |  10.215 μs |  10.930 μs |   531.62 μs |      - |      - |     161 B |
| DefaultEcs_MonoThread           | 100000      | 10            |   571.35 μs |  11.122 μs |  12.808 μs |   571.77 μs |      - |      - |      97 B |
| RelEcs                          | 100000      | 10            | 1,138.55 μs |  22.090 μs |  35.671 μs | 1,136.89 μs |      - |      - |     170 B |
| SveltoECS                       | 100000      | 10            | 1,204.02 μs |   7.407 μs |   6.929 μs | 1,202.89 μs |      - |      - |       2 B |
| Morpeh_Stash                    | 100000      | 0             | 2,380.69 μs |  43.168 μs |  40.379 μs | 2,380.96 μs |      - |      - |       4 B |
| MonoGameExtended                | 100000      | 10            | 2,437.67 μs |  41.587 μs |  38.901 μs | 2,440.90 μs |      - |      - |     164 B |
| Morpeh_Direct                   | 100000      | 0             | 3,934.95 μs |  67.641 μs |  63.272 μs | 3,918.62 μs |      - |      - |       8 B |
| Morpeh_Stash                    | 100000      | 10            | 8,713.33 μs | 172.168 μs | 169.092 μs | 8,698.68 μs |      - |      - |      17 B |
| Morpeh_Direct                   | 100000      | 10            | 9,810.58 μs | 142.716 μs | 126.514 μs | 9,796.39 μs |      - |      - |      17 B |

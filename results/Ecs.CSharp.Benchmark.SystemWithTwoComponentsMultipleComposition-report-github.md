```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.26100.3194)
Intel Core i5-10505 CPU 3.20GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX2


```
| Method                          | EntityCount | Mean        | Error     | StdDev    | Median      | Gen0   | Gen1   | Allocated |
|-------------------------------- |------------ |------------:|----------:|----------:|------------:|-------:|-------:|----------:|
| Frent_Simd                      | 100000      |    14.12 μs |  0.070 μs |  0.062 μs |    14.12 μs |      - |      - |         - |
| FrifloEngineEcs_SIMD_MonoThread | 100000      |    15.01 μs |  0.173 μs |  0.153 μs |    15.06 μs |      - |      - |         - |
| FrifloEngineEcs_MultiThread     | 100000      |    16.60 μs |  0.556 μs |  1.560 μs |    15.88 μs |      - |      - |         - |
| Myriad_SingleThreadChunk_SIMD   | 100000      |    17.40 μs |  0.272 μs |  0.255 μs |    17.38 μs |      - |      - |         - |
| Myriad_MultiThreadChunk         | 100000      |    17.86 μs |  0.082 μs |  0.077 μs |    17.85 μs | 1.4648 | 0.0305 |    9216 B |
| HypEcs_MultiThread              | 100000      |    18.92 μs |  0.335 μs |  0.329 μs |    18.86 μs | 0.4272 |      - |    2803 B |
| TinyEcs_EachJob                 | 100000      |    27.33 μs |  0.802 μs |  2.208 μs |    27.22 μs | 0.3052 |      - |    2080 B |
| TinyEcs_Each                    | 100000      |    33.55 μs |  0.210 μs |  0.197 μs |    33.58 μs |      - |      - |         - |
| Frent_QueryInline               | 100000      |    44.83 μs |  0.181 μs |  0.169 μs |    44.84 μs |      - |      - |         - |
| HypEcs_MonoThread               | 100000      |    45.06 μs |  0.159 μs |  0.148 μs |    45.05 μs |      - |      - |     352 B |
| Arch_MonoThread_SourceGenerated | 100000      |    47.93 μs |  0.143 μs |  0.119 μs |    47.90 μs |      - |      - |         - |
| Myriad_SingleThreadChunk        | 100000      |    48.95 μs |  0.107 μs |  0.095 μs |    48.95 μs |      - |      - |         - |
| Myriad_SingleThread             | 100000      |    54.20 μs |  0.198 μs |  0.185 μs |    54.25 μs |      - |      - |         - |
| FrifloEngineEcs_MonoThread      | 100000      |    56.43 μs |  0.162 μs |  0.151 μs |    56.40 μs |      - |      - |         - |
| Arch                            | 100000      |    57.74 μs |  0.127 μs |  0.106 μs |    57.76 μs |      - |      - |         - |
| Fennecs_Raw                     | 100000      |    59.85 μs |  0.143 μs |  0.127 μs |    59.87 μs |      - |      - |         - |
| Fennecs_ForEach                 | 100000      |    64.57 μs |  0.670 μs |  0.627 μs |    64.30 μs |      - |      - |         - |
| Myriad_MultiThread              | 100000      |    70.68 μs |  0.690 μs |  0.612 μs |    70.69 μs | 3.2959 | 0.2441 |   20859 B |
| FlecsNet_Iter                   | 100000      |    79.57 μs |  0.297 μs |  0.278 μs |    79.63 μs |      - |      - |         - |
| Arch_MultiThread                | 100000      |    80.71 μs |  0.802 μs |  0.750 μs |    81.01 μs |      - |      - |         - |
| Fennecs_Job                     | 100000      |    95.45 μs |  1.175 μs |  1.042 μs |    95.45 μs |      - |      - |         - |
| DefaultEcs_MultiThread          | 100000      |   106.45 μs |  1.040 μs |  0.922 μs |   106.16 μs |      - |      - |         - |
| Myriad_Delegate                 | 100000      |   113.91 μs |  0.394 μs |  0.329 μs |   113.79 μs |      - |      - |         - |
| DefaultEcs_MonoThread           | 100000      |   122.54 μs |  0.951 μs |  0.889 μs |   122.42 μs |      - |      - |         - |
| FlecsNet_Each                   | 100000      |   134.59 μs |  0.669 μs |  0.593 μs |   134.48 μs |      - |      - |         - |
| LeopotamEcs                     | 100000      |   147.55 μs |  0.534 μs |  0.499 μs |   147.68 μs |      - |      - |         - |
| LeopotamEcsLite                 | 100000      |   180.09 μs |  0.867 μs |  0.768 μs |   180.22 μs |      - |      - |         - |
| Myriad_Enumerable               | 100000      |   198.72 μs |  0.441 μs |  0.368 μs |   198.69 μs |      - |      - |         - |
| SveltoECS                       | 100000      |   223.13 μs |  0.899 μs |  0.797 μs |   223.17 μs |      - |      - |         - |
| MonoGameExtended                | 100000      |   691.31 μs | 13.034 μs | 12.192 μs |   691.55 μs |      - |      - |     161 B |
| RelEcs                          | 100000      |   710.16 μs | 13.808 μs | 13.561 μs |   713.43 μs |      - |      - |     489 B |
| Morpeh_Stash                    | 100000      | 4,285.93 μs | 69.234 μs | 64.762 μs | 4,269.97 μs |      - |      - |       8 B |
| Morpeh_Direct                   | 100000      | 5,498.44 μs | 62.410 μs | 58.378 μs | 5,500.20 μs |      - |      - |       8 B |

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3447/23H2/2023Update/SunValley3)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2


```
| Method                          | EntityCount | Mean         | Error      | StdDev     | Gen0    | Allocated |
|-------------------------------- |------------ |-------------:|-----------:|-----------:|--------:|----------:|
| Arch                            | 100000      |    45.588 μs |  0.1667 μs |  0.1559 μs |       - |         - |
| Arch_MonoThread_SourceGenerated | 100000      |    28.864 μs |  0.1579 μs |  0.1477 μs |       - |         - |
| Arch_MultiThread                | 100000      |   216.326 μs |  0.5008 μs |  0.4440 μs |       - |         - |
| DefaultEcs_MonoThread           | 100000      |   111.634 μs |  0.3284 μs |  0.2742 μs |       - |         - |
| DefaultEcs_MultiThread          | 100000      |    17.336 μs |  0.3461 μs |  0.7883 μs |       - |         - |
| Fennecs_ForEach                 | 100000      |    45.614 μs |  0.2717 μs |  0.2408 μs |       - |         - |
| Fennecs_Job                     | 100000      |    54.985 μs |  0.2037 μs |  0.1906 μs |       - |         - |
| Fennecs_Raw                     | 100000      |    44.672 μs |  0.2330 μs |  0.2179 μs |       - |         - |
| FlecsNet_Each                   | 100000      |   206.724 μs |  0.1604 μs |  0.1340 μs |       - |         - |
| FlecsNet_Iter                   | 100000      |    58.126 μs |  0.2896 μs |  0.2709 μs |       - |         - |
| FrifloEngineEcs_MonoThread      | 100000      |    45.401 μs |  0.2362 μs |  0.2210 μs |       - |         - |
| FrifloEngineEcs_MultiThread     | 100000      |    21.822 μs |  0.4332 μs |  0.9865 μs |       - |         - |
| FrifloEngineEcs_SIMD_MonoThread | 100000      |     9.130 μs |  0.0415 μs |  0.0388 μs |       - |         - |
| HypEcs_MonoThread               | 100000      |    33.012 μs |  0.1804 μs |  0.1687 μs |       - |     352 B |
| HypEcs_MultiThread              | 100000      |    11.779 μs |  0.2332 μs |  0.3269 μs |  0.1678 |    2826 B |
| LeopotamEcsLite                 | 100000      |   155.412 μs |  0.0678 μs |  0.0566 μs |       - |         - |
| LeopotamEcs                     | 100000      |   124.123 μs |  0.5376 μs |  0.5029 μs |       - |         - |
| MonoGameExtended                | 100000      |   301.107 μs |  1.1098 μs |  1.0381 μs |       - |     160 B |
| Morpeh_Direct                   | 100000      | 1,518.622 μs | 12.8902 μs | 11.4268 μs |       - |       2 B |
| Morpeh_Stash                    | 100000      |   862.835 μs |  6.9734 μs |  6.5229 μs |       - |       1 B |
| Myriad_SingleThread             | 100000      |    54.953 μs |  0.1963 μs |  0.1836 μs |       - |         - |
| Myriad_MultiThread              | 100000      |   985.841 μs | 11.6655 μs | 10.3412 μs | 27.3438 |  477241 B |
| Myriad_SingleThreadChunk        | 100000      |    40.976 μs |  0.0664 μs |  0.0621 μs |       - |         - |
| Myriad_MultiThreadChunk         | 100000      |    54.084 μs |  0.2846 μs |  0.2662 μs |  1.1597 |   19365 B |
| Myriad_Enumerable               | 100000      |   241.300 μs |  1.0985 μs |  1.0275 μs |       - |         - |
| Myriad_Delegate                 | 100000      |    67.886 μs |  0.2847 μs |  0.2663 μs |       - |         - |
| Myriad_SingleThreadChunk_SIMD   | 100000      |    12.698 μs |  0.0903 μs |  0.0845 μs |       - |         - |
| RelEcs                          | 100000      |   327.387 μs |  5.8896 μs |  5.2210 μs |       - |     488 B |
| SveltoECS                       | 100000      |   195.377 μs |  0.8974 μs |  0.8394 μs |       - |         - |
| TinyEcs_Each                    | 100000      |    26.289 μs |  0.0748 μs |  0.0699 μs |       - |         - |
| TinyEcs_EachJob                 | 100000      |    18.676 μs |  0.0448 μs |  0.0397 μs |  0.1221 |    2080 B |

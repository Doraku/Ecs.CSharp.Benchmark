``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5), VM=Hyper-V
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
  [Host] : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|           Method | EntityCount | Mean | Error | Ratio | RatioSD |
|----------------- |------------ |-----:|------:|------:|--------:|
|       DefaultEcs |      100000 |   NA |    NA |     ? |       ? |
|          Entitas |      100000 |   NA |    NA |     ? |       ? |
|      LeopotamEcs |      100000 |   NA |    NA |     ? |       ? |
|  LeopotamEcsLite |      100000 |   NA |    NA |     ? |       ? |
| MonoGameExtended |      100000 |   NA |    NA |     ? |       ? |
|        SveltoECS |      100000 |   NA |    NA |     ? |       ? |

Benchmarks with issues:
  CreateEntityWithOneComponent.DefaultEcs: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  CreateEntityWithOneComponent.Entitas: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  CreateEntityWithOneComponent.LeopotamEcs: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  CreateEntityWithOneComponent.LeopotamEcsLite: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  CreateEntityWithOneComponent.MonoGameExtended: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  CreateEntityWithOneComponent.SveltoECS: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]

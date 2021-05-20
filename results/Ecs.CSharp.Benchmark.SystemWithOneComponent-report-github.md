``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1879 (1809/October2018Update/Redstone5), VM=Hyper-V
Intel Xeon CPU E5-2673 v3 2.40GHz, 1 CPU, 2 logical and 2 physical cores
  [Host] : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT

InvocationCount=1  UnrollFactor=1  

```
|                                 Method | EntityCount | Mean | Error | Ratio | RatioSD |
|--------------------------------------- |------------ |-----:|------:|------:|--------:|
|  DefaultEcs_ComponentSystem_MonoThread |      100000 |   NA |    NA |     ? |       ? |
| DefaultEcs_ComponentSystem_MultiThread |      100000 |   NA |    NA |     ? |       ? |
|  DefaultEcs_EntitySetSystem_MonoThread |      100000 |   NA |    NA |     ? |       ? |
| DefaultEcs_EntitySetSystem_MultiThread |      100000 |   NA |    NA |     ? |       ? |
|                     Entitas_MonoThread |      100000 |   NA |    NA |     ? |       ? |
|                    Entitas_MultiThread |      100000 |   NA |    NA |     ? |       ? |
|                 LeopotamEcs_MonoThread |      100000 |   NA |    NA |     ? |       ? |
|                LeopotamEcs_MultiThread |      100000 |   NA |    NA |     ? |       ? |
|             LeopotamEcsLite_MonoThread |      100000 |   NA |    NA |     ? |       ? |
|            LeopotamEcsLite_MultiThread |      100000 |   NA |    NA |     ? |       ? |
|                       MonoGameExtended |      100000 |   NA |    NA |     ? |       ? |
|                              SveltoECS |      100000 |   NA |    NA |     ? |       ? |

Benchmarks with issues:
  SystemWithOneComponent.DefaultEcs_ComponentSystem_MonoThread: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  SystemWithOneComponent.DefaultEcs_ComponentSystem_MultiThread: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  SystemWithOneComponent.DefaultEcs_EntitySetSystem_MonoThread: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  SystemWithOneComponent.DefaultEcs_EntitySetSystem_MultiThread: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  SystemWithOneComponent.Entitas_MonoThread: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  SystemWithOneComponent.Entitas_MultiThread: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  SystemWithOneComponent.LeopotamEcs_MonoThread: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  SystemWithOneComponent.LeopotamEcs_MultiThread: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  SystemWithOneComponent.LeopotamEcsLite_MonoThread: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  SystemWithOneComponent.LeopotamEcsLite_MultiThread: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  SystemWithOneComponent.MonoGameExtended: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]
  SystemWithOneComponent.SveltoECS: Job-FEFVFA(InvocationCount=1, UnrollFactor=1) [EntityCount=100000]

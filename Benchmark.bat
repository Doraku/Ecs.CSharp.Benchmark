@ECHO off

pushd %~dp0

DEL /q /s BenchmarkDotNet.Artifacts
dotnet clean source\Ecs.CSharp.Benchmark\Ecs.CSharp.Benchmark.csproj -c Release

dotnet build source\Ecs.CSharp.Benchmark\Ecs.CSharp.Benchmark.csproj -c Release /p:CheckCacheMisses=true
IF %ERRORLEVEL% GTR 0 GOTO :end

dotnet run --project source\Ecs.CSharp.Benchmark\Ecs.CSharp.Benchmark.csproj -c Release --no-build --anyCategories DefaultEcs

:end
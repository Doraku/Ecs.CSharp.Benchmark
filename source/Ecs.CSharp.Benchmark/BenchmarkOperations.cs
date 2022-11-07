using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ecs.CSharp.Benchmark
{
    internal static class BenchmarkOperations
    {
        private static readonly MethodInfo _disposeMethod = typeof(IDisposable).GetMethod(nameof(IDisposable.Dispose));

        private static IEnumerable<FieldInfo> GetContextFields<T>() => typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(f => f.GetCustomAttribute<ContextAttribute>() != null);

        public static void SetupContexts<T>(T benchmark, params object[] args)
        {
            foreach (FieldInfo field in GetContextFields<T>())
            {
                field.SetValue(benchmark, Activator.CreateInstance(field.FieldType, args));
            }
        }

        public static void CleanupContexts<T>(T benchmark)
        {
            foreach (FieldInfo field in GetContextFields<T>())
            {
                _disposeMethod.Invoke(field.GetValue(benchmark), null);
            }
        }
    }
}

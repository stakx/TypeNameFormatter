// Copyright (c) 2018-2025 stakx and project contributors
// License available at https://github.com/stakx/TypeNameFormatter/blob/main/LICENSE.md.

namespace TypeNameFormatter.Benchmarks
{
    using BenchmarkDotNet.Running;

    public static class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<MeVersusCodeDomBenchmarks>();
        }
    }
}

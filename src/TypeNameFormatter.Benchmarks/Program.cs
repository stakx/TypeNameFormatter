// Copyright (c) 2018-2021 stakx
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

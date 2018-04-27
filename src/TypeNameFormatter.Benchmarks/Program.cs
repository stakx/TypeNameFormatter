// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

using BenchmarkDotNet.Running;

namespace TypeNameFormatter.Benchmarks
{
    public static class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<MeVersusCodeDomBenchmarks>();
        }
    }
}

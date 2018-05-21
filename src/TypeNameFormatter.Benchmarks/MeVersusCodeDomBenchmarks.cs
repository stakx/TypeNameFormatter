// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

namespace TypeNameFormatter.Benchmarks
{
    using System;
    using System.CodeDom;

    using BenchmarkDotNet.Attributes;

    using Microsoft.CSharp;

    /// <summary>
    ///   Contains benchmarks that are used to compare performance of the main library against that of Code DOM.
    /// </summary>
    public class MeVersusCodeDomBenchmarks
    {
        private static readonly Type ComplexType = typeof(A<int*[,][][,,]>[]);
        private static readonly Type IntermediateType = typeof(A<int[]>);
        private static readonly Type SimpleType = typeof(int);

        [Benchmark]
        public string CodeDom_Complex_type()
        {
            return FormatUsingCodeDom(ComplexType);
        }

        [Benchmark]
        public string CodeDom_Intermediate_type()
        {
            return FormatUsingCodeDom(IntermediateType);
        }

        [Benchmark]
        public string CodeDom_Simple_type()
        {
            return FormatUsingCodeDom(SimpleType);
        }

        [Benchmark]
        public string Me_Complex_type()
        {
            return FormatUsingMe(ComplexType);
        }

        [Benchmark]
        public string Me_Intermediate_type()
        {
            return FormatUsingMe(IntermediateType);
        }

        [Benchmark(Baseline = true)]
        public string Me_Simple_type()
        {
            return FormatUsingMe(SimpleType);
        }

        private static string FormatUsingCodeDom(Type type)
        {
            using (var provider = new CSharpCodeProvider())
            {
                var typeReference = new CodeTypeReference(type);
                return provider.GetTypeOutput(typeReference);
            }
        }

        private static string FormatUsingMe(Type type)
        {
            return type.GetFormattedName(TypeNameFormatOptions.Namespaces);
        }

        private class A<T>
        {
        }
    }
}

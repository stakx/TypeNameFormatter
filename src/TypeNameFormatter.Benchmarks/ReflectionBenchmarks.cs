// Copyright (c) 2018-2021 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/main/LICENSE.md.

namespace TypeNameFormatter.Benchmarks
{
    using System;

    using BenchmarkDotNet.Attributes;

    /// <summary>
    ///   Contains benchmarks that are used to measure performance of several reflection scenarios relative to one another.
    ///   This is used to determine how to structure fast code paths in the main library.
    /// </summary>
    public class ReflectionBenchmarks
    {
        private static Type ByRefType = typeof(int).MakeByRefType();

        [Benchmark]
        public bool HasElementType_array_type()
        {
            return typeof(int[]).HasElementType;
        }

        [Benchmark]
        public bool HasElementType_by_ref_type()
        {
            return ByRefType.HasElementType;
        }

        [Benchmark]
        public bool HasElementType_pointer_type()
        {
            return typeof(void*).HasElementType;
        }

        [Benchmark]
        public bool IsArray_array_type()
        {
            return typeof(int[]).IsArray;
        }

        [Benchmark]
        public bool IsArray_non_array_type()
        {
            return typeof(Uri).IsArray;
        }

        [Benchmark]
        public bool IsGenericType_generic_type()
        {
            return typeof(ArraySegment<>).IsGenericType;
        }

        [Benchmark]
        public bool IsGenericType_generic_type_instantiation()
        {
            return typeof(ArraySegment<int>).IsGenericType;
        }

        [Benchmark]
        public bool IsGenericType_non_generic_type()
        {
            return typeof(Action).IsGenericType;
        }

        [Benchmark]
        public bool IsNested_non_nested_type()
        {
            return typeof(ReflectionBenchmarks).IsNested;
        }

        [Benchmark]
        public bool IsNested_nested_type()
        {
            return typeof(A).IsNested;
        }

        public class A
        {
        }
    }
}

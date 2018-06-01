﻿// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

namespace TypeNameFormatter
{
    using System;

    using Xunit;

    public class Tests
    {
        [Theory]
        [InlineData("A", typeof(global::A))]
        [InlineData("A", typeof(global::N.A))]
        [InlineData("A", typeof(global::N.O.A))]
        public void Simple_type_Name(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName());
        }

        [Theory]
        [InlineData("A", typeof(global::A))]
        [InlineData("N.A", typeof(global::N.A))]
        [InlineData("N.O.A", typeof(global::N.O.A))]
        public void Simple_type_FullName(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName(TypeNameFormatOptions.Namespaces));
        }


        [Theory]
        [InlineData("A.B", typeof(global::A.B))]
        [InlineData("A.B", typeof(global::N.A.B))]
        [InlineData("A.B", typeof(global::N.O.A.B))]
        [InlineData("A.B.C", typeof(global::A.B.C))]
        [InlineData("A.B.C", typeof(global::N.A.B.C))]
        [InlineData("A.B.C", typeof(global::N.O.A.B.C))]
        public void Nested_type_Name(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName());
        }

        [Theory]
        [InlineData("A.B", typeof(global::A.B))]
        [InlineData("N.A.B", typeof(global::N.A.B))]
        [InlineData("N.O.A.B", typeof(global::N.O.A.B))]
        [InlineData("A.B.C", typeof(global::A.B.C))]
        [InlineData("N.A.B.C", typeof(global::N.A.B.C))]
        [InlineData("N.O.A.B.C", typeof(global::N.O.A.B.C))]
        public void Nested_type_FullName(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName(TypeNameFormatOptions.Namespaces));
        }

        [Theory]
        [InlineData("A<>", typeof(global::A<>))]
        [InlineData("A<>", typeof(global::N.A<>))]
        [InlineData("A<>", typeof(global::N.O.A<>))]
        [InlineData("A<,>", typeof(global::A<,>))]
        [InlineData("A<,>", typeof(global::N.A<,>))]
        [InlineData("A<,>", typeof(global::N.O.A<,>))]
        public void Generic_type_Name(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName());
        }

        [Theory]
        [InlineData("A<T>", typeof(global::A<>))]
        [InlineData("A<T>", typeof(global::N.A<>))]
        [InlineData("A<T>", typeof(global::N.O.A<>))]
        [InlineData("A<T, U>", typeof(global::A<,>))]
        [InlineData("A<T, U>", typeof(global::N.A<,>))]
        [InlineData("A<T, U>", typeof(global::N.O.A<,>))]
        public void Generic_type_with_parameter_names_Name(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName(TypeNameFormatOptions.GenericParameterNames));
        }

        [Theory]
        [InlineData("A<T>", typeof(global::A<>))]
        [InlineData("N.A<T>", typeof(global::N.A<>))]
        [InlineData("N.O.A<T>", typeof(global::N.O.A<>))]
        [InlineData("A<T, U>", typeof(global::A<,>))]
        [InlineData("N.A<T, U>", typeof(global::N.A<,>))]
        [InlineData("N.O.A<T, U>", typeof(global::N.O.A<,>))]
        public void Generic_type_with_parameter_names_FullName(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName(TypeNameFormatOptions.Namespaces | TypeNameFormatOptions.GenericParameterNames));
        }

        [Theory]
        [InlineData("A<A>", typeof(global::A<global::A>))]
        [InlineData("A<A>", typeof(global::N.A<global::A>))]
        [InlineData("A<A>", typeof(global::N.O.A<global::A>))]
        [InlineData("A<A>", typeof(global::A<global::N.A>))]
        [InlineData("A<A>", typeof(global::N.A<global::N.A>))]
        [InlineData("A<A>", typeof(global::N.O.A<global::N.A>))]
        [InlineData("A<A>", typeof(global::A<global::N.O.A>))]
        [InlineData("A<A>", typeof(global::N.A<global::N.O.A>))]
        [InlineData("A<A>", typeof(global::N.O.A<global::N.O.A>))]
        public void Generic_type_instantiation_Name(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName());
        }

        [Theory]
        [InlineData("A<A>", typeof(global::A<global::A>))]
        [InlineData("N.A<A>", typeof(global::N.A<global::A>))]
        [InlineData("N.O.A<A>", typeof(global::N.O.A<global::A>))]
        [InlineData("A<N.A>", typeof(global::A<global::N.A>))]
        [InlineData("N.A<N.A>", typeof(global::N.A<global::N.A>))]
        [InlineData("N.O.A<N.A>", typeof(global::N.O.A<global::N.A>))]
        [InlineData("A<N.O.A>", typeof(global::A<global::N.O.A>))]
        [InlineData("N.A<N.O.A>", typeof(global::N.A<global::N.O.A>))]
        [InlineData("N.O.A<N.O.A>", typeof(global::N.O.A<global::N.O.A>))]
        public void Generic_type_instantiation_FullName(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName(TypeNameFormatOptions.Namespaces));
        }

        [Theory]
        [InlineData("A<A<A>>", typeof(global::A<global::A<global::A>>))]
        [InlineData("A<A<A>>", typeof(global::N.A<global::A<global::A>>))]
        [InlineData("A<A<A>>", typeof(global::N.O.A<global::A<global::A>>))]
        public void Recursive_generic_type_instantiation_Name(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName());
        }

        [Theory]
        [InlineData("A<A<A>>", typeof(global::A<global::A<global::A>>))]
        [InlineData("N.A<A<A>>", typeof(global::N.A<global::A<global::A>>))]
        [InlineData("N.O.A<A<A>>", typeof(global::N.O.A<global::A<global::A>>))]
        public void Recursive_generic_type_instantiation_FullName(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName(TypeNameFormatOptions.Namespaces));
        }

        [Theory]
        [InlineData("A.B<U>", typeof(global::A.B<>))]
        [InlineData("A<T>.B", typeof(global::A<>.B))]
        [InlineData("A<T>.B.C", typeof(global::A<>.B.C))]
        [InlineData("A<T>.B.C<U>", typeof(global::A<>.B.C<>))]
        [InlineData("A<T>.B.C<U, V>", typeof(global::A<>.B.C<,>))]
        [InlineData("A<T>.B<U>", typeof(global::A<>.B<>))]
        [InlineData("A<T>.B<U>.C", typeof(global::A<>.B<>.C))]
        [InlineData("A<T>.B<U>.C<V>", typeof(global::A<>.B<>.C<>))]
        [InlineData("A<T>.B<U>.C<V, W>", typeof(global::A<>.B<>.C<,>))]
        [InlineData("A<T>.B<U, V>", typeof(global::A<>.B<,>))]
        [InlineData("A<T>.B<U, V>.C", typeof(global::A<>.B<,>.C))]
        [InlineData("A<T>.B<U, V>.C<W>", typeof(global::A<>.B<,>.C<>))]
        [InlineData("A<T>.B<U, V>.C<W, X>", typeof(global::A<>.B<,>.C<,>))]
        [InlineData("A<T, U>.B", typeof(global::A<,>.B))]
        [InlineData("A<T, U>.B.C", typeof(global::A<,>.B.C))]
        [InlineData("A<T, U>.B.C<V>", typeof(global::A<,>.B.C<>))]
        [InlineData("A<T, U>.B.C<V, W>", typeof(global::A<,>.B.C<,>))]
        [InlineData("A<T, U>.B<V>", typeof(global::A<,>.B<>))]
        [InlineData("A<T, U>.B<V>.C", typeof(global::A<,>.B<>.C))]
        [InlineData("A<T, U>.B<V>.C<W>", typeof(global::A<,>.B<>.C<>))]
        [InlineData("A<T, U>.B<V>.C<W, X>", typeof(global::A<,>.B<>.C<,>))]
        [InlineData("A<T, U>.B<V, W>", typeof(global::A<,>.B<,>))]
        [InlineData("A<T, U>.B<V, W>.C", typeof(global::A<,>.B<,>.C))]
        [InlineData("A<T, U>.B<V, W>.C<X>", typeof(global::A<,>.B<,>.C<>))]
        [InlineData("A<T, U>.B<V, W>.C<X, Y>", typeof(global::A<,>.B<,>.C<,>))]
        public void Nested_generic_type(string expectedName, Type type)
        {
            Assert.Equal(expectedName, type.GetFormattedName(TypeNameFormatOptions.GenericParameterNames));
        }

        [Fact]
        public void Nested_generic_type_instantiation_FullName()
        {
            Assert.Equal("A<A>.B<N.A, N.O.A>.C<A>", typeof(global::A<global::A>.B<global::N.A, global::N.O.A>.C<global::A>).GetFormattedName(TypeNameFormatOptions.Namespaces | TypeNameFormatOptions.GenericParameterNames));
        }

        [Fact]
        public void Nested_recursive_generic_type_instantiation_FullName()
        {
            Assert.Equal("A<A>.B<N.A<N.O.A<A>>, N.O.A>.C<A>", typeof(global::A<global::A>.B<global::N.A<global::N.O.A<global::A>>, global::N.O.A>.C<global::A>).GetFormattedName(TypeNameFormatOptions.Namespaces | TypeNameFormatOptions.GenericParameterNames));
        }

        [Theory]
        [InlineData("bool", typeof(bool))]
        [InlineData("byte", typeof(byte))]
        [InlineData("char", typeof(char))]
        [InlineData("decimal", typeof(decimal))]
        [InlineData("double", typeof(double))]
        [InlineData("float", typeof(float))]
        [InlineData("int", typeof(int))]
        [InlineData("long", typeof(long))]
        [InlineData("object", typeof(object))]
        [InlineData("sbyte", typeof(sbyte))]
        [InlineData("short", typeof(short))]
        [InlineData("string", typeof(string))]
        [InlineData("uint", typeof(uint))]
        [InlineData("ulong", typeof(ulong))]
        [InlineData("ushort", typeof(ushort))]
        [InlineData("void", typeof(void))]
        public void Type_keyword_Name(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName());
        }

        [Theory]
        [InlineData("bool", typeof(bool))]
        [InlineData("byte", typeof(byte))]
        [InlineData("char", typeof(char))]
        [InlineData("decimal", typeof(decimal))]
        [InlineData("double", typeof(double))]
        [InlineData("float", typeof(float))]
        [InlineData("int", typeof(int))]
        [InlineData("long", typeof(long))]
        [InlineData("object", typeof(object))]
        [InlineData("sbyte", typeof(sbyte))]
        [InlineData("short", typeof(short))]
        [InlineData("string", typeof(string))]
        [InlineData("uint", typeof(uint))]
        [InlineData("ulong", typeof(ulong))]
        [InlineData("ushort", typeof(ushort))]
        [InlineData("void", typeof(void))]
        public void Type_keyword_FullName(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName(TypeNameFormatOptions.Namespaces));
        }


        [Theory]
        [InlineData("System.Boolean", typeof(bool))]
        [InlineData("System.Byte", typeof(byte))]
        [InlineData("System.Char", typeof(char))]
        [InlineData("System.Decimal", typeof(decimal))]
        [InlineData("System.Double", typeof(double))]
        [InlineData("System.Single", typeof(float))]
        [InlineData("System.Int32", typeof(int))]
        [InlineData("System.Int64", typeof(long))]
        [InlineData("System.Object", typeof(object))]
        [InlineData("System.SByte", typeof(sbyte))]
        [InlineData("System.Int16", typeof(short))]
        [InlineData("System.String", typeof(string))]
        [InlineData("System.UInt32", typeof(uint))]
        [InlineData("System.UInt64", typeof(ulong))]
        [InlineData("System.UInt16", typeof(ushort))]
        [InlineData("System.Void", typeof(void))]
        public void Type_keyword_disabled_FullName(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName(TypeNameFormatOptions.Namespaces | TypeNameFormatOptions.NoKeywords));
        }

        [Theory]
        [InlineData("A<int>", typeof(global::A<int>))]
        [InlineData("A<int, short>", typeof(global::N.A<int, short>))]
        public void Type_keyword_as_generic_type_argument_Name(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName());
        }

        [Theory]
        [InlineData("A<int>", typeof(global::A<int>))]
        [InlineData("N.A<int, short>", typeof(global::N.A<int, short>))]
        public void Type_keyword_as_generic_type_argument_FullName(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName(TypeNameFormatOptions.Namespaces));
        }

        [Theory]
        [InlineData("A[]", typeof(global::A[]))]
        [InlineData("A[]", typeof(global::N.A[]))]
        [InlineData("A<A[]>", typeof(global::A<global::A[]>))]
        [InlineData("object[]", typeof(object[]))]
        public void Array_type_Name(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName());
        }

        [Theory]
        [InlineData("A[]", typeof(global::A[]))]
        [InlineData("N.A[]", typeof(global::N.A[]))]
        [InlineData("A<A[]>", typeof(global::A<global::A[]>))]
        [InlineData("object[]", typeof(object[]))]
        public void Array_type_FullName(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName(TypeNameFormatOptions.Namespaces));
        }

        [Theory]
        [InlineData("A[,]", typeof(global::A[,]))]
        [InlineData("A[,,]", typeof(global::A[,,]))]
        [InlineData("A[,,,]", typeof(global::A[,,,]))]
        public void Multidimensional_array_type_Name(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName());
        }

        [Theory]
        [InlineData("A[][,]", typeof(global::A[][,]))]
        [InlineData("A[][,][,,]", typeof(global::A[][,][,,]))]
        public void Jagged_array_type_Name(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName());
        }

        [Fact]
        public void Reference_type_Name()
        {
            var type = typeof(global::N.A).MakeByRefType();
            Assert.Equal("ref A", type.GetFormattedName());
        }

        [Fact]
        public void Reference_type_FullName()
        {
            var type = typeof(global::N.A).MakeByRefType();
            Assert.Equal("ref N.A", type.GetFormattedName(TypeNameFormatOptions.Namespaces));
        }

        [Theory]
        [InlineData("void*", typeof(void*))]
        public void Pointer_type_Name(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName());
        }

        [Fact]
        public void Array_of_generic_type_instantiation_of_jagged_array_type()
        {
            var type = typeof(global::N.A<int*[,][][,,]>[]);
            Assert.Equal("N.A<int*[,][][,,]>[]", type.GetFormattedName(TypeNameFormatOptions.Namespaces));
        }

        [Theory]
        [InlineData("int?", typeof(int?), TypeNameFormatOptions.Default)]
        [InlineData("Int32?", typeof(int?), TypeNameFormatOptions.NoKeywords)]
        [InlineData("Nullable<int>", typeof(int?), TypeNameFormatOptions.NoNullableQuestionMark)]
        [InlineData("Nullable<Int32>", typeof(int?), TypeNameFormatOptions.NoKeywords | TypeNameFormatOptions.NoNullableQuestionMark)]
        [InlineData("S?", typeof(global::N.S?), TypeNameFormatOptions.Default)]
        [InlineData("Nullable<S>", typeof(global::N.S?), TypeNameFormatOptions.NoNullableQuestionMark)]
        [InlineData("N.S?", typeof(global::N.S?), TypeNameFormatOptions.Namespaces)]
        [InlineData("System.Nullable<N.S>", typeof(global::N.S?), TypeNameFormatOptions.Namespaces | TypeNameFormatOptions.NoNullableQuestionMark)]
        [InlineData("A<S?>", typeof(global::A<global::S?>), TypeNameFormatOptions.Default)]
        [InlineData("A<N.S?>", typeof(global::A<global::N.S?>), TypeNameFormatOptions.Namespaces)]
        public void Nullable_type(string expectedFormattedName, Type type, TypeNameFormatOptions options)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName(options));
        }
    }
}

// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

using System;
using Xunit;

namespace TypeNameFormatter
{
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
            Assert.Equal(expectedFormattedName, type.GetFormattedFullName());
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
            Assert.Equal(expectedFormattedName, type.GetFormattedFullName());
        }

        [Theory]
        [InlineData("A<T>", typeof(global::A<>))]
        [InlineData("A<T>", typeof(global::N.A<>))]
        [InlineData("A<T>", typeof(global::N.O.A<>))]
        [InlineData("A<T, U>", typeof(global::A<,>))]
        [InlineData("A<T, U>", typeof(global::N.A<,>))]
        [InlineData("A<T, U>", typeof(global::N.O.A<,>))]
        public void Generic_type_Name(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName());
        }

        [Theory]
        [InlineData("A<T>", typeof(global::A<>))]
        [InlineData("N.A<T>", typeof(global::N.A<>))]
        [InlineData("N.O.A<T>", typeof(global::N.O.A<>))]
        [InlineData("A<T, U>", typeof(global::A<,>))]
        [InlineData("N.A<T, U>", typeof(global::N.A<,>))]
        [InlineData("N.O.A<T, U>", typeof(global::N.O.A<,>))]
        public void Generic_type_FullName(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedFullName());
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
            Assert.Equal(expectedFormattedName, type.GetFormattedFullName());
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
            Assert.Equal(expectedFormattedName, type.GetFormattedFullName());
        }

        [Theory]
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
            Assert.Equal(expectedName, type.GetFormattedName());
        }

        [Fact]
        public void Nested_generic_type_instantiation_FullName()
        {
            Assert.Equal("A<A>.B<N.A, N.O.A>.C<A>", typeof(global::A<global::A>.B<global::N.A, global::N.O.A>.C<global::A>).GetFormattedFullName());
        }

        [Fact]
        public void Nested_recursive_generic_type_instantiation_FullName()
        {
            Assert.Equal("A<A>.B<N.A<N.O.A<A>>, N.O.A>.C<A>", typeof(global::A<global::A>.B<global::N.A<global::N.O.A<global::A>>, global::N.O.A>.C<global::A>).GetFormattedFullName());
        }

        [Theory]
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
            Assert.Equal(expectedFormattedName, type.GetFormattedFullName());
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
            Assert.Equal(expectedFormattedName, type.GetFormattedFullName());
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
            Assert.Equal(expectedFormattedName, type.GetFormattedFullName());
        }


        [Theory]
        [InlineData("A[,]", typeof(global::A[,]))]
        [InlineData("A[,,]", typeof(global::A[,,]))]
        [InlineData("A[,,,]", typeof(global::A[,,,]))]
        public void Multidimensional_array_type_Name(string expectedFormattedName, Type type)
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
            Assert.Equal("ref N.A", type.GetFormattedFullName());
        }

        [Theory]
        [InlineData("void*", typeof(void*))]
        public void Pointer_type_Name(string expectedFormattedName, Type type)
        {
            Assert.Equal(expectedFormattedName, type.GetFormattedName());
        }
    }
}

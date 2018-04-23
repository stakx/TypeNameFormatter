// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

using Xunit;

namespace TypeNameFormatter
{
    public class Tests
    {
        [Fact]
        public void Type_without_namespace_Name()
        {
            Assert.Equal("A", typeof(global::A).GetFormattedName());
        }

        [Fact]
        public void Type_without_namespace_FullName()
        {
            Assert.Equal("A", typeof(global::A).GetFormattedFullName());
        }

        [Fact]
        public void Type_with_namespace_Name()
        {
            Assert.Equal("A", typeof(global::N.A).GetFormattedName());
        }

        [Fact]
        public void Type_with_namespace_FullName()
        {
            Assert.Equal("N.A", typeof(global::N.A).GetFormattedFullName());
        }

        [Fact]
        public void Type_with_double_namespace_Name()
        {
            Assert.Equal("A", typeof(global::N.O.A).GetFormattedName());
        }

        [Fact]
        public void Type_with_double_namespace_FullName()
        {
            Assert.Equal("N.O.A", typeof(global::N.O.A).GetFormattedFullName());
        }

        [Fact]
        public void Nested_type_without_namespace_Name()
        {
            Assert.Equal("A.B", typeof(global::A.B).GetFormattedName());
        }

        [Fact]
        public void Nested_type_without_namespace_FullName()
        {
            Assert.Equal("A.B", typeof(global::A.B).GetFormattedFullName());
        }

        [Fact]
        public void Nested_type_with_namespace_Name()
        {
            Assert.Equal("A.B", typeof(global::N.A.B).GetFormattedName());
        }

        [Fact]
        public void Nested_type_with_namespace_FullName()
        {
            Assert.Equal("N.A.B", typeof(global::N.A.B).GetFormattedFullName());
        }

        [Fact]
        public void Nested_type_with_double_namespace_Name()
        {
            Assert.Equal("A.B", typeof(global::N.O.A.B).GetFormattedName());
        }

        [Fact]
        public void Nested_type_with_double_namespace_FullName()
        {
            Assert.Equal("N.O.A.B", typeof(global::N.O.A.B).GetFormattedFullName());
        }

        [Fact]
        public void Double_nested_type_without_namespace_Name()
        {
            Assert.Equal("A.B.C", typeof(global::A.B.C).GetFormattedName());
        }

        [Fact]
        public void Double_nested_type_without_namespace_FullName()
        {
            Assert.Equal("A.B.C", typeof(global::A.B.C).GetFormattedFullName());
        }

        [Fact]
        public void Double_nested_type_with_namespace_Name()
        {
            Assert.Equal("A.B.C", typeof(global::N.A.B.C).GetFormattedName());
        }

        [Fact]
        public void Double_nested_type_with_namespace_FullName()
        {
            Assert.Equal("N.A.B.C", typeof(global::N.A.B.C).GetFormattedFullName());
        }

        [Fact]
        public void Double_nested_type_with_double_namespace_Name()
        {
            Assert.Equal("A.B.C", typeof(global::N.O.A.B.C).GetFormattedName());
        }

        [Fact]
        public void Double_nested_type_with_double_namespace_FullName()
        {
            Assert.Equal("N.O.A.B.C", typeof(global::N.O.A.B.C).GetFormattedFullName());
        }

        [Fact]
        public void Generic_type_without_namespace_Name()
        {
            Assert.Equal("A<T>", typeof(global::A<>).GetFormattedName());
        }

        [Fact]
        public void Generic_type_without_namespace_FullName()
        {
            Assert.Equal("A<T>", typeof(global::A<>).GetFormattedFullName());
        }

        [Fact]
        public void Generic_type_with_namespace_Name()
        {
            Assert.Equal("A<T>", typeof(global::N.A<>).GetFormattedName());
        }

        [Fact]
        public void Generic_type_with_namespace_FullName()
        {
            Assert.Equal("N.A<T>", typeof(global::N.A<>).GetFormattedFullName());
        }

        [Fact]
        public void Generic_type_with_double_namespace_Name()
        {
            Assert.Equal("A<T>", typeof(global::N.O.A<>).GetFormattedName());
        }

        [Fact]
        public void Generic_type_with_double_namespace_FullName()
        {
            Assert.Equal("N.O.A<T>", typeof(global::N.O.A<>).GetFormattedFullName());
        }
    }
}

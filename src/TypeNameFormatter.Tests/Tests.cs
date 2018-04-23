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
    }
}

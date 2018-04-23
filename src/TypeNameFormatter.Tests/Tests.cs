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
            Assert.Equal("Type", typeof(global::Type).GetFormattedName());
        }

        [Fact]
        public void Type_without_namespace_FullName()
        {
            Assert.Equal("Type", typeof(global::Type).GetFormattedFullName());
        }

        [Fact]
        public void Type_with_namespace_Name()
        {
            Assert.Equal("Type", typeof(global::Namespace.Type).GetFormattedName());
        }

        [Fact]
        public void Type_with_namespace_FullName()
        {
            Assert.Equal("Namespace.Type", typeof(global::Namespace.Type).GetFormattedFullName());
        }
    }
}

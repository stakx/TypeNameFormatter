// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

using System;
using System.ComponentModel;
using System.Text;

namespace TypeNameFormatter
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class TypeExtensions
    {
        public static string GetFormattedName(this Type type)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendName(type);
            return stringBuilder.ToString();
        }

        public static string GetFormattedFullName(this Type type)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFullName(type);
            return stringBuilder.ToString();
        }
    }
}

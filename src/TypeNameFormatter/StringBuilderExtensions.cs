// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

using System;
using System.ComponentModel;
using System.Text;

namespace TypeNameFormatter
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static partial class StringBuilderExtensions
    {
        public static StringBuilder AppendName(this StringBuilder stringBuilder, Type type)
        {
            stringBuilder.AppendName(type, withNamespace: false);
            return stringBuilder;
        }

        public static StringBuilder AppendFullName(this StringBuilder stringBuilder, Type type)
        {
            stringBuilder.AppendName(type, withNamespace: true);
            return stringBuilder;
        }

        private static void AppendName(this StringBuilder stringBuilder, Type type, bool withNamespace)
        {
            if (withNamespace)
            {
                string @namespace = type.Namespace;
                if (string.IsNullOrEmpty(@namespace) == false)
                {
                    stringBuilder.Append(type.Namespace);
                    stringBuilder.Append('.');
                }
            }

            stringBuilder.Append(type.Name);
        }
    }
}

// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

using System;
using System.ComponentModel;
using System.Diagnostics;
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
            stringBuilder.AppendName(type, withNamespace, type.IsGenericType ? type.GetGenericArguments() : null);
        }

        private static void AppendName(this StringBuilder stringBuilder, Type type, bool withNamespace, Type[] genericTypeArgs)
        {
            if (type.IsGenericParameter == false)
            {
                if (type.IsNested)
                {
                    stringBuilder.AppendName(type.DeclaringType, withNamespace, genericTypeArgs);
                    stringBuilder.Append('.');
                }
                else if (withNamespace)
                {
                    string @namespace = type.Namespace;
                    if (string.IsNullOrEmpty(@namespace) == false)
                    {
                        stringBuilder.Append(type.Namespace);
                        stringBuilder.Append('.');
                    }
                }
            }

            var name = type.Name;
            if (genericTypeArgs != null)
            {
                var backtickIndex = name.LastIndexOf('`');
                if (backtickIndex >= 0)
                {
                    stringBuilder.Append(name, 0, backtickIndex);
                }
                else
                {
                    stringBuilder.Append(name);
                }

                var ownGenericTypeParamCount = type.GetGenericArguments().Length;

                int ownGenericTypeArgStartIndex = 0;
                if (type.IsNested)
                {
                    var outerTypeGenericTypeParamCount = type.DeclaringType.GetGenericArguments().Length;
                    if (ownGenericTypeParamCount >= outerTypeGenericTypeParamCount)
                    {
                        ownGenericTypeArgStartIndex = outerTypeGenericTypeParamCount;
                    }
                }

                if (ownGenericTypeArgStartIndex < ownGenericTypeParamCount)
                {
                    stringBuilder.Append('<');

                    for (int i = ownGenericTypeArgStartIndex, n = ownGenericTypeParamCount; i < n; ++i)
                    {
                        if (i > ownGenericTypeArgStartIndex)
                        {
                            stringBuilder.Append(", ");
                        }

                        stringBuilder.AppendName(genericTypeArgs[i], withNamespace);
                    }

                    stringBuilder.Append('>');
                }
            }
            else
            {
                stringBuilder.Append(name);
            }
        }
    }
}

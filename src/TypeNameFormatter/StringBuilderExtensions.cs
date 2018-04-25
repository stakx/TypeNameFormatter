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

        private static void AppendName(this StringBuilder stringBuilder, Type type, bool withNamespace, Type[] innermostTypeGenericTypeArgs = null)
        {
            if (type.IsGenericParameter == false)
            {
                if (type.IsNested)
                {
                    if (type.IsGenericType && innermostTypeGenericTypeArgs == null)
                    {
                        innermostTypeGenericTypeArgs = type.GetGenericArguments();
                    }

                    stringBuilder.AppendName(type.DeclaringType, withNamespace, innermostTypeGenericTypeArgs);
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
            if (type.IsGenericType)
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

                var genericTypeArgs = type.GetGenericArguments();
                int offset = 0;
                if (type.IsNested)
                {
                    var outerTypeGenericTypeArgs = type.DeclaringType.GetGenericArguments();
                    if (genericTypeArgs.Length >= outerTypeGenericTypeArgs.Length)
                    {
                        offset = outerTypeGenericTypeArgs.Length;
                    }
                }

                if (offset < genericTypeArgs.Length)
                {
                    stringBuilder.Append('<');

                    if (innermostTypeGenericTypeArgs == null)
                    {
                        innermostTypeGenericTypeArgs = genericTypeArgs;
                    }

                    for (int i = offset, n = genericTypeArgs.Length; i < n; ++i)
                    {
                        if (i > offset)
                        {
                            stringBuilder.Append(", ");
                        }

                        stringBuilder.AppendName(innermostTypeGenericTypeArgs[i], withNamespace);
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

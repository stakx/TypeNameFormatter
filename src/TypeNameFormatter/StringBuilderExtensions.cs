// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace TypeNameFormatter
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static partial class StringBuilderExtensions
    {
        private static Dictionary<Type, string> typeKeywords;

        static StringBuilderExtensions()
        {
            typeKeywords = new Dictionary<Type, string>()
            {
                [typeof(byte)] = "byte",
                [typeof(char)] = "char",
                [typeof(decimal)] = "decimal",
                [typeof(double)] = "double",
                [typeof(float)] = "float",
                [typeof(int)] = "int",
                [typeof(long)] = "long",
                [typeof(object)] = "object",
                [typeof(sbyte)] = "sbyte",
                [typeof(short)] = "short",
                [typeof(string)] = "string",
                [typeof(uint)] = "uint",
                [typeof(ulong)] = "ulong",
                [typeof(ushort)] = "ushort",
                [typeof(void)] = "void",
            };
        }

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
            if (typeKeywords.TryGetValue(type, out string typeKeyword))
            {
                stringBuilder.Append(typeKeyword);
                return;
            }
            else if (type.HasElementType)
            {
                var elementType = type.GetElementType();

                if (type.IsArray)
                {
                    if (elementType.IsArray == false)
                    {
                        stringBuilder.AppendName(elementType, withNamespace, genericTypeArgs);

                        var rank = type.GetArrayRank();
                        if (rank == 1)
                        {
                            stringBuilder.Append("[]");
                        }
                        else
                        {
                            Debug.Assert(rank > 1);

                            stringBuilder.Append('[');
                            stringBuilder.Append(',', rank - 1);
                            stringBuilder.Append(']');
                        }
                    }
                    else
                    {
                        var queue = new Queue<Type>();
                        var at = type;
                        while (at.IsArray)
                        {
                            queue.Enqueue(at);
                            at = at.GetElementType();
                        }

                        stringBuilder.AppendName(at, withNamespace, genericTypeArgs);
                        while (queue.Count > 0)
                        {
                            at = queue.Dequeue();
                            var rank = at.GetArrayRank();
                            stringBuilder.Append('[');
                            stringBuilder.Append(',', rank - 1);
                            stringBuilder.Append(']');
                        }
                    }
                }
                else if (type.IsByRef)
                {
                    stringBuilder.Append("ref ");
                    stringBuilder.AppendName(elementType, withNamespace, genericTypeArgs);
                }
                else if (type.IsPointer)
                {
                    stringBuilder.AppendName(elementType, withNamespace, genericTypeArgs);
                    stringBuilder.Append('*');
                }
                else
                {
                    Debug.Fail("Only array, by-ref, and pointer types have an element type. This should be unreachable.");
                }

                return;
            }


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

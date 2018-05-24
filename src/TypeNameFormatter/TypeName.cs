// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

namespace TypeNameFormatter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Reflection;
    using System.Text;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class TypeName
    {
        private static Dictionary<Type, string> typeKeywords;

        static TypeName()
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

        /// <summary>
        ///   Appends a string representation of the specified type to this instance.
        /// </summary>
        /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance to which to append.</param>
        /// <param name="type">The <see cref="Type"/> of which a string representation should be appended.</param>
        /// <param name="options">Any combination of formatting options that should be applied. (Optional.)</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public static StringBuilder AppendFormattedName(this StringBuilder stringBuilder, Type type, TypeNameFormatOptions options = TypeNameFormatOptions.Default)
        {
            stringBuilder.AppendFormattedName(type, options, IsGenericType(type) ? GetGenericTypeArguments(type) : null);
            return stringBuilder;
        }

        /// <summary>
        ///   Gets a string representation of this instance.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> of which a string representation is requested.</param>
        /// <param name="options">Any combination of formatting options that should be applied. (Optional.)</param>
        /// <returns>A string representation of this instance.</returns>
        public static string GetFormattedName(this Type type, TypeNameFormatOptions options = TypeNameFormatOptions.Default)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormattedName(type, options);
            return stringBuilder.ToString();
        }

        private static void AppendFormattedName(this StringBuilder stringBuilder, Type type, TypeNameFormatOptions options, Type[] genericTypeArgs)
        {
            if (IsSet(TypeNameFormatOptions.NoKeywords, options) == false && typeKeywords.TryGetValue(type, out string typeKeyword))
            {
                stringBuilder.Append(typeKeyword);
                return;
            }
            else if (type.HasElementType)
            {
                var elementType = type.GetElementType();

                if (type.IsArray)
                {
                    var ranks = new Queue<int>();
                    ranks.Enqueue(type.GetArrayRank());
                    HandleArrayElementType(elementType, ranks);

                    void HandleArrayElementType(Type et, Queue<int> r)
                    {
                        if (et.IsArray)
                        {
                            r.Enqueue(et.GetArrayRank());
                            HandleArrayElementType(et.GetElementType(), r);
                        }
                        else
                        {
                            stringBuilder.AppendFormattedName(et, options);
                            while (r.Count > 0)
                            {
                                stringBuilder.Append('[');
                                stringBuilder.Append(',', r.Dequeue() - 1);
                                stringBuilder.Append(']');
                            }
                        }
                    }
                }
                else if (type.IsByRef)
                {
                    stringBuilder.Append("ref ");
                    stringBuilder.AppendFormattedName(elementType, options);
                }
                else if (type.IsPointer)
                {
                    stringBuilder.AppendFormattedName(elementType, options);
                    stringBuilder.Append('*');
                }
                else
                {
                    Debug.Assert(false, "Only array, by-ref, and pointer types have an element type. This should be unreachable.");
                }

                return;
            }


            if (type.IsGenericParameter == false)
            {
                if (type.IsNested)
                {
                    stringBuilder.AppendFormattedName(type.DeclaringType, options, genericTypeArgs);
                    stringBuilder.Append('.');
                }
                else if (IsSet(TypeNameFormatOptions.NoNullableQuestionMark, options) == false && genericTypeArgs?.Length == 1 && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    stringBuilder.AppendFormattedName(genericTypeArgs[0], options);
                    stringBuilder.Append('?');
                    return;
                }
                else if (IsSet(TypeNameFormatOptions.Namespaces, options))
                {
                    string @namespace = type.Namespace;
                    if (string.IsNullOrEmpty(@namespace) == false)
                    {
                        stringBuilder.Append(type.Namespace);
                        stringBuilder.Append('.');
                    }
                }
            }
            else if (IsSet(TypeNameFormatOptions.GenericParameterNames, options) == false)
            {
                return;
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

                var ownGenericTypeParamCount = GetGenericTypeArguments(type).Length;

                int ownGenericTypeArgStartIndex = 0;
                if (type.IsNested)
                {
                    var outerTypeGenericTypeParamCount = GetGenericTypeArguments(type.DeclaringType).Length;
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
                            if (IsSet(TypeNameFormatOptions.GenericParameterNames, options) || genericTypeArgs[i].IsGenericParameter == false)
                            {
                                stringBuilder.Append(", ");
                            }
                            else
                            {
                                stringBuilder.Append(',');
                            }
                        }

                        stringBuilder.AppendFormattedName(genericTypeArgs[i], options);
                    }

                    stringBuilder.Append('>');
                }
            }
            else
            {
                stringBuilder.Append(name);
            }
        }

        /// <remarks>
        ///   Replacement for <see cref="M:System.Enum.HasFlag(System.Enum)"/>
        ///   which may be slow or even unavailable on earlier target frameworks.
        /// </remarks>
        private static bool IsSet(TypeNameFormatOptions option, TypeNameFormatOptions options)
        {
            return (options & option) == option;
        }

        /// <remarks>
        ///   Allows uniform reflection across all target frameworks.
        /// </remarks>
        private static Type[] GetGenericTypeArguments(Type type)
        {
#if TYPENAMEFORMATTER_USE_SEMIBROKEN_REFLECTION
            return type.GenericTypeArguments;
#else
            return type.GetGenericArguments();
#endif
        }

        /// <remarks>
        ///   Allows uniform reflection across all target frameworks.
        /// </remarks>
        private static bool IsGenericType(Type type)
        {
#if TYPENAMEFORMATTER_USE_SEMIBROKEN_REFLECTION
            return type.GetTypeInfo().IsGenericType;
#else
            return type.IsGenericType;
#endif
        }
    }
}

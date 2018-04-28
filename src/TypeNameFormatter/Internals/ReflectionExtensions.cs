// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

using System;
using System.Reflection;

namespace TypeNameFormatter.Internals
{
    /// <summary>
    ///   Contains extension methods that allow uniform reflection across all target frameworks.
    /// </summary>
    internal static class ReflectionExtensions
    {
        public static Type[] GetGenericTypeArguments(this Type type)
        {
#if NETSTANDARD10
            return type.GenericTypeArguments;
#else
            return type.GetGenericArguments();
#endif
        }

        public static bool IsGenericType(this Type type)
        {
#if NETSTANDARD10
            return type.GetTypeInfo().IsGenericType;
#else
            return type.IsGenericType;
#endif
        }
    }
}

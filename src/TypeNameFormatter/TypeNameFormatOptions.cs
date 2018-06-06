// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

namespace TypeNameFormatter
{
    using System;

    /// <summary>
    ///   An enumeration of available options when a <see cref="Type"/> name's string representation is requested.
    /// </summary>
    [Flags]
#if TYPENAMEFORMATTER_INTERNAL
    internal
#else
    public
#endif
    enum TypeNameFormatOptions
    {
        /// <summary>
        ///   The default type name formatting options.
        /// </summary>
        Default = 0,

        /// <summary>
        ///   Specifies that an open generic type's parameter names should be omitted.
        ///   <example>
        ///     For example, the open generic type <see cref="IEquatable{T}"/> is formatted as <c>"IEquatable&lt;T&gt;"</c> by default.
        ///     When this flag is specified, it will be formatted as <c>"IEquatable&lt;&gt;"</c>.
        ///   </example>
        /// </summary>
        NoGenericParameterNames = 1,

        /// <summary>
        ///   Specifies that a type's namespace should be included.
        ///   <example>
        ///     For example, the type <see cref="Action"/> is formatted as <c>"Action"</c> by default.
        ///     When this flag is specified, it will be formatted as <c>"System.Action"</c>.
        ///   </example>
        /// </summary>
        Namespaces = 2,

        /// <summary>
        ///   Specifies that primitive types should not be mapped to their corresponding C# language keywords.
        ///   <example>
        ///     For example, the type <see cref="Int32"/> is formatted as <c>"int"</c> by default.
        ///     When this flag is specified, it will be formatted as <c>"Int32"</c>.
        ///   </example>
        /// </summary>
        NoKeywords = 4,

        /// <summary>
        ///   Specifies that nullable types should not be simplified to C# question mark syntax.
        ///   <example>
        ///   For example, the type <see cref="Nullable{T}"/> of <see cref="Int32"/> is formatted as <c>"int?"</c> by default.
        ///   When this flag is specified, it will be formatted as <c>"Nullable&lt;int&gt;"</c>.
        ///   </example>
        /// </summary>
        NoNullableQuestionMark = 8,

        /// <summary>
        ///   Specifies that value tuple types should not be transformed to C# tuple syntax.
        ///   <example>
        ///   For example, the type <see cref="T:System.ValueTuple`2"/> of <see cref="Boolean"/>, <see cref="Int32"/>
        ///   is formatted as <c>"(bool, int)"</c> by default. When this flag is specified,
        ///   it will be formatted as <c>"ValueTuple&lt;bool, int&gt;"</c>.
        ///   </example>
        /// </summary>
        NoTuple = 16,

        /// <summary>
        ///   Specifies that anonymous types should not be transformed to C#-like syntax.
        ///   <example>
        ///   For example, the anonymous type of <c>"new { Name = "Blob", Count = 17 }"</c> is formatted as
        ///   <c>"{string Name, int Count}"</c> by default. When this flag is specified, it will be formatted as
        ///   the raw "display class" name, which looks something like <c>"&lt;&gt;f__AnonymousType5&lt;string, int&gt;"</c>.
        ///   </example>
        /// </summary>
        NoAnonymousTypes = 32,
    }
}

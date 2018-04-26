// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

namespace TypeNameFormatter.Internals
{
    internal static class TypeNameFormatOptionsExtensions
    {
        public static bool IsSet(this TypeNameFormatOptions options, TypeNameFormatOptions option)
        {
            return (options & option) == option;
        }
    }
}

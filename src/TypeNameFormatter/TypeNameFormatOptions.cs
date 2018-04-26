// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

using System;

namespace TypeNameFormatter
{
    [Flags]
    public enum TypeNameFormatOptions
    {
        Default = 0,
        Namespaces = 1,
        NoKeywords = 2,
    }
}

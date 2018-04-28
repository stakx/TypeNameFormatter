// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

#if NET20
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    internal sealed class ExtensionAttribute : Attribute
    {
    }
}
#endif

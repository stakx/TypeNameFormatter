// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/TypeNameFormatter/blob/master/LICENSE.md.

internal class A
{
    internal class B
    {
        internal class C
        {
        }
    }
}

internal class A<T>
{
}

namespace N
{
    internal class A
    {
        internal class B
        {
            internal class C
            {
            }
        }
    }

    internal class A<T>
    {
    }
}

namespace N.O
{
    internal class A
    {
        internal class B
        {
            internal class C
            {
            }
        }
    }

    internal class A<T>
    {
    }
}

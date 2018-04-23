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

internal class A<T, U>
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

    internal class A<T, U>
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

    internal class A<T, U>
    {
    }
}

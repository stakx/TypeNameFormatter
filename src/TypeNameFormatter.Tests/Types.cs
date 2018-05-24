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

    internal struct S
    {
    }
}

internal class A<T>
{
    internal class B
    {
        internal class C
        {
        }

        internal class C<U>
        {
        }

        internal class C<U, V>
        {
        }
    }

    internal class B<U>
    {
        internal class C
        {
        }

        internal class C<V>
        {
        }

        internal class C<V, W>
        {
        }
    }

    internal class B<U, V>
    {
        internal class C
        {
        }

        internal class C<W>
        {
        }

        internal class C<W, X>
        {
        }
    }
}

internal class A<T, U>
{
    internal class B
    {
        internal class C
        {
        }

        internal class C<V>
        {
        }

        internal class C<V, W>
        {
        }
    }

    internal class B<V>
    {
        internal class C
        {
        }

        internal class C<W>
        {
        }

        internal class C<W, X>
        {
        }
    }

    internal class B<V, W>
    {
        internal class C
        {
        }

        internal class C<X>
        {
        }

        internal class C<X, Y>
        {
        }
    }
}

internal struct S
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

    internal struct S
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

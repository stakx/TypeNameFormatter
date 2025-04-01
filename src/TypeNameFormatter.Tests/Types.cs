// Copyright (c) 2018-2025 stakx and project contributors
// License available at https://github.com/stakx/TypeNameFormatter/blob/main/LICENSE.md.

internal class A
{
    internal class B
    {
        internal class C
        {
        }
    }

    internal class B<U>
    {
    }

    internal struct S
    {
    }
}

internal class A<T>
{
    public T[] Array = null;

    public (T, T) Tuple = (default(T), default(T));

    /// <remarks>
    ///   Note that there is a small difference between the declaring type `A<T>` and the return type `A<T>`:
    ///   The declaring type `A<T>` is a generic type definition, while the return type `A<T>` is a generic
    ///   type definition instantiated over its own generic argument. That is, in the return type, the type's
    ///   generic type *parameter* acts as an *argument*. Reflection does not distinguish between these two
    ///   concepts, and that will show in the unit test case targeting this field.
    /// </remarks>
    public A<T> Self = null;

    public B<T> OtherGeneric = null;

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

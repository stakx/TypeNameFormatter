# TypeNameFormatter

A small .NET library for formatting type names à la C#. 

## What is this good for?

Have you ever stumbled over the cryptic formatting of `Type` objects?

```csharp
var someType = typeof(IEnumerable<int[]>);

Console.WriteLine(someType);
// => System.Collections.Generic.IEnumerable`1[System.Int32[]]
```

If you'd rather see something that looks more like a C# type reference, then this library might be for you:

```csharp
using TypeNameFormatter;

var someType = typeof(IEnumerable<int[]>);

Console.WriteLine(someType.GetFormattedName());
// => IEnumerable<int[]>

Console.WriteLine(someType.GetFormattedFullName());
// => System.Collections.Generic.IEnumerable<int[]>
```

Formatting any `Type` involves more special cases than you might expect (such as generic types, nested types, multi-dimensional and jagged arrays, by-reference and pointer types). This library deals with all of those, so that you don't have to.


## How do I use it?

By importing the `TypeNameFormatter` namespace, the following extension methods become available:

* **`stringBuilder.AppendName(Type type)`**: Appends a C#-formatted type reference to the given `StringBuilder`. Does not include namespaces.
 
* **`stringBuilder.AppendFullName(Type type)`**: Same as above, but with namespaces included.

* **`type.GetFormattedName()`**: Returns a C#-formatted type reference as a string. Does not include namespaces. (This is a convenience method that simply uses a throw-away `StringBuilder` and the first extension method from this list.)

* **`type.GetFormattedFullName()`**: Same as above, but with namespaces included.


## But it doesn't format \<some type\> correctly!

If you think you've found a bug, please raise an [issue](https://github.com/stakx/TypeNameFormatter/issues) so it can be looked into. (Make sure to mention the type that doesn't get formatted as expected.)


## Alternatives

* If you're targeting the .NET Framework, you can use good old `System.CodeDom` (which isn't particularly fast, however):

   ```csharp
   using Microsoft.CSharp;
   using System.CodeDom;

   static string GetFormattedFullName(this Type type)
   {
       using (var provider = new CSharpCodeProvider())
       {
           var typeReference = new CodeTypeReference(type);
           return provider.GetTypeOutput(typeReference));
       }
   }
   ```

* You could perhaps use Microsoft's [.NET Compiler Platform (Roslyn)](https://www.nuget.org/packages/Microsoft.CodeAnalysis "'Microsoft.CodeAnalysis' package on NuGet"), but that is a large library that can do much more than is needed.

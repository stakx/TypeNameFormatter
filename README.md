﻿![TypeNameFormatter](https://github.com/stakx/typenameformatter/raw/master/assets/icon-64x64.png "TypeNameFormatter")

TypeNameFormatter is a small .NET library for formatting type names à la C#. 

[![NuGet badge](https://img.shields.io/nuget/v/TypeNameFormatter.Sources.svg)](https://www.nuget.org/packages/TypeNameFormatter.Sources "Package available on NuGet.org")


## What is this good for?

Have you ever stumbled over the cryptic formatting of `Type` objects?

```csharp
var someType = typeof(IEnumerable<int[]>);

Console.WriteLine(someType);
// => System.Collections.Generic.IEnumerable`1[System.Int32[]]
```

If you'd rather see something that looks more like a C# type name, then this library might be for you:

```csharp
using TypeNameFormatter;

var someType = typeof(IEnumerable<int[]>);

Console.WriteLine(someType.GetFormattedName());
// => IEnumerable<int[]>
```

Formatting any `Type` involves more special cases than you might expect (such as generic types, nested types, multi-dimensional and jagged arrays, by-reference and pointer types). This library deals with all of those, so that you don't have to.


## How do I use it?

By importing the `TypeNameFormatter` namespace, the following extension methods become available:

* **`stringBuilder.AppendFormattedName(Type type, [TypeNameFormatOptions options])`**:  
  Appends a C#-formatted type name to the given `StringBuilder`.
 
* **`type.GetFormattedName([TypeNameFormatOptions options])`**:  
  Returns a C#-formatted type name as a string. (This is a convenience method that does exactly the same as the above, using a throw-away `StringBuilder`.)

Both methods allow you to specify any combination of the following `TypeNameFormatOptions` flags:

* **`Namespaces`**:  
  Namespaces should be included. (For example, `System.Action` instead of `Action`.)

* **`NoAnonymousTypes`**:
  Anonymous types should not have their "display class" name transformed to a more legible syntax. (For example, `<>f__AnonymousType5<string, int>` instead of `{string Name, int Count}`.)

* **`NoGenericParameterNames`**:  
  Parameter names of an open generic type should be omitted. (For example, `IEnumerable<>` instead of `IEnumerable<T>`. Note that this setting does not affect closed generic types; their arguments are always included.)

* **`NoKeywords`**:  
  Primitive types should not be mapped to their corresponding C# language keywords. (For example, `Int32` instead of `int`.)

* **`NoNullableQuestionMark`**:
  Nullable types should not be formatted using C# question mark syntax. (For example, `Nullable<int>` instead of `int?`.)

* **`NoTuple`**:
  Value tuple types should not be formatted using C# tuple syntax. (For example, `ValueTuple<bool, int>` instead of `(bool, int)`.)


## But it doesn't format \<some type\> correctly!

If you think you've found a bug, please raise an [issue](https://github.com/stakx/TypeNameFormatter/issues) so it can be looked into. (Make sure to mention the type that doesn't get formatted as expected.)


## Alternatives

* If you're targeting the .NET Framework, you can use good old `System.CodeDom` (which isn't particularly fast, however):

   ```csharp
   using Microsoft.CSharp;
   using System.CodeDom;

   static string GetFormattedName(this Type type)
   {
       using (var provider = new CSharpCodeProvider())
       {
           var typeReference = new CodeTypeReference(type);
           return provider.GetTypeOutput(typeReference);
       }
   }
   ```

* You could perhaps use Microsoft's [.NET Compiler Platform (Roslyn)](https://www.nuget.org/packages/Microsoft.CodeAnalysis "'Microsoft.CodeAnalysis' package on NuGet"), but that is a large library that can do much more than is needed.

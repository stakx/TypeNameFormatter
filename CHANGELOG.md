# TypeNameFormatter Changelog

All notable changes to this project will be documented in this file.

The format is loosely based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/).


## 1.0.0 (2018-07-11)

Initial stable release. (Identical to 1.0.0-beta3 for all practical purposes.)


## 1.0.0-beta3 (2018-06-07)

#### Fixed

* Regression with closed generic types enclosed by non-generic types.
* Regression with detection of nullable types.
* Regression with building using MSBuild.


## 1.0.0-beta2 (2018-06-07)

#### Added

* Support for value tuples.
* Support for anonymous types.
* Support for JetBrains' Rider IDE.

#### Fixed

* Add missing support for `bool` keyword.

#### Changed

* Prevent debugger from "stepping into" (F11).
* Do not transform open generic `Nullable<>` and `ValueType<>` to special syntaxes (do that only for closed generic types).
* Distinguish better between generic type parameters and generic type arguments (only the former may be omitted).
* Invert definition of `GenericParameterNames` into `NoGenericParameterNames` (that is, including parameter names is now the default behavior, whereas they were previously omitted).
* Prevent ReSharper from analyzing the library's source.


## 1.0.0-beta (2018-05-24)

#### Added

* MSBuild property `<TypeNameFormatterInternal>` for controlling visbility of the types defined by the library.

#### Fixed

* `InvalidOperationException` when formatting generic types enclosed by non-generic types.
* Extend, but don't override MSBuild property `<DefineConstants>`.


## 1.0.0-alpha (2018-05-24)

Initial pre-release.

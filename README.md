# Carp
[![CodeFactor](https://www.codefactor.io/repository/github/melodi17/carp/badge/master)](https://www.codefactor.io/repository/github/melodi17/carp/overview/master)
[![](https://github.com/Melodi17/Carp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Melodi17/Carp/actions/workflows/dotnet.yml)

> Currently Carp is in early public releases, it may not be the most stable language for large projects, please report any issues through the GitHub issues page.

### What's new in version 1.0.6? [...](https://github.com/Melodi17/Carp/blob/master/UPDATES.md)
This version was based on making the language more debuggable and fixing some small issues.
- Fixed issue with the `*=` compound operator not being recognized in some circumstances by the parser
- Added stacktraces to errors, making it easier to debug, it now shows the line number, line content, source (e.g interpreter or file name) for each level of the stack to the error:
   ```
  UnusedBranch: Unused expression branch, side-effects are not allowed on PropertyExpressionContext
        --->  path-to-thing\thing.carp  5 |  x.do
        --->  path-to-thing\thing.carp  8 |  fail(1)
   ```
- Math package no longer rounds power and square root functions to full integers
- Deleted more todo items from the codebase
- Stacktrace now shows an out of bounds message if the current stackframe is not able to be found
- Partially fixed func casting
- Added `marshal.id` method that provides a unique identifier for a given object

### Features

- Implicit, but not stupid type coercion
- Open source (obviously)
- Import directly from GitHub
- Lots of short-hands
- Large collection of built-in types
- Statically typed and structured errors
- Can be written as scripts, projects, packages or real-time with the REPL



### Installation

1. Ensure dotnet is installed

2. Run the following to install it from NuGet

   ```bash
   $ dotnet tool install --global Carp
   ```

3. Check carp is installed

   ```bash
   $ carp --version
   ```

4. It is recommended to use Visual Studio Code with the [Carp Language](https://marketplace.visualstudio.com/items?itemName=MelodiDey17.carp) extension to aide with development



### Hello world

Create a new file, give it the .carp extension, and write the following code:

```carp
import std.io

IO.println('Hello, world!')
```

Now run the file with the Carp interpreter:

```sh
$ carp hello.carp
````

You should see the output `Hello, world!` printed to the console.
Alternatively you can go file-less and use the REPL:

```sh
carp
 : import std.io
 :
 : IO.println('Hello, world!')
````

### Documentation
For more documentation refer to [Docs](https://github.com/Melodi17/Carp/blob/master/DOCS.md)

### Contributing
As the language is still very early, contributions would be very much appricated. Some ideas include; more standard libraries, bugfixes or new features.

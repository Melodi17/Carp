# Carp
[![CodeFactor](https://www.codefactor.io/repository/github/melodi17/carp/badge/master)](https://www.codefactor.io/repository/github/melodi17/carp/overview/master)
[![](https://github.com/Melodi17/Carp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Melodi17/Carp/actions/workflows/dotnet.yml)

> Currently Carp is in early public releases, it may not be the most stable language for large projects, please report any issues through the GitHub issues page.

### What's new in version 1.0.4/5?
These versions were focused on fixing bugs, and adding more support.
- Added `byte_sequence` primitive for storing bytes
- Increased publicity of the methods, allowing for usage as an embedded language
- Unknown resource extensions now default to `byte_sequence`
- Resource extensions supported include text formats: `.txt`, `.json`, `.yaml`, `.dat`, `.xml`
- Fixed initialization of native types with the `.new` method
- Added trigonometric functions to the `std.math` package
- Added support for non-bool values in logical operators (e.g. `'hi' | null` will return the non-null value)
- Added a new method to collections and maps `.get(tkey key, tvalue default)` that returns a default value if the key is not found
- Fixed issues with map set-indexing new values and removing non-existent ones
- Fixed issue when creating empty maps, since it'd assume its a collection

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

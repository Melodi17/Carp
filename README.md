# Carp

[![CodeFactor](https://www.codefactor.io/repository/github/melodi17/carp/badge/master)](https://www.codefactor.io/repository/github/melodi17/carp/overview/master)
[![](https://github.com/Melodi17/Carp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Melodi17/Carp/actions/workflows/dotnet.yml)

> Currently Carp is in early public releases, it may not be the most stable language for large projects, please report
> any issues through the GitHub issues page.

### What's new in version 2.0.0? [...](https://github.com/Melodi17/Carp/blob/master/UPDATES.md)

Carp has been re-written from the ground up, focusing on more clean modelling, smarter syntax, and reliability.

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

4. It is recommended to use Visual Studio Code with
   the [Carp Language](https://marketplace.visualstudio.com/items?itemName=MelodiDey17.carp) extension to aid with
   development

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

As the language is still very early, contributions would be very much appreciated. Some ideas include; more standard
libraries, bugfixes or new features.

# Learning Carp



## Getting started
### Installation

### Hello world
Create a new file, give it the .carp extension, and write the following code:
```carp
import std.io

IO.println('Hello, world!')
```

Now run the file with the Carp interpreter:
```sh
carp hello.carp
````

You should see the output `Hello, world!` printed to the console.
Alternatively you can go file-less and use the REPL:
```sh
carp
 : import std.io
 :
 : IO.println('Hello, world!')
````

## Basics
### The standard library
#### IO
The IO package is responsible for input and output operations in Carp. It contains functions for controlling the connected console.

#### Math
Math is for extended mathematical operations, not included in the base language's operators. It also contains random number generation functions.

#### FS
The FS package is for file system operations, such as reading and writing files.

#### Parse
Parse is a universal package for parsing JSON, XML, HTML and for Regex operations.

#### Net

#### Resource
Resource is for loading and managing external resources (the ones stored in /resources), such as images, sounds, and other files.

#### System

### Projects
Projects are designed for larger codebases, they may contain multiple files, and have resources stored within them. They can later be packaged into `.caaarp` files for distribution and execution.

#### Creating a project
To create a new project, run the following command:
```sh
carp new -n my_project
```
Or you can convert an existing script into a project using:
```sh
carp new -s my_script.carp
```
Optionally the name of the project can be specified with the `-n` flag.

#### Running a project
To run a project, navigate to the project directory and run:
```sh
carp .
```
This will build and run the project. To just build it, use:
```sh
carp build .
```
These will generate a `.caaarp` file in the /export directory, named the projects name suffixed with the current version in the `.carpproj` file.

#### Project structure
A project will have all its scripts in the initial directory, and resources in the /resources directory. The /export directory will contain the generated `.caaarp` files.


## Advanced
### Interpreter flags

### The preprocessor




## Style guide

### Block bodies
The shorthand block body should be used whenever possible (whenever the body is a single expression).
```carp
# Single-line block body
int add(int a, int b) -> a + b

# Multi-line block body
int slowmultiply(int a, int b) {
    int result = 0
    for b -> result = add(result, a)
    return result
}
```


### Naming conventions
Variables and properties are named in snake_case. Classes are named in upper CamelCase.
Methods and functions are lower mergecase.

For example:
```carp
int my_var = 10

void print(str message) -> IO.println(message)

class MyObj {
    void dosomething() -> print('Hello, world!')
}
```

### Comments
Comments must have a space after the # symbol, otherwise the preprocessor will get them confused with a directive.
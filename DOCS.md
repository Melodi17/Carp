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


### Projects



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
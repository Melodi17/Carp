# Learning Carp



## Getting started
### Installation

### Hello world



## Basics
### The standard library



## Advanced
### Interpreter flags




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
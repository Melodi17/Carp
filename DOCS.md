# Learning Carp

This is a reference manual and instruction guide filled with samples and explanations learning Carp.



## Getting started
### Installation

1. Ensure dotnet is installed

2. Run the following to install it from NuGet
   ```bash
   $ dotnet tool install --global carp
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
$ carp
 : import std.io
 :
 : IO.println('Hello, world!')
````



## Basics

### Types

#### Primitive types
```carp
# Strings are only denoted with single quotes
str my_string = 'Hello, world!'

# Booleans are either true or false
bool my_bool = true

# Integers are whole numbers, decimals, and negative numbers
int my_int = 10
int my_decimal_int = -10.5

# Obj is the base type for all objects
obj my_obj = 5

# Null is the absence of a value
obj my_null = null

# Objects are automatically assigned null if not given a value
obj my_auto_null
# value is null

# If the object is a struct though, they will be auto-instatiated
int my_auto_int
# value is 0

# Let implicitly determines the type of the variable based on the value
let my_auto_typed_int = 5
```



#### Compound types

```carp
# Collections are a list of objects, they are denoted with *
int* my_list = [1, 2, 3, 4, 5]

# Maps are a collection of key-value pairs
str:int my_map = [
    'key1': 1,
    'key2': 2,
    'key3': 3
]

# Ranges are a collection between two values
range<int> my_range = 1..10
```



### Comments

Comments are used to annotate code, they are ignored by the interpreter.
```carp
# This is a comment

#(
   This is a multi-line comment
)
```
*Make sure a space is present after the `#` symbol, otherwise the preprocessor will get confused with a directive.*



### Blocks

Blocks are used to group statements together, there are two types of blocks in Carp: the shorthand block and the full block.
```carp
# Shorthand block
int add(int a, int b) -> a + b

# Full block
int add(int a, int b) {
    return a + b
}
```



### Casting and handling types

Casting is used to convert one type to another, and type checking is used to determine the type of an object.
```carp
# Object type coercion, this is implicit type conversion
int my_num = '5'
# value is 5

# Explicit type conversion
int my_num = '5' ~ int
# value is 5

# Type checking
bool is_int = my_num ~~ int
# value is true

# Type storage
type my_type = t('hi')
# value is str
```



### Operators

Operators are used to perform operations on values, such as addition, subtraction, and comparison.
```carp
# Arithmetic operators
int add = 5 + 5
int subtract = 5 - 5
int multiply = 5 * 5
int divide = 5 / 5
int modulo = 5 % 5
int power = 5 ^ 5

# All of these operators can be combined with the assignment operator to modify the value of a variable
int num = 5
num += 5

# Comparison operators
bool equal = 5 == 5

bool not_equal = 5 != 5
# or alternatively
not_equal = 5 <> 5

bool greater_than = 5 > 5
bool less_than = 5 < 5
bool greater_than_or_equal = 5 >= 5
bool less_than_or_equal = 5 <= 5

# Logical operators
bool and = true & false
bool or = true | false

bool not = !true
bool inverse = -num
```



### Control flow

Control flow is used to determine the flow of the program, such as loops and conditionals.
```carp
# If statements
if 5 > 4 -> IO.println('5 is greater than 4')

# If-else statements
if 5 > 4 -> IO.println('5 is greater than 4') 
else -> IO.println('5 is not greater than 4')

# While loops
int i = 0
while i < 5 {
    IO.println(i)
    i += 1
}

# For loops
for i : 0..5 {
    IO.println(i)
}

# The 0..5 can actually be simplified to ..5
# But since for requires a collection, it will even take just 5

# For loops without storing the index
for 0..5 -> IO.println('hi')
```


### Functions and methods

Functions are used to encapsulate code into reusable blocks, they can take arguments and return values.
```carp
# The return type is specified first, or if none, void
int add(int a, int b) -> a + b
void print(str message) -> IO.println(message)

# The arguments and their types are specified in the parentheses
# The block is specified directly after the arguments
```



### Classes and structs

Classes are used to define objects with properties and methods, they can be instantiated and used in the program.
```carp
class MyClass {
    # Properties are defined the same way as variables
    int my_prop

    # Methods are defined in the same way as functions
    void print_prop() -> IO.println(this.my_prop)
    
    # Constructors are used to initialize the object
    void init(int prop) -> this.my_prop = prop
}

# Instantiating a class
MyClass my_obj = MyClass.new(5)

my_obj.print_prop()
```



#### Structs

Structs are similar to classes, but they cannot be null, meaning they must have an empty constructor for implicit instantiation
```carp
struct Vec2 {
    int x
    int y
    
    void init() {
        this.x = 0
        this.y = 0
    }
    
    void init(int x, int y) {
        this.x = x
        this.y = y
    }
    
    str string() -> 'Vec2(' + this.x + ', ' + this.y + ')'
}
```



### The standard library and imports

Imports are used to include external code into the program, such as the standard library or other scripts.
They are controlled by the active package resolver. The `std` prefix is available to access the standard library. The `git` prefix is available to access the git package resolver. Not specifying one of these will search the current active directory or the current package's source.
```carp
# Standard library import
import std.io

# Github import
import git.username.repo

# Local import
import utils
```



#### IO
The IO package is responsible for input and output operations in Carp. It contains functions for controlling the connected console.

<details>



</details>

#### Math
Math is for extended mathematical operations, not included in the base language's operators. It also contains random number generation functions.

#### FS
The FS package is for file system operations, such as reading and writing files.

#### Parse
Parse is a universal package for parsing JSON, XML, HTML and for Regex operations.

#### Net
Net is for network operations, such as HTTP requests.

#### Resource
Resource is for loading and managing external resources (the ones stored in /resources), such as text files.

#### System
System is for system operations, such as executing shell commands.


### Projects
Projects are designed for larger codebases, they may contain multiple files, and have resources stored within them. They can later be packaged into `.caaarp` files for distribution and execution.


#### Creating a project

To create a new project, run the following command:
```sh
$ carp new -n my_project
```
Or you can convert an existing script into a project using:
```sh
$ carp new -s my_script.carp
```
Optionally the name of the project can be specified with the `-n` flag.



#### Running a project

To run a project, navigate to the project directory and run:
```sh
$ carp .
```
This will build and run the project. To just build it, use:
```sh
$ carp build .
```
These will generate a `.caaarp` file in the /export directory, named the projects name suffixed with the current version in the `.carpproj` file.



#### Project structure

A project will have all its scripts in the initial directory, and resources in the /resources directory. The /export directory will contain the generated `.caaarp` files.



#### Project configuration

The project configuration is stored in a `.carpproj` file in the project directory. It contains the project name, version, and other metadata.



## Advanced

### Interpreter flags

### The preprocessor

### Directives




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

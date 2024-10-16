﻿# Learning Carp
> Reference manual and instruction guide for Carp
> 
> _Version `1.0.6` for Carp `1.0.5`_

This is a reference manual and instruction guide filled with samples and explanations learning Carp.

## Outline
- [Learning Carp](#learning-carp)
   * [Getting started](#getting-started)
      + [Installation](#installation)
      + [Hello world](#hello-world)
   * [Basics](#basics)
      + [Types](#types)
         - [Primitive types](#primitive-types)
         - [Compound types](#compound-types)
         - [Type behaviours](#type-behaviours)
            * [Object `obj`](#object--obj-)
            * [String `str`](#string--str-)
            * [Character `chr`](#character--chr-)
            * [Integer `int`](#integer--int-)
            * [Boolean `bool`](#boolean--bool-)
            * [Function `func`](#function--func-)
            * [Collection `obj*`](#collection--obj--)
            * [Map `obj:obj`](#map--obj-obj-)
            * [Range `range`](#range--range-)
            * [Type `type`](#type--type-)
      + [Comments](#comments)
      + [Blocks](#blocks)
      + [Casting and handling types](#casting-and-handling-types)
      + [Operators](#operators)
      + [Control flow](#control-flow)
      + [Functions and methods](#functions-and-methods)
      + [Classes and structs](#classes-and-structs)
         - [Structs](#structs)
      + [Shortcuts](#shortcuts)
      + [The standard library and imports](#the-standard-library-and-imports)
         - [IO](#io)
         - [Math](#math)
         - [FS](#fs)
         - [Parse](#parse)
         - [Net](#net)
         - [Resource](#resource)
         - [System](#system)
      + [Projects](#projects)
         - [Creating a project](#creating-a-project)
         - [Running a project](#running-a-project)
         - [Project structure](#project-structure)
         - [Project configuration](#project-configuration)
   * [Advanced](#advanced)
      + [Interpreter flags](#interpreter-flags)
      + [The preprocessor](#the-preprocessor)
      + [Directives](#directives)
         - [Include](#include)
         - [Define](#define)
   * [Style guide](#style-guide)
      + [Block bodies](#block-bodies)
      + [Naming conventions](#naming-conventions)


## Getting started
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

#### Type behaviours

##### Object `obj`
This is the base object of everything.

##### String `str`
Strings are immutable, meaning they cannot be changed after they are created. They are represented by surrounding the text value with single quotes `'hello world'`. Unlike other languages, double quotes are **not** permitted. They can use backslashes to escape a quote character or another backslash.

Casting:
- From any type to `str` will perform override `.string` on it
- `int` Converts the string into an integer
- `chr` Converts the string into a character, using the first character only
- `bool` Converts the string into a boolean, comparing it to 'true' and 'false'

Properties:
- `.length` `int` Calculates the length of the string
- `.lower` `str` Converts the string to lowercase
- `.upper` `str` Converts the string to uppercase
- `.clean` `str` Removes leading and trailing whitespace
- `.split(str delimiter)` `str*` Splits the string into an array of strings based on a delimiter
- `.replace(str source, str replacement)` `str` Replaces all occurrences of a substring with another substring
- `.contains(str search)` `bool` Checks if the string contains a substring
- `.startswith(str prefix)` `bool` Checks if the string starts with a substring
- `.endswith(str suffix)` `bool` Checks if the string ends with a substring
- `.encode(str encoding)` `byte_sequence` Encodes a string to a byte array using the specified encoding. Encoding can be any of the following: `utf8`, `utf32`, `unicode`, `bigendianunicode`, `latin`, `ascii`

Overrides:
- `iterate` String overrides the iterate method to allow enumeration of each character in the string
- `add` String overrides the add method to concatenate two strings
- `multiply` String overrides the multiply method to repeat the string a specified number of times
- `divide` String overrides the divide method to split the string into a collection of strings based on a delimiter, which can be a `str` or a `chr`
- `index` String overrides the index method to get the character at a specified index, if a range is passed, it will return a substring based on that range

##### Character `chr`
Characters are represented by using a backtick and then a single character `\`a` .

Casting:
- `int` Converts the character into an integer

Properties:
- `.lower` `chr` Converts the character to lowercase
- `.upper` `chr` Converts the character to uppercase
- `.is_upper` `bool` Checks if the character is uppercase
- `.is_lower` `bool` Checks if the character is lowercase
- `.is_digit` `bool` Checks if the character is a digit
- `.is_alpha` `bool` Checks if the character is a letter
- `.is_symbol` `bool` Checks if the character is a symbol
- `.is_whitespace` `bool` Checks if the character is whitespace
- `.is_upper` `bool` Checks if the character is uppercase
- `.is_lower` `bool` Checks if the character is lowercase

##### Integer `int`
Integers are whole numbers, decimals, and negative numbers. They are represented by a number, and can be negative or decimal. They can be used in mathematical operations, and are represented by `5`, `-5`, `5.5`. They are a `struct` type which means they default to 0 instead of null.

Casting:
- `chr` Converts the integer into a character

Overrides:
- `add` Integer overrides the add method to add two integers
- `subtract` Integer overrides the subtract method to subtract two integers
- `multiply` Integer overrides the multiply method to multiply two integers
- `divide` Integer overrides the divide method to divide two integers
- `modulo` Integer overrides the modulo method to get the remainder of two integers
- `pow` Integer overrides the power method to raise the integer to the power of another integer
- `greater` Integer overrides the greater method to check if the integer is greater than another integer
- `less` Integer overrides the less method to check if the integer is less than another integer
- `negate` Integer overrides the negate method to get the inverse of the integer
- `step` Integer overrides the step method to get the current integer plus 1
- `iterate` Iterator from 0 to the integer

##### Boolean `bool`
Booleans are either true or false. They are represented by `true` or `false`. They can be used in logical operations, and are a `struct` type which means they default to `false` instead of null.

Overrides:
- `not` Boolean overrides the not method to get the inverse of the boolean

##### Function `func`
Functions are a type of object that can be called. They are represented by `func<treturn>` where the generic type is the return type of the function. They can be called by using the `()` operator.

Overrides:
- `call` Function overrides the call method to execute the body of the function

##### Collection `obj*`
Collections are a list of objects, they are represented by `[obj0, obj1, obj2]`. They can be accessed by index, and can be iterated over. When a collection is not supplied with a type, it will default to the highest common type, if one exists, else `obj*`

Casting:
- `tvalue*` Converts the collection into a new collection, if it the item's type extends the sub_type

Properties:
- `.length` `int` Calculates the length of the collection
- `.first` `tvalue` Gets the first item in the collection
- `.last` `tvalue` Gets the last item in the collection
- `.append(tvalue item)` `void` Appends an item to the end of the collection
- `.remove(tvalue item)` `void` Removes an item from the collection
- `.removeat(int index)` `void` Removes an item from the collection at a specified index
- `.insert(int index, tvalue item)` `void` Inserts an item into the collection at a specified index
- `.contains(tvalue item)` `bool` Checks if the collection contains an item
- `.within(int index)` `bool` Checks if the index is within the bounds of the collection
- `.clear()` `void` Clears the collection
- `.get(int index, tvalue default)` `tvalue` Gets the item at a specified index, if a range is passed, it will return a sub-collection based on that range

Overrides:
- `add` Collection overrides the add method allow merging two collections of the same type
- `iterate` Collection overrides the iterate method to allow enumeration of each item in the collection
- `index` Collection overrides the index method to get the item at a specified index, if a range is passed, it will return a sub-collection based on that range

##### Map `obj:obj`
Maps are a collection of key-value pairs, they are represented by `['key0': value0, 'key1': value1]`. They can be accessed by key, and can be iterated over. It uses the same high common type rule as collections, if no type is supplied.

Properties:
- `.length` `int` Calculates the length of the map
- `.keys` `tkey*` Gets all the keys in the map
- `.values` `tvalue*` Gets all the values in the map
- `.remove(tkey key)` `void` Removes an item from the map
- `.contains(tkey key)` `bool` Checks if the map contains a key
- `.clear()` `void` Clears the map
- `.get(tkey key, tvalue default)` `tvalue` Gets the value at a specified key, if the key is not found, it will return the default value

##### Range `range`
Ranges are represented as `start..end`, they must be the same type and the object must override `Less`, `Subtract` and `Step`. As a generic type, their type is referenced as `range<tvalue>`

Casting:
- `tvalue*` Converts range into a collection of type

Properties:
- `.length` `int` Calculates length of range based on `end` - `start`
- `.start` `tvalue` Start of range
- `.end` `tvalue` End of range

Overrides:
- `iterate` Range overrides the iterate method to allow enumeration between the start and the end points


##### Type `type`
Types are used to store the type of an object, they are represented by `t(obj)`. They can be used to check the type of an object, and can be used in casting.

Casting:
- From any type to `type` will return the type of the object

Properties:
- `.name` `str` Gets the name of the type
- `.base` `type` Gets the base type of the type
- `.is_struct` `bool` Checks if the type is a struct


##### Byte Sequence `byte_sequence`
Byte sequences are a collection of bytes. They have no representation in the language, but can be used to store binary data. Any resources of an unknown type will default to a byte sequence.

Properties:
- `.length` `int` Calculates the length of the byte sequence
- `.decode(str encoding)` `str` Decodes the byte sequence into a string of specified encoding type which can be any of the following: `utf8`, `utf32`, `unicode`, `bigendianunicode`, `latin`, `ascii`

Overrides:
- `index` Byte Sequence overrides the index method to get the byte at a specified index, if a range is passed, it will return a sub-sequence based on that range. Note that the byte returned will be in the form of an integer, not a character.

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
type my_type = 'hi' ~ type
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

# Note that logical operators work on not only booleans, but also other objects,
# Where it will compare them with null (null being false and anything else being true)
# For example, null | 5 will return 5, as null is falsey
str value = null | 'hi'
# value is 'hi'

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
    # Also! You can have multiple constructors with different arguments
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

#### Overriding
Classes and structs can override special methods to change how operators and other operations work on them. The following methods can be overridden:
- `init` `void` - Constructor, this is called when the object is created, you can have multiple constructors with different arguments
- `string` `str` - String representation of the object, casting to a string or using `IO.println` will call this method
- `property(str prop)` `obj` - Gets a property of the object, this is called when using the `.` operator
- `setproperty(str prop, obj value)` `obj` - Sets a property of the object, this is called when assigning to a `.` property
- `call(obj* args)` `obj` - Calls the object as a function, this is called when using the `()` operator
- `index(obj index)` `obj` - Gets an index of the object, this is called when using the `[]` operator
- `setindex(obj index, obj value)` `obj` - Sets an index of the object, this is called when assigning to a `[]` index
- `add(obj value)` `obj` - Adds a value to the object, this is called when using the `+` operator
- `subtract(obj value)` `obj` - Subtracts a value from the object, this is called when using the `-` operator
- `multiply(obj value)` `obj` - Multiplies the object by a value, this is called when using the `*` operator
- `divide(obj value)` `obj` - Divides the object by a value, this is called when using the `/` operator
- `modulus(obj value)` `obj` - Gets the remainder of the object divided by a value, this is called when using the `%` operator
- `less(obj value)` `bool` - Checks if the object is less than a value, this is called when using the `<` operator
- `greater(obj value)` `bool` - Checks if the object is greater than a value, this is called when using the `>` operator
- `pow(obj value)` `obj` - Raises the object to the power of a value, this is called when using the `^` operator
- `match(obj value)` `bool` - Checks if the object matches a value, a default implementation exists for this, this is called when using the `==` operator
- `step()` `obj` - Gets the next value of the object, this is used in `range` objects and can be used for iteration
- `negate()` `obj` - Gets the inverse of the object, this is called when using the `-` operator
- `iterate()` `obj*` - Gets an iterator for the object, this is called when using the `for` loop or a winded expression



### Shortcuts
Winding and filtering allow applying an operation to a sequence of values. As of the current version, filtering is not supported, but uses the `;;` operator. Winding can be done using the `::` operator.
```carp
int nums = [1, 2, 3, 4, 5]
# this can actually be done using int* nums = 1..6
# or 1..6 ~ int* if type coercion is disabled

int new_nums = nums :: * 10
# value will be [10, 20, 30, 40, 50]
```
The winding operator `::` converts a collection into a "winded" object where all operations applied to it, will be applied to all items. This includes operators and properties, note that only one operation can be applied per wind.
```carp
str* names = ['John', 'Jane', 'Francis', 'Joe']

str* lower_names = names :: .lower
# value is ['john', 'jane', 'francis', 'joe']
```
As of the latest version, `bool` operators cannot be used with winded expressions and produce a collection, instead they will produce a single value, based on whether they all matched `true`.



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
<summary>Reference</summary>

```carp
void println(obj str)
```
> Writes a line to the output.

---

```carp
void printw(obj str)
```
> Writes a string to the output, without a newline.

---

```carp
str readln(obj str)
```
> Reads a line from the input.

---

```carp
chr readw(bool hideKeyStrokes)
```
> Reads a character from the input.

---

```carp
void clear()
```
> Clears the output.

---

```carp
void move(int x, int y)
```
> Move the cursor to the specified position.

</details>

#### Math
Math is for extended mathematical operations, not included in the base language's operators. It also contains random number generation functions.

<details>

<summary>Reference</summary>

```carp
int random(int min, int max)
```
> Generates a random integer within the specified range.

---

```carp
bool chance(int chance)
```
> Determines if a random event occurs based on the specified chance.

---

```carp
void wait(int ms)
```
> Pauses the execution of the current thread for the specified amount of time.

---

```carp
int abs(int num)
```
> Returns the absolute value of the specified number.

---

```carp
int ceil(int num)
```
> Rounds the specified number up to the nearest integer.

---

```carp
int floor(int num)
```
> Rounds the specified number down to the nearest integer.

---

```carp
int round(int num)
```
> Rounds the specified number to the nearest integer.

---

```carp
int max(int a, int b)
```
> Returns the larger of two specified numbers.

---

```carp
int min(int a, int b)
```
> Returns the smaller of two specified numbers.

---

```carp
int clamp(int num, int min, int max)
```
> Clamps a number to a specified range.

---

```carp
int sqrt(int num)
```
> Calculates the square root of a specified number.

---

```carp
int pow(int num, int pow)
```
> Raises a specified number to the power of another specified number.

---

```carp
int sin(int num)
```
> The sine of a specified number.

---

```carp
int cos(int num)
```
> The cosine of a specified number.

---

```carp
int tan(int num)
```
> The tangent of a specified number.

---

```carp
int asin(int num)
```
> The arcsine of a specified number.

---

```carp
int acos(int num)
```
> The arccosine of a specified number.

---

```carp
int atan(int num)
```
> The arctangent of a specified number.

---

```carp
int linearinterpolation(int a, int b, int t)
```
> Linearly interpolates between two values based on a specified index (t).

</details>

#### FS
The FS package is for file system operations, such as reading and writing files.

<details>

<summary>Reference</summary>

```carp
str readfile(str path)
```
> Reads the content of a file at the given path.

---

```carp
str* readfilelines(str path)
```
> Reads all lines from a file at the given path.

---

```carp
void writefile(str path, str cont)
```
> Writes the specified content to a file at the given path.

---

```carp
void writefilelines(str path, str* cont)
```
> Writes the specified lines to a file at the given path.

---

```carp
bool exists(str path)
```
> Checks if a file or directory exists at the given path.

---

```carp
void delete(str path)
```
> Deletes a file at the given path.

---

```carp
void createdir(str path)
```
> Creates a directory at the given path.

---

```carp
void deletedir(str path)
```
> Deletes a directory at the given path.

---

```carp
str* listdir(str path)
```
> Lists all files in a directory at the given path.

---

```carp
str* listdirs(str path)
```
> Lists all directories in a directory at the given path.

</details>

#### Parse
Parse is a universal package for parsing JSON, XML, HTML and for Regex operations.

<details>

<summary>Reference</summary>

```carp
obj Json.loadjson(str json)
```
> Loads a JSON string and converts it into a Carp object.

---

```carp
MatchResult Regex.match(str pattern, str text)
```
> Converts a dynamic object into a Carp object.

---

```carp
MatchResult* Regex.matches(str pattern, str text)
```
> Matches a regular expression pattern against a text and returns all matches.

---

```carp
str Regex.replace(str pattern, str text, str replacement)
```
> Replaces all occurrences of a regular expression pattern in a text with a replacement string.

---

```carp
str* Regex.split(str pattern, str text)
```
> Splits a text into an array of strings based on a regular expression pattern.

---

```carp
bool Regex.test(str pattern, str text)
```
> Tests if a regular expression pattern matches a text.

</details>

#### Net
Net is for network operations, such as HTTP requests.

<details>

<summary>Reference</summary>

```carp
str Http.get(str url)
```
> Makes a GET request to the specified URL.

---

```carp
str Http.post(str url, str content)
```
> Makes a POST request to the specified URL with the specified content.

---

</details>

#### Resource
Resource is for loading and managing external resources (the ones stored in /resources), such as text files.

<details>

<summary>Reference</summary>

```carp
obj load(str name)
```
> Loads a resource with the specified name.

---

```carp
obj list()
```
> Lists all the resources in the package.

</details>

#### System
System is for system operations, such as executing shell commands.

<details>

<summary>Reference</summary>

```carp
str runcommand(str command)
```
> Executes a command in the command prompt and returns the output.

---

```carp
str username
```
> Gets the username of the current user.

---

```carp
str machine_name
```
> Gets the name of the machine.

---

```carp
str os_version
```
> Gets the version of the operating system.

---

```carp
int processor_count
```
> Gets the number of processors on the current machine.

</details>

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

```python
  -i, --interactive        Start the Carp REPL after executing the script.

  -c, --line               Execute the Carp code provided in the command line.

  -v, --verbose            (Default: true) Print the result of the script execution to the console.

  -d, --debug              Start the Carp debugger.

  -f, --force-throw        Force the internal errors to trigger the native stacktrace.

  --strict-warnings        Treat warnings as errors

  --default-non-structs    (Default: true) Allow non-struct objects to be auto-initialized

  --implicit-casts         (Default: true) Enable implicit casting/type coercion

  --help                   Display this help screen.

  --version                Display version information.

  Path (pos. 0)            The path to the script, project or package to run.
```


### The preprocessor

The preprocessor is responsible for formatting the input code for the lexer and parser. It adds support for directives, strips comments, re-writes imports and can be expanded in the future to do even more.

### Directives

#### Include
The include directive, directly includes the specified file path in the current file. Note that this is not package-safe and will only use the current directory as a source, which makes it helpful for the REPL. It will also be preprocessed before being injected.
```carp 
#include header.carp
```

#### Define
Define allows you to create macros, which are similar to methods except they directly replace tokens and their arguments with the body. Brackets can be used to allow it to span multiple lines
```carp
#define add(a, b) = (
    a + b
)

int sum = add(1, 2)
# This will be replaced with 1 + 2
```
It can also be used for things such as constants, as it does not need to take parameters
```carp
#define my_const = 25.5

my_const
# Replaced with 25.5
```


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

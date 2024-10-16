# Carp Updates
> Includes latest, and historical update notes for Carp

### What's new in version 1.0.6?
This version was based on making the language more debuggable and fixing some small issues.
- Added scope patch that allows methods to use the return type of their contained class/struct
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
- Added support for all behaviour overrides in user-defined types
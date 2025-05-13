namespace Carp.exceptions.impl;

public class ReferenceDoesNotExistException(string name) : InterpreterException(
    $"Reference '{name}' does not exist in the current context.");
namespace Carp.exceptions.impl;

public class ReferenceAlreadyDefinedException(string name) : InterpreterException(
    $"Reference '{name}' already exists in the current context.");
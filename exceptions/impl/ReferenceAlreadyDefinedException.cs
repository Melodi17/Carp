namespace Carp.exceptions.impl;

public class ReferenceAlreadyDefinedException(string name) : RuntimeException(
    $"Reference '{name}' already exists in the current context.");
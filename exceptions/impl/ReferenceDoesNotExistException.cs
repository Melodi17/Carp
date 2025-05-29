namespace Carp.exceptions.impl;

public class ReferenceDoesNotExistException(string name) : RuntimeException(
    $"Reference '{name}' does not exist in the current context.");
namespace Carp.exceptions.impl;

public class IllegalArgumentsException(string message)
    : RuntimeException($"Illegal arguments: {message}");
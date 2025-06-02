namespace Carp.exceptions.impl;

public class IllegalOperationException(string message)
    : RuntimeException(message);
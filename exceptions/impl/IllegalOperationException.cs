namespace Carp.exceptions.impl;

using objects.typing;

public class IllegalOperationException(string message) : RuntimeException(message);
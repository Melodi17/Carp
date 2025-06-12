namespace Carp.exceptions.impl;

using objects;
using objects.typing;

public class IllegalInstantiationException(CarpType type, string reason) : RuntimeException(
    $"Cannot instantiate type '{type.Name}', {reason}");
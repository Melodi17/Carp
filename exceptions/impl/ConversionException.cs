namespace Carp.exceptions.impl;

using objects.typing;

public class ConversionException(CarpType from, CarpType to)
    : RuntimeException($"{from} does not match type constraint of {to}.");
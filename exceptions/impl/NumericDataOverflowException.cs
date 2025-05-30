namespace Carp.exceptions.impl;

using objects.typing;

public class NumericDataOverflowException(string value, CarpType type)
    : RuntimeException($"Numeric value '{value}' exceeds the limits of {type}");
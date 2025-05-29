using Carp.objects.typing;

namespace Carp.exceptions.impl;

public class NumericDataOverflowException(string value, CarpType type) : RuntimeException(
    $"Numeric value '{value}' exceeds the limits of {type}");
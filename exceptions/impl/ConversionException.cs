using Carp.objects.typing;

namespace Carp.exceptions.impl;

public class ConversionException(CarpType from, CarpType to) : RuntimeException(
    $"{from} does not match type constraint of {to}.");
using Carp.objects;

namespace Carp.exceptions.impl;

public class PrimitiveIncompatibleException(string primitive, CarpObject obj) : RuntimeException(
    $"Primitive '{primitive}' is not compatible with {obj.GetCarpType()} object: {obj.Repr()}");
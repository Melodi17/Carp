using Carp.objects;

namespace Carp.exceptions;

public class PrimitiveIncompatibleException(string primitive, CarpObject obj) : Exception(
    $"Primitive '{primitive}' is not compatible with {obj.Type} object: {obj.Repr()}");
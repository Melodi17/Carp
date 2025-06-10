namespace Carp.exceptions.impl;

using objects;
using objects.typing;

public class BoundsExceededException(CarpObject obj, CarpObject[] bounds)
    : RuntimeException(
        $"Bounds exceeded for object {obj} with bounds [{string.Join(", ", bounds.Select(x => x.Repr()))}]");
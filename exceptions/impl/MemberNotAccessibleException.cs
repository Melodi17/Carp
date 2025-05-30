namespace Carp.exceptions.impl;

using objects;

public class MemberNotAccessibleException(CarpObject obj, string memberName)
    : RuntimeException($"Member '{memberName}' is not accessible in {obj.Repr()}");
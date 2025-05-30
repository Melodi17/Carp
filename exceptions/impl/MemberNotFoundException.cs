namespace Carp.exceptions.impl;

using objects;

public class MemberNotFoundException(CarpObject obj, string memberName)
    : RuntimeException($"Member '{memberName}' not found in {obj.Repr()}");
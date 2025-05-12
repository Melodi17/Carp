using Carp.objects;

namespace Carp.exceptions.impl;

public class MemberNotFoundException(CarpObject obj, string memberName) : RuntimeException(
    $"Member '{memberName}' not found in {obj.Repr()}");
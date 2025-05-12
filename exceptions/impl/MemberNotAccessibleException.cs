using Carp.objects;

namespace Carp.exceptions.impl;

public class MemberNotAccessibleException(CarpObject obj, string memberName) : RuntimeException(
    $"Member '{memberName}' is not accessible in {obj.Repr()}");
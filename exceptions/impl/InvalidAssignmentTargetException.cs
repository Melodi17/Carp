namespace Carp.exceptions.impl;

public class InvalidAssignmentTargetException(string reason)
    : RuntimeException($"Invalid assignment target, {reason}");
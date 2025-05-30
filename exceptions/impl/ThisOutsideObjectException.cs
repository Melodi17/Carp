namespace Carp.exceptions.impl;

public class ThisOutsideObjectException()
    : RuntimeException("Cannot access 'this' outside of an object context");
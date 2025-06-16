namespace Carp.exceptions.impl;

public class LibraryNotFoundException(string[] path)
    : RuntimeException($"Library not found at '{string.Join(".", path)}'. ");
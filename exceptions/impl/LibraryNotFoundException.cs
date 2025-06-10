namespace Carp.exceptions.impl;

using System.Reflection;
using objects;
using objects.typing;

public class LibraryNotFoundException(string[] path) 
    : RuntimeException($"Library not found at '{string.Join(".", path)}'. ");
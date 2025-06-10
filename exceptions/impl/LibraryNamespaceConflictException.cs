namespace Carp.exceptions.impl;

using System.Reflection;
using objects;
using objects.typing;

public class LibraryNamespaceConflictException(string ns, Assembly existingType, Assembly newType) 
    : RuntimeException($"Namespace '{ns}' already contains types from assembly '{existingType.GetName().Name}', " +
                       $"but '{newType.GetName().Name}' is trying to add types to it. " +
                       "Please ensure that the namespace is unique across all libraries.");
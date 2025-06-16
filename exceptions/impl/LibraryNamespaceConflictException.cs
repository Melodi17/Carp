namespace Carp.exceptions.impl;

using toolkit.dependency;

public class LibraryNamespaceConflictException(string ns, IModule existingType, IModule newType)
    : RuntimeException($"Namespace '{ns}' already contains modules from library '{existingType.Library.Name}', "
                       + $"but '{newType.Library.Name}' is trying to add modules to it. "
                       + "Please ensure that the namespace is unique across all libraries.");
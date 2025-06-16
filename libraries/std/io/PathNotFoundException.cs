namespace Carp.libraries.std.io;

using exceptions;

public class PathNotFoundException(string path)
    : RuntimeException($"Path '{path}' not found.");
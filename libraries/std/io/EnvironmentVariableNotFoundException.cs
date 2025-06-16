namespace Carp.libraries.std.io;

using exceptions;

public class EnvironmentVariableNotFoundException(string key)
    : RuntimeException($"Environment variable '{key}' not found.");
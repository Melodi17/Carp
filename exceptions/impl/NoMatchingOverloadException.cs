using Carp.objects;

namespace Carp.exceptions.impl;

public class NoMatchingOverloadException(string methodName, CarpObject[] args)
    : RuntimeException(
        $"No matching overload for method '{methodName}' with arguments: " +
        $"<{string.Join(", ", args.Select(a => a.GetCarpType().Name))}>");
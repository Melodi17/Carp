using Carp.package.packages;
using Carp.package.resolvers;

namespace Carp.package;

public interface IPackageResolver
{
    public Package GetPackage(CarpInterpreter interpreter, string[] fullPath, string[] path, string version);
}

public static class PackageResolverExtensions
{
    public static Package GetPackageEx(this IPackageResolver resolver, CarpInterpreter interpreter, string[] fullPath, string[] path,
        string version)
    {
        // check cache
        string cachePath = Path.Join(LocalPackageResolver.CachePackagesPath, string.Join(".", fullPath));
        if (File.Exists(cachePath))
        {
            return Path.GetExtension(cachePath) switch
            {
                ".carp" => new SourcePackage(resolver, interpreter.PackageResolver, fullPath[^1], File.ReadAllText(cachePath)),
                ".caaarp" => new PackedPackage(resolver, interpreter.PackageResolver, fullPath[^1], File.ReadAllBytes(cachePath)),
                _ => throw new CarpError.PackageNotFound(fullPath, version)
            };
        }
        
        Package package = resolver.GetPackage(interpreter, fullPath, path, version);
        return package;
    }
}
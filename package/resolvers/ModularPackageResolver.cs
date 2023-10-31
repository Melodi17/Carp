namespace Carp.package.resolvers;

public class ModularPackageResolver : IPackageResolver
{
    private readonly Dictionary<string, IPackageResolver> _children = new();
    private IPackageResolver _defaultResolver;

    public void AddResolver(string key, IPackageResolver resolver)
    {
        this._children[key] = resolver;
    }

    public void SetDefaultResolver(IPackageResolver resolver)
    {
        this._defaultResolver = resolver;
    }
    
    public Package GetPackage(string path, string version = "latest")
    {
        foreach ((string key, IPackageResolver value) in this._children)
        {
            if (path.StartsWith(key))
                return value.GetPackage(path[key.Length..].TrimStart('.'), version);
        }

        if (this._defaultResolver != null)
            return this._defaultResolver.GetPackage(path);

        throw new CarpError.PackageNotFound(path, version);
    }
}
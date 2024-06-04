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
    
    public Package GetPackage(CarpInterpreter interpreter, string[] fullPath, string[] path, string version)
    {
        foreach ((string key, IPackageResolver value) in this._children)
        {
            if (path[0] == key)
                return value.GetPackageEx(interpreter, fullPath, path[1..], version);
        }

        if (this._defaultResolver != null)
            return this._defaultResolver.GetPackageEx(interpreter, fullPath, path, version);

        throw new CarpError.PackageNotFound(fullPath, version);
    }
}
﻿namespace Carp.package.resolvers;

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
    
    public Package GetPackage(string[] fullPath, string[] path, string version = "latest")
    {
        foreach ((string key, IPackageResolver value) in this._children)
        {
            if (path[0] == key)
                return value.GetPackage(fullPath, path[1..], version);
        }

        if (this._defaultResolver != null)
            return this._defaultResolver.GetPackage(fullPath, path);

        throw new CarpError.PackageNotFound(fullPath, version);
    }
}
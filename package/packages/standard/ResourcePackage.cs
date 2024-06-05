using Carp.objects.types;

namespace Carp.package.packages.standard;

public class ResourcePackage(IPackageResolver source, Dictionary<string, CarpObject> resourceCollection)
    : EmbeddedPackage(source, "Resource")
{
    private readonly Dictionary<string, CarpObject> _resourceCollection = resourceCollection;

    /// <summary>
    /// Loads a resource with the specified name.
    /// </summary>
    /// <param name="name">The name of the resource to load.</param>
    /// <returns>The loaded resource object.</returns>
    /// <exception cref="ResourceNotFound">Thrown when the resource with the specified name is not found.</exception>
    [PackageMember]
    public CarpObject Load(CarpString name)
    {
        if (this._resourceCollection.TryGetValue(name.Native, out CarpObject? resource))
            return resource;

        throw new ResourceNotFound(name);
    }

    /// <summary>
    /// Lists all the resources in the package.
    /// </summary>
    /// <returns>A collection of the names of all resources in the package.</returns>
    [PackageMember]
    public CarpObject List()
    {
        return new CarpCollection(CarpString.Type,
            this._resourceCollection.Keys.Select(x => new CarpString(x)).ToArray());
    }

    public class ResourceNotFound(CarpString resource)
        : CarpError($"Resource '{resource.Native}' not found in package");
}
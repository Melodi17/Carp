using Carp.objects.types;

namespace Carp.package.packages.standard;

public class ResourcePackage(IPackageResolver source, Dictionary<string, CarpObject> resourceCollection) : EmbeddedPackage(source, "Resource")
{
    private readonly Dictionary<string, CarpObject> _resourceCollection = resourceCollection;
    
    [PackageMember]
    public CarpObject Load(CarpString name)
    {
        if (this._resourceCollection.TryGetValue(name.Native, out CarpObject? resource))
            return resource;
        
        throw new ResourceNotFound(name);
    }
    
    [PackageMember]
    public CarpObject List()
    {
        return new CarpCollection(CarpString.Type, this._resourceCollection.Keys.Select(x => new CarpString(x)).ToArray());
    }

    public class ResourceNotFound(CarpString resource) : CarpError($"Resource '{resource.Native}' not found in package");
}
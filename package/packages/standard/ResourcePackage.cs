using Carp.objects.types;

namespace Carp.package.packages.standard;

public class ResourcePackage(IPackageResolver source) : EmbeddedPackage(source, "Resource")
{
    [PackageMember]
    public CarpObject GetResource(CarpString name)
    {
        if (this.Interpreter.Resources.TryGetValue(name.Native, out CarpObject? resource))
            return resource;
        
        throw new ResourceNotFound(name);
    }

    public class ResourceNotFound(CarpString resource) : CarpError($"Resource '{resource.Native}' not found in package");
}
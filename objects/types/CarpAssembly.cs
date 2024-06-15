using System.Reflection;
using Carp.interpreter;
using Carp.package;
using Carp.package.packages;

namespace Carp.objects.types;

public class CarpAssembly : CarpObject, IPackageResolver
{
    public static CarpType Type = NativeType.Of<CarpAssembly>("assembly");
    public override CarpType GetCarpType() => Type;
    
    private readonly Assembly _assembly;
    public string Name => this._assembly.GetName().FullName.ToSnakeCase();
    private readonly Dictionary<string, Type> _types;
    
    public CarpAssembly(byte[] assembly)
    {
        this._assembly = Assembly.Load(assembly);
        this._types = this._assembly.GetExportedTypes()
            .Where(x => x.IsSubclassOf(typeof(EmbeddedPackage)) 
                        && x.GetCustomAttribute<PackageAttribute>() != null)
            .ToDictionary(x => x.GetCustomAttribute<PackageAttribute>()!.Name, x => x);
    }

    public override CarpString String() => new($"assembly({this._assembly.FullName})");
    
    public override CarpObject Property(Signature signature)
    {
        return signature.Name switch
        {
            "name" => new CarpString(this.Name),
            _ => throw new CarpError.InvalidProperty(signature),
        };
    }

    public override CarpBool Match(CarpObject other)
    {
        if (other is not CarpAssembly ca)
            throw new CarpError.InvalidType(CarpAssembly.Type, other.GetCarpType());

        return CarpBool.Of(this._assembly == ca._assembly);
    }

    public Package GetPackage(CarpInterpreter interpreter, string[] fullPath, string[] path, string version)
    {
        string j = string.Join(".", path);
        
        if (!_types.TryGetValue(j, out Type? value))
            throw new CarpError.PackageNotFound(fullPath, version);
        
        return (Package) Activator.CreateInstance(value)!;
    }
}
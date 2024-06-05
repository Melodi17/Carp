using System.Reflection;
using Carp.interpreter;
using Carp.objects.types;
using Carp.package.resolvers;

namespace Carp.package.packages;

/// <summary>
/// These are packages that allow an interface between the Carp language and C# code
/// </summary>
public abstract class EmbeddedPackage : Package
{
    public CarpInterpreter Interpreter;
    public EmbeddedPackage(IPackageResolver source, string name) : base(source, source,
        name)
    {
    }

    public override CarpStatic Export(CarpInterpreter interpreter)
    {
        this.Interpreter = interpreter;
        
        CarpStatic cs = new(this.Name);

        // Fetch all fields of this class, with a PackageMemberAttribute
        Dictionary<string, CarpObject> flattened = new();

        foreach (FieldInfo field in this.GetType().GetFields()
                     .Where(x => x.GetCustomAttribute<PackageMemberAttribute>() != null))
        {
            PackageMemberAttribute att = field.GetCustomAttribute<PackageMemberAttribute>()!;
            string name = att.Name ?? Formatting.FormatProperty(field.Name); // Use the attribute name if it exists, otherwise use the field name
            if (name.EndsWith('.')) name += Formatting.FormatProperty(field.Name);

            // Get the value of the field
            object value = field.GetValue(this);
            if (value is not CarpObject carpValue)
                throw new("Package member must be of type CarpObject");

            flattened.Add(name, carpValue);
        }

        // Fetch all methods of this class, with a PackageMemberAttribute
        foreach (MethodInfo method in this.GetType().GetMethods()
                     .Where(x => x.GetCustomAttribute<PackageMemberAttribute>() != null))
        {
            PackageMemberAttribute att = method.GetCustomAttribute<PackageMemberAttribute>()!;
            string name = att.Name ?? Formatting.FormatMethod(method.Name); // Use the attribute name if it exists, otherwise use the method name
            if (name.EndsWith('.')) name += Formatting.FormatMethod(method.Name);

            // Add the method to the CarpStatic object
            CarpType type = method.ReturnType == typeof(void) ? CarpVoid.Type : NativeType.Find(method.ReturnType);

            Delegate del = Extensions.CreateDelegate(method, this);

            flattened.Add(name, new CarpExternalFunc(type, del));
        }
        
        // Add all the members to the CarpStatic object
        // If theres dots, make nested carpstatic objects for them
        foreach ((string key, CarpObject value) in flattened)
        {
            string[] parts = key.Split('.');
            if (parts.Length == 1)
                cs.DefineProperty(Signature.OfVariable(key), value.GetCarpType(), value);
            else
            {
                CarpStatic current = cs;
                for (int i = 0; i < parts.Length - 1; i++)
                {
                    Signature sig = Signature.OfVariable(parts[i]);
                    if (!current.HasProperty(sig))
                        current.DefineProperty(Signature.OfVariable(parts[i]), CarpStatic.Type, new CarpStatic(parts[i]));
                    current = (CarpStatic) current.Property(sig);
                }

                current.DefineProperty(Signature.OfVariable(parts[^1]), value.GetCarpType(), value);
            }
        }

        return cs;
    }
}

public class PackageMemberAttribute(string? name = null) : Attribute
{
    public string? Name = name;
    public string? ReturnType;
}

public class StandardPackageAttribute : Attribute
{
    public string Name;
    public StandardPackageAttribute(string name)
    {
        this.Name = name;
    }
}
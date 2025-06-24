namespace Carp.utils.attributes;

using objects.typing;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class TypeExtensionAttribute : Attribute
{
    public TypeExtensionAttribute(Type t)
    {
        // ask type for Static member .Type
        var field = t.GetField("Type");
        if (field == null)
            throw new ArgumentException($"Type '{t.Name}' does not have a static field 'Type'");

        this.BaseType = field.GetValue(null) as CarpType;
    }
    public CarpType BaseType { get; }
}

public class ConsiderAttribute : Attribute
{
    public ConsiderAttribute(string? name = null, MemberType typeOverride = MemberType.Method)
    {
        this.TypeOverride = typeOverride;
        this.Name = name;
    }
    
    public MemberType TypeOverride { get; }
    public string? Name { get; }
}

public enum MemberType
{
    Method,
    Property,
}
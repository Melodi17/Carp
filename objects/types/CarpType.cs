using System.Reflection;

namespace Carp.objects.types;

public class CarpType : CarpObject
{
    public static new CarpType Type = Of<CarpType>(new("type"));
    public static CarpType Auto = new(null, new("auto"));
    
    public Type Native => this._value;

    private readonly Type _value;
    private readonly CarpString _repr;
    public readonly bool IsStruct;
    public CarpType(Type source, CarpString repr, bool isStruct = false)
    {
        this._value = source;
        this._repr = repr;
        this.IsStruct = isStruct;
        
        // type.GetGenericTypeDefinition() to get base_type
        // type.GetGenericArguments() to get sub_types
    }

    public static CarpType GetType(CarpObject source) => source.GetCarpType();

    public static CarpType GetType<T>() where T : CarpObject => GetType(typeof(T));

    public static CarpType GetType(Type t)
    {
        FieldInfo fi = t.GetField(nameof(Type), BindingFlags.Public | BindingFlags.Static);
        if (fi is not null)
        {
            CarpType ct = fi!.GetValue(null) as CarpType;
            return ct;
        }

        PropertyInfo pi = t.GetProperty(nameof(Type), BindingFlags.Public | BindingFlags.Static);
        if (pi is not null)
        {
            CarpType ct = pi!.GetValue(null) as CarpType;
            return ct;
        }
        
        throw new($"{t.GetFormattedName()} did not have static member {nameof(Type)}");
    }

    public static CarpType Of<T>(CarpString repr) where T : CarpObject => new(typeof(T), repr);
    public override CarpString String() => this._repr;
    public override CarpObject Property(string name)
    {
        return name switch {
            "name" => this.String(),
            "is_struct" => CarpBool.Of(this.IsStruct),
            _ => throw new CarpError.InvalidProperty(name),
        };
    }
}
using System.Reflection;
using System.Text;

namespace Carp.objects.types;

public abstract class CarpType : CarpObject
{
    public static new CarpType Type = NativeType.Of<CarpType>("type");
    public override CarpType GetCarpType() => Type;

    protected readonly CarpType _baseType;
    private readonly CarpString _repr;
    public readonly bool IsStruct;
    protected CarpType(CarpType baseType, CarpString repr, bool isStruct = false)
    {
        this._baseType = baseType;
        this._repr = repr;
        this.IsStruct = isStruct;
    }

    public abstract CarpObject Instantiate(CarpObject[] args);

    public bool Extends(CarpType baseType) 
        => this == baseType // If we are that type
        || (this._baseType?.Extends(baseType) ?? false); // If our ancestors are that type
    public GenericCarpType With(params CarpType[] subTypes) => new(this, subTypes);

    // public static CarpType Of<T>(CarpString repr) where T : CarpObject => new(typeof(T), repr);
    public override CarpString String() => this._repr;
    public override CarpObject Property(string name)
    {
        return name switch {
            "name" => this.String(),
            "is_struct" => CarpBool.Of(this.IsStruct),
            _ => throw new CarpError.InvalidProperty(name),
        };
    }

    public static bool operator ==(CarpType left, CarpType right) => left!.Equals(right);
    public static bool operator !=(CarpType left, CarpType right) => !left!.Equals(right);
}

public class GenericCarpType : CarpType
{
    private CarpType[] _subTypes;
    public CarpType[] SubTypes => this._subTypes;
    private static CarpString GenericfyName(CarpType baseType, CarpType[] subTypes)
    {
        if (baseType.Extends(CarpCollection.Type))
            return new(subTypes[0].GetCarpType().String().Native + "*");
        
        if (baseType.Extends(CarpMap.Type))
            return new(subTypes[0].GetCarpType().String() + ":" + subTypes[1].GetCarpType().String());

        StringBuilder sb = new();
        sb.Append(baseType.String().Native);
        sb.Append('<');
        sb.AppendJoin(", ", subTypes.Select(x => x.String().Native));
        sb.Append('>');
        return new(sb.ToString());
    }
    public GenericCarpType(CarpType baseType, CarpType[] subTypes) : base(baseType, GenericfyName(baseType, subTypes), baseType.IsStruct)
    {
        this._subTypes = subTypes;
    }

    public override bool Equals(object obj)
    {
        if (obj is GenericCarpType gct)
        {
            return gct._baseType.Equals(this._baseType)
                && gct._subTypes
                    .Zip(this._subTypes)
                    .Select(x => x.First == x.Second)
                    .All(x => x);
        }

        return base.Equals(obj);
    }

    public override CarpObject Instantiate(CarpObject[] args)
    {
        CarpObject[] newArr = new CarpObject[this._subTypes.Length + args.Length];
        this._subTypes.CopyTo(newArr, 0);
        args.CopyTo(newArr, this._subTypes.Length);
        
        return this._baseType.Instantiate(newArr);
    }
}

public class NativeType : CarpType
{
    private Type _t;
    public NativeType(Type t, string displayName) : base(CarpObject.Type, new(displayName), t.GetCustomAttribute<CarpStructAttribute>() != null)
    {
        this._t = t;
    }

    public static NativeType Of<T>(string name) => new(typeof(T), name);

    public override CarpObject Instantiate(CarpObject[] args)
        => (CarpObject)Activator.CreateInstance(this._t, args);

    public override bool Equals(object obj)
    {
        if (obj is NativeType nt)
            return nt._t == this._t;

        return base.Equals(obj);
    }

}

public class AutoType : CarpType
{
    public static readonly AutoType Instance = new();
    public AutoType() : base(null, new("auto")) { }

    public override CarpObject Instantiate(CarpObject[] args) 
        => throw new InvalidOperationException("Cannot instantiate an auto type.");
}
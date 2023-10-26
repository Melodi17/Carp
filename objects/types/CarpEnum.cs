namespace Carp.objects.types;

public class CarpEnum : CarpObject
{
    public static CarpType Type = NativeType.Of<CarpEnum>("enum");
    public override CarpType GetCarpType() => Type;
    private List<string> _keys;
    private CarpObject _source;
    
    private CarpEnum(CarpObject source, List<string> keys)
    {
        this._source = source;
        this._keys = keys;
    }

    public override CarpString String() => new(string.Join(", ", this._keys));
    
    public static CarpEnum Of(CarpObject obj, string item) => new(obj, new List<string> {item});
    public static CarpEnum Of(CarpObject obj, List<string> items) => new(obj, items);

    public override CarpBool Match(CarpObject other)
    {
        if (other is not CarpEnum en)
            throw new CarpError.InvalidType(CarpEnum.Type, other.GetCarpType());

        return CarpBool.Of(this._source.Equals(en._source) && this._keys == en._keys);
    }
    
    public CarpBool Has(string key) => CarpBool.Of(this._keys.Contains(key));

    public override CarpObject Property(string name)
    {
        return name switch {
            "keys" => new CarpCollection(CarpString.Type, this._keys.Select(x => new CarpString(x)).ToArray()),
            "source" => this._source,
            "has" => new CarpExternalFunc(CarpBool.Type, this.Has),
            _ => throw new CarpError.InvalidProperty(name),
        };
    }
}
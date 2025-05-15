using Carp.objects.typing;

namespace Carp.objects;

public class CarpString : CarpObject
{
    public new static readonly CarpType Type = CarpType.Create("string", CarpObject.Type).Build();
    public override CarpType GetCarpType() => Type;
    public static readonly CarpString Empty = new(string.Empty);
    private static readonly Dictionary<string, CarpString> Cache = new();
    public string Value { get; }


    protected CarpString(string value)
    {
        this.Value = value;
    }
    
    public static CarpString Create(string value)
    {
        if (Cache.TryGetValue(value, out var cached))
            return cached;

        CarpString str = new(value);
        Cache[value] = str;
        return str;
    }

    public override CarpString String() => this;

    public override string Repr() => $"\"{this.Value}\"";
    public override CarpObject Equal(CarpObject right) => right is CarpString str
        ? CarpBoolean.Create(this.Value == str.Value)
        : CarpBoolean.False;
}
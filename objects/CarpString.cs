namespace Carp.objects;

using scoping;
using typing;

public class CarpString : CarpObject
{
    public new static readonly CarpType Type = CarpType.Create("string", CarpObject.Type,
        b => b.Member(new PropertyMember("length", CarpNumber.Type).Getter(x => CarpNumber.Create(((CarpString) x).Value.Length))));
    public static readonly CarpString Empty = new(string.Empty);
    private static readonly Dictionary<string, CarpString> Cache = new();

    protected CarpString(string value)
    {
        this.Value = value;
    }
    public string Value { get; }
    public override CarpType GetCarpType() => CarpString.Type;

    public static CarpString Create(string value)
    {
        if (CarpString.Cache.TryGetValue(value, out CarpString? cached))
            return cached;

        CarpString str = new(value);
        CarpString.Cache[value] = str;
        return str;
    }

    public override CarpString String() => this;

    public override string Repr() => $"\'{this.Value}\'";
    public override CarpObject Equal(CarpObject right) => right is CarpString str ? CarpBoolean.Create(this.Value == str.Value) : CarpBoolean.False;
}
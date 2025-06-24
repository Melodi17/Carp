namespace Carp.objects;

using scoping;
using typing;

public class CarpString : CarpObject, IIterable
{
    public new static readonly CarpType Type = CarpType.Create("string", IIterable.Type);
    public static readonly CarpString Empty = new(string.Empty);
    private static readonly Dictionary<string, CarpString> Cache = new();

    protected CarpString(string value)
    {
        this.Value = value;
    }
    public string Value { get; }
    public IEnumerable<CarpObject> GetIterator() => this.Value.Select(c => CarpString.Create(c));
    public override CarpType GetCarpType() => CarpString.Type;

    public static CarpString Create(string value)
    {
        if (CarpString.Cache.TryGetValue(value, out CarpString? cached))
            return cached;

        CarpString str = new(value);
        CarpString.Cache[value] = str;
        return str;
    }

    public override CarpObject Add(CarpObject right) => CarpString.Create(this.Value + right.String().Value);
    public override CarpObject Divide(CarpObject right)
    {
        if (right is CarpString str)
            return CarpString.Create(Path.Join(this.Value, str.Value));

        if (right is CarpRange { Start: null, End: null })
            return CarpString.Create(Path.GetDirectoryName(this.Value) ?? string.Empty);

        return base.Divide(right);
    }

    public static CarpString Create(char value) => CarpString.Create(value.ToString());

    public override CarpObject Index(CarpObject[] index)
        => CommonBehavior.Index(this, this.Value.Select(x => (CarpObject) CarpString.Create(x)).ToList(),
            CarpString.Type, index);

    public override CarpObject IndexSet(CarpObject[] index, CarpObject value)
        => CommonBehavior.IndexSet(this, this.Value.Select(x => (CarpObject) CarpString.Create(x)).ToList(),
            CarpString.Type, index, value);

    public override CarpString String() => this;

    public override string Repr() => $"\'{this.Value}\'";
    public override CarpObject Equal(CarpObject right)
        => right is CarpString str ? CarpBoolean.Create(this.Value == str.Value) : CarpBoolean.False;

    public override CarpObject Coerce(CarpType type) => CommonBehavior.CoerceIIterable(this, type) ?? base.Coerce(type);
}
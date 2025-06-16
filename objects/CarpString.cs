namespace Carp.objects;

using scoping;
using typing;

public class CarpString : CarpObject, IIterable
{
    public new static readonly CarpType Type = CarpType.Create("string", IIterable.Type, b => b
        .Member(new MethodMember("replace").Overload(new NativeConstrainedFunction(CarpString.Type!, (self, args) =>
        {
            CarpString str = (CarpString) self!;
            string oldValue = ((CarpString) args[0]).Value;
            string newValue = ((CarpString) args[1]).Value;

            return CarpString.Create(str.Value.Replace(oldValue, newValue));
        }, [CarpString.Type!, CarpString.Type!])))
        .Member(new MethodMember("remove").Overload(new NativeConstrainedFunction(CarpString.Type!, (self, args) =>
        {
            CarpString str = (CarpString) self!;
            string oldValue = ((CarpString) args[0]).Value;

            return CarpString.Create(str.Value.Replace(oldValue, ""));
        }, [CarpString.Type!])))
        .Member(new MethodMember("split").Overload(new NativeConstrainedFunction(CarpCollection.Type, (self, args) =>
        {
            CarpString str = (CarpString) self!;
            string delimiter = ((CarpString) args[0]).Value;

            if (delimiter.Length == 0)
                return new CarpCollection(CarpString.Type!, str.Value.Select(CarpString.Create));
            return new CarpCollection(CarpString.Type!, str.Value.Split(delimiter).Select(CarpString.Create));
        }, [CarpString.Type!])))
        .Member(new MethodMember("contains").Overload(new NativeConstrainedFunction(CarpBoolean.Type, (self, args) =>
        {
            CarpString str = (CarpString) self!;
            string substring = ((CarpString) args[0]).Value;

            return CarpBoolean.Create(str.Value.Contains(substring));
        }, [CarpString.Type!])))
        .Member(new MethodMember("starts").Overload(new NativeConstrainedFunction(CarpBoolean.Type, (self, args) =>
        {
            CarpString str = (CarpString) self!;
            string substring = ((CarpString) args[0]).Value;

            return CarpBoolean.Create(str.Value.StartsWith(substring));
        }, [CarpString.Type!])))
        .Member(new MethodMember("ends").Overload(new NativeConstrainedFunction(CarpBoolean.Type, (self, args) =>
        {
            CarpString str = (CarpString) self!;
            string substring = ((CarpString) args[0]).Value;

            return CarpBoolean.Create(str.Value.EndsWith(substring));
        }, [CarpString.Type!])))
        .Member(new PropertyMember("strip", CarpNumber.Type).Getter<CarpString>(x => CarpString.Create(x.Value.Trim())))
        .Member(new PropertyMember("lower", CarpNumber.Type).Getter<CarpString>(x
            => CarpString.Create(x.Value.ToLower())))
        .Member(new PropertyMember("upper", CarpString.Type!).Getter<CarpString>(x
            => CarpString.Create(x.Value.ToUpper()))));
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
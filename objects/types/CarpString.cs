namespace Carp.objects.types;

public class CarpString : CarpObject
{
    public static new CarpType Type = CarpType.Of<CarpString>(new("str"));
    
    private readonly string _value;

    public string Native => this._value;

    public CarpString(string v)
    {
        this._value = v;
    }

    public override CarpObject Add(CarpObject other)
    {
        if (other is CarpString cs)
            return new CarpString(this._value + cs.Native);
        else
            return new CarpString(this._value + other.String().Native);
    }

    public override CarpObject Multiply(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, CarpType.GetType(other));
        
        return new CarpString(
            string.Join("", Enumerable.Repeat(this._value, ci.NativeInt)));
    }

    public override CarpObject Cast(CarpType t)
    {
        if (t == CarpObject.Type)
            return this;
        if (t == Type)
            return this.String();
        if (t == CarpInt.Type)
        {
            try
            {
                return new CarpInt(double.Parse(this._value));
            }
            catch (FormatException fe)
            {
                throw new CarpError.UnparseableInt(this._value);
            }
        }
        else if (t == CarpBool.Type)
        {
            if (this._value == "true")
                return CarpBool.True;
            else if (this._value == "false")
                return CarpBool.False;
            else
                throw new CarpError.InvalidCast(t);
        }
        else
            throw new CarpError.InvalidCast(t);
    }

    public override CarpIterator<CarpObject> Iterate()
    {
        IEnumerable<CarpObject> Iter()
        {
            foreach (char c in this._value)
                yield return new CarpChar(c);
        }

        return new CarpEnumerableIterator<CarpObject>(Iter());
    }

    public override CarpObject Index(CarpObject[] args)
    {
        if (args.Length != 1)
            throw new CarpError.InvalidParameterCount(1, args.Length);

        if (args[0] is not CarpInt)
            args[0] = args[0].Cast<CarpInt>();

        int index = (args[0] as CarpInt).NativeInt;
        if (index < 0 || index >= this._value.Length)
            throw new CarpError.IndexOutOfRange(index);

        return new CarpChar(this._value[index]);
    }

    private CarpBool Contains(CarpString inner) => CarpBool.Of(this._value.Contains(inner._value));
    private CarpCollection<CarpString> Split(CarpString delim)
    {
        string[] chunks = this._value.Split(delim._value);
        return new(chunks.Select(x => new CarpString(x)).ToList());
    }

    public override CarpObject Property(string name)
    {
        return name switch
        {
            "length" => new CarpInt(this._value.Length),
            "lower" => new CarpString(this._value.ToLower()),
            "upper" => new CarpString(this._value.ToUpper()),
            "clean" => new CarpString(this._value.Trim()),
            "split" => new CarpExternalFunc<CarpCollection<CarpString>>(this.Split),
            "contains" => new CarpExternalFunc<CarpBool>(this.Contains),
            _ => throw new CarpError.InvalidProperty(name),
        };
    }

    public override CarpString String() => new(this._value);
    public override string Repr() => $"'{this._value}'";
    
    public override CarpBool Match(CarpObject other)
    {
        if (other is not CarpString cs)
            throw new CarpError.InvalidType(CarpString.Type, CarpType.GetType(other));

        return CarpBool.Of(this._value == cs._value);
    }
}
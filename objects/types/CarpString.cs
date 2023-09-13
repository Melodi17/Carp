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
        if (t == Type)
            return this.String();
        if (t == CarpInt.Type)
            return new CarpInt(double.Parse(this._value));
        else if (t == CarpBool.Type)
            return CarpBool.Of(this._value == "true");
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

    public override CarpObject Property(string name)
    {
        return name switch
        {
            "length" => new CarpInt(this._value.Length),
            _ => throw new CarpError.InvalidProperty(name),
        };
    }

    public override CarpString String() => new(this._value);
    public override string Repr() => $"'{this._value}'";
}
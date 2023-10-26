namespace Carp.objects.types;

[CarpStruct(0)]
public class CarpInt : CarpObject
{
    public static new CarpType Type = NativeType.Of<CarpInt>("int");
    public override CarpType GetCarpType() => Type;

    private readonly double _value;
    public double Native => this._value;
    public int NativeInt => (int)this._value;

    public CarpInt(double v)
    {
        this._value = v;
    }

    public override CarpObject Step() => new CarpInt(this._value + 1);

    public override CarpObject Add(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, other.GetCarpType());

        return new CarpInt(this._value + ci._value);
    }

    public override CarpObject Subtract(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, other.GetCarpType());

        return new CarpInt(this._value - ci._value);
    }
    
    public override CarpObject Multiply(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, other.GetCarpType());

        return new CarpInt(this._value * ci._value);
    }
    
    public override CarpObject Divide(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, other.GetCarpType());

        if (ci._value == 0)
            throw new CarpError.DivideByZero(this);

        return new CarpInt(this._value / ci._value);
    }
    
    public override CarpObject Pow(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, other.GetCarpType());

        return new CarpInt(Math.Pow(this._value, ci._value));
    }
    
    public override CarpObject Modulus(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, other.GetCarpType());

        return new CarpInt(this._value % ci._value);
    }

    public override CarpBool Greater(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, other.GetCarpType());

        return CarpBool.Of(this._value > ci._value);
    }
    
    public override CarpBool Less(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, other.GetCarpType());

        return CarpBool.Of(this._value < ci._value);
    }

    public override CarpObject Negate() => new CarpInt(-this._value);

    public override CarpIterator Iterate()
    {
        IEnumerable<CarpObject> Iter()
        {
            double cur = 0;
            while (cur < this._value)
            {
                yield return new CarpInt(cur);
                cur++;
            }
        }

        return new CarpEnumerableIterator(CarpInt.Type, Iter());
    }

    public override CarpString String()
    {
        // Tostring it, but if it ends with .0, remove it
        string str = this._value.ToString();
        if (str.EndsWith(".0"))
            str = str[..^2];
        
        return new(str);
    }

    public override CarpBool Match(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, other.GetCarpType());

        return CarpBool.Of(this._value == ci._value);
    }
}
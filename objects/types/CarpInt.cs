namespace Carp.objects.types;

public class CarpInt : CarpObject
{
    public static new CarpType Type = CarpType.Of<CarpInt>(new("int"));
    
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
            throw new CarpError.InvalidType(CarpInt.Type, CarpType.GetType(other));

        return new CarpInt(this._value + ci._value);
    }

    public override CarpObject Subtract(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, CarpType.GetType(other));

        return new CarpInt(this._value - ci._value);
    }
    
    public override CarpObject Multiply(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, CarpType.GetType(other));

        return new CarpInt(this._value * ci._value);
    }
    
    public override CarpObject Divide(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, CarpType.GetType(other));

        if (ci._value == 0)
            throw new CarpError.DivideByZero(this);

        return new CarpInt(this._value / ci._value);
    }
    
    public override CarpObject Pow(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, CarpType.GetType(other));

        return new CarpInt(Math.Pow(this._value, ci._value));
    }

    public override CarpBool Greater(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, CarpType.GetType(other));

        return CarpBool.Of(this._value > ci._value);
    }
    
    public override CarpBool Less(CarpObject other)
    {
        if (other is not CarpInt ci)
            throw new CarpError.InvalidType(CarpInt.Type, CarpType.GetType(other));

        return CarpBool.Of(this._value < ci._value);
    }

    public override CarpIterator<CarpObject> Iterate()
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

        return new CarpEnumerableIterator<CarpObject>(Iter());
    }

    public override CarpString String()
    {
        // Tostring it, but if it ends with .0, remove it
        string str = this._value.ToString();
        if (str.EndsWith(".0"))
            str = str[..^2];
        
        return new(str);
    }
}
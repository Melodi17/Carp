using Carp.objects.typing;

namespace Carp.objects;

public class CarpNumber : CarpObject
{
    public new static readonly CarpType Type = CarpType.Create("int", CarpObject.Type, b =>
        b.DefaultValue(() => CarpNumber.Create(0)));
    public override CarpType GetCarpType() => Type;
    public double Value { get; }
    public int ValueFull => (int)this.Value;
    
    private static readonly Dictionary<double, CarpNumber> Cache = new();

    protected CarpNumber(double value)
    {
        this.Value = value;
    }
    
    
    public static CarpNumber Create(double value)
    {
        if (Cache.TryGetValue(value, out CarpNumber? cached))
            return cached;

        CarpNumber number = new(value);
        Cache[value] = number;
        return number;
    }

    public override CarpObject Add(CarpObject right) => right is CarpNumber number
        ? CarpNumber.Create(this.Value + number.Value)
        : base.Add(right);
    public override CarpObject Subtract(CarpObject right) => right is CarpNumber number
        ? CarpNumber.Create(this.Value - number.Value)
        : base.Subtract(right);
    public override CarpObject Multiply(CarpObject right) => right is CarpNumber number
        ? CarpNumber.Create(this.Value * number.Value)
        : base.Multiply(right);
    public override CarpObject Divide(CarpObject right) => right is CarpNumber number
        ? CarpNumber.Create(this.Value / number.Value)
        : base.Divide(right);
    public override CarpObject Power(CarpObject right) => right is CarpNumber number
        ? CarpNumber.Create(Math.Pow(this.Value, number.Value))
        : base.Power(right);
    public override CarpObject Modulus(CarpObject right) => right is CarpNumber number
        ? CarpNumber.Create(this.Value % number.Value)
        : base.Modulus(right);

    public override CarpObject Less(CarpObject right) => right is CarpNumber number
        ? CarpBoolean.Create(this.Value < number.Value)
        : base.Less(right);
    
    public override CarpObject Greater(CarpObject right) => right is CarpNumber number
        ? CarpBoolean.Create(this.Value > number.Value)
        : base.Greater(right);
    
    public override CarpObject Negate() => CarpNumber.Create(-this.Value);
    public override CarpString String() => CarpString.Create(this.Value.ToString());
    public override CarpObject Equal(CarpObject right) => right is CarpNumber number
        ? CarpBoolean.Create(this.Value == number.Value)
        : CarpBoolean.False;
}
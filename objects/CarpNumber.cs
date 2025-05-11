namespace Carp.objects;

public class CarpNumber : CarpObject
{
    public double Value { get; }
    public int ValueFull => (int)this.Value;

    protected CarpNumber(double value)
    {
        this.Value = value;
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

    public static CarpNumber Create(double value) => new(value);
    public override CarpString String() => CarpString.Create(this.Value.ToString());
    public override CarpObject Equal(CarpObject right) => right is CarpNumber number
        ? CarpBoolean.Create(this.Value == number.Value)
        : CarpBoolean.False;
}
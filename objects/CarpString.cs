namespace Carp.objects;

public class CarpString : CarpObject
{
    public string Value { get; }

    protected CarpString(string value)
    {
        this.Value = value;
    }
    
    public static CarpString Create(string value) => new(value);

    public override CarpString String() => this;

    public override string Repr() => $"\"{this.Value}\"";
    public override CarpObject Equal(CarpObject right) => right is CarpString str
        ? CarpBoolean.Create(this.Value == str.Value)
        : CarpBoolean.False;
}
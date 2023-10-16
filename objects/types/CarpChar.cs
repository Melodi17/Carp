namespace Carp.objects.types;

public class CarpChar : CarpObject
{
    public static new CarpType Type = NativeType.Of<CarpChar>("char");
    public override CarpType GetCarpType() => Type;

    private readonly char _value;

    public char Native => this._value;

    public CarpChar(char v)
    {
        this._value = v;
    }

    public override CarpObject Cast(CarpType t)
    {
        if (t == CarpInt.Type)
            return new CarpInt(this._value);

        return base.Cast(t);
    }

    public override CarpString String() => new(this._value.ToString());
    public override string Repr() => $"'{this._value}'";
}
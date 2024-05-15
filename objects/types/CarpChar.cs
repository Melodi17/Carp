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
    public override CarpBool Match(CarpObject other)
    {
        if (other is CarpChar cc) return CarpBool.Of(this._value == cc._value);
        if (other is CarpString cs) return CarpBool.Of(this._value.ToString() == cs.Native);
        throw new CarpError.InvalidType(CarpChar.Type, other.GetCarpType());

    }
}
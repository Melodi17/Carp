using Carp.interpreter;

namespace Carp.objects.types;

public class CarpChar : CarpObject
{
    public static new CarpType Type = NativeType.Of<CarpChar>("chr");
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

    public override CarpObject Property(Signature signature)
    {
        return signature.Name switch
        {
            "lower" => new CarpChar(char.ToLower(this._value)),
            "upper" => new CarpChar(char.ToUpper(this._value)),
            "is_digit" => CarpBool.Of(char.IsDigit(this._value)),
            "is_alpha" => CarpBool.Of(char.IsLetter(this._value)),
            "is_symbol" => CarpBool.Of(char.IsSymbol(this._value)),
            "is_whitespace" => CarpBool.Of(char.IsWhiteSpace(this._value)),
            "is_alphanumeric" => CarpBool.Of(char.IsLetterOrDigit(this._value)),
            "is_upper" => CarpBool.Of(char.IsUpper(this._value)),
            "is_lower" => CarpBool.Of(char.IsLower(this._value)),
            _ => throw new CarpError.InvalidProperty(signature),
        };
    }

    public override CarpString String() => new(this._value.ToString());
    public override string Repr() => $"`{this._value}";
    public override CarpBool Match(CarpObject other)
    {
        if (other is CarpChar cc) return CarpBool.Of(this._value == cc._value);
        if (other is CarpString cs) return CarpBool.Of(this._value.ToString() == cs.Native);
        throw new CarpError.InvalidType(CarpChar.Type, other.GetCarpType());
    }
}
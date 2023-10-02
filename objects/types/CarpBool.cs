namespace Carp.objects.types;

public class CarpBool : CarpObject
{
    public static new CarpType Type = CarpType.Of<CarpBool>(new("bool"));
    
    public static CarpBool True = new(true);
    public static CarpBool False = new(false);
    public bool Native => this._value;
    private readonly bool _value;

    private CarpBool(bool v)
    {
        this._value = v;
    }

    public override CarpString String() => new(this._value ? "true" : "false");
    
    public static CarpBool Of(bool v) => v ? True : False;

    public CarpBool Not() => Of(!this._value);

    public override CarpBool Match(CarpObject other)
    {
        if (other is not CarpBool cb)
            throw new CarpError.InvalidType(CarpBool.Type, CarpType.GetType(other));

        return Of(this._value == cb._value);
    }
}
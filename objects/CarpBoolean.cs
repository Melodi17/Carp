namespace Carp.objects;

using typing;

public class CarpBoolean : CarpObject
{
    public new static readonly CarpType Type = CarpType.Create("bool", CarpObject.Type);

    public static readonly CarpBoolean True = new(true);
    public static readonly CarpBoolean False = new(false);

    private CarpBoolean(bool value)
    {
        this.Value = value;
    }

    public bool Value { get; }
    public override CarpType GetCarpType() => CarpBoolean.Type;

    public static CarpBoolean Create(bool value) => value ? CarpBoolean.True : CarpBoolean.False;
    public override CarpString String() => CarpString.Create(this.Value ? "true" : "false");
    public override CarpObject Equal(CarpObject right) => right is CarpBoolean boolean ? CarpBoolean.Create(this.Value == boolean.Value) : CarpBoolean.False;

    public override CarpObject Not() => CarpBoolean.Create(!this.Value);
}
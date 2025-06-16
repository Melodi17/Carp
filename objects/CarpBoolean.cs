namespace Carp.objects;

using typing;

public class CarpBoolean : CarpObject
{
    public new static readonly CarpType Type = CarpType.Create("bool", CarpObject.Type);

    private static CarpBoolean? _true;
    private static CarpBoolean? _false;

    private CarpBoolean(bool value)
    {
        this.Value = value;
    }

    public static CarpBoolean True => CarpBoolean._true ??= new CarpBoolean(true);
    public static CarpBoolean False => CarpBoolean._false ??= new CarpBoolean(false);

    public bool Value { get; }
    public override CarpType GetCarpType() => CarpBoolean.Type;

    public static CarpBoolean Create(bool value) => value ? CarpBoolean.True : CarpBoolean.False;
    public override CarpString String() => CarpString.Create(this.Value ? "true" : "false");
    public override CarpObject Equal(CarpObject right)
        => right is CarpBoolean boolean ? CarpBoolean.Create(this.Value == boolean.Value) : CarpBoolean.False;

    public override CarpObject Not() => CarpBoolean.Create(!this.Value);
}
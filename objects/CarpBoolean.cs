using Carp.objects.typing;

namespace Carp.objects;

public class CarpBoolean : CarpObject
{
    public new static readonly CarpType Type = CarpType.Create("bool", CarpObject.Type);
    public override CarpType GetCarpType() => Type;
    
    public static readonly CarpBoolean True = new(true);
    public static readonly CarpBoolean False = new(false);
    
    public bool Value { get; }
    
    public static CarpBoolean Create(bool value) => value ? True : False;
    
    private CarpBoolean(bool value)
    {
        this.Value = value;
    }
    public override CarpString String() => CarpString.Create(this.Value ? "true" : "false");
    public override CarpObject Equal(CarpObject right) => right is CarpBoolean boolean
        ? CarpBoolean.Create(this.Value == boolean.Value)
        : CarpBoolean.False;

    public override CarpObject Not() => CarpBoolean.Create(!this.Value);
}
namespace Carp.objects;

using typing;

public class CarpNull : CarpObject
{
    public new static readonly CarpType Type = CarpType.Create("null", CarpObject.Type);
    public static readonly CarpNull Instance = new();

    private CarpNull() { }
    public override CarpType GetCarpType() => CarpNull.Type;

    public override CarpString String() => CarpString.Create("null");
}
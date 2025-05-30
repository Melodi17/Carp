namespace Carp.objects;

using typing;

public class CarpVoid : CarpObject
{
    public new static readonly CarpType Type = CarpType.Create("void", CarpObject.Type);
    public static readonly CarpVoid Instance = new();

    private CarpVoid() { }
    public override CarpType GetCarpType() => CarpVoid.Type;

    public override CarpString String() => CarpString.Create("void");
}
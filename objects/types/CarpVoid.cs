namespace Carp.objects.types;

public class CarpVoid : CarpObject
{
    public static new CarpType Type = NativeType.Of<CarpVoid>("void");
    public override CarpType GetCarpType() => Type;

    public static CarpVoid Instance = new();
    
    private CarpVoid() { }
    
    public override CarpString String() => new("void");
}
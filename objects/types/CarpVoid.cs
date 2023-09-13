namespace Carp.objects.types;

public class CarpVoid : CarpObject
{
    public static new CarpType Type = CarpType.Of<CarpVoid>(new("void"));
    
    public static CarpVoid Instance = new();
    
    private CarpVoid() { }
    
    public override CarpString String() => new("void");
}
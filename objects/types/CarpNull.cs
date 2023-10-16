namespace Carp.objects.types;

public class CarpNull : CarpObject
{
    public static new CarpType Type = NativeType.Of<CarpNull>("null");
    public override CarpType GetCarpType() => Type;
    
    public static CarpNull Instance = new();
    
    private CarpNull() { }
    
    public override CarpString String() => new("null");
}
namespace Carp.objects.types;

public class CarpNull : CarpObject
{
    public static new CarpType Type = CarpType.Of<CarpNull>(new("null"));
    
    public static CarpNull Instance = new();
    
    private CarpNull() { }
    
    public override CarpString String() => new("null");
}
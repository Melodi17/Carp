namespace Carp.objects;

public class CarpNull : CarpObject
{
    public static readonly CarpNull Instance = new();
    
    private CarpNull() { }
    
    public override CarpString String() => CarpString.Create("null");
}
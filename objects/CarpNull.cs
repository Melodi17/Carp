using Carp.objects.typing;

namespace Carp.objects;

public class CarpNull : CarpObject
{
    public new static readonly CarpType Type = CarpType.Create("null", CarpObject.Type);
    public override CarpType GetCarpType() => Type;
    public static readonly CarpNull Instance = new();
    
    private CarpNull() { }
    
    public override CarpString String() => CarpString.Create("null");
}
using Carp.objects.typing;
using Carp.scoping;

namespace Carp.objects;

public class CarpVoid : CarpObject
{
    public new static readonly CarpType Type = CarpType.Create("void", CarpObject.Type).Build();
    public override CarpType GetCarpType() => Type;
    public static readonly CarpVoid Instance = new();
    
    private CarpVoid() { }
    
    public override CarpString String() => CarpString.Create("void");
}
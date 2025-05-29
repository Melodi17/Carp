using Carp.objects.typing;

namespace Carp.objects;

public abstract class CarpFunction : CarpObject
{
    protected CarpFunction(CarpType returnType)
    {
        this.ReturnType = returnType;
    }
    public new static readonly CarpType Type = CarpType.Create("la", CarpObject.Type);
    public CarpType ReturnType { get; }
    public override CarpType GetCarpType() => Type;
    public override abstract CarpString String();

    public override CarpObject Call(CarpObject[] args) => this.Call(null, args);
    public abstract CarpObject Call(CarpObject? self, CarpObject[] args);
    public abstract bool Accepts(CarpObject[] args);
}
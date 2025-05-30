namespace Carp.objects;

using typing;

public abstract class CarpFunction : CarpObject
{
    public new static readonly CarpType Type = CarpType.Create("la", CarpObject.Type);
    protected CarpFunction(CarpType returnType)
    {
        this.ReturnType = returnType;
    }
    public CarpType ReturnType { get; }
    public override CarpType GetCarpType() => CarpFunction.Type;
    public override abstract CarpString String();

    public override CarpObject Call(CarpObject[] args) => this.Call(null, args);
    public abstract CarpObject Call(CarpObject? self, CarpObject[] args);
    public abstract bool Accepts(CarpObject[] args);
}
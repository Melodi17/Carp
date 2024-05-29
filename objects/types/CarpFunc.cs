namespace Carp.objects.types;

public abstract class CarpFunc : CarpObject
{
    public static new CarpType Type = NativeType.Of<CarpFunc>("func");
    public override CarpType GetCarpType() => Type.With(this.ReturnType);
    
    public CarpType ReturnType { get; protected set; }
    public CarpType[] ArgTypes { get; protected set; }

    protected CarpFunc(CarpType returnType, CarpType[] argTypes)
    {
        this.ReturnType = returnType;
        this.ArgTypes = argTypes;
    }
    
    public override abstract CarpObject Call(CarpObject[] args);

    public override CarpString String() 
        => new($"func<{this.ReturnType.String().Native}>");
}

public class EmptyFunc : CarpFunc
{
    public EmptyFunc(CarpType returnType, CarpType[] argTypes) : base(returnType, argTypes)
    {
    }

    public override CarpObject Call(CarpObject[] args) => CarpNull.Instance;
}
namespace Carp.objects;

using typing;
using utils;

public class NativeFunction : CarpFunction
{
    private readonly Func<CarpObject?, CarpObject[], CarpObject> _func;
    public readonly string ID = Helpers.GenerateID();

    public NativeFunction(CarpType returnType, Func<CarpObject?, CarpObject[], CarpObject> func) : base(returnType)
    {
        this._func = func;
    }
    public override CarpString String() => CarpString.Create($"<native function {this.ID}>");
    public override CarpObject Call(CarpObject? self, CarpObject[] args)
        =>
            // Native functions do not use self, so we ignore it
            this._func(self, args);
    public override bool Accepts(CarpObject[] args) => true;
}
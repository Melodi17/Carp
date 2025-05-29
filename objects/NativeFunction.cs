using Carp.objects.typing;
using Carp.utils;

namespace Carp.objects;

public class NativeFunction : CarpFunction
{
    public readonly string ID = Helpers.GenerateID();
    private readonly Func<CarpObject[], CarpObject> _func;

    public NativeFunction(CarpType returnType, Func<CarpObject[], CarpObject> func) : base(returnType)
    {
        this._func = func;
    }
    public override CarpString String() => CarpString.Create($"<native function {ID}>");
    public override CarpObject Call(CarpObject? self, CarpObject[] args)
    {
        // Native functions do not use self, so we ignore it
        return this._func(args);
    }
    public override bool Accepts(CarpObject[] args) => true;
}
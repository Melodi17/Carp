using Carp.objects.typing;

namespace Carp.objects;

public class NativeConstrainedFunction : NativeFunction
{
    private readonly CarpType[] _argTypes;


    public NativeConstrainedFunction(CarpType returnType, Func<CarpObject[], CarpObject> func, CarpType[] argTypes)
        : base(returnType, func)
    {
        this._argTypes = argTypes;
    }

    public override bool Accepts(CarpObject[] args) => 
        args.Length == this._argTypes.Length &&
        args.Zip(this._argTypes, (arg, type) => arg.GetCarpType().Extends(type)).All(x => x) &&
        base.Accepts(args);
}
namespace Carp.objects;

using System.Reflection;
using utils;

public class NativePolyFunction : CarpFunction
{
    private readonly MethodInfo _func;
    public readonly string ID = Helpers.GenerateID();

    public NativePolyFunction(MethodInfo func) : base(Polygot.TypeFromNative(func.ReturnType))
    {
        this._func = func;
    }
    
    public override CarpString String() => CarpString.Create($"<native poly function {this.ID}>");
    public override CarpObject Call(CarpObject? self, CarpObject[] args)
        => Polygot.ObjFromNative(this._func.Invoke(null, args.ToArray<object?>()), this._func.ReturnType);
    public override bool Accepts(CarpObject[] args)
    {
        var parameters = this._func.GetParameters();
        if (args.Length != parameters.Length)
            return false;

        for (int i = 0; i < args.Length; i++)
        {
            var argType = args[i].GetCarpType();
            var paramType = Polygot.TypeFromNative(parameters[i].ParameterType);
            if (!argType.Extends(paramType))
                return false;
        }
        
        return true;
    }
}
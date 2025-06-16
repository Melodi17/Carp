namespace Carp.objects;

using System.Reflection;
using exceptions;
using typing;
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
    {
        try
        {
            object?[] parameters = args
                .Select((x, i) => Polygot.ObjToNative(x, this._func.GetParameters()[i].ParameterType))
                .ToArray();

            object? selfObj = Polygot.ObjToNative(self, this._func.DeclaringType);
            object? result = this._func.Invoke(selfObj, parameters);

            return Polygot.ObjFromNative(result, this._func.ReturnType);
        }
        catch (RuntimeException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"{ex.GetType().Name}, {ex.Message}");
        }
    }
    public override bool Accepts(CarpObject[] args)
    {
        ParameterInfo[] parameters = this._func.GetParameters();
        if (args.Length != parameters.Length)
            return false;

        for (int i = 0; i < args.Length; i++)
        {
            CarpType argType = args[i].GetCarpType();
            CarpType paramType = Polygot.TypeFromNative(parameters[i].ParameterType);
            if (!argType.Extends(paramType))
                return false;
        }

        return true;
    }
}
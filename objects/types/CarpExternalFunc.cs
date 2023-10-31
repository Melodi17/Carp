using System.Reflection;
using Carp.interpreter;

namespace Carp.objects.types;

public class CarpExternalFunc : CarpFunc
{
    public static new CarpType Type = NativeType.Of<CarpExternalFunc>(CarpFunc.Type, "funcEx");
    public override CarpType GetCarpType() => Type;
    // takes func, with any args, returns T
    private Delegate _value;
    private CarpType[] _argTypes;
    private bool _ignoreArgTypes;
    
    public CarpExternalFunc(CarpType returnType, Delegate value, bool ignoreArgTypes = false) : base(returnType)
    {
        this._value = value;
        this._ignoreArgTypes = ignoreArgTypes;
        // check return type is T, unless T is CarpVoid
        if (returnType == CarpVoid.Type)
        {
            if (value.Method.ReturnType != typeof(void))
                throw new CarpError.InvalidType(CarpVoid.Type, NativeType.Find(value.Method.ReturnType));
        }
        else
        {
            // if (value.Method.ReturnType != typeof(T))
            //     throw new CarpError.InvalidType(this._returnType,
            //         CarpType.GetType(value.Method.ReturnType));
        }

        // check args are all derived from CarpObject
        if (this._ignoreArgTypes)
            return;
        
        foreach (ParameterInfo p in value.Method.GetParameters())
        {
            if (!typeof(CarpObject).IsAssignableFrom(p.ParameterType))
                throw new CarpError.InvalidType(CarpObject.Type,
                    NativeType.Find(p.ParameterType));
        }
        
        // save arg types
        this._argTypes = value.Method.GetParameters()
            .Select(x => NativeType.Find(x.ParameterType))
            .ToArray();
    }

    public override CarpObject Call(CarpObject[] args)
    {
        if (this._ignoreArgTypes)
        {
            object returnValue;
            try
            {
                returnValue = this._value.DynamicInvoke(new object[] { args });
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException!;
            }
            
            if (this._returnType == CarpVoid.Type)
                return CarpVoid.Instance;
            
            if (returnValue is CarpObject coResp)
                return coResp;
            else
                throw new("External function did not return a CarpObject");
        }
        
        // check parameter length
        if (args.Length != this._argTypes.Length)
            throw new CarpError.InvalidArgumentCount(args.Length, this._argTypes.Length);
        
        // cast all args to their respective types
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].GetCarpType() == this._argTypes[i])
                continue;
            
            if (this._argTypes[i] == AutoType.Instance)
                continue;
            
            // null
            if (args[i] is CarpNull)
            {
                if (this._argTypes[i].IsStruct)
                    throw new CarpError.CastNullToStruct(this._argTypes[i]);
                else
                    continue;
            }

            // cast
            args[i] = args[i].CastEx(this._argTypes[i]);
        }
        
        // invoke
        object resp = this._value.DynamicInvoke(args);
        if (this._returnType == CarpVoid.Type)
            return CarpVoid.Instance;
            
        if (resp is CarpObject co)
            return co;
        else
            throw new("External function did not return a CarpObject");
    }
}
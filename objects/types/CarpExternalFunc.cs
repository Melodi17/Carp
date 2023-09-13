using System.Reflection;

namespace Carp.objects.types;

public class CarpExternalFunc<T> : CarpFunc<T>
    where T : CarpObject
{
    public static new CarpType Type => CarpFunc<T>.Type;

    // takes func, with any args, returns T
    private Delegate _value;
    private CarpType[] _argTypes;
    
    public CarpExternalFunc(Delegate value)
    {
        this._value = value;
        // check return type is T, unless T is CarpVoid
        if (typeof(T) == typeof(CarpVoid))
        {
            if (value.Method.ReturnType != typeof(void))
                throw new CarpError.InvalidType(CarpType.GetType<CarpVoid>(),
                    CarpType.GetType(value.Method.ReturnType));
        }
        else
        {
            if (value.Method.ReturnType != typeof(T))
                throw new CarpError.InvalidType(CarpType.GetType<T>(),
                    CarpType.GetType(value.Method.ReturnType));
        }

        // check args are all derived from CarpObject
        foreach (ParameterInfo p in value.Method.GetParameters())
        {
            if (!typeof(CarpObject).IsAssignableFrom(p.ParameterType))
                throw new CarpError.InvalidType(CarpType.GetType<CarpObject>(),
                    CarpType.GetType(p.ParameterType));
        }
        
        // save arg types
        this._argTypes = value.Method.GetParameters()
            .Select(x => CarpType.GetType(x.ParameterType))
            .ToArray();

    }

    public override CarpObject Call(CarpObject[] args)
    {
        // check parameter length
        if (args.Length != this._argTypes.Length)
            throw new CarpError.InvalidType(this._argTypes.ToList(),
                CarpType.GetType(args[0]));
        
        // cast all args to their respective types
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].GetType() == this._argTypes[i].Native)
                continue;
            
            if (this._argTypes[i] == CarpType.Auto)
                continue;
            
            // null
            if (args[i] is CarpNull)
            {
                if (this._argTypes[i].IsStruct)
                    throw new CarpError.CastNullToStruct(this._argTypes[i]);
                else
                    continue;
            }
            
            // generic object
            if (this._argTypes[i] == CarpObject.Type)
                continue;

            // cast
            args[i] = args[i].Cast(this._argTypes[i]);
        }
        
        // invoke
        object resp = this._value.DynamicInvoke(args);
        if (typeof(T) == typeof(CarpVoid))
            return CarpVoid.Instance;
            
        if (resp is CarpObject co)
            return co;
        else
            throw new Exception("External function did not return a CarpObject");
    }
}
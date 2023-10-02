using System.Reflection;
using Carp.interpreter;

namespace Carp.objects.types;

public class CarpInternalFunc<T> : CarpFunc<T>
    where T : CarpObject
{
    public static new CarpType Type => CarpFunc<T>.Type;

    private CarpGrammarParser.Generic_blockContext _block;
    private Dictionary<string, CarpType> _parameters;
    private CarpType _returnType;
    private IScope _scope;

    public CarpInternalFunc(IScope scope, Dictionary<string, CarpType> parameters, CarpGrammarParser.Generic_blockContext block)
    {
        this._scope = scope;
        this._parameters = parameters;
        this._block = block;
        this._returnType = CarpType.GetType<T>();
    }
    
    public CarpInternalFunc(IScope scope, Dictionary<string, CarpType> parameters)
    {
        this._scope = scope;
        this._parameters = parameters;
        this._block = null;
    }

    public override CarpObject Call(CarpObject[] args)
    {
        // check parameter length
        if (args.Length != this._parameters.Count)
            throw new CarpError.InvalidType(this._parameters.Values.ToList(),
                CarpType.GetType(args[0]));
        
        // cast all args to their respective types
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].GetType() == this._parameters.ElementAt(i).Value.Native)
                continue;

            if (this._parameters.ElementAt(i).Value == CarpType.Auto)
                throw new CarpError.AutoNotPermitted();
            
            // null
            if (args[i] is CarpNull)
            {
                if (this._parameters.ElementAt(i).Value.IsStruct)
                    throw new CarpError.CastNullToStruct(this._parameters.ElementAt(i).Value);
                else
                    continue;
            }
            
            // generic object
            if (this._parameters.ElementAt(i).Value == CarpObject.Type)
                continue;

            // cast
            args[i] = args[i].Cast(this._parameters.ElementAt(i).Value);
        }
        
        // invoke
        Scope scope = new(this._scope);
        for (int index = 0; index < args.Length; index++)
        {
            CarpObject obj = args[index];
            string name = this._parameters.ElementAt(index).Key;
            scope.Define(name, this._parameters.ElementAt(index).Value, obj);
        }

        CarpObject returnVal = CarpInterpreter.Instance.GetObject(scope, this._block);

        if (this._returnType == CarpVoid.Type)
            return CarpVoid.Instance;

        if (returnVal == CarpVoid.Instance)
            throw new CarpError.VoidFromNonVoidFunction();

        if (CarpType.GetType(returnVal) != this._returnType)
            return returnVal.Cast(this._returnType);

        return returnVal;
    }
    
    public CarpInternalFunc<T> Bind(CarpObject obj)
    {
        // set this
        Scope boundScope = new(this._scope);
        boundScope.Define("this", CarpType.GetType(obj), obj);
        
        return new(boundScope, this._parameters, this._block);
    }
}
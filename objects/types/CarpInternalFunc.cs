﻿using System.Reflection;
using Carp.interpreter;

namespace Carp.objects.types;

public class CarpInternalFunc : CarpFunc
{
    public static new CarpType Type = NativeType.Of<CarpInternalFunc>(CarpFunc.Type, "funcIn");
    public override CarpType GetCarpType() => Type;

    private CarpGrammarParser.Generic_blockContext _block;
    private Dictionary<string, CarpType> _parameters;
    public readonly CarpInterpreter Interpreter;
    private IScope _scope;

    public CarpInternalFunc(CarpInterpreter interpreter, CarpType returnType, IScope scope, Dictionary<string, CarpType> parameters, CarpGrammarParser.Generic_blockContext block) 
        : base(returnType, parameters.Values.ToArray())
    {
        this.Interpreter = interpreter;
        this._scope = scope;
        this._parameters = parameters;
        this._block = block;
    }
    
    public CarpInternalFunc(CarpInterpreter interpreter, CarpType returnType, IScope scope, Dictionary<string, CarpType> parameters) 
        : base(returnType, parameters.Values.ToArray())
    {
        this.Interpreter = interpreter;
        this._scope = scope;
        this._parameters = parameters;
        this._block = null;
    }

    public override CarpObject Call(CarpObject[] args)
    {
        // check parameter length
        if (args.Length != this._parameters.Count)
            throw new CarpError.InvalidArgumentCount(args.Length, this._parameters.Count);
        
        // cast all args to their respective types
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].GetCarpType() == this._parameters.ElementAt(i).Value)
                continue;

            if (this._parameters.ElementAt(i).Value == AutoType.Instance)
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
            args[i] = args[i].CastEx(this._parameters.ElementAt(i).Value);
        }
        
        // invoke
        Scope scope = new(this._scope);
        for (int index = 0; index < args.Length; index++)
        {
            CarpObject obj = args[index];
            string name = this._parameters.ElementAt(index).Key;
            scope.Define(Signature.OfVariable(name), this._parameters.ElementAt(index).Value, obj);
        }

        CarpObject returnVal = CarpVoid.Instance;
        try
        {
            object? obj = this.Interpreter.Visit(this._block, scope);
            if (obj is CarpObject co)
                returnVal = co;
        }
        // catch (CarpError ce)
        // {
        //     ce.StackTrace.Add(new(this._interpreter, this._block.Start.Line));
        //     throw;
        // }
        catch (CarpFlowControlError.Return returnError)
        {
            returnVal = returnError.Value;
        }

        if (this.ReturnType == CarpVoid.Type)
            return CarpVoid.Instance;
        
        if (this.ReturnType == AutoType.Instance)
            return returnVal;

        if (returnVal == CarpVoid.Instance)
            throw new CarpError.VoidFromNonVoidFunction();

        if (returnVal.GetCarpType() != this.ReturnType)
            return returnVal.CastEx(this.ReturnType);

        return returnVal;
    }
    
    public CarpInternalFunc Bind(IScope scope) =>
        new(this.Interpreter, this.ReturnType, scope, this._parameters, this._block);
}
using Carp.interpreter;

namespace Carp.objects.types;

public class CarpDynamic : CarpObject
{
    private readonly CarpInterpreter _interpreter;
    private CarpClass _class;
    private Scope _scope;

    public CarpDynamic(CarpInterpreter interpreter, CarpClass carpClass, Scope scope)
    {
        this._interpreter = interpreter;
        this._class = carpClass;
        this._scope = scope;

        this._scope.Define(Signature.ThisVariable, carpClass, this);
    }

    private CarpObject? CallPrimitive(Signature signature, CarpObject[] args)
    {
        if (this._scope.Has(signature))
        {
            CarpObject f = this._scope.Get(signature);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            try
            {
                return func.Call(args);
            }
            catch (CarpError e)
            {
                e.AddStackFrame(new(this._interpreter, this._interpreter.CurrentLine));
                throw;
            }
        }

        return null;
    }

    public override CarpString String()
    {
        return this.CallPrimitive(Signature.StringMethod, Array.Empty<CarpObject>())?.String() 
               ?? new($"instance of {this._class}");
    }

    public override CarpObject Property(Signature signature)
    {
        CarpObject? result = this.CallPrimitive(Signature.PropertyMethod, new[] { new CarpString(signature.Name) });
        
        if (result != null)
            return result;
        
        if (signature.Name != "init" && this._scope.Has(signature))
            return this._scope.Get(signature);

        throw new CarpError.InvalidProperty(signature);
    }

    public override CarpObject SetProperty(Signature signature, CarpObject value)
    {
        // if (this._scope.Has(Signature.SetPropertyMethod))
        // {
        //     CarpObject f = this._scope.Get(Signature.SetPropertyMethod);
        //     if (f is not CarpFunc func)
        //         throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
        //
        //     return func.Call(new[] { new CarpString(signature.Name), value });
        // }
        CarpObject? result = this.CallPrimitive(Signature.SetPropertyMethod, new[] { new CarpString(signature.Name), value });
        
        if (result != null)
            return result;

        if (signature.Name != "init")
            return this._scope.Set(signature, value);
        
        throw new CarpError.InvalidProperty(signature);
    }

    public override CarpObject Call(CarpObject[] args)
    {
        // if (this._scope.Has(Signature.CallMethod))
        // {
        //     CarpObject f = this._scope.Get(Signature.CallMethod);
        //     if (f is not CarpFunc func)
        //         throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
        //
        //     return func.Call(args);
        // }
        //
        // return base.Call(args);
        
        return this.CallPrimitive(Signature.CallMethod, args) ?? base.Call(args);
    }

    public override CarpObject Index(CarpObject[] args)
    {
        return this.CallPrimitive(Signature.IndexMethod, args) ?? base.Index(args);
    }

    public override CarpObject SetIndex(CarpObject[] args, CarpObject value)
    {
        // if (this._scope.Has(Signature.SetIndexMethod))
        // {
        //     CarpObject f = this._scope.Get(Signature.SetIndexMethod);
        //     if (f is not CarpFunc func)
        //         throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
        //
        //     return func.Call(new[] { args[0], value });
        // }
        //
        // return base.SetIndex(args, value);
        
        return this.CallPrimitive(Signature.SetIndexMethod, new[] { args[0], value }) ?? base.SetIndex(args, value);
    }

    public override CarpObject Add(CarpObject other)
    {
        // if (this._scope.Has(Signature.AddMethod))
        // {
        //     CarpObject f = this._scope.Get(Signature.AddMethod);
        //     if (f is not CarpFunc func)
        //         throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
        //
        //     return func.Call(new[] { other });
        // }
        //
        // return base.Add(other);
        
        return this.CallPrimitive(Signature.AddMethod, new[] { other }) ?? base.Add(other);
    }

    public override CarpObject Subtract(CarpObject other)
    {
        // if (this._scope.Has(Signature.SubtractMethod))
        // {
        //     CarpObject f = this._scope.Get(Signature.SubtractMethod);
        //     if (f is not CarpFunc func)
        //         throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
        //
        //     return func.Call(new[] { other });
        // }
        //
        // return base.Subtract(other);
        
        return this.CallPrimitive(Signature.SubtractMethod, new[] { other }) ?? base.Subtract(other);
    }

    public override CarpObject Multiply(CarpObject other)
    {
        // if (this._scope.Has(Signature.MultiplyMethod))
        // {
        //     CarpObject f = this._scope.Get(Signature.MultiplyMethod);
        //     if (f is not CarpFunc func)
        //         throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
        //
        //     return func.Call(new[] { other });
        // }
        //
        // return base.Multiply(other);
        
        return this.CallPrimitive(Signature.MultiplyMethod, new[] { other }) ?? base.Multiply(other);
    }

    public override CarpObject Divide(CarpObject other)
    {
        // if (this._scope.Has(Signature.DivideMethod))
        // {
        //     CarpObject f = this._scope.Get(Signature.DivideMethod);
        //     if (f is not CarpFunc func)
        //         throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
        //
        //     return func.Call(new[] { other });
        // }
        //
        // return base.Divide(other);
        
        return this.CallPrimitive(Signature.DivideMethod, new[] { other }) ?? base.Divide(other);
    }

    public override CarpObject Modulus(CarpObject other)
    {
        // if (this._scope.Has(Signature.ModulusMethod))
        // {
        //     CarpObject f = this._scope.Get(Signature.ModulusMethod);
        //     if (f is not CarpFunc func)
        //         throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
        //
        //     return func.Call(new[] { other });
        // }
        //
        // return base.Modulus(other);
        
        return this.CallPrimitive(Signature.ModulusMethod, new[] { other }) ?? base.Modulus(other);
    }
    
    public override CarpBool Less(CarpObject other)
    {
        // if (this._scope.Has(Signature.LessMethod))
        // {
        //     CarpObject f = this._scope.Get(Signature.LessMethod);
        //     if (f is not CarpFunc func)
        //         throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
        //
        //     return func.Call(new[] { other }).Less(CarpBool.True);
        // }
        //
        // return base.Less(other);

        return this.CallPrimitive(Signature.LessMethod, new[] { other })?.Match(CarpBool.True) ?? base.Less(other);
    }
    
    public override CarpBool Greater(CarpObject other)
    {
        // if (this._scope.Has(Signature.GreaterMethod))
        // {
        //     CarpObject f = this._scope.Get(Signature.GreaterMethod);
        //     if (f is not CarpFunc func)
        //         throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
        //
        //     return func.Call(new[] { other }).Greater(CarpBool.True);
        // }
        //
        // return base.Greater(other);
        
        return this.CallPrimitive(Signature.GreaterMethod, new[] { other })?.Match(CarpBool.True) ?? base.Greater(other);
    }

    public override CarpObject Pow(CarpObject other)
    {
        // if (this._scope.Has(Signature.PowMethod))
        // {
        //     CarpObject f = this._scope.Get(Signature.PowMethod);
        //     if (f is not CarpFunc func)
        //         throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
        //
        //     return func.Call(new[] { other });
        // }
        //
        // return base.Pow(other);
        
        return this.CallPrimitive(Signature.PowMethod, new[] { other }) ?? base.Pow(other);
    }

    public override CarpBool Match(CarpObject other)
    {
        // if (this._scope.Has(Signature.MatchMethod))
        // {
        //     CarpObject f = this._scope.Get(Signature.MatchMethod);
        //     if (f is not CarpFunc func)
        //         throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
        //
        //     return func.Call(new[] { other }).Match(CarpBool.True);
        // }
        //
        // return base.Match(other);
        
        return this.CallPrimitive(Signature.MatchMethod, new[] { other })?.Match(CarpBool.True) ?? base.Match(other);
    }

    public override CarpObject Step()
    {
        // if (this._scope.Has(Signature.StepMethod))
        // {
        //     CarpObject f = this._scope.Get(Signature.StepMethod);
        //     if (f is not CarpFunc func)
        //         throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
        //
        //     return func.Call(Array.Empty<CarpObject>());
        // }
        //
        // return base.Step();
        
        return this.CallPrimitive(Signature.StepMethod, Array.Empty<CarpObject>()) ?? base.Step();
    }

    public override CarpObject Negate()
    {
        // if (this._scope.Has(Signature.NegateMethod))
        // {
        //     CarpObject f = this._scope.Get(Signature.NegateMethod);
        //     if (f is not CarpFunc func)
        //         throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
        //
        //     return func.Call(Array.Empty<CarpObject>());
        // }
        //
        // return base.Negate();
        
        return this.CallPrimitive(Signature.NegateMethod, Array.Empty<CarpObject>()) ?? base.Negate();
    }

    public override CarpIterator Iterate()
    {
        // if (this._scope.Has(Signature.IterateMethod))
        // {
        //     CarpObject f = this._scope.Get(Signature.IterateMethod);
        //     if (f is not CarpFunc func)
        //         throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
        //
        //     return func.Call(Array.Empty<CarpObject>()).Iterate();
        // }
        //
        // return base.Iterate();
        
        return this.CallPrimitive(Signature.IterateMethod, Array.Empty<CarpObject>())?.Iterate() ?? base.Iterate();
    }


    public override CarpType GetCarpType() => this._class;
}
using Carp.interpreter;

namespace Carp.objects.types;

public class CarpDynamic : CarpObject
{
    private CarpClass _class;
    private Scope _scope;

    public CarpDynamic(CarpClass carpClass, Scope scope)
    {
        this._class = carpClass;
        this._scope = scope;

        this._scope.Define(Signature.ThisVariable, carpClass, this);
    }

    public override CarpString String()
    {
        if (this._scope.Has(Signature.StringMethod))
        {
            CarpObject str = this._scope.Get(Signature.StringMethod);
            if (str is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, str.GetCarpType());

            return func.Call(Array.Empty<CarpObject>()).String();
        }

        return new($"instance of {this._class}");
    }

    public override CarpObject Property(Signature signature)
    {
        if (this._scope.Has(Signature.PropertyMethod))
        {
            CarpObject f = this._scope.Get(Signature.PropertyMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(new CarpObject[] { new CarpString(signature.Name) });
        }
        else if (signature.Name != "init" && this._scope.Has(signature))
            return this._scope.Get(signature);

        throw new CarpError.InvalidProperty(signature);
    }

    public override CarpObject SetProperty(Signature signature, CarpObject value)
    {
        if (this._scope.Has(Signature.SetPropertyMethod))
        {
            CarpObject f = this._scope.Get(Signature.SetPropertyMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(new[] { new CarpString(signature.Name), value });
        }
        else
            this._scope.Set(signature, value);

        return value;
    }

    public override CarpObject Call(CarpObject[] args)
    {
        if (this._scope.Has(Signature.CallMethod))
        {
            CarpObject f = this._scope.Get(Signature.CallMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(args);
        }

        return base.Call(args);
    }

    public override CarpObject Index(CarpObject[] args)
    {
        if (this._scope.Has(Signature.IndexMethod))
        {
            CarpObject f = this._scope.Get(Signature.IndexMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(args);
        }

        return base.Index(args);
    }

    public override CarpObject SetIndex(CarpObject[] args, CarpObject value)
    {
        if (this._scope.Has(Signature.SetIndexMethod))
        {
            CarpObject f = this._scope.Get(Signature.SetIndexMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(new[] { args[0], value });
        }

        return base.SetIndex(args, value);
    }

    public override CarpObject Add(CarpObject other)
    {
        if (this._scope.Has(Signature.AddMethod))
        {
            CarpObject f = this._scope.Get(Signature.AddMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(new[] { other });
        }

        return base.Add(other);
    }

    public override CarpObject Subtract(CarpObject other)
    {
        if (this._scope.Has(Signature.SubtractMethod))
        {
            CarpObject f = this._scope.Get(Signature.SubtractMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(new[] { other });
        }

        return base.Subtract(other);
    }

    public override CarpObject Multiply(CarpObject other)
    {
        if (this._scope.Has(Signature.MultiplyMethod))
        {
            CarpObject f = this._scope.Get(Signature.MultiplyMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(new[] { other });
        }

        return base.Multiply(other);
    }

    public override CarpObject Divide(CarpObject other)
    {
        if (this._scope.Has(Signature.DivideMethod))
        {
            CarpObject f = this._scope.Get(Signature.DivideMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(new[] { other });
        }

        return base.Divide(other);
    }

    public override CarpObject Modulus(CarpObject other)
    {
        if (this._scope.Has(Signature.ModulusMethod))
        {
            CarpObject f = this._scope.Get(Signature.ModulusMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(new[] { other });
        }

        return base.Modulus(other);
    }
    
    public override CarpBool Less(CarpObject other)
    {
        if (this._scope.Has(Signature.LessMethod))
        {
            CarpObject f = this._scope.Get(Signature.LessMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(new[] { other }).Less(CarpBool.True);
        }

        return base.Less(other);
    }
    
    public override CarpBool Greater(CarpObject other)
    {
        if (this._scope.Has(Signature.GreaterMethod))
        {
            CarpObject f = this._scope.Get(Signature.GreaterMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(new[] { other }).Greater(CarpBool.True);
        }

        return base.Greater(other);
    }

    public override CarpObject Pow(CarpObject other)
    {
        if (this._scope.Has(Signature.PowMethod))
        {
            CarpObject f = this._scope.Get(Signature.PowMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(new[] { other });
        }

        return base.Pow(other);
    }

    public override CarpBool Match(CarpObject other)
    {
        if (this._scope.Has(Signature.MatchMethod))
        {
            CarpObject f = this._scope.Get(Signature.MatchMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(new[] { other }).Match(CarpBool.True);
        }

        return base.Match(other);
    }

    public override CarpObject Step()
    {
        if (this._scope.Has(Signature.StepMethod))
        {
            CarpObject f = this._scope.Get(Signature.StepMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(Array.Empty<CarpObject>());
        }

        return base.Step();
    }

    public override CarpObject Negate()
    {
        if (this._scope.Has(Signature.NegateMethod))
        {
            CarpObject f = this._scope.Get(Signature.NegateMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(Array.Empty<CarpObject>());
        }

        return base.Negate();
    }

    public override CarpIterator Iterate()
    {
        if (this._scope.Has(Signature.IterateMethod))
        {
            CarpObject f = this._scope.Get(Signature.IterateMethod);
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());

            return func.Call(Array.Empty<CarpObject>()).Iterate();
        }

        return base.Iterate();
    }

    public override CarpType GetCarpType() => this._class;
}
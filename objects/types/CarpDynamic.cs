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
            
            return func.Call(new CarpObject[] {new CarpString(signature.Name)});
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
            
            return func.Call(new[] {new CarpString(signature.Name), value});
        }
        else
            this._scope.Set(signature, value);
        
        return value;
    }

    public override CarpType GetCarpType() => this._class;
}
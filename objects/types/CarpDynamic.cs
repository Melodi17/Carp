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

        this._scope.Define("this", carpClass, this);
    }

    public override CarpString String()
    {
        if (this._scope.Has("string"))
        {
            CarpObject str = this._scope.Get("string");
            if (str is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, str.GetCarpType());

            return func.Call(Array.Empty<CarpObject>()).String();
        }

        return new($"instance of {this._class}");
    }

    public override CarpObject Property(string name)
    {
        if (this._scope.Has("property"))
        {
            CarpObject f = this._scope.Get("property");
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
            
            return func.Call(new CarpObject[] {new CarpString(name)});
        }
        else if (this._scope.Has(name))
            return this._scope.Get(name);
        
        throw new CarpError.InvalidProperty(name);
    }
    
    public override CarpObject SetProperty(string name, CarpObject value)
    {
        if (this._scope.Has("set_property"))
        {
            CarpObject f = this._scope.Get("set_property");
            if (f is not CarpFunc func)
                throw new CarpError.InvalidType(CarpFunc.Type, f.GetCarpType());
            
            return func.Call(new CarpObject[] {new CarpString(name), value});
        }
        else
            this._scope.Set(name, value);
        
        return value;
    }

    public override CarpType GetCarpType() => this._class;
}
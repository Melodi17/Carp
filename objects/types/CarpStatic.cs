using Carp.interpreter;

namespace Carp.objects.types;

public class CarpStatic : CarpObject
{
    public static CarpType Type = NativeType.Of<CarpEnum>("static");
    public override CarpType GetCarpType() => Type;
    private IScope _scope;
    public string _name;
    public CarpStatic(string name)
    {
        this._name = name;
        this._scope = new Scope();
    }

    public CarpStatic(string name, IScope scope)
    {
        this._name = name;
        this._scope = scope;
    }

    public override CarpString String() => new(this._name);
    public override CarpBool Match(CarpObject other)
    {
        if (other is not CarpStatic en)
            throw new CarpError.InvalidType(CarpStatic.Type, other.GetCarpType());

        return CarpBool.Of(this._name == en._name);   
    }

    public override CarpObject Property(string name)
    {
        if (this._scope.Has(new(name)))
            return this._scope.Get(new(name));
        
        throw new CarpError.InvalidProperty(name);
    }

    public override CarpObject SetProperty(string name, CarpObject value)
    {
        this._scope.Set(new(name), value);
        return value;
    }
    
    public void DefineProperty(string name, CarpType type, CarpObject value)
    {
        this._scope.Define(new(name), type, value);
    }
    
    public bool HasProperty(string name)
    {
        return this._scope.Has(name);
    }
}
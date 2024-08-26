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

    public override CarpObject Property(Signature signature)
    {
        if (this._scope.Has(signature))
            return this._scope.Get(signature);
        
        throw new CarpError.InvalidProperty(signature);
    }

    public override CarpObject SetProperty(Signature signature, CarpObject value)
    {
        this._scope.Set(signature, value);
        return value;
    }
    
    public void DefineProperty(Signature signature, CarpType type, CarpObject value)
    {
        this._scope.Define(signature, type, value);
    }
    
    public bool HasProperty(Signature signature)
    {
        return this._scope.Has(signature);
    }

    public CarpEnum AddEnum(string name)
    {
        CarpEnum e = CarpEnum.Of(this, name);
        this.DefineProperty(Signature.OfVariable(name), CarpEnum.Type, e);
        return e;
    }

    public CarpEnum Enum(string name)
    {
        return (CarpEnum) this.Property(Signature.OfVariable(name));
    }
}
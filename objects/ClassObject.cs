namespace Carp.objects;

using exceptions;
using scoping;
using typing;

public class ClassObject : CarpObject
{
    private readonly CarpType _type;
    public ClassObject(CarpType type) : base(type)
    {
        this._type = type;
    }
    public override CarpType GetCarpType() => this._type;

    private T? GetOverload<T>(string name, CarpObject[] args, CarpType? coerce = null)
        where T : CarpObject
    {
        if (!TryMember($"_{name}", out Member? member))
            return null;
        
        if (member is not MethodMember methodMember)
            throw new RuntimeException($"Member '{name}' is not a method in class '{this._type.Name}'");

        var res = methodMember.Get(this).Call(args);
        res = coerce != null ? res.Coerce(coerce) : res;
        return res as T;
    }
    public override CarpString String()
        => GetOverload<CarpString>("string", [], CarpString.Type)
           ?? CarpString.Create($"<class instance {this._type.Name}>");
}
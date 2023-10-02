using System.Reflection;
using Carp.interpreter;

namespace Carp.objects.types;

public class CarpStatic : CarpType
{
    public static new CarpType Type = CarpType.Of<CarpStatic>(new("static"));
    
    public Scope Scope { get; }
    public Scope InstanceScope { get; }

    public CarpStatic(CarpStatic repr, Scope scope, Scope instanceScope, bool isStruct = false) : base(typeof(CarpStatic), repr.String(), isStruct)
    {
        this.Scope = scope;
        this.InstanceScope = instanceScope;
    }

    public override CarpObject Property(string name)
    {
        if (name == "new")
            return new CarpExternalFunc<CarpInstance>(this.Instantiate);
        
        return base.Property(name);
    }
    
    public CarpInstance Instantiate()
    {
        return new(this, this.InstanceScope);
    }
}

public class CarpInstance : CarpObject
{
    public CarpType Type { get; }
    
    public Scope Scope { get; }
    
    public CarpInstance(CarpType type, Scope scope)
    {
        this.Type = type;
        this.Scope = new(scope);

        foreach ((string key, (CarpType carpType, CarpObject carpObject)) in scope.GetValues())
        {
            if (carpObject.GetType().BaseType == typeof(CarpInternalFunc<>))
            {
                // Run .bind on the function
                MethodInfo method = carpObject.GetType().GetMethod("Bind")!;
                CarpObject bound = method.Invoke(carpObject, new object[] { this }) as CarpObject;
                this.Scope.Set(key, bound);
            }
        }
    }
    
    public override CarpObject Property(string name)
    {
        if (name == "type")
            return this.Type;
        else
            return this.Scope.Get(name);
    }

    public override CarpString String()
    {
        if (this.Scope.Has("string"))
        {
            CarpObject obj = this.Scope.Get("string").Call(new CarpObject[]{});
            if (obj is CarpString cs)
                return cs;
            else
                throw new CarpError.InvalidType(CarpString.Type, CarpType.GetType(obj));
        }
        else
            return new CarpString($"<instance of {this.Type.String().Native}>");
    }

    public override CarpType GetCarpType()
    {
        return this.Type;
    }
}
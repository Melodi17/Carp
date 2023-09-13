using Carp.objects.types;

namespace Carp.interpreter;

public class Scope : IScope, IDisposable
{
    public IScope? Parent { get; set; }
    public bool HasParent => this.Parent != null;
    
    private readonly Dictionary<string, (CarpType type, CarpObject obj)> _values = new();
    
    public Scope(IScope parent)
    {
        this.Parent = parent;
    }
    
    public Scope()
    {
        this.Parent = null;
    }
    
    public CarpObject Get(string name)
    {
        if (this._values.ContainsKey(name))
            return this._values[name].obj;
        else if (this.HasParent)
            return this.Parent!.Get(name);
        else
            throw new CarpError.ReferenceDoesNotExist(name);
    }
    
    public CarpType GetType(string name)
    {
        if (this._values.ContainsKey(name))
            return this._values[name].type;
        else if (this.HasParent)
            return this.Parent!.GetType(name);
        else
            throw new CarpError.ReferenceDoesNotExist(name);
    }
    
    public CarpObject Set(string name, CarpObject value)
    {
        if (this._values.ContainsKey(name))
        {
            var (type, _) = this._values[name];
            if (type != CarpType.GetType(value))
                throw new CarpError.InvalidType(type, CarpType.GetType(value));
            else
            {
                this._values[name] = (type, value);
                return value;
            }
        }
        else if (this.HasParent)
            return this.Parent!.Set(name, value);
        else
            throw new CarpError.ReferenceAssignedBeforeDefinition(name);
    }
    
    public CarpObject Define(string name, CarpType type, CarpObject value)
    {
        if (this._values.ContainsKey(name))
            throw new CarpError.ReferenceAlreadyDefined(name);
        
        if (this.HasParent && this.Parent!.Has(name))
            new CarpWarning.Shadowing(name).Warn();
        this._values[name] = (type, value);
        return value;
    }
    
    public bool Has(string name)
    {
        if (this._values.ContainsKey(name))
            return true;
        else if (this.HasParent)
            return this.Parent!.Has(name);
        else
            return false;
    }

    public void Dispose()
    {
        this._values.Clear();
    }

    public override string ToString() => "Scope{" + string.Join(", ", this._values.Select(x => $"{x.Key}: {x.Value.type}")) + "}";
}

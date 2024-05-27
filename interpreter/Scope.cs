using System.Diagnostics.CodeAnalysis;
using Carp.objects.types;

namespace Carp.interpreter;

public class Scope : IScope, IDisposable
{
    public IScope? Parent { get; set; }
    public bool HasParent => this.Parent != null;
    
    private readonly Dictionary<Signature, (CarpType type, CarpObject obj)> _values = new();
    
    public Scope(IScope parent)
    {
        this.Parent = parent;
    }
    
    public Scope()
    {
        this.Parent = null;
    }
    
    public List<Signature> GetAll() => this._values.Keys.ToList();
    public List<Signature> GetSpecifications(Signature name) => this._values.Keys.Where(name.Includes).ToList();

    private (CarpType type, CarpObject obj)? FindBySignature(Signature sig)
    {
        if (this._values.TryGetValue(sig, out (CarpType type, CarpObject obj) value))
            return value;
        
        // sig will be MORE generic
        return this._values.FirstOrDefault(x => sig.Includes(x.Key)).Value;
    }

    public CarpObject Get(Signature name)
    {
        CarpObject? obj = this.FindBySignature(name)?.obj;
        
        if (obj != null)
            return this._values[name].obj;
        
        if (this.HasParent)
            return this.Parent!.Get(name);
        
        throw new CarpError.ReferenceDoesNotExist(name.ToString());
    }
    
    public CarpType GetType(Signature name)
    {
        CarpType? type = this.FindBySignature(name)?.type;
        
        if (type != null)    
            return this._values[name].type;
        
        if (this.HasParent)
            return this.Parent!.GetType(name);
        
        throw new CarpError.ReferenceDoesNotExist(name.ToString());
    }
    
    public CarpObject Set(Signature name, CarpObject value)
    {
        if (this._values.ContainsKey(name))
        {
            var (type, _) = this._values[name];
            if (!type.Extends(value.GetCarpType()))
                throw new CarpError.InvalidType(type, value.GetCarpType());
            else
            {
                this._values[name] = (type, value);
                return value;
            }
        }
        else if (this.HasParent)
            return this.Parent!.Set(name, value);
        else
            throw new CarpError.ReferenceAssignedBeforeDefinition(name.ToString());
    }
    
    public CarpObject Define(Signature name, CarpType type, CarpObject value)
    {
        if (this._values.ContainsKey(name))
            throw new CarpError.ReferenceAlreadyDefined(name.ToString());
        
        // if (this.HasParent && this.Parent!.Has(name))
        //     new CarpWarning.Shadowing(name).Warn();
        
        this._values[name] = (type, value);
        return value;
    }
    
    public bool Has(Signature name)
    {
        if (this._values.ContainsKey(name))
            return true;
        else if (this.HasParent)
            return this.Parent!.Has(name);
        else
            return false;
    }
    
    public bool TryGet(Signature name, [NotNullWhen(true)] out CarpObject? value)
    {
        if (this._values.ContainsKey(name))
        {
            value = this._values[name].obj;
            return true;
        }

        if (this.HasParent)
            return this.Parent!.TryGet(name, out value);
        
        value = null;
        return false;
    }

    public void Dispose()
    {
        this._values.Clear();
    }


    public override string ToString() => "Scope{" + string.Join(", ", this._values.Select(x => $"{x.Key}: {x.Value.type}")) + "}";
}

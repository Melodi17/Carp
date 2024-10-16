using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Carp.objects.types;

namespace Carp.interpreter;

public class Scope : IScope, IDisposable, IEnumerable<KeyValuePair<Signature, (CarpType type, CarpObject obj)>>
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
        // return this._values.FirstOrDefault(x => sig.Includes(x.Key))?.Value;
        
        var result = this._values.FirstOrDefault(x => x.Key.Includes(sig));
        if (result.Key != null)
            return result.Value;
        
        return null;
    }

    public CarpObject Get(Signature name)
    {
        CarpObject? obj = this.FindBySignature(name)?.obj;

        if (obj != null)
            return obj;

        if (this.HasParent)
            return this.Parent!.Get(name);

        throw new CarpError.ReferenceDoesNotExist(name.ToString());
    }

    public CarpType GetType(Signature name)
    {
        CarpType? type = this.FindBySignature(name)?.type;

        if (type != null)
            return type;

        if (this.HasParent)
            return this.Parent!.GetType(name);

        throw new CarpError.ReferenceDoesNotExist(name.ToString());
    }
    public CarpObject SetLocal(Signature name, CarpObject value)
    {
        if (this._values.ContainsKey(name))
        {
            var (type, _) = this._values[name];
            if (!value.GetCarpType().Extends(type))
                value = value.CastEx(type);

            this._values[name] = (type, value);
        }
        else
            this._values[name] = (value.GetCarpType(), value);
        return value;
    }

    public CarpObject Set(Signature name, CarpObject value)
    {
        var result = this.FindBySignature(name);
        if (result != null)
        {
            var (type, _) = result.Value;
            // if (!type.Extends(value.GetCarpType()))
            //     throw new CarpError.InvalidType(type, value.GetCarpType());
            // else
            // {
            //     this._values[name] = (type, value);
            //     return value;
            // }
            
            if (!value.GetCarpType().Extends(type))
                value = value.CastEx(type);
            
            this._values[name] = (type, value);
            return value;
        }
        else if (this.HasParent)
            return this.Parent!.Set(name, value);
        else
            throw new CarpError.ReferenceAssignedBeforeDefinition(name.ToString());
    }

    public bool Has(Signature name)
    {
        if (this.FindBySignature(name) != null)
            return true;
        else if (this.HasParent)
            return this.Parent!.Has(name);
        else
            return false;
    }

    public bool TryGet(Signature name, [NotNullWhen(true)] out CarpObject? value)
    {
        var result = this.FindBySignature(name);
        if (result != null)
        {
            value = result.Value.obj;
            return true;
        }

        if (this.HasParent)
            return this.Parent!.TryGet(name, out value);

        value = null;
        return false;
    }

    public CarpObject Define(Signature name, CarpType type, CarpObject value)
    {
        if (this.FindBySignature(name) != null)
            throw new CarpError.ReferenceAlreadyDefined(name.ToString());

        this._values[name] = (type, value);
        return value;
    }

    public void Dispose()
    {
        this._values.Clear();
    }
    
    public IEnumerator<KeyValuePair<Signature, (CarpType type, CarpObject obj)>> GetEnumerator() =>
        this._values.GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    public override string ToString() =>
        "Scope{" + string.Join(", ", this._values.Select(x => $"{x.Key}: {x.Value.type}")) + "}";
}
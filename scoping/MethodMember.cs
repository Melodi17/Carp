namespace Carp.scoping;

using exceptions.impl;
using objects;
using objects.typing;

public class MethodMember : Member
{
    private readonly List<CarpFunction> _overloads;

    public MethodMember(string name, params CarpFunction[] overloads) : base(name, CarpFunction.Type)
    {
        this._overloads = overloads.ToList();
    }

    public override NativeFunction Get(CarpObject? self)
    {
        // Wrap dispatch into a new external func that selects the right overload
        return new NativeFunction(this.ResolveReturnType(), (_, args) => this.Dispatch(self, args));
    }

    private CarpObject Dispatch(CarpObject? self, CarpObject[] args)
    {
        foreach (CarpFunction overload in this._overloads)
        {
            if (overload.Accepts(args))
                return overload.Call(self, args);
        }

        throw new NoMatchingOverloadException(this.Name, args);
    }

    private CarpType ResolveReturnType()
        =>
            // Optional: union of return types, or just first
            this._overloads[0].ReturnType;
    public void Merge(MethodMember other)
    {
        // copy overloads from other to this
        foreach (CarpFunction? overload in other._overloads)
            this._overloads.Add(overload);

        this.Docstring ??= other.Docstring;
        this.Modifiers |= other.Modifiers;
    }
    
    public MethodMember Overload(CarpFunction overload)
    {
        this._overloads.Add(overload);
        return this;
    }
}
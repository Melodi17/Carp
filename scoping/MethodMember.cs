using Carp.exceptions.impl;
using Carp.objects;
using Carp.objects.typing;

namespace Carp.scoping;

public class MethodMember : Member
{
    private readonly List<CarpFunction> _overloads;

    public MethodMember(string name, CarpType type, params CarpFunction[] overloads)
        : base(name, type)
    {
        _overloads = overloads.ToList();
    }

    public override CarpObject Get(CarpObject? self)
    {
        // Wrap dispatch into a new external func that selects the right overload
        return new NativeFunction(ResolveReturnType(), args => Dispatch(self, args));
    }

    private CarpObject Dispatch(CarpObject? self, CarpObject[] args)
    {
        foreach (var overload in _overloads)
        {
            if (overload.Accepts(args))
                return overload.Call(self, args);
        }

        throw new NoMatchingOverloadException(this.Name, args);
    }

    private CarpType ResolveReturnType()
    {
        // Optional: union of return types, or just first
        return _overloads[0].ReturnType;
    }
}
using Carp.exceptions.impl;
using Carp.objects;

namespace Carp.scoping;

public class PropertyMember : Member
{
    private readonly Func<CarpObject, CarpObject> _getter;
    private readonly Action<CarpObject, CarpObject>? _setter;

    public PropertyMember(Modifiers modifiers, CarpType type, 
        Func<CarpObject, CarpObject> getter, Action<CarpObject, CarpObject>? setter = null)
        : base(modifiers, type)
    {
        this._getter = getter;
        this._setter = setter;
    }

    public override CarpObject Get(CarpObject self) => this._getter(self);
    public override void Set(CarpObject self, CarpObject value)
    {
        if (this._setter == null)
            throw new InvalidAssignmentTargetException($"Property is read-only");
        this._setter(self, value);
    }
}
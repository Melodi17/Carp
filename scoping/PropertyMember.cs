namespace Carp.scoping;

using exceptions.impl;
using objects;
using objects.typing;

public class PropertyMember : Member
{
    private Func<CarpObject?, CarpObject> _getter;
    private Action<CarpObject?, CarpObject>? _setter;

    public PropertyMember(string name, CarpType type, Func<CarpObject?, CarpObject> getter, Action<CarpObject?, CarpObject>? setter = null) : base(name, type)
    {
        this._getter = getter;
        this._setter = setter;
    }

    public PropertyMember(string name, CarpType type) : base(name, type) { }

    public PropertyMember Getter(Func<CarpObject?, CarpObject> getter)
    {
        this._getter = getter;
        return this;
    }

    public PropertyMember Setter(Action<CarpObject?, CarpObject> setter)
    {
        this._setter = setter;
        return this;
    }

    public override CarpObject Get(CarpObject? self) => this._getter(self).Coerce(this.Type);
    public override CarpObject Set(CarpObject? self, CarpObject value)
    {
        if (this._setter == null || this.Is(Modifiers.Final))
            throw new InvalidAssignmentTargetException($"Property '{this.Name}' is read-only");
        CarpObject valueCoerced = value.Coerce(this.Type);
        this._setter(self, valueCoerced);
        return valueCoerced;
    }
}
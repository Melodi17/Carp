using Carp.exceptions.impl;
using Carp.objects;
using Carp.objects.typing;

namespace Carp.scoping;

public class FieldMember : Member
{
    private CarpObject _value;

    public FieldMember(string name, CarpType type, CarpObject value)
        : base(name, type)
    {
        this._value = value.Coerce(type);
    }

    public override CarpObject Get(CarpObject? self) => this._value;
    public override CarpObject Set(CarpObject? self, CarpObject value)
    {
        if (this.Is(Modifiers.Final))
            throw new InvalidAssignmentTargetException($"Field '{Name}' is read-only");
        
        this._value = value.Coerce(this.Type);
        return this._value;
    }
    public override Member Clone() 
    {
        // Create a new instance of FieldMember with the same name, type, and value
        return new FieldMember(this.Name, this.Type, this._value);
    }
}
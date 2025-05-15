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
        this._value = value;
    }

    public override CarpObject Get(CarpObject? self) => this._value;
    public override void Set(CarpObject? self, CarpObject value)
    {
        if (this.Is(Modifiers.Final))
            throw new InvalidAssignmentTargetException($"Field is read-only");
       
        // TODO: check type
        
        this._value = value;
    }
}
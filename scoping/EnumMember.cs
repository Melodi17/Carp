namespace Carp.scoping;

using exceptions.impl;
using objects;
using objects.typing;

public class EnumMember : Member
{
    private readonly CarpEnum _type;
    public EnumMember(CarpEnum type) : base(type.Name, CarpType.Type)
    {
        this._type = type;
    }
    
    public override CarpObject Get(CarpObject? self) => this._type;

    public override CarpObject Set(CarpObject? self, CarpObject value)
        => throw new InvalidAssignmentTargetException($"Cannot set enum '{this.Name}'");
}
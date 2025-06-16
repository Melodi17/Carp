namespace Carp.scoping;

using exceptions.impl;
using objects;

public class ClassMember : Member
{
    private readonly Action _constructMembers;
    private readonly ClassType _type;
    private readonly string _variant;

    public ClassMember(string variant, ClassType type, Action constructMembers) : base(type.Name, type)
    {
        this._variant = variant;
        this._type = type;
        this._constructMembers = constructMembers;
        this._type.MemberReference = this;
    }

    public void ConstructMembers() => this._constructMembers();

    public override CarpObject Get(CarpObject? self) => this._type;

    public override CarpObject Set(CarpObject? self, CarpObject value)
        => throw new InvalidAssignmentTargetException($"Cannot set value of {this._variant} '{this.Name}'");
}
namespace Carp.objects;

using exceptions.impl;
using scoping;
using typing;

public class ClassType : CarpType
{
    public List<CarpType> Implements { get; }
    public CarpType Parent { get; }
    public ClassMember MemberReference { get; set; }

    public ClassType(string name, CarpType? parent, List<CarpType> implements) : base(name, parent ?? CarpObject.Type,
        [])
    {
        this.Parent = parent;
        this.Implements = implements;
    }

    public override CarpObject Instantiate(CarpObject[] args)
    {
        if (this.MemberReference.Is(Modifiers.Static))
            throw new IllegalInstantiationException(this, "Cannot instantiate a static class");

        ClassObject obj = new(this);
        if (!obj.MemberExists("new"))
            return obj;

        MethodMember m = obj.Member("new", this) as MethodMember;

        if (m == null)
            return obj;

        m.Get(obj).Call(args);
        return obj;
    }
}
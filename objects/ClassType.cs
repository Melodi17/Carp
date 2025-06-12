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
        if (!obj.TryMember("new", out Member? member))
            return obj;

        MethodMember methodMember = member as MethodMember;

        if (methodMember == null)
            return obj;

        methodMember.Get(obj).Call(args);
        return obj;
    }
}
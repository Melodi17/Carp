using Carp.exceptions;
using Carp.exceptions.impl;
using Carp.interpreter;
using Carp.objects.typing;
using Carp.scoping;

namespace Carp.objects;

public abstract class CarpObject
{
    public static readonly CarpType Type = CarpType.Create("obj", null)
        .Member(new PropertyMember("type", CarpType.Type)
            .Getter(x => x.GetCarpType())
            .With(Modifiers.None)
            .Doc("The type of this object"))
        .Member(new PropertyMember("string", CarpString.Type)
            .Getter(x => x.String())
            .With(Modifiers.None)
            .Doc("The string representation of this object"))
        .Build();
    public Scope Members { get; }

    public CarpObject()
    {
        this.Members = this.GetCarpType().Members.Clone();
    }

    public abstract CarpType GetCarpType();
    public abstract CarpString String();
    public virtual string Repr() => String().Value;

    public virtual CarpObject Add(CarpObject right) { throw new PrimitiveIncompatibleException("Add", this); }
    public virtual CarpObject Subtract(CarpObject right) { throw new PrimitiveIncompatibleException("Subtract", this); }
    public virtual CarpObject Multiply(CarpObject right) { throw new PrimitiveIncompatibleException("Multiply", this); }
    public virtual CarpObject Divide(CarpObject right) { throw new PrimitiveIncompatibleException("Divide", this); }
    public virtual CarpObject Power(CarpObject right) { throw new PrimitiveIncompatibleException("Power", this); }
    public virtual CarpObject Modulus(CarpObject right) { throw new PrimitiveIncompatibleException("Modulus", this); }

    public virtual CarpObject LeftShift(CarpObject right) { throw new PrimitiveIncompatibleException("LeftShift", this); }
    public virtual CarpObject RightShift(CarpObject right) { throw new PrimitiveIncompatibleException("RightShift", this); }

    public virtual CarpObject Negate() { throw new PrimitiveIncompatibleException("Negate", this); }
    public virtual CarpObject Not() { throw new PrimitiveIncompatibleException("Not", this); }
    public virtual CarpObject Equal(CarpObject right) { throw new PrimitiveIncompatibleException("Equal", this); }
    public virtual CarpObject NotEqual(CarpObject right) => Equal(right).Not();
    public virtual CarpObject Greater(CarpObject right) { throw new PrimitiveIncompatibleException("Greater", this); }
    public virtual CarpObject Less(CarpObject right) { throw new PrimitiveIncompatibleException("Less", this); }
    public virtual CarpObject GreaterEqual(CarpObject right) => CarpObject.LogicalOr(this.Greater(right), () => this.Equal(right));
    public virtual CarpObject LessEqual(CarpObject right) => CarpObject.LogicalOr(this.Less(right), () => this.Equal(right));

    public virtual CarpObject Call(CarpObject[] args) => throw new PrimitiveIncompatibleException("Call", this);
    public virtual CarpObject Index(CarpObject index) => throw new PrimitiveIncompatibleException("Index", this);
    public virtual CarpObject IndexSet(CarpObject index, CarpObject value) => throw new PrimitiveIncompatibleException("IndexSet", this);
    public virtual Member Member(string name, CarpObject? caller = null, bool meta = false)
    {
        Member member = this.Members.Find(name);

        if (this.IsAccessible(member, caller) || meta)
            return member;

        throw new MemberNotAccessibleException(this, name);
    }

    protected virtual bool IsAccessible(Member member, CarpObject? caller)
    {
        if (member.Is(Modifiers.Private))
            return this.Equals(caller);

        if (member.Is(Modifiers.Static))
            return false;

        return true;
    }


    public static bool IsTruthy(CarpObject obj)
    {
        if (obj is CarpBoolean boolean)
            return boolean.Value;

        if (obj is CarpNull)
            return false;

        return true;
    }

    public static CarpObject LogicalOr(CarpObject left, Func<CarpObject> right)
    {
        bool truthy = CarpObject.IsTruthy(left);
        return truthy ? left : right();
    }

    public static CarpObject LogicalAnd(CarpObject left, Func<CarpObject> right)
    {
        bool truthy = CarpObject.IsTruthy(left);
        return truthy ? right() : left;
    }

    public override bool Equals(object? obj)
    {
        if (obj is CarpObject co)
            return CarpObject.IsTruthy(this.Equal(co));

        return false;
    }

    public override string ToString() => this.Repr();
}
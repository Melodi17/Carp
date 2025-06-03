namespace Carp.objects;

using exceptions.impl;
using scoping;
using typing;

public abstract class CarpObject
{
    public static readonly CarpType Type = CarpType.Create("obj", null,
        t => t
            .Member(new PropertyMember("type", CarpType.Type).Getter(x => x.GetCarpType()).With(Modifiers.None).Doc("The type of this object"))
            .Member(new PropertyMember("string", CarpString.Type).Getter(x => x.String()).With(Modifiers.None).Doc("The string representation of this object")));

    public CarpObject(CarpType? type = null)
    {
        if (this.GetCarpType() != null || type != null)
            this.Members = (this.GetCarpType() ?? type).Members.Clone();
        else
            this.Members = new Scope();
    }
    public Scope Members { get; set; }

    public abstract CarpType GetCarpType();
    public abstract CarpString String();
    public virtual string Repr() => this.String().Value;

    public virtual CarpObject Add(CarpObject right) => throw new PrimitiveIncompatibleException("Add", this);
    public virtual CarpObject Subtract(CarpObject right) => throw new PrimitiveIncompatibleException("Subtract", this);
    public virtual CarpObject Multiply(CarpObject right) => throw new PrimitiveIncompatibleException("Multiply", this);
    public virtual CarpObject Divide(CarpObject right) => throw new PrimitiveIncompatibleException("Divide", this);
    public virtual CarpObject Power(CarpObject right) => throw new PrimitiveIncompatibleException("Power", this);
    public virtual CarpObject Modulus(CarpObject right) => throw new PrimitiveIncompatibleException("Modulus", this);

    public virtual CarpObject LeftShift(CarpObject right) => throw new PrimitiveIncompatibleException("LeftShift", this);
    public virtual CarpObject RightShift(CarpObject right) => throw new PrimitiveIncompatibleException("RightShift", this);

    public virtual CarpObject Negate() => throw new PrimitiveIncompatibleException("Negate", this);
    public virtual CarpObject Not() => throw new PrimitiveIncompatibleException("Not", this);
    public virtual CarpObject Equal(CarpObject right) => throw new PrimitiveIncompatibleException("Equal", this);
    public virtual CarpObject NotEqual(CarpObject right) => this.Equal(right).Not();
    public virtual CarpObject Greater(CarpObject right) => throw new PrimitiveIncompatibleException("Greater", this);
    public virtual CarpObject Less(CarpObject right) => throw new PrimitiveIncompatibleException("Less", this);
    public virtual CarpObject GreaterEqual(CarpObject right)
    {
        return CarpObject.LogicalOr(this.Greater(right), () => this.Equal(right));
    }
    public virtual CarpObject LessEqual(CarpObject right)
    {
        return CarpObject.LogicalOr(this.Less(right), () => this.Equal(right));
    }

    /// Call primitive is used to invoke the object as a function. This is done with the func(args) syntax.
    public virtual CarpObject Call(CarpObject[] args) => throw new PrimitiveIncompatibleException("Call", this);

    /// Index primitive is used to access an element of the object, like obj[index].
    public virtual CarpObject Index(CarpObject index) => throw new PrimitiveIncompatibleException("Index", this);

    /// IndexSet primitive is used to set an element of the object, like obj[index] = value.
    public virtual CarpObject IndexSet(CarpObject index, CarpObject value) => throw new PrimitiveIncompatibleException("IndexSet", this);

    /// <summary>
    ///     Accesses the object's scope member. This is used to find a member of the object, like obj.member.
    /// </summary>
    /// <param name="name">Name of member to find</param>
    /// <param name="caller">The current object attempting to call this</param>
    /// <param name="meta">Whether to bypass the access level requirements</param>
    /// <returns>Member if found</returns>
    /// <exception cref="MemberNotAccessibleException">Throws when can't find specified member</exception>
    public virtual Member Member(string name, CarpObject? caller = null, bool meta = false)
    {
        Member member = this.Members.Find(name, this);

        if (this.IsAccessible(member, caller) || meta)
            return member;

        throw new MemberNotAccessibleException(this, name);
    }

    public virtual CarpObject Rise() => throw new PrimitiveIncompatibleException("Rise", this);
    public virtual CarpObject Fall() => throw new PrimitiveIncompatibleException("Fall", this);

    protected virtual bool IsAccessible(Member member, CarpObject? caller)
    {
        if (member.Is(Modifiers.Private))
            return this.Equals(caller);

        if (member.Is(Modifiers.Static))
            return false;

        return true;
    }

    /// Returns whether the object is truthy or not.
    /// - true (boolean) ->
    /// <c>true</c>
    /// - false (boolean) ->
    /// <c>false</c>
    /// - null ->
    /// <c>false</c>
    /// - everything else ->
    /// <c>true</c>
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

    public virtual CarpObject Coerce(CarpType type)
    {
        if (this.GetCarpType() == type)
            return this;

        if (this.GetCarpType().Extends(type))
            return this;

        if (type == CarpVoid.Type || this.GetCarpType() == CarpVoid.Type)
            return CarpVoid.Instance;
        
        if (type == CarpString.Type)
            return this.String();

        throw new ConversionException(this.GetCarpType(), type);
    }

    /// ToString is a shortcut to requesting the object's representation, not its string value.
    public override string ToString() => this.Repr();
}
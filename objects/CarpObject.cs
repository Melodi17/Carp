using Carp.exceptions;

namespace Carp.objects;

public abstract class CarpObject
{
    public CarpType Type { get; }

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

    public static bool IsTruthy(CarpObject obj)
    {
        // TODO: implement bool and null
        if (obj is CarpBoolean boolean)
            return boolean.Value;
        //
        // if (obj is CarpNull)
        //     return false;

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
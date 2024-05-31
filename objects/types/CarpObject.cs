using Carp.interpreter;

namespace Carp.objects.types;

public abstract class CarpObject
{
    // public int RefCount = 0;
    public virtual CarpObject Add(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Add", this); }
    public virtual CarpObject Subtract(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Subtract", this); }
    public virtual CarpObject Multiply(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Multiply", this); }
    public virtual CarpObject Divide(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Divide", this); }
    public virtual CarpObject Pow(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Pow", this); }
    public virtual CarpObject Modulus(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Modulus", this); }
    
    public virtual CarpBool Match(CarpObject other)
    {
        CarpType t = other.GetCarpType();
        CarpType thisType = this.GetCarpType();

        if (!t.Extends(thisType))
            return CarpBool.False;

        return this == other ? CarpBool.True : CarpBool.False;
    }

    public virtual CarpObject Step() { throw new CarpError.PrimitiveIncompatible("Step", this); }
    public virtual CarpBool Greater(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Greater", this); }
    public virtual CarpBool Less(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Less", this); }
    public virtual CarpObject Negate() { throw new CarpError.PrimitiveIncompatible("Negate", this); }
    public virtual CarpIterator Iterate() { throw new CarpError.PrimitiveIncompatible("Iterate", this); }
    public virtual CarpObject Call(CarpObject[] args) { throw new CarpError.PrimitiveIncompatible("Call", this); }
    public virtual CarpObject Index(CarpObject[] args) { throw new CarpError.PrimitiveIncompatible("Index", this); }
    public virtual CarpObject SetIndex(CarpObject[] args, CarpObject value) { throw new CarpError.PrimitiveIncompatible("SetIndex", this); }

    public virtual CarpObject Property(Signature signature) { throw new CarpError.PrimitiveIncompatible("Property", this); }
    public virtual CarpObject SetProperty(Signature name, CarpObject value) { throw new CarpError.PrimitiveIncompatible("SetProperty", this); }
    
    public virtual CarpObject Cast(CarpType type)
    {
        // throw new CarpError.PrimitiveIncompatible("Cast", this);
        if (type == CarpObject.Type)
            return this;

        if (type == CarpString.Type)
            return this.String();

        throw new CarpError.InvalidCast(this, type);
    }
    
    public override bool Equals(object obj)
    {
        if (obj is CarpObject co)
            return this.Match(co).Native;

        return base.Equals(obj);
    }

    public abstract CarpString String();
    public virtual string Repr() => this.String().Native;
    public override string ToString() => this.Repr();

    public abstract CarpType GetCarpType();
    public static CarpType Type = NativeType.Of<CarpObject>("obj");
}

namespace Carp.objects.types;

public abstract class CarpObject
{
    public virtual CarpType GetCarpType() => CarpType.GetType(this.GetType());
    public virtual CarpObject Add(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Add", this); }
    public virtual CarpObject Subtract(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Subtract", this); }
    public virtual CarpObject Multiply(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Multiply", this); }
    public virtual CarpObject Divide(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Divide", this); }
    public virtual CarpObject Pow(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Pow", this); }
    public virtual CarpObject Modulus(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Modulus", this); }
    
    public virtual CarpBool Match(CarpObject other)
    {
        CarpType t = CarpType.GetType(other);
        CarpType thisType = CarpType.GetType(this.GetType());

        if (t != thisType)
            return CarpBool.False;

        return this == other ? CarpBool.True : CarpBool.False;
    }

    public virtual CarpObject Step() { throw new CarpError.PrimitiveIncompatible("Step", this); }
    public virtual CarpBool Greater(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Greater", this); }
    public virtual CarpBool Less(CarpObject other) { throw new CarpError.PrimitiveIncompatible("Less", this); }
    public virtual CarpObject Negate() { throw new CarpError.PrimitiveIncompatible("Negate", this); }
    public virtual CarpIterator<CarpObject> Iterate() { throw new CarpError.PrimitiveIncompatible("Iterate", this); }
    public virtual CarpObject Call(CarpObject[] args) { throw new CarpError.PrimitiveIncompatible("Call", this); }
    public virtual CarpObject Index(CarpObject[] args) { throw new CarpError.PrimitiveIncompatible("Index", this); }
    public virtual CarpObject SetIndex(CarpObject[] args, CarpObject value) { throw new CarpError.PrimitiveIncompatible("SetIndex", this); }

    public virtual CarpObject Property(string name) { throw new CarpError.PrimitiveIncompatible("Property", this); }
    public virtual CarpObject SetProperty(string name, CarpObject value) { throw new CarpError.PrimitiveIncompatible("SetProperty", this); }

    public T Cast<T>() where T : CarpObject => this.Cast(CarpType.GetType<T>()) as T;

    // TODO: Listen to Flags.ImplicitCast flag and make a cast helper
    public virtual CarpObject Cast(CarpType type)
    {
        // throw new CarpError.PrimitiveIncompatible("Cast", this);
        if (type == CarpObject.Type)
            return this;

        if (type == CarpString.Type)
            return this.String();

        throw new CarpError.InvalidCast(type);
    }

    public abstract CarpString String();
    public virtual string Repr() => this.String().Native;
    public override string ToString() => this.Repr();

    public static CarpType Type = CarpType.Of<CarpObject>(new("obj"));
}

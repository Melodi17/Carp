namespace Carp.objects;

using typing;

public class NativePolyObject : CarpObject
{
    private readonly NativePolyType _type;

    protected NativePolyObject(object? obj, NativePolyType type) : base(type)
    {
        this._type = type;
        this.NativeObject = obj;
    }
    public object? NativeObject { get; set; }

    public static NativePolyObject Create(object? obj, Type nativeType)
    {
        if (obj == null)
            return new NativePolyObject(null, NativePolyType.Create(nativeType));

        return new NativePolyObject(obj, NativePolyType.Create(nativeType));
    }

    public override CarpType GetCarpType() => this._type;
    public override CarpString String() => CarpString.Create(this.NativeObject?.ToString() ?? "null");
}
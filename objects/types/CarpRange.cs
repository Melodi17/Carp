using Carp.interpreter;

namespace Carp.objects.types;

public class CarpRange : CarpObject
{
    public static new CarpType Type = NativeType.Of<CarpRange>("range");
    public override CarpType GetCarpType() => Type.With(this._itemType);
    
    private CarpObject _start;
    private CarpObject _stop;

    private CarpType _itemType;
    
    [CarpGenericConstructor]
    public CarpRange(CarpType itemType, CarpObject start, CarpObject stop)
    {
        this._itemType = itemType;
        this._start = start.CastEx(itemType);
        this._stop = stop.CastEx(itemType);
    }

    public override CarpIterator Iterate()
    {
        IEnumerable<CarpObject> Iter()
        {
            CarpObject cur = this._start;
            while (cur.Less(this._stop).Native)
            {
                yield return cur;
                CarpObject t = cur.Step();
                if (!t.GetCarpType().Extends(this._itemType)) // Might wanna replace with a cast?
                    throw new CarpError.RangeNotCompatible(cur.GetCarpType());
                cur = t;
            }
        }

        return new CarpEnumerableIterator(this._itemType, Iter());
    }

    public override CarpObject Property(Signature signature)
    {
        return signature.Name switch
        {
            "start" => this._start,
            "stop" => this._stop,
            "length" => this._stop.Subtract(this._start),
            _ => throw new CarpError.InvalidProperty(signature),
        };
    }

    public override CarpObject Cast(CarpType type)
    {
        if (type.Extends(CarpCollection.Type) && type is GenericCarpType genericCarpType)
        {
            if (genericCarpType.SubTypes[0] == this._itemType)
                return this.Iterate().ToCollection();
        }

        return base.Cast(type);
    }

    public override CarpString String() 
        => new($"range<{this._itemType}>({this._start}..{this._stop})");
}

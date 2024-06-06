using Carp.interpreter;

namespace Carp.objects.types;

public class CarpRange : CarpObject
{
    public static new CarpType Type = NativeType.Of<CarpRange>("range");
    public override CarpType GetCarpType() => Type.With(this.ItemType);
    
    public CarpObject Start;
    public CarpObject Stop;

    public CarpType ItemType;
    
    [CarpGenericConstructor]
    public CarpRange(CarpType itemType, CarpObject start, CarpObject stop)
    {
        this.ItemType = itemType;
        this.Start = start.CastEx(itemType);
        this.Stop = stop.CastEx(itemType);
    }

    public override CarpIterator Iterate()
    {
        IEnumerable<CarpObject> Iter()
        {
            CarpObject cur = this.Start;
            while (cur.Less(this.Stop).Native)
            {
                yield return cur;
                CarpObject t = cur.Step();
                if (!t.GetCarpType().Extends(this.ItemType)) // Might wanna replace with a cast?
                    throw new CarpError.RangeNotCompatible(cur.GetCarpType());
                cur = t;
            }
        }

        return new CarpEnumerableIterator(this.ItemType, Iter());
    }

    public override CarpObject Property(Signature signature)
    {
        return signature.Name switch
        {
            "start" => this.Start,
            "end" => this.Stop,
            "length" => this.Stop.Subtract(this.Start),
            _ => throw new CarpError.InvalidProperty(signature),
        };
    }

    public override CarpObject Cast(CarpType type)
    {
        if (type.Extends(CarpCollection.Type) && type is GenericCarpType genericCarpType)
        {
            if (genericCarpType.SubTypes[0] == this.ItemType)
                return this.Iterate().ToCollection();
        }

        return base.Cast(type);
    }

    public override CarpString String() 
        => new($"range<{this.ItemType}>({this.Start}..{this.Stop})");
}

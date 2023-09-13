namespace Carp.objects.types;

public class CarpRange<T> : CarpObject
    where T : CarpObject
{
    public static new CarpType Type = CarpType.Of<CarpRange<T>>(
        new($"range<{CarpType.GetType<T>()
            .String().Native}>"));
    
    private T _start;
    private T _stop;
    
    public CarpRange(T start, T stop)
    {
        this._start = start;
        this._stop = stop;
    }

    public override CarpIterator<CarpObject> Iterate()
    {
        IEnumerable<CarpObject> Iter()
        {
            T cur = this._start;
            while (cur.Less(this._stop).Native)
            {
                yield return cur;
                if (cur.Step() is not T t)
                    throw new CarpError.RangeNotCompatible(CarpType.GetType(cur));
                cur = t;
            }
        }

        return new CarpEnumerableIterator<CarpObject>(Iter());
    }

    public override CarpString String() 
        => new($"{this._start}..{this._stop}");
}

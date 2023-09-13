namespace Carp.objects.types;

public abstract class CarpIterator<T> : CarpObject
    where T : CarpObject
{
    public static new CarpType Type = CarpType.Of<CarpIterator<T>>(
        new($"iterator<{CarpType.GetType<T>()
            .String().Native}>"));

    public abstract CarpBool HasNext();
    public abstract T Next();
    public abstract void Reset();

    public override CarpString String() 
        => new($"iterator<{CarpType.GetType<T>()
            .String().Native}>");
}

public class CarpFastIterator<T> : CarpIterator<T>
    where T : CarpObject
{
    public static new CarpType Type = CarpIterator<T>.Type;
    
    private Func<T> _next;
    private Func<CarpBool> _hasNext;
    private Action _reset;
    
    public CarpFastIterator(Func<T> next, Func<CarpBool> hasNext, Action reset)
    {
        this._next = next;
        this._hasNext = hasNext;
        this._reset = reset;
    }
    
    public override CarpBool HasNext() => this._hasNext();
    public override T Next() => this._next();
    public override void Reset() => this._reset();
}

public class CarpEnumerableIterator<T> : CarpIterator<T>
    where T : CarpObject
{
    public static new CarpType Type = CarpIterator<T>.Type;

    private IEnumerator<T> _enumerator;
    private bool _exhausted;

    public CarpEnumerableIterator(IEnumerable<T> enumerable)
    {
        this._enumerator = enumerable.GetEnumerator();
        this._enumerator.MoveNext();
    }

    public override T Next()
    {
        T value = this._enumerator.Current;
        this._exhausted = !this._enumerator.MoveNext();
        return value;
    }

    public override CarpBool HasNext() => CarpBool.Of(!this._exhausted);

    public override void Reset()
    {
        this._enumerator.Reset();
        this._enumerator.MoveNext();
    }
}
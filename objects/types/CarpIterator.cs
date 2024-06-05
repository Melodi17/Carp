namespace Carp.objects.types;

public abstract class CarpIterator : CarpObject
{
    public static new CarpType Type = NativeType.Of<CarpIterator>("iterator");
    public override CarpType GetCarpType() => Type.With(this._itemType);
    private CarpType _itemType;

    public abstract CarpBool HasNext();
    public abstract CarpObject Next();
    public abstract void Reset();

    public override CarpString String()
        => new($"iterator<{this._itemType.String().Native}>");

    public CarpIterator(CarpType itemType)
    {
        this._itemType = itemType;
    }
    
    public CarpCollection ToCollection()
    {
        List<CarpObject> list = new();
        while (this.HasNext().Native)
            list.Add(this.Next());
        return new CarpCollection(this._itemType, list.ToArray());
    }
}

public class CarpFastIterator : CarpIterator
{
    public static new CarpType Type = CarpIterator.Type;

    private Func<CarpObject> _next;
    private Func<CarpBool> _hasNext;
    private Action _reset;

    public CarpFastIterator(CarpType itemType, Func<CarpObject> next, Func<CarpBool> hasNext, Action reset) :
        base(itemType)
    {
        this._next = next;
        this._hasNext = hasNext;
        this._reset = reset;
    }

    public override CarpBool HasNext() => this._hasNext();
    public override CarpObject Next() => this._next();
    public override void Reset() => this._reset();
}

public class CarpEnumerableIterator : CarpIterator
{
    public static new CarpType Type = CarpIterator.Type;

    private IEnumerator<CarpObject> _enumerator;
    private bool _exhausted;

    public CarpEnumerableIterator(CarpType itemType, IEnumerable<CarpObject> enumerable) : base(itemType)
    {
        this._enumerator = enumerable.GetEnumerator();
        this._exhausted = !this._enumerator.MoveNext();
    }

    public override CarpObject Next()
    {
        CarpObject value = this._enumerator.Current;
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
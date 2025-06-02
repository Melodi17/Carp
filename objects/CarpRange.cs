namespace Carp.objects;

using typing;

public class CarpRange : CarpObject, IIterable
{
    public new static readonly CarpType Type = CarpType.Create("range", IIterable.Type);
    private readonly CarpType _itemType;
    public CarpRange(CarpType itemType, CarpObject start, CarpObject end) : base(CarpType.CreateGeneric(CarpRange.Type, itemType))
    {
        this.Start = start;
        this.End = end;
        this._itemType = itemType;
    }
    public CarpObject Start { get; }
    public CarpObject End { get; }

    public IEnumerable<CarpObject> GetIterator()
    {
        CarpObject current = this.Start;
        while (CarpObject.IsTruthy(current.Less(this.End)))
        {
            yield return current.Coerce(this._itemType);
            current = current.Step();
        }
    }
    public override CarpType GetCarpType() => CarpType.CreateGeneric(CarpRange.Type, this._itemType);
    public override CarpString String() => CarpString.Create($"range({this.Start.Repr()}, {this.End.Repr()})");

    public override CarpObject Coerce(CarpType type)
    {
        if (type.Extends(CarpCollection.Type))
        {
            CarpType itemType = type.TypeArguments[0];
            return new CarpCollection(itemType, this.GetIterator().Select(x => x.Coerce(itemType)));
        }

        return base.Coerce(type);
    }
}
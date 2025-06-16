namespace Carp.objects;

using exceptions.impl;
using scoping;
using typing;

public class CarpRange : CarpObject, IIterable
{
    public new static readonly CarpType Type = CarpType.Create("range", IIterable.Type,
        b => b
            .Member(new PropertyMember("start", CarpType.Auto).Getter<CarpRange>(x => x.Start ?? CarpNull.Instance))
            .Member(new PropertyMember("end", CarpType.Auto).Getter<CarpRange>(x => x.End ?? CarpNull.Instance)));
    private readonly CarpType _itemType;
    public CarpRange(CarpType itemType, CarpObject? start, CarpObject? end) : base(
        CarpType.CreateGeneric(CarpRange.Type, itemType))
    {
        this.Start = start;
        this.End = end;
        this._itemType = itemType;
    }
    public CarpObject? Start { get; }
    public CarpObject? End { get; }

    public IEnumerable<CarpObject> GetIterator()
    {
        if (this.End == null)
            throw new IllegalOperationException("Range must have an end value to be iterated on.");

        CarpObject current = this.Start ?? this._itemType.DefaultValue();
        while (CarpObject.IsTruthy(current.Less(this.End)))
        {
            yield return current.Coerce(this._itemType);
            current = current.Rise();
        }
    }
    public override CarpType GetCarpType() => CarpType.CreateGeneric(CarpRange.Type, this._itemType);
    public override CarpString String()
        => (this.Start == null, this.End == null) switch
        {
            (true, true) => CarpString.Create(".."),
            (false, true) => CarpString.Create($"{this.Start!.Repr()}.."),
            (true, false) => CarpString.Create($"..{this.End!.Repr()}"),
            (false, false) => CarpString.Create($"{this.Start!.Repr()}..{this.End!.Repr()}")
        };

    public override CarpObject Coerce(CarpType type) => CommonBehavior.CoerceIIterable(this, type) ?? base.Coerce(type);
}
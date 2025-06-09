namespace Carp.objects;

using System.Diagnostics;
using exceptions.impl;
using typing;

public class CarpRange : CarpObject, IIterable
{
    public new static readonly CarpType Type = CarpType.Create("range", IIterable.Type);
    private readonly CarpType _itemType;
    public CarpRange(CarpType itemType, CarpObject? start, CarpObject? end) : base(
        CarpType.CreateGeneric(CarpRange.Type, itemType))
    {
        this.Start = start;
        this.End = end;
        this._itemType = itemType;
        
        if (start == null && end == null)
            throw new IllegalOperationException("Range must have at least one value defined (start or end).");
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
        => (Start == null, End == null) switch
        {
            (true, true) => throw new UnreachableException("Both start and end of a range cannot be null."),
            (false, true) => CarpString.Create($"{this.Start!.Repr()}.."),
            (true, false) => CarpString.Create($"..{this.End!.Repr()}"),
            (false, false) => CarpString.Create($"{this.Start!.Repr()}..{this.End!.Repr()}")
        };

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
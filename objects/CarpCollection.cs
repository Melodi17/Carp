namespace Carp.objects;

using scoping;
using typing;

public class CarpCollection : CarpObject, IIterable
{
    public new static readonly CarpType Type = CarpType.Create("collection", IIterable.Type);
    private readonly CarpType _itemType;
    public CarpCollection(CarpType itemType, IEnumerable<CarpObject> items) : base(
        CarpType.CreateGeneric(CarpCollection.Type, itemType))
    {
        this._itemType = itemType;
        this.Items = items.ToList();
    }
    public List<CarpObject> Items { get; }

    public IEnumerable<CarpObject> GetIterator()
    {
        return this.Items.Select(item => item.Coerce(this._itemType));
    }
    public override CarpObject Index(CarpObject[] index)
        => CommonBehavior.Index(this, this.Items, this._itemType, index);

    public override CarpObject IndexSet(CarpObject[] index, CarpObject value)
        => CommonBehavior.IndexSet(this, this.Items, this._itemType, index, value);

    public override CarpType GetCarpType() => CarpType.CreateGeneric(CarpCollection.Type, this._itemType);
    public override CarpString String() => CarpString.Create(CommonBehavior.ReprArray(this.Items));

    public override CarpObject Coerce(CarpType type)
    {
        if (type.Extends(CarpCollection.Type))
        {
            CarpType itemType = type.TypeArguments[0];
            return new CarpCollection(itemType, this.Items.Select(x => x.Coerce(itemType)));
        }
        
        if (type.Extends(CarpString.Type) && this._itemType == CarpString.Type)
        {
            return CarpString.Create(
                string.Join("", this.Items.Select(x => ((CarpString)x).Value)));
        }

        return base.Coerce(type);
    }
}
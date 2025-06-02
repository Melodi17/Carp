namespace Carp.objects;

using scoping;
using typing;

public class CarpCollection : CarpObject, IIterable
{
    public new static readonly CarpType Type = CarpType.Create("collection", IIterable.Type,
        b => b.Member(new PropertyMember("length", CarpNumber.Type).Getter(x => CarpNumber.Create(((CarpCollection) x).Items.Count))));
    private readonly CarpType _itemType;
    public CarpCollection(CarpType itemType, IEnumerable<CarpObject> items) : base(CarpType.CreateGeneric(CarpCollection.Type, itemType))
    {
        this._itemType = itemType;
        this.Items = items.ToList();
    }
    public List<CarpObject> Items { get; }

    public IEnumerable<CarpObject> GetIterator()
    {
        return this.Items.Select(item => item.Coerce(this._itemType));
    }
    public override CarpType GetCarpType() => CarpType.CreateGeneric(CarpCollection.Type, this._itemType);
    public override CarpString String()
    {
        return CarpString.Create($"[" + $"{string.Join(", ", this.Items.Select(i => i.Repr()))}" + $"]");
    }

    public override CarpObject Coerce(CarpType type)
    {
        if (type.Extends(CarpCollection.Type))
        {
            CarpType itemType = type.TypeArguments[0];
            return new CarpCollection(itemType, this.Items.Select(x => x.Coerce(itemType)));
        }

        return base.Coerce(type);
    }
}
using System.Text;
using Carp.objects.typing;
using Carp.scoping;

namespace Carp.objects;

public class CarpCollection : CarpObject
{
    public static new readonly CarpType Type = CarpType.Create("collection", CarpObject.Type, b => b
        .Member(new PropertyMember("length", CarpNumber.Type)
            .Getter(x => CarpNumber.Create(((CarpCollection)x).Items.Count))));
    private readonly CarpType _itemType;
    public List<CarpObject> Items { get; }
    public CarpCollection(CarpType itemType, IEnumerable<CarpObject> items) : base(CarpType.CreateGeneric(Type, itemType))
    {
        this._itemType = itemType;
        this.Items = items.ToList();
    }
    public override CarpType GetCarpType() => CarpType.CreateGeneric(Type, this._itemType);
    public override CarpString String()
    {
        return CarpString.Create($"[" +
                                 $"{string.Join(", ", this.Items.Select(i => i.Repr()))}" +
                                 $"]");
    }

    public override CarpObject Coerce(CarpType type)
    {
        if (type.Extends(CarpCollection.Type))
        {
            CarpType itemType = type.TypeArguments[0];
            return new CarpCollection(itemType, Items.Select(x => x.Coerce(itemType)));
        }
        
        return base.Coerce(type);
    }
}
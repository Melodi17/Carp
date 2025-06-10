namespace Carp.objects;

using scoping;
using typing;

public class CarpCollection : CarpObject, IIterable
{
    public new static readonly CarpType Type = CarpType.Create("collection", IIterable.Type, b => b
        .Member(new MethodMember("add").Overload(new NativeConstrainedFunction(CarpCollection.Type, (self, args) =>
        {
            CarpCollection collection = (CarpCollection) self!;
            CarpObject item = args[0].Coerce(collection._itemType);
            collection.Items.Add(item);
            return self;
        }, [CarpObject.Type])))
        .Member(new MethodMember("remove").Overload(new NativeConstrainedFunction(CarpCollection.Type, (self, args) =>
        {
            CarpCollection collection = (CarpCollection) self!;
            CarpObject item = args[0].Coerce(collection._itemType);
            collection.Items.Remove(item);
            return self;
        }, [CarpObject.Type])))
        .Member(new MethodMember("clear").Overload(new NativeConstrainedFunction(CarpCollection.Type, (self, _) =>
        {
            CarpCollection collection = (CarpCollection) self!;
            collection.Items.Clear();
            return self;
        }, [])))
        .Member(new MethodMember("remove_at").Overload(new NativeConstrainedFunction(CarpCollection.Type, (self, args) =>
        {
            CarpCollection collection = (CarpCollection) self!;
            int index = ((CarpNumber) args[0]).ValueAsFull;
            if (index < 0)
                index += collection.Items.Count;
            if (index < 0 || index >= collection.Items.Count)
                throw new IndexOutOfRangeException("Index out of range for collection.");
            collection.Items.RemoveAt(index);
            return self;
        }, [CarpNumber.Type])))
        .Member(new MethodMember("contains").Overload(new NativeConstrainedFunction(CarpBoolean.Type, (self, args) =>
        {
            CarpCollection collection = (CarpCollection) self!;
            CarpObject item = args[0].Coerce(collection._itemType);
            return CarpBoolean.Create(collection.Items.Contains(item));
        }, [CarpObject.Type]))));
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
            return CarpString.Create(string.Join("", this.Items.Select(x => ((CarpString) x).Value)));
        }

        return base.Coerce(type);
    }
}
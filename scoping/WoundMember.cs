namespace Carp.scoping;

using objects;
using objects.typing;

public class WoundMember : Member
{
    private readonly IEnumerable<CarpObject> _items;
    private readonly IEnumerable<Member> _members;
    private readonly CarpType _type;
    private readonly IEnumerable<CarpObject>? _values;

    public WoundMember(
        string name,
        CarpType type,
        IEnumerable<Member> members,
        IEnumerable<CarpObject> items,
        IEnumerable<CarpObject>? values = null) : base(name, type)
    {
        this._type = type;
        this._members = members;
        this._items = items;
        this._values = values;
    }

    public override CarpObject Get(CarpObject? self)
    {
        if (this._values != null)
        {
            return new CarpWoundFilter(this._type, this._values,
                this._members.Zip(this._items).Select(m => m.First.Get(m.Second))).Select(x => x);
        }
        return new CarpWound(this._type, this._members.Zip(this._items).Select(m => m.First.Get(m.Second)));
    }

    public override CarpObject Set(CarpObject? self, CarpObject value)
    {
        if (this._values != null)
        {
            return new CarpWoundFilter(this._type, this._values,
                this._members.Zip(this._items).Select(m => m.First.Set(m.Second, value))).Select(x => x);
        }

        return new CarpWound(this._type, this._members.Zip(this._items).Select(m => m.First.Set(m.Second, value)));
    }
}
namespace Carp.objects;

using scoping;
using typing;

public class CarpWoundFilter : CarpWound
{
    private readonly IEnumerable<CarpObject> _filter;
    public CarpWoundFilter(
        CarpType itemType,
        IEnumerable<CarpObject> items,
        IEnumerable<CarpObject>? filter = null) : base(itemType, items)
    {
        this._filter = filter ?? items;
    }

    public override CarpWound Select(Func<CarpObject, CarpObject> selector)
    {
        IEnumerable<(CarpObject First, CarpObject Second)> filteredItems =
            this
                .Items.Zip(this._filter)
                .Select(x => (x.First, Second: selector(x.Second)))
                .Where(x => CarpObject.IsTruthy(x.Second))
                .ToArray();

        return new CarpWoundFilter(this._itemType, filteredItems.Select(x => x.First),
            filteredItems.Select(x => x.Second));
    }

    public override CarpString String() => base.String();
    public override Member Member(string name, CarpObject? caller = null, bool meta = false)
    {
        if (this.Items.Count() == 0)
            return CarpNull.Instance.Member(name, caller, meta);
        CarpType itemType = this.Items.First().Member(name, caller, meta).Type;
        return new WoundMember(name, itemType,
            this._filter.Select(item => item.Member(name, caller, meta)), this._filter, this.Items);
    }
}
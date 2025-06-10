namespace Carp.objects;

using scoping;
using typing;

public class CarpWound : CarpObject, IIterable
{
    public new static readonly CarpType Type = CarpType.Create("wound", IIterable.Type);
    protected readonly CarpType _itemType;
    public CarpWound(CarpType itemType, IEnumerable<CarpObject> items) : base(
        CarpType.CreateGeneric(CarpWound.Type, itemType))
    {
        this._itemType = itemType;
        this.Items = items;
    }
    public IEnumerable<CarpObject> Items { get; }

    public IEnumerable<CarpObject> GetIterator()
    {
        return this.Items;
    }
    public override CarpType GetCarpType()
        => CarpType.CreateGeneric(CarpWound.Type, this._itemType);
    public override CarpString String()
    {
        return CarpString.Create($"wound({string.Join(", ", this.Items.Select(i => i.Repr()))})");
    }

    public override CarpObject Coerce(CarpType type)
    {
        if (type.Extends(CarpCollection.Type))
        {
            CarpType itemType = type.TypeArguments[0];
            return new CarpCollection(itemType, this.Items);
        }

        return base.Coerce(type);
    }

    public virtual CarpWound Select(Func<CarpObject, CarpObject> selector)
    {
        return new CarpWound(this._itemType, this.Items.Select(selector));
    }

    public override CarpObject Add(CarpObject right) => Select(x => x.Add(right));
    public override CarpObject Subtract(CarpObject right) => this.Select(x => x.Subtract(right));
    public override CarpObject Multiply(CarpObject right) => this.Select(x => x.Multiply(right));
    public override CarpObject Divide(CarpObject right) => this.Select(x => x.Divide(right));
    public override CarpObject Power(CarpObject right) => this.Select(x => x.Power(right));
    public override CarpObject Modulus(CarpObject right) => this.Select(x => x.Modulus(right));
    public override CarpObject LeftShift(CarpObject right) => this.Select(x => x.LeftShift(right));
    public override CarpObject RightShift(CarpObject right) => this.Select(x => x.RightShift(right));
    public override CarpObject Negate() => this.Select(x => x.Negate());
    public override CarpObject Not() => this.Select(x => x.Negate());
    public override CarpObject Equal(CarpObject right) => this.Select(x => x.Equal(right));
    public override CarpObject NotEqual(CarpObject right) => this.Select(x => x.NotEqual(right));
    public override CarpObject Greater(CarpObject right) => this.Select(x => x.Greater(right));
    public override CarpObject Less(CarpObject right) => this.Select(x => x.Less(right));
    public override CarpObject GreaterEqual(CarpObject right)
        => this.Select(x => x.GreaterEqual(right));
    public override CarpObject LessEqual(CarpObject right) => this.Select(x => x.LessEqual(right));
    public override CarpObject Call(CarpObject[] args) => this.Select(x => x.Call(args));
    public override CarpObject Index(CarpObject[] index) => this.Select(x => x.Index(index));
    public override CarpObject IndexSet(CarpObject[] index, CarpObject value)
        => this.Select(x => x.IndexSet(index, value));
    public override Member Member(string name, CarpObject? caller = null, bool meta = false)
    {
        if (this.Items.Count() == 0)
            return CarpNull.Instance.Member(name, caller, meta);
        CarpType itemType = this.Items.First().Member(name, caller, meta).Type;
        return new WoundMember(name, itemType,
            this.Items.Select(item => item.Member(name, caller, meta)), this.Items);
    }
    public override CarpObject Rise() => this.Select(x => x.Rise());
    public override CarpObject Fall() => this.Select(x => x.Fall());
}
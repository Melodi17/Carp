namespace Carp.objects.types;

public class CarpWinded : CarpObject
{
    public static new CarpType Type = CarpType.Of<CarpWinded>(new("winded"));

    private CarpObject _value;

    public CarpWinded(CarpObject value)
    {
        this._value = value;
    }
    
    private CarpCollection<T> CollectAll<T>(Func<CarpObject, T> func)
        where T : CarpObject
    {
        // Run d on all elements of this._value
        CarpIterator<CarpObject> iter = this._value.Iterate();
        List<CarpObject> result = new();

        while (iter.HasNext().Native)
        {
            CarpObject src = iter.Next();
            CarpObject o = func(src);
            result.Add(o);
        }
        
        return new(result.ToArray());
    }


    private CarpBool All(CarpCollection<CarpBool> collection) => CarpBool.Of(collection.Native.All(x => x.Native));

    public override CarpObject Add(CarpObject other) => this.CollectAll(o => o.Add(other));

    public override CarpObject Subtract(CarpObject other) => this.CollectAll(o => o.Subtract(other));

    public override CarpObject Multiply(CarpObject other) => this.CollectAll(o => o.Multiply(other));

    public override CarpObject Divide(CarpObject other) => this.CollectAll(o => o.Divide(other));

    public override CarpObject Pow(CarpObject other) => this.CollectAll(o => o.Pow(other));

    public override CarpObject Modulus(CarpObject other) => this.CollectAll(o => o.Modulus(other));

    public override CarpBool Match(CarpObject other) => this.All(this.CollectAll(o => o.Match(other)));

    public override CarpObject Step() => this.CollectAll(o => o.Step());

    public override CarpBool Greater(CarpObject other) => this.All(this.CollectAll(o => o.Greater(other)));

    public override CarpBool Less(CarpObject other) => this.All(this.CollectAll(o => o.Less(other)));

    public override CarpObject Negate() => this.CollectAll(o => o.Negate());

    public override CarpIterator<CarpObject> Iterate()
    {
        // runiterate on all elements of this._value
        CarpCollection<CarpIterator<CarpObject>> result = this.CollectAll(o => o.Iterate());
        IEnumerable<CarpObject> Iter()
        {
            foreach (CarpIterator<CarpObject> iter in result.Native)
            {
                while (iter.HasNext().Native)
                {
                    yield return iter.Next();
                }
            }
        }
        
        return new CarpEnumerableIterator<CarpObject>(Iter());
    }

    public override CarpObject Call(CarpObject[] args) => this.CollectAll(o => o.Call(args));

    public override CarpObject Index(CarpObject[] args) => this.CollectAll(o => o.Index(args));

    public override CarpObject SetIndex(CarpObject[] args, CarpObject value) => this.CollectAll(o => o.SetIndex(args, value));

    public override CarpObject Property(string name) => this.CollectAll(o => o.Property(name));

    public override CarpObject SetProperty(string name, CarpObject value) => this.CollectAll(o => o.SetProperty(name, value));

    public override CarpObject Cast(CarpType type) => this.CollectAll(o => o.Cast(type));
    
    public override CarpString String() => this._value.String().Add(new CarpString("::")) as CarpString;
}
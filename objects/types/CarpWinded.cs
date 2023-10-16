using Carp.interpreter;

namespace Carp.objects.types;

public class CarpWinded : CarpObject
{
    public static new CarpType Type = NativeType.Of<CarpWinded>("winded");
    public override CarpType GetCarpType() => Type;

    private CarpObject _value;

    public CarpWinded(CarpObject value)
    {
        this._value = value;
    }
    
    private CarpCollection CollectAll<T>(Func<CarpObject, T> func)
        where T : CarpObject
    {
        // Run d on all elements of this._value
        CarpIterator iter = this._value.Iterate();
        List<CarpObject> result = new();

        while (iter.HasNext().Native)
        {
            CarpObject src = iter.Next();
            CarpObject o = func(src);
            result.Add(o);
        }
        // TODO: Should this really be so generic???
        return new(CarpObject.Type, result.ToArray());
    }


    private CarpBool All(CarpCollection collection) => CarpBool.Of(collection.Native.All(x => (x.CastEx(CarpBool.Type) as CarpBool)!.Native));

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

    public override CarpIterator Iterate()
    {
        // runiterate on all elements of this._value
        CarpCollection result = this.CollectAll(o => o.Iterate());
        IEnumerable<CarpObject> Iter()
        {
            foreach (CarpIterator iter in result.Native)
            {
                while (iter.HasNext().Native)
                {
                    yield return iter.Next();
                }
            }
        }
        
        return new CarpEnumerableIterator(CarpObject.Type, Iter());
    }

    public override CarpObject Call(CarpObject[] args) => this.CollectAll(o => o.Call(args));

    public override CarpObject Index(CarpObject[] args) => this.CollectAll(o => o.Index(args));

    public override CarpObject SetIndex(CarpObject[] args, CarpObject value) => this.CollectAll(o => o.SetIndex(args, value));

    public override CarpObject Property(string name) => this.CollectAll(o => o.Property(name));

    public override CarpObject SetProperty(string name, CarpObject value) => this.CollectAll(o => o.SetProperty(name, value));

    public override CarpObject Cast(CarpType type) => this.CollectAll(o => o.Cast(type));
    
    public override CarpString String() => this._value.String().Add(new CarpString("::")) as CarpString;
}
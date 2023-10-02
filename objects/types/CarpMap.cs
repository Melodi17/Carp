using System.Text;

namespace Carp.objects.types;

public class CarpMap<TK, TV> : CarpObject 
    where TK : CarpObject
    where TV : CarpObject
{
    public static new CarpType Type = CarpType.Of<CarpMap<TK, TV>>(
        CarpType.GetType<TK>()
                .String()
                .Add(new CarpString(":"))
                .Add(CarpType.GetType<TV>()
                    .String())
            as CarpString);

    private Dictionary<TK, TV> _value;
    
    public CarpMap()
    {
        this._value = new();
    }

    public CarpMap(Dictionary<TK, TV> value)
    {
        this._value = value;
    }

    public CarpMap(Dictionary<CarpObject, CarpObject> srcMap)
    {
        this._value = srcMap.ToDictionary(k => k.Key as TK,
            v => v.Value as TV);
    }

    public CarpMap(CarpObject[] keys, CarpObject[] values)
    {
        this._value = new();
        for (int i = 0; i < keys.Length; i++)
        {
            // Throw if TK null
            this._value.Add(keys[i] as TK, values[i] as TV);
        }
    }

    public override CarpIterator<CarpObject> Iterate() 
        => new CarpEnumerableIterator<CarpObject>(this._value.Keys.ToArray());

    public override CarpObject Index(CarpObject[] args)
    {
        if (args.Length != 1)
            throw new CarpError.InvalidParameterCount(1, args.Length);

        if (args[0] is not TK)
            args[0] = args[0].Cast<TK>();

        TK index = (args[0] as TK)!;
        if (!this._value.ContainsKey(index))
            throw new CarpError.KeyNotPresent(index);

        return this._value[index];
    }

    public override CarpObject SetIndex(CarpObject[] args, CarpObject value)
    {
        if (args.Length != 1)
            throw new CarpError.InvalidParameterCount(1, args.Length);

        if (args[0] is not TK)
            args[0] = args[0].Cast<TK>();

        TK index = (args[0] as TK)!;
        if (!this._value.ContainsKey(index))
            throw new CarpError.KeyNotPresent(index);

        if (value is TV t)
            this._value[index] = t;
        else
            this._value[index] = value.Cast<TV>();

        return value;
    }
    
    private CarpBool Contains(TK inner) => CarpBool.Of(this._value.ContainsKey(inner));

    private void Remove(TK index)
    {
        if (!this._value.ContainsKey(index))
            throw new CarpError.KeyNotPresent(index);

        this._value.Remove(index);
    }
    private void Clear() => this._value.Clear();

    public override CarpObject Property(string name)
    {
        return name switch
        {
            "length" => new CarpInt(this._value.Count),
            "remove" => new CarpExternalFunc<CarpVoid>(this.Remove),
            "clear" => new CarpExternalFunc<CarpVoid>(this.Clear),
            "contains" => new CarpExternalFunc<CarpBool>(this.Contains),
            _ => throw new CarpError.InvalidProperty(name),
        };
    }

    public override CarpString String()
    {
        StringBuilder sb = new();
        sb.Append('[');
        sb.Append(string.Join(", ", this._value.Select(x => $"{x.Key}: {x.Value}")));
        sb.Append(']');
        return new(sb.ToString());
    }
}
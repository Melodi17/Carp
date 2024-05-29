using System.Text;
using Carp.interpreter;

namespace Carp.objects.types;

public class CarpMap : CarpObject 
{
    public static new CarpType Type = NativeType.Of<CarpMap>("map");
    public override CarpType GetCarpType() => Type.With(this._keyType, this._valueType);

    private Dictionary<CarpObject, CarpObject> _value;
    private readonly CarpType _keyType;
    private readonly CarpType _valueType;
    
    public CarpMap()
    {
        this._value = new();
    }

    public CarpMap(CarpType keyType, CarpType valueType, Dictionary<CarpObject, CarpObject> value)
    {
        this._keyType = keyType;
        this._valueType = valueType;
        this._value = value.ToDictionary(x => x.Key.CastEx(keyType), x => x.Value.CastEx(valueType));
    }
    
    public CarpMap(CarpType keyType, CarpType valueType)
    {
        this._keyType = keyType;
        this._valueType = valueType;
        this._value = new();
    }

    public CarpMap(CarpType keyType, CarpType valueType, CarpObject[] keys, CarpObject[] values)
    {
        this._keyType = keyType;
        this._valueType = valueType;

        this._value = new();
        for (int i = 0; i < keys.Length; i++)
        {
            // Throw if TK null
            if (keys[i] is CarpNull)
                throw new CarpError.CastNullToStruct(this._keyType);
            
            CarpObject key = keys[i].CastEx(this._keyType);
            CarpObject value = values[i].CastEx(this._valueType);
            this._value.Add(key, value);
        }
    }

    public override CarpIterator Iterate() 
        => new CarpEnumerableIterator(this._keyType, this._value.Keys.ToArray());

    public override CarpObject Index(CarpObject[] args)
    {
        if (args.Length != 1)
            throw new CarpError.InvalidParameterCount(1, args.Length);
        
        CarpObject index = args[0].CastEx(this._keyType);
        if (!this._value.ContainsKeySlow(index))
            throw new CarpError.KeyNotPresent(index);

        return this._value.GetValueSlow(index);
    }

    public override CarpObject SetIndex(CarpObject[] args, CarpObject value)
    {
        if (args.Length != 1)
            throw new CarpError.InvalidParameterCount(1, args.Length);

        CarpObject index = args[0].CastEx(this._keyType);
        // if (!this._value.ContainsKeySlow(index))
        //     throw new CarpError.KeyNotPresent(index);
        // The fuck is this doing here?

        this._value.SetValueSlow(index, value.CastEx(this._valueType));

        return value;
    }
    
    private CarpBool Contains(CarpObject inner) => CarpBool.Of(this._value.ContainsKeySlow(inner));

    private void Remove(CarpObject index)
    {
        if (!this._value.ContainsKeySlow(index))
            throw new CarpError.KeyNotPresent(index);

        this._value.RemoveSlow(index);
    }
    private void Clear() => this._value.Clear();

    public override CarpObject Property(Signature signature)
    {
        return signature.Name switch
        {
            "length" => new CarpInt(this._value.Count),
            "remove" => new CarpExternalFunc(CarpVoid.Type, this.Remove),
            "clear" => new CarpExternalFunc(CarpVoid.Type, this.Clear),
            "contains" => new CarpExternalFunc(CarpBool.Type, this.Contains),
            _ => throw new CarpError.InvalidProperty(signature),
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
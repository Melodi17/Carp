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

    public override CarpString String()
    {
        StringBuilder sb = new();
        sb.Append('[');
        sb.Append(string.Join(", ", this._value.Select(x => $"{x.Key}: {x.Value}")));
        sb.Append(']');
        return new(sb.ToString());
    }
}
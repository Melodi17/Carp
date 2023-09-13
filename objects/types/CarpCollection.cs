using System.Text;

namespace Carp.objects.types;

public class CarpCollection<T> : CarpObject where T : CarpObject
{
    public static new CarpType Type = CarpType.Of<CarpCollection<T>>(
        CarpType.GetType<T>()
                .String()
                .Add(new CarpString("*"))
            as CarpString);

    private List<T> _value;

    public CarpCollection()
    {
        this._value = new();
    }

    public CarpCollection(List<T> value)
    {
        this._value = value;
    }

    public CarpCollection(CarpObject[] srcArr)
    {
        this._value = srcArr.Select(x => x as T).ToList();
    }

    public override CarpIterator<CarpObject> Iterate() => new CarpEnumerableIterator<CarpObject>(this._value);

    public override CarpString String()
    {
        StringBuilder sb = new();
        sb.Append('[');
        sb.Append(string.Join(", ", this._value.Select(x => x.Repr())));
        sb.Append(']');
        return new(sb.ToString());
    }
}
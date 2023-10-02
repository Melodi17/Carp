using System.Collections;
using System.Text;

namespace Carp.objects.types;

public class CarpCollection<T> : CarpObject
    where T : CarpObject
{
    public static new CarpType Type = CarpType.Of<CarpCollection<T>>(
        CarpType.GetType<T>()
                .String()
                .Add(new CarpString("*"))
            as CarpString);

    private List<T> _value;
    public List<T> Native => this._value;
    

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

    public override CarpIterator<CarpObject> Iterate() 
        => new CarpEnumerableIterator<CarpObject>(this._value);

    public override CarpObject Index(CarpObject[] args)
    {
        if (args.Length != 1)
            throw new CarpError.InvalidParameterCount(1, args.Length);

        if (args[0] is not CarpInt)
            args[0] = args[0].Cast<CarpInt>();

        int index = (args[0] as CarpInt)!.NativeInt;
        if (index < 0 || index >= this._value.Count)
            throw new CarpError.IndexOutOfRange(index);

        return this._value[index];
    }
    
    public override CarpObject SetIndex(CarpObject[] args, CarpObject value)
    {
        if (args.Length != 1)
            throw new CarpError.InvalidParameterCount(1, args.Length);

        if (args[0] is not CarpInt)
            args[0] = args[0].Cast<CarpInt>();

        int index = (args[0] as CarpInt)!.NativeInt;
        if (index < 0 || index >= this._value.Count)
            throw new CarpError.IndexOutOfRange(index);

        if (value is T t)
            this._value[index] = t;
        else
            this._value[index] = value.Cast<T>();

        return value;
    }


    private CarpBool Contains(T inner) => CarpBool.Of(this._value.Contains(inner));
    private CarpBool Within(CarpInt index) 
        => CarpBool.Of(index.NativeInt >= 0 && index.NativeInt < this._value.Count);
    
    private void Append(T item) => this._value.Add(item);
    private void Remove(T item) => this._value.Remove(item);
    private void RemoveAt(CarpInt indexObj)
    {
        int index = indexObj.NativeInt;
        if (index < 0 || index >= this._value.Count)
            throw new CarpError.IndexOutOfRange(index);
        
        this._value.RemoveAt(index);
    }

    private void Insert(CarpInt indexObj, T item)
    {
        int index = indexObj.NativeInt;
        if (index < 0 || index >= this._value.Count)
            throw new CarpError.IndexOutOfRange(index);
        
        this._value.Insert(index, item);
    }

    private void Clear() => this._value.Clear();


    public override CarpObject Property(string name)
    {
        return name switch
        {
            "length" => new CarpInt(this._value.Count),
            "append" => new CarpExternalFunc<CarpVoid>(this.Append),
            "remove" => new CarpExternalFunc<CarpVoid>(this.Remove),
            "remove_at" => new CarpExternalFunc<CarpVoid>(this.RemoveAt),
            "insert" => new CarpExternalFunc<CarpVoid>(this.Insert),
            "clear" => new CarpExternalFunc<CarpVoid>(this.Clear),
            "contains" => new CarpExternalFunc<CarpBool>(this.Contains),
            "within" => new CarpExternalFunc<CarpBool>(this.Within),
            _ => throw new CarpError.InvalidProperty(name),
        };
    }

    public override CarpObject Cast(CarpType type)
    {
        if (type == CarpObject.Type)
            return this;

        if (type == CarpString.Type)
            return this.String();
        
        if (type == CarpCollection<CarpObject>.Type)
            return new CarpCollection<CarpObject>(this._value.Select(x => x as CarpObject).ToList());

        if (type.Native.GetGenericTypeDefinition() == typeof(CarpCollection<>))
        {
            // try cast all the items to the arg type
            Type[] args = type.Native.GetGenericArguments();
            Type arg = args[0];
            
            List<CarpObject> casted = this._value
                .Select(item => item.GetType() == arg
                    ? item
                    : item.Cast(CarpType.GetType(arg)))
                .ToList();
            
            return Activator.CreateInstance(type.Native, 
                    new object[] { casted.ToArray() })
                as CarpObject;
        }

        throw new CarpError.InvalidCast(type);
    }

    public override CarpString String()
    {
        StringBuilder sb = new();
        sb.Append('[');
        sb.Append(string.Join(", ", this._value.Select(x => x.Repr())));
        sb.Append(']');
        return new(sb.ToString());
    }
}
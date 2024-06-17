using System.Collections;
using System.Text;
using Carp.interpreter;

namespace Carp.objects.types;

public class CarpCollection : CarpObject
{
    public static new CarpType Type = NativeType.Of<CarpCollection>("collection");
    public override CarpType GetCarpType() => Type.With(this._itemType);

    private readonly CarpType _itemType;
    private List<CarpObject> _value;
    public List<CarpObject> Native => this._value;

    [CarpGenericConstructor]
    public CarpCollection(CarpType itemType)
    {
        this._itemType = itemType;
        this._value = new();
    }
    
    [CarpGenericConstructor]
    public CarpCollection(CarpType itemType, CarpObject[] srcArr)
    {
        // TODO: Cast all
        this._itemType = itemType;
        this._value = srcArr.Select(x => x.CastEx(itemType)).ToList();
    }

    public override CarpIterator Iterate() 
        => new CarpEnumerableIterator(this._itemType, this._value);

    public override CarpObject Index(CarpObject[] args)
    {
        if (args.Length != 1)
            throw new CarpError.InvalidParameterCount(1, args.Length);
        
        if (args[0] is CarpRange range && range.ItemType == CarpInt.Type)
        {
            if (range.Start is not CarpInt start)
                throw new CarpError.InvalidType(CarpInt.Type, range.Start.GetCarpType());
            if (range.Stop is not CarpInt end)
                throw new CarpError.InvalidType(CarpInt.Type, range.Stop.GetCarpType());
            
            int count = end.NativeInt - start.NativeInt;
            return new CarpCollection(this._itemType, this._value.GetRange(start.NativeInt, count).ToArray());
        }
        
        if (args[0] is not CarpInt)
            args[0] = args[0].CastEx(CarpInt.Type);

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
            args[0] = args[0].CastEx(CarpInt.Type);

        int index = (args[0] as CarpInt)!.NativeInt;
        if (index < 0 || index >= this._value.Count)
            throw new CarpError.IndexOutOfRange(index);

        this._value[index] = value.CastEx(this._itemType);

        return value;
    }

    private CarpBool Contains(CarpObject inner) => CarpBool.Of(this._value.Contains(inner));
    private CarpBool Within(CarpInt index) 
        => CarpBool.Of(index.NativeInt >= 0 && index.NativeInt < this._value.Count);
    
    private void Append(CarpObject item) => this._value.Add(item);
    private void Remove(CarpObject item) => this._value.Remove(item);
    private void RemoveAt(CarpInt indexObj)
    {
        int index = indexObj.NativeInt;
        if (index < 0 || index >= this._value.Count)
            throw new CarpError.IndexOutOfRange(index);
        
        this._value.RemoveAt(index);
    }

    private void Insert(CarpInt indexObj, CarpObject item)
    {
        int index = indexObj.NativeInt;
        if (index < 0 || index >= this._value.Count)
            throw new CarpError.IndexOutOfRange(index);
        
        this._value.Insert(index, item);
    }

    private void Clear() => this._value.Clear();

    public override CarpObject Property(Signature signature)
    {
        return signature.Name switch
        {
            "length" => new CarpInt(this._value.Count),
            "append" => new CarpExternalFunc(CarpVoid.Type, this.Append),
            "remove" => new CarpExternalFunc(CarpVoid.Type, this.Remove),
            "removeat" => new CarpExternalFunc(CarpVoid.Type, this.RemoveAt),
            "insert" => new CarpExternalFunc(CarpVoid.Type, this.Insert),
            "clear" => new CarpExternalFunc(CarpVoid.Type, this.Clear),
            "contains" => new CarpExternalFunc(CarpBool.Type, this.Contains),
            "within" => new CarpExternalFunc(CarpBool.Type, this.Within),
            "first" => this._value.Count > 0 ? this._value[0] : CarpNull.Instance,
            "last" => this._value.Count > 0 ? this._value[^1] : CarpNull.Instance,
            _ => throw new CarpError.InvalidProperty(signature),
        };
    }

    public override CarpObject Cast(CarpType type)
    {
        if (type.Extends(CarpMap.Type) && type is GenericCarpType genericCarpType)
        {
            // if we are empty, convert to empty map
            
            if (this._value.Count == 0)
                return new CarpMap(genericCarpType.SubTypes[0], genericCarpType.SubTypes[1]);
        }
        
        if (type.Extends(CarpCollection.Type) && type is GenericCarpType genericCarpType1)
        {
            // TODO: Sort out this casting behaviour
            return new CarpCollection(genericCarpType1.SubTypes[0], this._value.ToArray());
        }
        // if (type == CarpCollection<CarpObject>.Type)
        //     return new CarpCollection<CarpObject>(this._value.Select(x => x as CarpObject).ToList());
        //
        // if (type.Native.GetGenericTypeDefinition() == typeof(CarpCollection<>))
        // {
        //     // try cast all the items to the arg type
        //     Type[] args = type.Native.GetGenericArguments();
        //     Type arg = args[0];
        //     
        //     List<CarpObject> casted = this._value
        //         .Select(item => item.GetType() == arg
        //             ? item
        //             : item.Cast(CarpType.GetType(arg)))
        //         .ToList();
        //     
        //     return Activator.CreateInstance(type.Native, 
        //             new object[] { casted.ToArray() })
        //         as CarpObject;
        // }

        return base.Cast(type);
    }

    public override CarpObject Add(CarpObject other)
    {
        // if its a collection, add all the items
        if (other is CarpCollection otherCollection)
        {
            if (otherCollection._itemType != this._itemType)
                throw new CarpError.InvalidOperation("Cannot add collections of different types");

            this._value.AddRange(otherCollection._value);
            return this;
        }
        
        // else incorrect type
        throw new CarpError.InvalidType(this.GetCarpType(), other.GetCarpType());
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
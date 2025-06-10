namespace Carp.utils;

using System.Collections;
using objects;
using objects.typing;

public static class Polygot
{
    public static CarpObject ObjFromNative(object? obj, Type? expectedType = null)
    {
        if (expectedType == typeof(void))
            return CarpVoid.Instance;
        
        if (obj is null)
            return CarpNull.Instance;

        if (obj is CarpObject carpObject)
            return carpObject;

        if (obj is string str)
            return CarpString.Create(str);

        if (obj is int i)
            return CarpNumber.Create(i);
        
        if (obj is byte t)
            return CarpNumber.Create(t);

        if (obj is double d)
            return CarpNumber.Create(d);

        if (obj is bool b)
            return CarpBoolean.Create(b);

        if (obj is IEnumerable<CarpObject> iterable)
        {
            IEnumerable<CarpObject> objs = iterable as CarpObject[] ?? iterable.ToArray();
            return new CarpCollection(CarpType.HighestCommonType(objs.Select(x => x.GetCarpType()).ToArray()),
                objs);
        }

        if (obj is IEnumerable enumerable)
        {
            CarpObject[] objs = enumerable
                .Cast<object>()
                .Select(x => Polygot.ObjFromNative(x))
                .ToArray();
            return new CarpCollection(CarpType.HighestCommonType(objs.Select(x => x.GetCarpType()).ToArray()), objs);
        }
        
        throw new NotSupportedException($"Unsupported type: {obj.GetType()}");
    }
    
    public static object? ObjToNative(CarpObject? obj, Type? t = null)
    {
        if (obj is null || obj is CarpNull)
            return null;
        
        if (obj is CarpVoid)
            return null;

        if (obj is CarpString carpString)
            return carpString.Value;

        if (obj is CarpNumber carpNumber)
            return carpNumber.ValueAsFraction;

        if (obj is CarpBoolean carpBoolean)
            return carpBoolean.Value;

        if (obj is CarpCollection collection)
        {
            if (t == null || t == typeof(object[]))
                return collection.Items.Select(x => Polygot.ObjToNative(x)).ToArray();
            else if (t.IsArray)
            {
                Type itemType = t.GetElementType()!;
                return Helpers.ConvertToTypedArray(itemType, collection.Items.Select(x => Polygot.ObjToNative(x, itemType)).ToArray());
            }
            else if (t.GetInterfaces().Contains(typeof(IEnumerable)))
            {
                Type itemType = t.GetGenericArguments().FirstOrDefault() ?? typeof(object);
                return collection.Items.Select(x => Polygot.ObjToNative(x, itemType)).ToList();
            }
            else
            {
                throw new NotSupportedException($"Unsupported collection type: {t}");
            }
        }
        
        throw new NotSupportedException($"Unsupported type: {obj.GetCarpType()}");
    }
    
    public static CarpType TypeFromNative(Type type)
    {
        if (type == typeof(string))
            return CarpString.Type;
        
        if (type == typeof(bool))
            return CarpBoolean.Type;

        if (type.IsArray || type.GetInterfaces().Contains(typeof(IEnumerable)))
            return CarpCollection.Type;

        if (type == typeof(void))
            return CarpVoid.Type;

        if (CarpNumber.Creators.Any(x => x.Value.native == type))
            return CarpNumber.Creators.First(x => x.Value.native == type).Value.Type;
        
        if (type == typeof(object))
            return CarpObject.Type;

        throw new NotSupportedException($"Unsupported native type: {type}");
    }
}
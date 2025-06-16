namespace Carp.objects;

using exceptions.impl;
using typing;

public static class CommonBehavior
{
    public static CarpObject Index(CarpObject self, List<CarpObject> items, CarpType itemType, CarpObject[] index)
    {
        if (index.Length != 1)
            throw new IllegalArgumentsException($"Index must be a single value, got {index.Length} values.");

        CarpObject idx = index[0];
        if (idx is CarpNumber number)
        {
            int idxValue = number.ValueAsFull;
            if (idxValue < 0)
                idxValue += items.Count;

            if (idxValue < 0 || idxValue >= items.Count)
                throw new BoundsExceededException(self, index);

            return items[idxValue].Coerce(itemType);
        }

        if (idx is CarpRange { Start: null, End: null })
            return self;

        if (idx is CarpRange range && range.GetCarpType().TypeArguments[0].Group == CarpNumber.Group)
        {
            int start = range.Start != null ? ((CarpNumber) range.Start).ValueAsFull : 0;
            int end = range.End != null ? ((CarpNumber) range.End).ValueAsFull : items.Count;

            if (start < 0)
                start += items.Count;
            if (end < 0)
                end += items.Count;

            if (start < 0 || end > items.Count || start >= end)
                throw new BoundsExceededException(self, index);

            return new CarpCollection(itemType, items.Skip(start).Take(end - start));
        }

        throw new IllegalArgumentsException($"Index must be a number or range, got {idx.GetCarpType().Name}.");
    }

    public static CarpObject IndexSet(
        CarpObject self,
        List<CarpObject> items,
        CarpType itemType,
        CarpObject[] index,
        CarpObject value)
    {
        if (index.Length != 1)
            throw new IllegalArgumentsException($"Index must be a single value, got {index.Length} values.");

        CarpObject idx = index[0];
        if (idx is CarpNumber number)
        {
            int idxValue = number.ValueAsFull;
            if (idxValue < 0)
                idxValue += items.Count;

            if (idxValue < 0 || idxValue >= items.Count)
                throw new BoundsExceededException(self, index);

            items[idxValue] = value.Coerce(itemType);
            return value;
        }

        if (idx is CarpRange { Start: null, End: null })
        {
            for (int i = 0; i < items.Count; i++)
                items[i] = value.Coerce(itemType);
            return value;
        }

        if (idx is CarpRange range && range.GetCarpType().TypeArguments[0].Group == CarpNumber.Group)
        {
            int start = range.Start != null ? ((CarpNumber) range.Start).ValueAsFull : 0;
            int end = range.End != null ? ((CarpNumber) range.End).ValueAsFull : items.Count;

            if (start < 0)
                start += items.Count;
            if (end < 0)
                end += items.Count;

            if (start < 0 || end > items.Count || start >= end)
                throw new BoundsExceededException(self, index);

            for (int i = start; i < end; i++)
                items[i] = value.Coerce(itemType);
            return value;
        }

        throw new IllegalArgumentsException($"Index must be a number, got {idx.GetCarpType().Name}.");
    }

    public static string ReprArray(IEnumerable<CarpObject> arr)
    {
        return $"[" + $"{string.Join(", ", arr.Select(i => i.Repr()))}" + $"]";
    }

    public static CarpCollection? CoerceIIterable(IIterable self, CarpType type)
    {
        if (type.Extends(CarpCollection.Type))
        {
            CarpType itemType = type.TypeArguments[0];
            return new CarpCollection(itemType, self.GetIterator().Select(x => x.Coerce(itemType)));
        }

        return null;
    }
}
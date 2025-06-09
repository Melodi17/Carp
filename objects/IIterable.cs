namespace Carp.objects;

using typing;

public interface IIterable
{
    public static readonly CarpType Type = CarpType.Create("iterable", CarpObject.Type);

    public IEnumerable<CarpObject> GetIterator();
}
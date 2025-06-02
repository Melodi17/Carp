namespace Carp.objects;

using typing;

public interface IIterable
{
    public new static readonly CarpType Type = CarpType.Create("iterable", CarpObject.Type);

    public IEnumerable<CarpObject> GetIterator();
}
namespace Carp.objects;

using scoping;
using typing;

public interface IIterable
{
    public new static readonly CarpType Type = CarpType.Create("iterable", CarpObject.Type);

    public abstract IEnumerable<CarpObject> GetIterator();
}
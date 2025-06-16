namespace Carp.objects;

using scoping;
using typing;

public interface IIterable
{
    public static readonly CarpType Type = CarpType.Create("iterable", CarpObject.Type,
        b => b
            .Member(new PropertyMember("first", CarpType.Auto).Getter(x => ((IIterable) x).GetIterator().First()))
            .Member(new PropertyMember("last", CarpType.Auto).Getter(x => ((IIterable) x).GetIterator().Last()))
            .Member(new PropertyMember("length", CarpNumber.Type).Getter(x
                => CarpNumber.Create(((IIterable) x).GetIterator().Count()))));

    public IEnumerable<CarpObject> GetIterator();
}
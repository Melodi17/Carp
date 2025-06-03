namespace Carp.scoping;

using exceptions.impl;
using objects;

public class Scope : IDisposable
{
    public Scope(Scope? parent = null)
    {
        this.Parent = parent;
    }
    public Dictionary<string, Member> Values { get; } = new();
    public Scope? Parent { get; }

    public void Dispose()
    {
        // TODO: implement IDisposable
    }

    /// <summary>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="owner">Owner is only relevant when member belongs to an object</param>
    /// <returns>Specified member if found</returns>
    /// <exception cref="ReferenceDoesNotExistException">
    ///     Thrown when a value can not be found in the scope, and the value has
    ///     no owner
    /// </exception>
    /// <exception cref="MemberNotFoundException">Thrown when a value can not be found in the scope, and the value has an owner</exception>
    public Member Find(string name, CarpObject? owner = null)
    {
        if (this.Values.TryGetValue(name, out Member? member))
            return member;

        if (this.Parent != null)
            return this.Parent.Find(name);

        if (owner == null)
            throw new ReferenceDoesNotExistException(name);
        throw new MemberNotFoundException(owner, name);
    }

    public bool TryFind(string name, out Member? member)
    {
        if (this.Values.TryGetValue(name, out member))
            return true;

        if (this.Parent != null)
            return this.Parent.TryFind(name, out member);

        member = null;
        return false;
    }

    public void Define(Member member)
    {
        if (!this.Values.TryAdd(member.Name, member))
            throw new ReferenceAlreadyDefinedException(member.Name);
    }
    public Scope Clone()
    {
        // TODO: check if the parent needs to be cloned
        Scope clone = new(this.Parent);
        foreach (KeyValuePair<string, Member> member in this.Values)
        clone.Define(member.Value.Clone());
        return clone;
    }
}
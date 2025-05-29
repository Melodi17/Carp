using Carp.exceptions.impl;
using Carp.objects;

namespace Carp.scoping;

public class Scope : IDisposable
{
    public Dictionary<string, Member> Values { get; } = new();
    public Scope? Parent { get; }

    public Scope(Scope? parent = null) => this.Parent = parent;

    public void Dispose()
    {
        // TODO: implement IDisposable
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="owner">Owner is only relevant when member belongs to an object</param>
    /// <returns>Specified member if found</returns>
    /// <exception cref="ReferenceDoesNotExistException">Thrown when a value can not be found in the scope, and the value has no owner</exception>
    /// <exception cref="MemberNotFoundException">Thrown when a value can not be found in the scope, and the value has an owner</exception>
    public Member Find(string name, CarpObject? owner = null)
    {
        if (this.Values.TryGetValue(name, out Member? member))
            return member;

        if (this.Parent != null)
            return this.Parent.Find(name);

        if (owner == null)
            throw new ReferenceDoesNotExistException(name);
        else
            throw new MemberNotFoundException(owner, name);
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
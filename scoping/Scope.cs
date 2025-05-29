using Carp.exceptions.impl;

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

    public Member Find(string name)
    {
        if (this.Values.TryGetValue(name, out Member? member))
            return member;

        if (this.Parent != null)
            return this.Parent.Find(name);

        throw new ReferenceDoesNotExistException(name);
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
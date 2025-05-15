using Carp.exceptions.impl;
using Carp.objects;
using Carp.objects.typing;

namespace Carp.scoping;

public abstract class Member
{
    public string Name { get; }
    public CarpType Type { get; }
    
    public Modifiers Modifiers { get; set; }
    
    public List<CarpObject> Annotations { get; set; }
    public string? Docstring { get; set; }
    
    public bool Is(Modifiers modifiers)
    {
        return (this.Modifiers & modifiers) == modifiers;
    }
    
    public Member With(Modifiers modifiers)
    {
        this.Modifiers |= modifiers;
        return this;
    }

    public Member Doc(string docstring)
    {
        this.Docstring = docstring;
        return this;
    }
    
    protected Member(string name, CarpType type)
    {
        this.Name = name;
        this.Type = type;
    }
    public abstract CarpObject Get(CarpObject? self);
    public virtual void Set(CarpObject self, CarpObject value) 
        => throw new InvalidAssignmentTargetException("Cannot set value of non-settable member");
    public Member Clone()
    {
        // Memberwise clone
        Member clone = (Member)this.MemberwiseClone();
        
        // Deep clone annotations
        clone.Annotations = new(this.Annotations);

        return clone;
    }
}
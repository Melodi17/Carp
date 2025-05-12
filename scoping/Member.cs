using Carp.exceptions.impl;
using Carp.objects;

namespace Carp.scoping;

[Flags]
public enum Modifiers
{
    None = 0, // No special modifiers
    Private = 1, // Inaccessible outside of the object
    Static = 2, // Accessed through the class, not the instance
    Protected = 4, // Implementations can't override this member
    Abstract = 8, // Must be implemented in a subclass
}

public abstract class Member
{
    public Modifiers Modifiers { get; }
    public CarpType Type { get; }
    // TODO: implement annotations
    // public CarpCollection Annotations { get; } = new(CarpObject.Type);
    public string? Docstring { get; set; }
    
    public bool Is(Modifiers modifiers)
    {
        return (this.Modifiers & modifiers) == modifiers;
    }
    
    protected Member(Modifiers modifiers, CarpType type)
    {
        this.Modifiers = modifiers;
        this.Type = type;
    }
    public abstract CarpObject Get(CarpObject self);
    public virtual void Set(CarpObject self, CarpObject value) 
        => throw new InvalidAssignmentTargetException("Cannot set value of non-settable member");
}
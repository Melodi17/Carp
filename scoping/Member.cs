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
        
        this.Modifiers = Modifiers.None;
        this.Docstring = null;
        this.Annotations = [];
    }
    /// <summary>
    /// Performs get operation on member
    /// </summary>
    /// <param name="self">Should be the object the member belongs to, or should be null when static context.</param>
    /// <returns>Result from get operation</returns>
    public abstract CarpObject Get(CarpObject? self);
    public virtual CarpObject Set(CarpObject? self, CarpObject value) 
        => throw new InvalidAssignmentTargetException($"Cannot set value of non-settable member '{Name}'");
    public virtual Member Clone()
    {
        // // Memberwise clone
        // Member clone = (Member)this.MemberwiseClone();

        // This is so child classes can override this method and return a new instance
        return this;
    }
}
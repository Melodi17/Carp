namespace Carp.interpreter;

public class Signature
{
    public static readonly Signature InitMethod = new("init");
    public static readonly Signature NewCall = new("new");

    private Signature(string name, string? specific = null)
    {
        this.Name = name;
        this.Specific = specific;
    }

    public static Signature OfVariable(string name) => new(name);

    public string Name { get; }
    public string? Specific { get; }

    public override string ToString()
    {
        return this.Specific == null ? this.Name : $"{this.Name}::{this.Specific}";
    }
    
    public bool Includes(Signature other)
    {
        return this.Name == other.Name && (this.Specific == null || this.Specific == other.Specific);
    }
    
    public Signature WithSpecific(string specific)
    {
        return new(this.Name, specific);
    }
    
    // comparisons
    public override bool Equals(object? obj)
    {
        if (obj is Signature sig)
            return this.Name == sig.Name && this.Specific == sig.Specific;
        return false;
    }
    
    public override int GetHashCode()
    {
        return this.Name.GetHashCode() + (this.Specific?.GetHashCode() ?? 0);
    }
}
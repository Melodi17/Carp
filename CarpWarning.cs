namespace Carp;

public abstract class CarpWarning : CarpError
{
    public string DisplayName => this.GetType().Name;
    public CarpWarning() : base("Warning occured in Carp runtime") { }
    public CarpWarning(string message) : base(message) { }
    private static readonly List<string> warnings = new();
    
    public string Key => $"{this.DisplayName}:{this.Message}";
    public void Warn()
    {
        if (warnings.Contains(this.Key))
            return;

        warnings.Add(this.Key);

        if (Flags.Instance.StrictWarnings)
            throw this;
        
        Console.WriteLine($"Warning: {this.Message}");
    }
    
    public class Shadowing : CarpWarning
    {
        public Shadowing(string name) : base($"Shadowing '{name}' in a parent scope") { }
    }
    
    public class Unused : CarpWarning
    {
        // TODO: Figure out how to detect unused variables
        public Unused(string name) : base($"Unused '{name}'") { }
    }
}

namespace Carp;

public class Flags
{
    public static readonly Flags Instance = new();
    
    public bool StrictWarnings = false;
    public bool ImplicitCasting = true;
    public bool DefaultNonStructs = true;
    public bool ForceThrow = false;
    public bool Debug = false;
    public bool LoadedFromFile;
    public string ExecutionContext;
}

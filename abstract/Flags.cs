namespace Carp;

public class Flags
{
    public static readonly Flags Instance = new();
    
    public bool TreatWarningsAsErrors = false;
    public bool ImplicitCasting = true;
    public bool DefaultNonStructs = true;
    public bool Debug = false;
    public bool LoadedFromFile;
    public string ExecutionContext;
}

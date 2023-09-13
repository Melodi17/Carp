namespace Carp;

public class Flags
{
    public static readonly Flags Instance = new();
    
    public bool TreatWarningsAsErrors = false;
    public bool Debug = false;
}

using Carp.objects.types;

namespace Carp.interpreter;

public interface IScope
{
    public CarpObject Get(string name);
    public CarpType GetType(string name);
    public CarpObject Set(string name, CarpObject value);
    public bool Has(string name);
    public CarpObject Define(string name, CarpType type, CarpObject value);
}
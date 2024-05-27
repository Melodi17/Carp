using System.Diagnostics.CodeAnalysis;
using Carp.objects.types;

namespace Carp.interpreter;

public interface IScope
{
    public CarpObject Get(Signature name);
    public List<Signature> GetSpecifications(Signature name);
    public List<Signature> GetAll();
    public bool TryGet(Signature name, [NotNullWhen(true)] out CarpObject? value);
    public CarpType GetType(Signature name);
    public CarpObject Set(Signature name, CarpObject value);
    public bool Has(Signature name);
    public CarpObject Define(Signature name, CarpType type, CarpObject value);
}
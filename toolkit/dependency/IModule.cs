namespace Carp.toolkit.dependency;

using Carp.scoping;

public interface IModule
{
    ILibrary Library { get; }
    string Namespace { get; }
    void Import(Scope scope);
}
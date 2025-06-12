namespace Carp.toolkit.dependency;

public interface ILibrary
{
    string Name { get; }
    IEnumerable<IModule> GetModules();
}
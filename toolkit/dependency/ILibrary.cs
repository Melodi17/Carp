namespace Carp.toolkit;

public interface ILibrary
{
    string Name { get; }
    IEnumerable<IModule> GetModules();
}
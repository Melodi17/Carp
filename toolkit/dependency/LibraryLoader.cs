namespace Carp.toolkit;

using exceptions;
using exceptions.impl;
using scoping;

public class LibraryLoader
{
    private Dictionary<string, IModule[]> _knownModules = new();
    public void Load(ILibrary library)
    {
        var loadedModules = library.GetModules()
            .GroupBy(x => x.Namespace)
            .ToDictionary(x => x.Key, x => x.ToArray());

        foreach (KeyValuePair<string, IModule[]> type in loadedModules)
        {
            if (this._knownModules.TryGetValue(type.Key, out IModule[]? module))
                throw new LibraryNamespaceConflictException(type.Key, type.Value.First(),
                    module.First());

            this._knownModules[type.Key] = type.Value;
        }
    }

    public void Import(Scope scope, string[] path)
    {
        IModule[] module = this.FindModules(path);
        
        foreach (IModule m in module)
            m.Import(scope);
    }

    public IModule[] FindModules(string[] path)
    {
        if (path.Last() == "*")
        {
            IModule[] foundTypes = this
                ._knownModules.Where(x => x.Key.StartsWith(string.Join(".", path[..^1])))
                .SelectMany(x => x.Value)
                .ToArray();

            if (foundTypes.Length == 0)
                throw new LibraryNotFoundException(path);

            return foundTypes;
        }

        if (path.Contains("*"))
            throw new RuntimeException("Wildcard '*' is not allowed in the middle of an import path, only at the end.");

        string ns = string.Join(".", path);
        if (!this._knownModules.TryGetValue(ns, out IModule[]? types))
            throw new LibraryNotFoundException(path);

        return types;
    }
}
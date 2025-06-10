namespace Carp.toolkit;

using System.Reflection;
using exceptions;
using exceptions.impl;
using objects;
using objects.typing;
using scoping;
using utils;

public class LibraryLoader
{
    private Dictionary<string, Type[]> _knownTypes = new();
    public void Load(LibraryMeta meta, Assembly asm)
    {
        var loadedTypes = asm
            .GetTypes()
            .Where(x => x.Namespace?.StartsWith(meta.StartNamespace) ?? false)
            .GroupBy(x => Formatting.FormatNamespace(x.Namespace![(meta.StartNamespace.Length + 1)..]))
            .ToDictionary(x => x.Key, x => x.ToArray());

        foreach (KeyValuePair<string, Type[]> type in loadedTypes)
        {
            if (_knownTypes.ContainsKey(type.Key))
                throw new LibraryNamespaceConflictException(type.Key, type.Value.First().Assembly,
                    _knownTypes[type.Key].First().Assembly);

            _knownTypes[type.Key] = type.Value;
        }
    }

    public void Import(Scope scope, string[] path)
    {
        Type[] types = this.FindTypes(path);

        foreach (Type type in types)
            scope.Define(new FieldMember(type.Name, CarpType.Type, new NativePolyType(type))
                .With(Modifiers.Final)
                .Doc(type.GetCustomAttribute<DocAttribute>()?.Text ?? ""));
    }

    public Type[] FindTypes(string[] path)
    {
        if (path.Last() == "*")
        {
            Type[] foundTypes = this
                ._knownTypes.Where(x => x.Key.StartsWith(string.Join(".", path[..^1])))
                .SelectMany(x => x.Value)
                .ToArray();

            if (foundTypes.Length == 0)
                throw new LibraryNotFoundException(path);

            return foundTypes;
        }

        if (path.Contains("*"))
            throw new RuntimeException("Wildcard '*' is not allowed in the middle of an import path, only at the end.");

        string ns = string.Join(".", path);
        if (!_knownTypes.TryGetValue(ns, out Type[]? types))
            throw new LibraryNotFoundException(path);

        return types;
    }
}

public class LibraryMeta
{
    public string StartNamespace;
}
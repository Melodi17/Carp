namespace Carp.toolkit.dependency.impl;

using System.Reflection;
using objects;
using objects.typing;
using scoping;
using utils;

public class NativeTypeModule(NativeLibrary library, string @namespace, Type type) : IModule
{
    public ILibrary Library => library;
    public string Namespace => @namespace;
    public void Import(Scope scope)
    {
        scope.Define(new FieldMember(type.GetFormattedName(), CarpType.Type, NativePolyType.Create(type))
            .With(Modifiers.Final)
            .Doc(type.GetCustomAttribute<DocAttribute>()?.Text ?? ""));
    }
}
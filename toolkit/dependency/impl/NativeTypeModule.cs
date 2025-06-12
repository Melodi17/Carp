namespace Carp.toolkit.dependency.impl;

using System.Reflection;
using Carp.objects;
using Carp.objects.typing;
using Carp.scoping;
using Carp.utils;

public class NativeTypeModule(NativeLibrary library, string @namespace, Type type) : IModule
{
    public ILibrary Library => library;
    public string Namespace => @namespace;
    public void Import(Scope scope)
    {
        scope.Define(new FieldMember(type.Name, CarpType.Type, NativePolyType.Create(type))
            .With(Modifiers.Final)
            .Doc(type.GetCustomAttribute<DocAttribute>()?.Text ?? ""));
    }
}
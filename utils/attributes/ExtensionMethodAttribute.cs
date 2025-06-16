namespace Carp.utils.attributes;

using objects.typing;

[AttributeUsage(AttributeTargets.Method)]
public class ExtensionMethodAttribute(CarpType baseType) : Attribute
{
    public CarpType BaseType { get; } = baseType;
}
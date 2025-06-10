namespace Carp.objects;

using System.Reflection;
using exceptions.impl;
using scoping;
using typing;
using utils;

public class NativePolyType : CarpType
{
    public Type NativeType { get; }

    public NativePolyType(Type nativeType) : base(nativeType.Name, CarpObject.Type, [])
    {
        this.NativeType = nativeType;

        foreach (var member in LoadMembers())
            this.Members.Define(member);
    }
    private IEnumerable<Member> LoadMembers()
    {
        foreach (var method in this
                     .NativeType.GetMethods(BindingFlags.Public | BindingFlags.Static)
                     .GroupBy(x => x.Name))
        {
            MethodMember member = new(Formatting.FormatMethod(method.Key));

            List<string?> docs = [];
            foreach (MethodInfo overload in method)
            {
                NativePolyFunction func = new(overload);
                member.Overload(func);
                docs.Add(overload.GetCustomAttribute<DocAttribute>()?.Text);
            }
            
            string doc = string.Join("\n", docs.Where(x => x != null));

            yield return member.Doc(doc).With(Modifiers.Static);
        }

        foreach (var property in this.NativeType.GetProperties(BindingFlags.Public | BindingFlags.Static))
        {
            string propName = Formatting.FormatProperty(property.Name);
            yield return new PropertyMember(propName, Polygot.TypeFromNative(property.PropertyType))
                .Getter(_ => Polygot.ObjFromNative(property.GetValue(null), property.PropertyType))
                .Setter((_, value) =>
                {
                    if (property.CanWrite)
                        property.SetValue(null, Polygot.ObjToNative(value, property.PropertyType));
                    else
                        throw new InvalidAssignmentTargetException($"Property '{propName}' is read-only");
                })
                .With(Modifiers.Static)
                .Doc(property.GetCustomAttribute<DocAttribute>()?.Text ?? "");
        }
    }

    public override CarpType GetCarpType() => CarpType.Type;
    public override CarpString String() => CarpString.Create($"<native poly type {this.NativeType.Name}>");
}
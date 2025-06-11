namespace Carp.objects;

using System.Reflection;
using exceptions.impl;
using scoping;
using typing;
using utils;

public class NativePolyType : CarpType
{
    public static readonly CarpType Type = CarpType.Create("NativePolyType", CarpObject.Type);
    public Type NativeType { get; }
    
    private static readonly Dictionary<Guid, NativePolyType> Cache = new();
    public static NativePolyType Create(Type nativeType)
    {
        if (NativePolyType.Cache.TryGetValue(nativeType.GUID, out NativePolyType? cached))
            return cached;

        NativePolyType polyType = new(nativeType);
        NativePolyType.Cache[nativeType.GUID] = polyType;
        return polyType;
    }

    protected NativePolyType(Type nativeType) : base(nativeType.Name, Type, [])
    {
        this.NativeType = nativeType;

        foreach (var member in LoadMembers())
            this.Members.Define(member);
    }
    private IEnumerable<Member> LoadMembers()
    {
        foreach (var method in this.NativeType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly).GroupBy(x => x.Name))
        {
            MethodMember member = new(Formatting.FormatMethod(method.Key));
            bool isStatic = method.Any(x => x.IsStatic);

            List<string?> docs = [];
            foreach (MethodInfo overload in method)
            {
                NativePolyFunction func = new(overload);
                member.Overload(func);
                docs.Add(overload.GetCustomAttribute<DocAttribute>()?.Text);
            }

            string doc = string.Join("\n", docs.Where(x => x != null));

            member.Doc(doc);

            if (isStatic)
                member.With(Modifiers.Static);

            yield return member;
        }

        foreach (var property in this.NativeType.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly))
        {
            string propName = Formatting.FormatProperty(property.Name);
            bool isStatic = property.GetAccessors(true).Any(x => x.IsStatic);

            Member member = new PropertyMember(propName, Polygot.TypeFromNative(property.PropertyType))
                .Getter(self =>
                {
                    object? inst = self != null ? Polygot.ObjToNative(self, property.DeclaringType) : null;
                    return Polygot.ObjFromNative(property.GetValue(inst), property.PropertyType);
                })
                .Setter((self, value) =>
                {
                    object? inst = self != null ? Polygot.ObjToNative(self, property.DeclaringType) : null;
                    if (property.CanWrite)
                        property.SetValue(inst, Polygot.ObjToNative(value, property.PropertyType));
                    else
                        throw new InvalidAssignmentTargetException($"Property '{propName}' is read-only");
                })
                .Doc(property.GetCustomAttribute<DocAttribute>()?.Text ?? "");

            if (isStatic)
                member.With(Modifiers.Static);

            yield return member;
        }
    }

    public override CarpType GetCarpType() => CarpType.Type;
    public override CarpString String() => CarpString.Create($"{this.NativeType.Name}");
}
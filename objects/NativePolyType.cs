namespace Carp.objects;

using System.Reflection;
using exceptions;
using exceptions.impl;
using scoping;
using typing;
using utils;
using utils.attributes;

public class NativePolyType : CarpType
{
    public static readonly CarpType Type = CarpType.Create("NativePolyType", CarpObject.Type);

    private static readonly Dictionary<Guid, NativePolyType> Cache = new();

    protected NativePolyType(Type nativeType) : base(nativeType.Name, GetBaseType(nativeType), [])
    {
        this.NativeType = nativeType;
    }
    private static CarpType GetBaseType(Type type)
    {
        return Polygot.TypeFromNative(type.BaseType ?? typeof(object));
    }
    public void Initialize()
    {
        foreach (Member member in this.LoadMembers())
            this.Members.Define(member);
    }
    public Type NativeType { get; }
    public static NativePolyType Create(Type nativeType)
    {
        if (NativePolyType.Cache.TryGetValue(nativeType.GUID, out NativePolyType? cached))
            return cached;

        NativePolyType polyType = new(nativeType);
        NativePolyType.Cache[nativeType.GUID] = polyType;
        polyType.Initialize();
        return polyType;
    }
    private IEnumerable<Member> LoadMembers()
    {
        foreach (IGrouping<string, MethodInfo> method in this
                     .NativeType.GetMethods(BindingFlags.Instance
                                            | BindingFlags.Static
                                            | BindingFlags.Public
                                            | BindingFlags.DeclaredOnly)
                     .GroupBy(x => x.Name))
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

        foreach (PropertyInfo property in this.NativeType.GetProperties(BindingFlags.Instance
                                                                        | BindingFlags.Static
                                                                        | BindingFlags.Public
                                                                        | BindingFlags.DeclaredOnly))
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

    public override CarpObject Instantiate(CarpObject[] args)
    {
        try
        {
            ConstructorInfo? constructor =
                this.NativeType.GetConstructors().FirstOrDefault(x => x.GetParameters().Length == args.Length);

            if (constructor == null)
                throw new IllegalInstantiationException(this, "No matching constructor found");

            object?[] parameters = args
                .Select((x, i) => Polygot.ObjToNative(x, constructor.GetParameters()[i].ParameterType))
                .ToArray();

            object? result = constructor.Invoke(parameters);

            return Polygot.ObjFromNative(result, this.NativeType);
        }
        catch (RuntimeException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"{ex.GetType().Name}, {ex.Message}");
        }
    }

    public override CarpType GetCarpType() => CarpType.Type;
    public override CarpString String() => CarpString.Create($"{this.NativeType.Name}");
}
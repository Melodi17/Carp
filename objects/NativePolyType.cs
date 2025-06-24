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
        TypeExtensionAttribute? classExtensionAttr = this.NativeType.GetCustomAttribute<TypeExtensionAttribute>();

        foreach (IGrouping<string, MethodInfo> method in this
                     .NativeType.GetMethods(BindingFlags.Instance
                                            | BindingFlags.Static
                                            | BindingFlags.Public
                                            | BindingFlags.DeclaredOnly)
                     .GroupBy(x => x.Name))
        {
            ConsiderAttribute? considerAttr = method.FirstOrDefault()?.GetCustomAttribute<ConsiderAttribute>();

            string name = considerAttr?.Name ?? Formatting.FormatMethod(method.Key);
            Member member = considerAttr?.TypeOverride == MemberType.Property
                ? new PropertyMember(name, Polygot.TypeFromNative(method.First().ReturnType))
                : new MethodMember(name);
            
            bool isStatic = method.Any(x => x.IsStatic);
            TypeExtensionAttribute? extensionAttr = classExtensionAttr
                                                    ?? method
                                                        .FirstOrDefault()
                                                        ?.GetCustomAttribute<TypeExtensionAttribute>();

            List<string?> docs = [];
            if (member is MethodMember methodMember)
            {
                foreach (MethodInfo overload in method)
                {
                    NativePolyFunction func = new(overload, extensionAttr != null);
                    methodMember.Overload(func);
                    docs.Add(overload.GetCustomAttribute<DocAttribute>()?.Text);
                }
            }
            else if (member is PropertyMember propertyMember)
            {
                MethodInfo overload = method.First();
                NativePolyFunction func = new(overload, extensionAttr != null);
                
                propertyMember.Getter(self => func.Call(self, []));
            }

            string doc = string.Join("\n", docs.Where(x => x != null));

            member.Doc(doc);

            if (extensionAttr != null)
            {
                if (!isStatic)
                    throw new InterpreterException("Extension methods must be static");

                extensionAttr.BaseType.Members.Define(member);
                continue;
            }

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
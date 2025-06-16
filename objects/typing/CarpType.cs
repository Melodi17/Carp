namespace Carp.objects.typing;

using exceptions.impl;
using scoping;

public class CarpType : CarpObject
{
    public new static readonly CarpType Type = CarpType.Create("type", CarpObject.Type,
        b => b.Member(new PropertyMember("type_name", CarpString.Type)));
    public static readonly CarpType Auto = CarpType.Create("auto", null);

    private static readonly Dictionary<(CarpType, CarpType[]), CarpType> genericCache = new();

    private static List<Action>? builderQueue;
    public CarpType(string name, CarpType? baseType, CarpType[] typeArguments, Func<CarpObject> defaultValueGen = null)
    {
        this.Name = name;
        this.BaseType = baseType;
        this.TypeArguments = typeArguments;
        this.DefaultValueGen = defaultValueGen;
    }
    public Func<CarpObject>? DefaultValueGen { get; set; }
    public Func<CarpObject[], CarpObject>? Constructor { get; set; }
    public string Name { get; }
    public CarpType? BaseType { get; }
    public CarpType[] TypeArguments { get; set; }
    // Used for grouping types, e.g. "List" for "List<int>" or Number for "Number<int>"
    public string? Group { get; set; }
    public bool IsGeneric => this.TypeArguments.Length > 0;
    public override CarpType GetCarpType() => CarpType.Type;
    public override CarpString String()
    {
        if (!this.IsGeneric)
            return CarpString.Create($"{this.Name}");
        if (this.Extends(CarpCollection.Type))
            return CarpString.Create($"{this.TypeArguments[0].Repr()}*");
        // TODO: implement map type
        // else if (this.Extends(CarpMap.Type))
        //     return CarpString.Create($"{TypeArguments[0].Repr()}:{TypeArguments[1].Repr()}");
        return CarpString.Create($"{this.Name}<{string.Join(", ", this.TypeArguments.Select(x => x.Repr()))}>");
    }
    public CarpObject DefaultValue()
    {
        if (this.DefaultValueGen != null)
            return this.DefaultValueGen();

        return CarpNull.Instance;
    }

    protected override bool IsAccessible(Member member, CarpObject? caller)
    {
        if (member.Is(Modifiers.Private))
            return this.Equals(caller);

        if (!member.Is(Modifiers.Static))
            return false;

        return true;
    }

    public bool Extends(CarpType type)
    {
        if (object.ReferenceEquals(this, type) || this.Equals(type))
            return true;

        if (this.BaseType != null && this.BaseType.Extends(type))
            return true;

        if (type == CarpNull.Type)
            return true;

        if (this.Group != null && this.Group == type?.Group)
            return true;

        return false;
    }

    public static CarpType Create(string name, CarpType? baseType, Action<CarpTypeBuilder>? builder = null)
    {
        CarpType t = new(name, baseType, []);
        CarpType.builderQueue ??= new List<Action>();

        void DeclareBaseTypeMembers(CarpType t)
        {
            if (t.BaseType != null)
                t.Members = t.BaseType.Members.Clone();
        }

        if (builder != null)
        {
            CarpType.builderQueue.Add(() =>
            {
                DeclareBaseTypeMembers(t);
                builder(new CarpTypeBuilder(t));
            });
        }
        else
            CarpType.builderQueue.Add(() => DeclareBaseTypeMembers(t));
        return t;
    }
    public static CarpType CreateGeneric(CarpType parentType, params CarpType[] generics)
    {
        if (CarpType.genericCache.ContainsKey((parentType, generics)))
            return CarpType.genericCache[(parentType, generics)];

        CarpType t = new(parentType.Name, parentType, generics);
        if (t.BaseType != null)
            t.Members = t.BaseType.Members.Clone();

        CarpType.genericCache[(parentType, generics)] = t;
        return t;
    }
    public static CarpType[] ConstructTypes()
    {
        CarpType[] knownTypes =
        [
            CarpObject.Type,
            CarpType.Type,
            CarpType.Auto,
            IIterable.Type,
            CarpString.Type,
            CarpNull.Type,
            CarpVoid.Type,
            CarpBoolean.Type,
            CarpCollection.Type,
            CarpRange.Type,
            CarpWound.Type,
            CarpFunction.Type,
            ..CarpNumber.AllTypes
        ];

        foreach (Action builder in CarpType.builderQueue ?? [])
            builder();
        CarpType.builderQueue?.Clear();

        return knownTypes;
    }

    public static CarpType HighestCommonType(params CarpType[] arr)
    {
        if (arr.Length == 0)
            return CarpObject.Type;

        CarpType type = arr[0];
        while (arr.Any(x => !x.Extends(type!)))
        {
            type = type.BaseType;
            if (type == null)
                return CarpObject.Type; // No common type found, fallback to CarpObject
        }
        return type;
    }

    public override bool Equals(object? obj)
    {
        if (obj is CarpType type)
            return this.Name == type.Name && this.TypeArguments.SequenceEqual(type.TypeArguments);

        return false;
    }

    public override int GetHashCode() => HashCode.Combine(this.Name, this.TypeArguments);
    public virtual CarpObject Instantiate(CarpObject[] args)
    {
        if (this.Constructor != null)
            return this.Constructor(args);

        throw new IllegalInstantiationException(this, "Type does not have a constructor defined.");
    }
}

public class CarpTypeBuilder
{
    private readonly CarpType _type;
    public CarpTypeBuilder(CarpType type)
    {
        this._type = type;
    }

    public CarpTypeBuilder Member(Member member)
    {
        this._type.Members.Define(member);
        return this;
    }
    public CarpTypeBuilder DefaultValue(Func<CarpObject> defaultValue)
    {
        this._type.DefaultValueGen = defaultValue;
        return this;
    }

    public CarpTypeBuilder Constructor(Func<CarpObject[], CarpObject> constructor)
    {
        this._type.Constructor = constructor;
        return this;
    }
}
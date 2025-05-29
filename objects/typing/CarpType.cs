using Carp.scoping;

namespace Carp.objects.typing;

public class CarpType : CarpObject
{
    public new static readonly CarpType Type = CarpType.Create("type", CarpObject.Type);
    public override CarpType GetCarpType() => Type;
    public CarpType(string name, CarpType? baseType, CarpType[] typeArguments, Func<CarpObject> defaultValueGen = null)
    {
        this.Name = name;
        this.BaseType = baseType;
        this.TypeArguments = typeArguments;
        this.DefaultValueGen = defaultValueGen;
    }
    public Func<CarpObject>? DefaultValueGen { get; set; }
    public string Name { get; }
    public CarpType? BaseType { get; }
    public CarpType[] TypeArguments { get; set; }
    // Used for grouping types, e.g. "List" for "List<int>" or Number for "Number<int>"
    public string? Group { get; set; }
    public bool IsGeneric => this.TypeArguments.Length > 0;
    public override CarpString String()
    {
        if (!IsGeneric)
            return CarpString.Create($"{this.Name}");
        else if (this.Extends(CarpCollection.Type))
            return CarpString.Create($"{TypeArguments[0].Repr()}*");
        // TODO: implement map type
        // else if (this.Extends(CarpMap.Type))
        //     return CarpString.Create($"{TypeArguments[0].Repr()}:{TypeArguments[1].Repr()}");
        else
            return CarpString.Create($"{this.Name}<{(string.Join(", ", TypeArguments.Select(x => x.Repr())))}");
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
        if (ReferenceEquals(this, type))
            return true;

        if (this.BaseType != null && this.BaseType.Extends(type))
            return true;

        if (type == CarpNull.Type)
            return true;

        if (this.Group == type.Group)
            return true;

        return false;
    }

    public static CarpType Create(string name, CarpType? baseType, Action<CarpTypeBuilder>? builder = null)
    {
        CarpType t = new(name, baseType, []);
        builderQueue ??= new();

        void DeclareBaseTypeMembers(CarpType t)
        {
            if (t.BaseType != null)
                t.Members = t.BaseType.Members.Clone();
        }

        if (builder != null)
            builderQueue.Add(() =>
            {
                DeclareBaseTypeMembers(t);
                builder(new CarpTypeBuilder(t));
            });
        else builderQueue.Add(() => DeclareBaseTypeMembers(t));
        return t;
    }

    private static Dictionary<(CarpType, CarpType[]), CarpType> genericCache = new();
    public static CarpType CreateGeneric(CarpType parentType, params CarpType[] generics)
    {
        if (genericCache.ContainsKey((parentType, generics)))
            return genericCache[(parentType, generics)];
        
        CarpType t = new(parentType.Name, parentType, generics);
        if (t.BaseType != null)
            t.Members = t.BaseType.Members.Clone();

        genericCache[(parentType, generics)] = t;
        return t;
    }

    private static List<Action>? builderQueue;
    public static CarpType[] ConstructTypes()
    {
        CarpType[] knownTypes =
        [
            CarpObject.Type,
            CarpType.Type,
            CarpString.Type,
            CarpNull.Type,
            CarpVoid.Type,
            CarpBoolean.Type,
            CarpCollection.Type,
            ..CarpNumber.AllTypes,
        ];

        foreach (Action builder in builderQueue ?? [])
            builder();
        builderQueue?.Clear();

        return knownTypes;
    }
    
    public static CarpType HighestCommonType(CarpType[] arr)
    {
        if (arr.Length == 0) return CarpObject.Type;
        
        CarpType type = arr[0];
        while (arr.Any(x => !x.Extends(type))) type = type.BaseType;
        return type;
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
}
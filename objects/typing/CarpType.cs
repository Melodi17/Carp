using Carp.scoping;

namespace Carp.objects.typing;

public class CarpType : CarpObject
{
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
    public CarpType[] TypeArguments { get; }
    
    public bool IsGeneric => this.TypeArguments.Length > 0;
    public override CarpString String() => CarpString.Create($"<type {this.Name}>");
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
        
        return false;
    }

    public override CarpType GetCarpType() => CarpType.Type;

    public static CarpTypeBuilder Create(string name, CarpType? baseType) => new(name, baseType);
}

public class CarpTypeBuilder
{
    public CarpTypeBuilder(string name, CarpType? baseType)
    {
        this.Name = name;
        this.BaseType = baseType;
        this.Members = new();
    }
    
    public string Name { get; }
    public CarpType? BaseType { get; }
    public List<Member> Members { get; }
    public Func<CarpObject>? DefaultValueGen { get; set; }
    
    public CarpTypeBuilder Member(Member member)
    {
        this.Members.Add(member);
        return this;
    }
    public CarpTypeBuilder DefaultValue(Func<CarpObject> defaultValue)
    {
        this.DefaultValueGen = defaultValue;
        return this;
    }

    public CarpType Build()
    {
        CarpType type = new(this.Name, this.BaseType, []);
        return type;
    }
}
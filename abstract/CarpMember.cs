using Carp.interpreter;
using Carp.objects.types;

namespace Carp;

public class CarpMember : CarpObject
{
    public static CarpType Type = NativeType.Of<CarpMember>("member");

    public CarpMember(Signature name, CarpType valueType, CarpObject value, params CarpObject[] attributes)
    {
        this.Name = name;
        this.ValueType = valueType;
        this.Value = value;
        this.Attributes = attributes;
    }

    public override CarpType GetCarpType() => Type;
    
    public Signature Name { get; }
    public CarpType ValueType { get; }
    public CarpObject Value { get; set; }
    public CarpObject[] Attributes { get; }
    
    public bool IsAbstract => this.Attributes.Any(x => x.Match(CarpInterpreter.Abstract).Native);
    public bool IsStatic => this.Attributes.Any(x => x.Match(CarpInterpreter.Static).Native);
    public bool IsProtected => this.Attributes.Any(x => x.Match(CarpInterpreter.Protected).Native);
    
    
    public override CarpString String()
    {
        return new(this.Name.ToString());
    }
}
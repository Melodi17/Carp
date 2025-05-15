using Carp.scoping;

namespace Carp.objects.typing;

public class CarpType : CarpObject
{
    public string Name { get; }
    public CarpType? BaseType { get; }
    public override CarpString String() => CarpString.Create($"<type {this.Name}>");
    public virtual CarpObject DefaultValue()
    {
        // TODO: implement null
        //return CarpNull.Instance;
        throw new NotImplementedException();
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
        
        return false;
    }
}
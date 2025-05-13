namespace Carp.objects;

public class CarpType : CarpObject
{
    public string Name { get; }
    public override CarpString String() => CarpString.Create($"<type {this.Name}>");
    public CarpObject DefaultValue()
    {
        // TODO: implement null
        //return CarpNull.Instance;
        throw new NotImplementedException();
    }
}
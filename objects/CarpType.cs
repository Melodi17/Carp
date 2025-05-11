namespace Carp.objects;

public class CarpType : CarpObject
{
    public string Name { get; }
    public override CarpString String() => CarpString.Create($"<type {this.Name}>");
}
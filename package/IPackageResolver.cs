using Carp.objects.types;

namespace Carp.package;

public interface IPackageResolver
{
    public Package GetPackage(string path, string version = "latest");
}

public class Package : CarpObject
{
    public new static CarpType Type = NativeType.Of<Package>("package");
    public override CarpType GetCarpType() => Type;

    public IPackageResolver Source;
    public IPackageResolver Utilized;
    public string Name;
    public string SourceCode;

    public Package(IPackageResolver source, IPackageResolver utilized, string name, string sourceCode)
    {
        this.Source = source;
        this.Utilized = utilized;
        this.Name = name;
        this.SourceCode = sourceCode;
    }

    public void Include(CarpInterpreter interpreter)
    {
        CarpInterpreter subInterpreter = new(this.Utilized);
        Program.RunString(subInterpreter, this.SourceCode);
        CarpStatic enclosure = new(this.Name, subInterpreter.GlobalScope);
        interpreter.GlobalScope.Define(this.Name, CarpStatic.Type, enclosure);
    }

    public override CarpString String() => new(this.Name);
}
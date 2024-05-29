using Carp.interpreter;
using Carp.objects.types;

namespace Carp.package;

public interface IPackageResolver
{
    public Package GetPackage(string[] fullPath, string[] path, string version = "latest");
}

public class Package : CarpObject
{
    public new static CarpType Type = NativeType.Of<Package>("package");
    public override CarpType GetCarpType() => Type;

    public IPackageResolver Source;
    public IPackageResolver Utilized;
    public string Name;
    public string SourceCode;
    public Func<CarpInterpreter, CarpStatic> Export;

    public Package(IPackageResolver source, IPackageResolver utilized, string name, string sourceCode = null, Func<CarpInterpreter, CarpStatic> export = null)
    {
        this.Source = source;
        this.Utilized = utilized;
        this.Name = name;
        this.SourceCode = sourceCode;
        this.Export = export;
    }

    public void Include(CarpInterpreter interpreter)
    {
        CarpInterpreter subInterpreter = new(this.Utilized);
        CarpStatic enclosure;
        if (this.SourceCode != null)
        {
            Program.RunString(subInterpreter, this.SourceCode);
            enclosure = new(this.Name, subInterpreter.GlobalScope);
        }
        else
            enclosure = this.Export(subInterpreter);

        interpreter.GlobalScope.Define(Signature.OfVariable(this.Name), CarpStatic.Type, enclosure);
    }

    public override CarpString String() => new(this.Name);
}
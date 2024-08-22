using Carp.objects.types;
using Carp.package.resolvers;

namespace Carp.package.packages;

/// <summary>
/// A package that is defined by Carp source code, normally a .carp file
/// </summary>
public class SourcePackage : Package
{
    public readonly string SourceCode;
    public Dictionary<string, CarpObject> Resources;
    public SourcePackage(IPackageResolver source, IPackageResolver utilized, string name, string sourceCode, Dictionary<string, CarpObject> resources) : base(source, utilized, name)
    {
        this.SourceCode = sourceCode;
        this.Resources = resources;
    }

    public override CarpStatic Export(CarpInterpreter interpreter)
    {
        interpreter.Resources = this.Resources;
        interpreter.ExecutionContext = new(this.Name, this.SourceCode.Split("\n"));
        Program.RunString(interpreter, this.SourceCode);
        return new(this.Name, interpreter.GlobalScope);
    }
}
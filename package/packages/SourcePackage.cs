using Carp.objects.types;
using Carp.package.resolvers;

namespace Carp.package.packages;

/// <summary>
/// A package that is defined by Carp source code, normally a .carp file
/// </summary>
public class SourcePackage : Package
{
    public readonly string SourceCode;
    
    public SourcePackage(IPackageResolver source, IPackageResolver utilized, string name, string sourceCode) : base(source, utilized, name)
    {
        this.SourceCode = sourceCode;
    }

    public override CarpStatic Export(CarpInterpreter interpreter)
    {
        Program.RunString(interpreter, this.SourceCode);
        return new(this.Name, interpreter.GlobalScope);
    }
}
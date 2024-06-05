using Carp.interpreter;
using Carp.objects.types;
using Carp.package.resolvers;

namespace Carp.package;

public abstract class Package : CarpObject
{
    public new static CarpType Type = NativeType.Of<Package>("package");
    public override CarpType GetCarpType() => Type;

    public IPackageResolver Source;
    public IPackageResolver Utilized;
    public string Name;

    protected Package(IPackageResolver source, IPackageResolver utilized, string name)
    {
        this.Source = source;
        this.Utilized = utilized;
        this.Name = name;
    }

    // public void Include(CarpInterpreter interpreter)
    // {
    //     CarpInterpreter subInterpreter = new(this.Utilized);
    //     CarpStatic enclosure;
    //     if (this.SourceCode != null)
    //     {
    //         Program.RunString(subInterpreter, this.SourceCode);
    //         enclosure = new(this.Name, subInterpreter.GlobalScope);
    //     }
    //     else
    //         enclosure = this.Export(subInterpreter);
    //
    //     interpreter.GlobalScope.Define(Signature.OfVariable(this.Name), CarpStatic.Type, enclosure);
    // }

    public void Include(CarpInterpreter interpreter)
    {
        CarpInterpreter subInterpreter = new(this.Utilized);
        CarpStatic enclosure = this.Export(subInterpreter);
        Signature sig = Signature.OfVariable(this.Name);

        if (interpreter.GlobalScope.Has(sig))
            throw new PackageAlreadyPresent(this.Name);
        
        interpreter.GlobalScope.Define(sig, CarpStatic.Type, enclosure);
    }
    
    /// <summary>
    /// Exports the package to the interpreter
    /// </summary>
    /// <param name="interpreter">The sandboxed interpreter to execute within</param>
    /// <returns>A static, object that contains the package data</returns>
    public abstract CarpStatic Export(CarpInterpreter interpreter);

    public override CarpString String() => new(this.Name);
}

public class PackageAlreadyPresent(string name) : CarpError($"Package {name}, or a identical-namespaced package is already present.");
using System.IO.Compression;
using System.Net;
using Carp.interpreter;
using Carp.package.packages.standard;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Carp.package.resolvers;

public class StandardPackageResolver : IPackageResolver
{
    public Package GetPackage(CarpInterpreter interpreter, string[] fullPath, string[] path, string version)
    {
        string j = string.Join(".", path);
        return j switch
        {
            "io" => new IOPackage(this),
            "fs" => new FSPackage(this),
            "math" => new MathPackage(this),
            "net" => new NetPackage(this),
            "parse" => new ParsePackage(this),
            "resource" => new ResourcePackage(this, interpreter.Resources),
            _ => throw new CarpError.PackageNotFound(fullPath, version),
        };
    }
}
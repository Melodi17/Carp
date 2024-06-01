using System.IO.Compression;
using Carp.objects.types;

namespace Carp.package.packages;

/// <summary>
/// This is a package commonly stored as a .caaarp file, which is a compressed archive of a package
/// Internally it is a zip, it may contain resources and source code
/// </summary>
public class PackedPackage : Package
{
    public byte[] Data;
    public PackedPackage(IPackageResolver source, IPackageResolver utilized, string name,
        byte[] data) : base(source, utilized, name)
    {
        this.Data = data;
    }
    
    private string GetFileDataString(ZipArchiveEntry entry)
    {
        using StreamReader reader = new(entry.Open());
        return reader.ReadToEnd();
    }
    
    private byte[] GetFileDataBytes(ZipArchiveEntry entry)
    {
        using MemoryStream stream = new();
        entry.Open().CopyTo(stream);
        return stream.ToArray();
    }

    public override CarpStatic Export(CarpInterpreter interpreter)
    {
        using MemoryStream stream = new(this.Data);
        using ZipArchive archive = new(stream);
        
        // main file will be main.carp
        ZipArchiveEntry? mainEntry = archive.GetEntry("main.carp");
        if (mainEntry == null)
            throw new PackageInvalid("No main.carp file found in package");
        
        string mainCode = GetFileDataString(mainEntry);
        
        Program.RunString(interpreter, mainCode);
        return new(this.Name, interpreter.GlobalScope);
    }
    
    public class PackageInvalid(string message) : CarpError(message);
}
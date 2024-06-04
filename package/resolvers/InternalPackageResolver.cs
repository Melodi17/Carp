using System.IO.Compression;
using System.Text;
using Carp.package.packages;

namespace Carp.package.resolvers;

public abstract class InternalPackageResolver : IPackageResolver
{
    public Package GetPackage(CarpInterpreter interpreter, string[] fullPath, string[] path, string version)
    {
        (string name, byte[] content) = FetchPackage(path, version, out bool isPackage);

        return isPackage
            ? new PackedPackage(this, interpreter.PackageResolver, name, content)
            : new SourcePackage(this, interpreter.PackageResolver, name, Encoding.UTF8.GetString(content));
    }

    protected abstract (string name, byte[] content) FetchPackage(string[] path, string version, out bool isPackage);
}

public class FileSystemInternalPackageResolver : InternalPackageResolver
{
    public FileSystemInternalPackageResolver(string basePath)
    {
        this.BasePath = basePath;
    }

    public string BasePath { get; }

    protected override (string, byte[]) FetchPackage(string[] path, string version, out bool isPackage)
    {
        string packagePath = Path.Join(new[] { this.BasePath }.Concat(path).ToArray());
        packagePath += version == "latest" ? "" : $"_{version}";
        
        if (File.Exists(packagePath + ".carp"))
        {
            isPackage = false;
            return (path[^1], File.ReadAllBytes(packagePath + ".carp"));
        }

        if (File.Exists(packagePath + ".caaarp"))
        {
            isPackage = true;
            return (path[^1], File.ReadAllBytes(packagePath + ".caaarp"));
        }

        throw new CarpError.PackageNotFound(path, version);
    }
}

public class ZipInternalPackageResolver : InternalPackageResolver
{
    public ZipInternalPackageResolver(ZipArchive archive)
    {
        this.Archive = archive;
    }

    public ZipArchive Archive { get; }

    protected override (string name, byte[] content) FetchPackage(string[] path, string version, out bool isPackage)
    {
        string packagePath = Path.Join(path) + (version == "latest" ? "" : $"_{version}");

        ZipArchiveEntry? entry = this.Archive.GetEntry(packagePath + ".carp");
        if (entry != null)
        {
            isPackage = false;
            using StreamReader reader = new(entry.Open());
            return (path[^1], Encoding.UTF8.GetBytes(reader.ReadToEnd()));
        }

        entry = this.Archive.GetEntry(packagePath + ".caaarp");
        if (entry != null)
        {
            isPackage = true;
            using MemoryStream stream = new();
            entry.Open().CopyTo(stream);
            return (path[^1], stream.ToArray());
        }

        throw new CarpError.PackageNotFound(path, version);
    }
}
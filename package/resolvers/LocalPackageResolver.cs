using System.IO.Compression;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Carp.package.resolvers;

public class LocalPackageResolver : IPackageResolver
{
    public static readonly string PackagesPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".carp", "packages");
    public static readonly string LocalPackagesPath = Path.Join(PackagesPath, "local");
    public static readonly string CachePackagesPath = Path.Join(PackagesPath, "cache");

    static LocalPackageResolver()
    {
        Directory.CreateDirectory(PackagesPath);
        
        Directory.CreateDirectory(CachePackagesPath);
        Directory.CreateDirectory(LocalPackagesPath);
    }
    
    public Package GetPackage(CarpInterpreter interpreter, string[] fullPath, string[] path, string version)
    {
        throw new NotImplementedException();
    }
    
    public static void InstallLocalPackage(string name, string version)
    {
        string packagePath = Path.Join(LocalPackagesPath, name);
        Directory.CreateDirectory(packagePath);
        
        // Get from source, change version
        
        string packageVersionPath = Path.Join(packagePath, version);
        Directory.CreateDirectory(packageVersionPath);
    }
}
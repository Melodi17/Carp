namespace Carp.package;

public interface IPackageResolver
{
    public Package GetPackage(string[] fullPath, string[] path, string version = "latest");
}
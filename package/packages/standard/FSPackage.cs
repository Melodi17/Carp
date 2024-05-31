using Carp.objects.types;

namespace Carp.package.packages.standard;

public class FSPackage(IPackageResolver source) : EmbeddedPackage(source, "FS")
{
    [PackageMember]
    public CarpString ReadFile(CarpObject path)
    {
        string strPath = path.String().Native;
        return new(File.ReadAllText(strPath));
    }

    [PackageMember]
    public CarpCollection ReadFileLines(CarpObject path)
    {
        return new(CarpString.Type, File.ReadAllLines(path.String().Native)
            .Select(x => new CarpString(x)).ToArray());
    }

    [PackageMember]
    public void WriteFile(CarpObject path, CarpObject cont)
    {
        File.WriteAllText(path.String().Native, cont.String().Native);
    }

    [PackageMember]
    public void WriteFileLines(CarpObject path, CarpCollection cont)
    {
        File.WriteAllLines(path.String().Native,
            cont.Native.Select(x => x.String().Native).ToArray());
    }

    [PackageMember]
    public CarpBool Exists(CarpObject path)
    {
        return CarpBool.Of(File.Exists(path.String().Native));
    }

    [PackageMember]
    public void Delete(CarpObject path)
    {
        File.Delete(path.String().Native);
    }

    [PackageMember]
    public void CreateDir(CarpObject path)
    {
        Directory.CreateDirectory(path.String().Native);
    }

    [PackageMember]
    public void DeleteDir(CarpObject path)
    {
        Directory.Delete(path.String().Native, true);
    }

    [PackageMember]
    public CarpCollection ListDir(CarpObject path)
    {
        return new(CarpString.Type,
            Directory.GetFiles(path.String().Native).Select(x => new CarpString(x)).ToArray());
    }

    [PackageMember]
    public CarpCollection ListDirs(CarpObject path)
    {
        return new(CarpString.Type,
            Directory.GetDirectories(path.String().Native).Select(x => new CarpString(x)).ToArray());
    }
}
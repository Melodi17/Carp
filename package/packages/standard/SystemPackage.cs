using System.Diagnostics;
using Carp.objects.types;

namespace Carp.package.packages.standard;

public class SystemPackage(IPackageResolver source) : EmbeddedPackage(source, "System")
{
    [PackageMember]
    public CarpString RunCommand(CarpString command)
    {
        using var process = new Process
        {
            StartInfo = new()
            {
                FileName = "cmd.exe",
                Arguments = $"/c {command.Native}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };

        process.Start();
        string result = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        return new(result);
    }
    
    [PackageMember]
    public CarpString Username => new(Environment.UserName);
    
    [PackageMember]
    public CarpString MachineName => new(Environment.MachineName);
    
    [PackageMember]
    public CarpString OSVersion => new(Environment.OSVersion.VersionString);
    
    [PackageMember]
    public CarpInt ProcessorCount => new(Environment.ProcessorCount);
}
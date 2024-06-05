using System.Diagnostics;
using Carp.objects.types;

namespace Carp.package.packages.standard;

public class SystemPackage(IPackageResolver source) : EmbeddedPackage(source, "System")
{
    /// <summary>
    /// Executes a command in the command prompt and returns the output.
    /// </summary>
    /// <param name="command">The command to be executed.</param>
    /// <returns>The output of the executed command.</returns>
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

    /// <summary>
    /// Gets the username of the current user.
    /// </summary>
    /// <returns>The username of the current user.</returns>
    [PackageMember]
    public CarpString Username => new(Environment.UserName);

    /// <summary>
    /// Gets the name of the machine.
    /// </summary>
    /// <returns>The name of the machine.</returns>
    [PackageMember]
    public CarpString MachineName => new(Environment.MachineName);

    /// <summary>
    /// Gets the version of the operating system.
    /// </summary>
    /// <returns>The version of the operating system.</returns>
    [PackageMember]
    public CarpString OSVersion => new(Environment.OSVersion.VersionString);

    /// <summary>
    /// Gets the number of processors on the current machine.
    /// </summary>
    /// <returns>The number of processors on the current machine.</returns>
    [PackageMember]
    public CarpInt ProcessorCount => new(Environment.ProcessorCount);
}
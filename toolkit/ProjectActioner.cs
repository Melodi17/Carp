using System.Diagnostics;
using System.IO.Compression;
using System.Text.RegularExpressions;
using Carp.package;
using Carp.package.packages;
using CommandLine;

namespace Carp.toolkit;

[Verb("please", HelpText = "Run specific action on the project.")]
public class ProjectActioner : IExecutableObject
{
    [Value(0, MetaName = "Name", HelpText = "Name of the action to run.")]
    public string ActionName { get; set; }

    [Option('p', "project", HelpText = "Path to the project folder.")]
    public string? ProjectPath { get; set; }

    private string GetProjectFolder()
    {
        return this.ProjectPath ?? Directory.GetCurrentDirectory();
    }

    public void Execute()
    {
        string projectFolder = this.GetProjectFolder();
        string projFilePath = Path.Combine(projectFolder, ".carpproj");
        if (!File.Exists(projFilePath))
            throw new PackedPackage.PackageInvalid(".carproj file is missing");

        ProjectConfiguration conf = ProjectConfiguration.Deserialize(File.ReadAllText(projFilePath));
        if (conf.Actions == null)
            throw new PackedPackage.PackageInvalid("No actions found in the project");

        if (!conf.Actions.TryGetValue(this.ActionName, out string[]? actions))
            throw new PackedPackage.PackageInvalid($"Action {this.ActionName} not found in the project");

        foreach (string action in actions)
        {
            ProcessStartInfo startInfo = new()
            {
                FileName = action,
                Arguments = string.Join(" ", actions.Skip(1)),
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using Process process = new() { StartInfo = startInfo };
            process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
            process.ErrorDataReceived += (sender, e) => Console.WriteLine(e.Data);
            process.Start();
        }
    }
}
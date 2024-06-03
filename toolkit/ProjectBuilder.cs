﻿using System.IO.Compression;
using System.Text.RegularExpressions;
using Carp.package.packages;
using CommandLine;

namespace Carp.toolkit;

[Verb("build", HelpText = "Build a carp project.")]
public class ProjectBuilder : IExecutableObject
{
    [Value(0, MetaName = "Path", HelpText = "The path to the project to build.")]
    public string? ProjectPath { get; set; }
    
    private string GetProjectFolder()
    {
        return this.ProjectPath ?? Directory.GetCurrentDirectory();
    }
    
    public void Execute()
    {
        string zip = BuildProject(this.GetProjectFolder());
        
        Program.WriteColor("Project built successfully", ConsoleColor.Green);
        Program.WriteColor($"Exported to {zip}", ConsoleColor.DarkCyan);
    }

    public static string BuildProject(string projectFolder)
    {
        string projFilePath = Path.Combine(projectFolder, ".carpproj");
        if (!File.Exists(projFilePath))
            throw new PackedPackage.PackageInvalid(".carproj file is missing");

        ProjectConfiguration conf = ProjectConfiguration.Deserialize(File.ReadAllText(projFilePath));

        string exportDir = Path.Join(projectFolder, "export");
        Directory.CreateDirectory(exportDir);

        // zip the project folder, but exclude the /export folder
        string zip = Path.Join(exportDir, $"{conf.Name}_{conf.Version}") + ".caaarp";

        if (File.Exists(zip))
            File.Delete(zip);

        using ZipArchive archive = ZipFile.Open(zip, ZipArchiveMode.Create);

        archive.ZipDirectory(projectFolder, new List<Regex> { new("export/") });
        
        return zip;
    }
}
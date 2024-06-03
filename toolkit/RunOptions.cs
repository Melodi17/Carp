using System.IO.Compression;
using System.Text.RegularExpressions;
using Carp.package.packages;
using CommandLine;

namespace Carp.toolkit;

public interface IExecutableObject
{
    public void Execute();
}

[Verb("run", true, HelpText = "Execute a carp script, project or package.")]
public class ScriptExecutor : IExecutableObject
{
    [Value(0, MetaName = "Path", HelpText = "The path to the script, project or package to run.")]
    public string? ScriptPath { get; set; }
    
    [Option('i', "interactive", HelpText = "Start the Carp REPL after executing the script.")]
    public bool Interactive { get; set; }
    
    [Option('c', "line", HelpText = "Execute the Carp code provided in the command line.")]
    public bool Line { get; set; }
    
    [Option('v', "verbose", Default = true, HelpText = "Print the result of the script execution to the console.")]
    public bool Verbose { get; set; }
    
    [Option('d', "debug", HelpText = "Start the Carp debugger.")]
    public bool Debug { get; set; }
    
    [Option('f', "force-throw", HelpText = "Force the internal errors to trigger the native stacktrace.")]
    public bool ForceThrow { get; set; }

    public string SoftScriptPath => this.ScriptPath ?? "";

    public void Execute()
    {
        
    }
}

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

[Verb("new", HelpText = "Create a new carp project.")]
public class ProjectCreator : IExecutableObject
{
    [Option('s', "script", HelpText = "Create a project from an existing script.")]
    public string? Script { get; set; }
    
    [Option('n', "name", HelpText = "The name of the project.")]
    public string? Name { get; set; }
    
    [Option('a', "author", HelpText = "The author of the project.")]
    public string? Author { get; set; }
    
    [Option('v', "version", HelpText = "The initial version of the project.")]
    public string? Version { get; set; }
    
    [Option('i', "icon", HelpText = "The icon of the project.")]
    public string? Icon { get; set; }

    private string GetProjectName()
    {
        return this.Name ?? Path.GetFileNameWithoutExtension(this.Script) ?? "Untitled";
    }
    
    public void Execute()
    {
        string name = this.GetProjectName();
        
        ProjectConfiguration config = new()
        {
            Name = name,
            Author = this.Author ?? Environment.UserName,
            Version = this.Version ?? "0.1.0",
            Icon = this.Icon ?? null,
        };
        
        this.CreateProject(config);
        
        Program.WriteColor($"Project {config.Name} (v{config.Version}) created successfully", ConsoleColor.Green);
        Program.WriteColor($"Project configuration saved to {config.Name}/.carpproj", ConsoleColor.DarkCyan);
    }

    public void CreateProject(ProjectConfiguration config)
    {
        Directory.CreateDirectory(config.Name);

        if (this.Script != null)
            File.Move(this.Script, Path.Combine(config.Name, "main.carp"));
        else
            File.WriteAllText(Path.Combine(config.Name, "main.carp"), """
                                                               import std.io

                                                               IO.println('Hello, world!')
                                                               """);

        if (config.Icon != null)
        {
            string ext = Path.GetExtension(config.Icon);
            string iconName = Path.ChangeExtension("icon", ext);
            File.Copy(config.Icon, Path.Combine(config.Name, iconName));

            config.Icon = iconName;
        }

        File.WriteAllText(Path.Combine(config.Name, ".carpproj"), config.Serialize());
    }
}
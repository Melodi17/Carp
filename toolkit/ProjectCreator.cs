using CommandLine;

namespace Carp.toolkit;

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
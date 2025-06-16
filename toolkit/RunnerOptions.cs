namespace Carp.toolkit;

using CommandLine;
using CommandLine.Text;

[Verb("run", true, HelpText = "Run a Carp program with the specified options.")]
public class RunnerOptions
{
    [Option('c', "code", Required = false, HelpText = "Run the specified Carp code directly.")]
    public string? Line { get; set; }

    [Value(0, MetaName = "file", HelpText = "The Carp file to run.")]
    public string? File { get; set; }

    [Option('i', "interactive", Required = false, HelpText = "Run in interactive mode (REPL).")]
    public bool Interactive { get; set; } = false;

    [Option('d', "debug", Required = false, HelpText = "Enable debug mode.")]
    public bool Debug { get; set; } = false;
    
    [Option('l', "library", Required = false, HelpText = "Load the specified library before running the program.")]
    public IEnumerable<string>? Libraries { get; set; }

    [Usage(ApplicationAlias = "Carp")]
    public static IEnumerable<Example> Examples => [
        new("Run a Carp file", new RunnerOptions { File = "example.carp" }),
        new("Run Carp code directly", new RunnerOptions { Line = "\'Hello, Carp!\'" }),
        new("Run in interactive mode", new RunnerOptions { File = "example.carp", Interactive = true }),
        new("Run with debug mode enabled", new RunnerOptions { File = "example.carp", Debug = true }),
        new("Load a library before running", new RunnerOptions { Libraries = ["std.io"], Line = "System.outln(\'Hello, Carp!\')" })
    ];
}
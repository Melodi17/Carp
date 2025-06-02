namespace Carp.toolkit;

using CommandLine;

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
}
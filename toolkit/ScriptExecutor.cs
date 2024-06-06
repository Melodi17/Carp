using CommandLine;

namespace Carp.toolkit;

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
    
    [Option("strict-warnings", HelpText = "Treat warnings as errors")]
    public bool StrictWarnings { get; set; }
    
    [Option("default-non-structs", Default = true, HelpText = "Allow non-struct objects to be auto-initialized")]
    public bool DefaultNonStructs { get; set; }
    
    [Option("implicit-casts", Default = true, HelpText = "Enable implicit casting/type coercion")]
    public bool ImplicitCasting { get; set; }

    public string SoftScriptPath => this.ScriptPath ?? "";

    public void Execute()
    {
        
    }
}
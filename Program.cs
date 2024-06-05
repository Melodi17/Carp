// See https://aka.ms/new-console-template for more information

using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using Carp.objects.types;
using Carp.package;
using Carp.package.packages;
using Carp.package.packages.standard;
using Carp.package.resolvers;
using Carp.preprocessor;
using Carp.toolkit;
using CommandLine;
using Parser = CommandLine.Parser;

namespace Carp;

internal class Program
{
    public static Debugger Debugger;
    public static ModularPackageResolver DefaultPackageResolver;
    public static bool ForceThrow = false;

    public static void Main(string[] args)
    {
        Parser parser = Parser.Default;
        IExecutableObject? options = null;
        parser.ParseArguments<ScriptExecutor, ProjectBuilder, ProjectCreator>(args)
            .WithParsed<IExecutableObject>(o => options = o);

        if (options == null)
            return;

        options.Execute();

        if (options is not ScriptExecutor se)
            return;

        DefaultPackageResolver = GetPackageResolver();
        CarpInterpreter.Instance = new(DefaultPackageResolver);
        ForceThrow = se.ForceThrow;

        bool scriptPathGiven = se.SoftScriptPath.Length > 0;

        Flags.Instance.LoadedFromFile = !se.Line && scriptPathGiven;
        Flags.Instance.ExecutionContext = se.SoftScriptPath;

        if (se.Debug)
            RunDebugger();

        if (se.Line)
        {
            if (!scriptPathGiven)
            {
                PrintError("No code given");
                return;
            }

            SetDefaultResolver(CarpInterpreter.Instance.PackageResolver,
                new FileSystemInternalPackageResolver(Environment.CurrentDirectory));

            CarpObject response = RunString(CarpInterpreter.Instance, se.SoftScriptPath);
            if (response != CarpVoid.Instance)
                WriteOutput(response, false);
        }
        else if (scriptPathGiven)
        {
            CarpObject response = RunFile(CarpInterpreter.Instance, se.SoftScriptPath);
            if (response != CarpVoid.Instance && se.Verbose)
                WriteOutput(response, false);
        }

        if (se.Interactive || !scriptPathGiven)
            Repl();
    }

    private static void RunDebugger()
    {
        Flags.Instance.Debug = true;
        Debugger = new();
        Debugger.StartAsync();
        CarpInterpreter.Instance.Paused = true;
        Console.WriteLine("Debugger started");
        while (!Debugger.Attached)
            Thread.Sleep(50);
        Console.WriteLine("Debugger continuing");
    }

    private static CarpObject RunFile(CarpInterpreter instance, string path)
    {
        bool isProject = !File.Exists(path);
        bool isArchive = Path.GetExtension(path) == ".caaarp";

        if (isProject)
        {
            string file = ProjectBuilder.BuildProject(path);
            return RunFile(instance, file);
        }

        if (isArchive)
        {
            byte[] data = File.ReadAllBytes(path);
            return RunProject(instance, data).result;
        }

        string code = File.ReadAllText(path, Encoding.UTF8);
        SetDefaultResolver(instance.PackageResolver,
            new FileSystemInternalPackageResolver(Path.GetDirectoryName(path)!));
        return RunString(instance, code);
    }

    public static (ProjectConfiguration config, CarpObject result) RunProject(CarpInterpreter instance, byte[] data)
    {
        using MemoryStream stream = new(data);
        using ZipArchive archive = new(stream);

        // get project file
        ZipArchiveEntry? projEntry = archive.GetEntry(".carpproj");
        if (projEntry == null)
            throw new PackedPackage.PackageInvalid("No .carpproj file found in package");

        ProjectConfiguration projConfig = ProjectConfiguration.Deserialize(projEntry.GetFileDataString());

        // look for /resources dir
        // ZipArchiveEntry? resourcesEntry = archive.GetEntry("resources");
        // if it exists, enumerate all files and add them to the interpreter
        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            if (entry.FullName.StartsWith("resources\\") || entry.FullName.StartsWith("resources/"))
            {
                string name = entry.FullName.Substring("resources/".Length);
                string ext = Path.GetExtension(name);
                name = Path.GetFileNameWithoutExtension(name)
                    .Replace("/", ".")
                    .Replace("\\", ".");

                string[] textFormats = {".txt", ".json"};
                
                if (textFormats.Contains(ext))
                    instance.Resources[name] = new CarpString(entry.GetFileDataString());
                else
                    throw new PackedPackage.PackageInvalid($"Unsupported resource type: {ext}");
            }
        }

        ZipInternalPackageResolver resolver = new(archive);
        SetDefaultResolver(instance.PackageResolver, resolver);

        // main file will be main.carp
        ZipArchiveEntry? mainEntry = archive.GetEntry("main.carp");
        if (mainEntry == null)
            throw new PackedPackage.PackageInvalid("No main.carp file found in package");

        string mainCode = mainEntry.GetFileDataString();

        return (projConfig, RunString(instance, mainCode));
    }


    private static ModularPackageResolver GetPackageResolver()
    {
        ModularPackageResolver mpr = new();
        mpr.AddResolver("std", new StandardPackageResolver());
        mpr.AddResolver("github", new GithubPackageResolver());

        return mpr;
    }

    private static void Repl()
    {
        SetDefaultResolver(CarpInterpreter.Instance.PackageResolver,
            new FileSystemInternalPackageResolver(Environment.CurrentDirectory));

        while (true)
        {
            string? msg = ReadLineAdvanced(" : ");
            if (msg is null or "exit")
                break;

            int predictionDepth = CalculateDepth(msg);

            while (predictionDepth > 0)
            {
                string spacer = "   " + string.Concat(Enumerable.Repeat("  ", predictionDepth));
                string? next = ReadLineAdvanced(spacer);
                if (next is null)
                    break;
                msg += "\n" + next;
                predictionDepth = CalculateDepth(msg);
            }

            CarpObject response = RunString(CarpInterpreter.Instance, msg);
            if (response != CarpVoid.Instance)
                WriteOutput(response, true);
        }
    }

    private static string? ReadLineAdvanced(string prompt)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write(prompt);
        Console.ForegroundColor = ConsoleColor.White;

        string? line = Console.ReadLine();

        Console.ResetColor();

        return line;
    }

    private static void WriteOutput(CarpObject obj, bool interactive)
    {
        if (!interactive)
        {
            Console.WriteLine(obj.Repr());
            return;
        }
        
        WriteColor(" > ", ConsoleColor.DarkGray, end: "");

        if (obj is CarpString str)
            WriteColor(str.Repr(), ConsoleColor.Yellow);

        else if (obj is CarpInt)
            WriteColor(obj.Repr(), ConsoleColor.Cyan);

        else if (obj is CarpBool)
            WriteColor(obj.Repr(), ConsoleColor.Magenta);

        else
            WriteColor(obj.Repr(), ConsoleColor.Gray);
    }

    public static void WriteColor(string text, ConsoleColor color, string end = "\n")
    {
        Console.ForegroundColor = color;
        Console.Write(text + end);
        Console.ResetColor();
    }

    public static CarpObject? RunString(CarpInterpreter interpreter, string s)
    {
        if (s.Trim().Length == 0)
            return CarpVoid.Instance;

        CarpGrammarParser.ProgramContext program;
        try
        {
            Preprocessor preprocessor = new(s);
            string processed = preprocessor.Process();
            
            // Console.WriteLine(processed);

            AntlrInputStream inputStream = new(processed);
            CarpGrammarLexer lexer = new(inputStream);
            lexer.RemoveErrorListeners();
            CommonTokenStream tokenStream = new(lexer);

            CarpGrammarParser parser = new(tokenStream);

            program = parser.program();
        }
        catch (Exception e)
        {
            PrintError($"Syntax error on {interpreter.CurrentLine}: {e.Message}");
            return CarpVoid.Instance;
        }

        try
        {
            CarpObject? obj = interpreter.Visit(program) as CarpObject;
            return obj;
        }
        catch (CarpError e)
        {
            if (ForceThrow) throw;

            PrintError($"{e.DisplayName} on {interpreter.CurrentLine}: {e.Message}");
        }
        catch (CarpFlowControlError fcError)
        {
            if (ForceThrow) throw;

            CarpError.UnenclosedFlowControl e = new(fcError);
            PrintError($"{e.DisplayName} on {interpreter.CurrentLine}: {e.Message}");
        }
        catch (NotImplementedException)
        {
            PrintError($"Not implemented on {interpreter.CurrentLine}: This feature has not been implemented yet");
        }

        return CarpVoid.Instance;
    }

    public static void PrintError(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine(text);
        Console.ResetColor();
    }

    public static int CalculateDepth(string text)
    {
        (string Opening, string Closing)[] delimiters =
        {
            ("(", ")"),
            ("{", "}"),
            ("[", "]"),
        };
        Preprocessor preprocessor = new(text);
        IEnumerable<Preprocessor.PrimitiveToken> lex = preprocessor.FastLex();
        int[] depths = new int[delimiters.Length];
        foreach (Preprocessor.PrimitiveToken token in lex)
        {
            for (int i = 0; i < delimiters.Length; i++)
            {
                if (token.Value == delimiters[i].Opening)
                    depths[i]++;
                else if (token.Value == delimiters[i].Closing)
                    depths[i]--;
            }
        }

        return depths.Sum();
    }

    private static void SetDefaultResolver(IPackageResolver resolver, IPackageResolver def)
    {
        if (resolver is ModularPackageResolver mpr)
            mpr.SetDefaultResolver(def);
        else
            throw new("Resolver is not a ModularPackageResolver");
    }
}
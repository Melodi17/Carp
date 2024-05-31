// See https://aka.ms/new-console-template for more information

using System.Text;
using Antlr4.Runtime;
using Carp.objects.types;
using Carp.package;
using Carp.package.resolvers;
using Carp.preprocessor;

namespace Carp;

internal class Program
{
    public static Debugger Debugger;
    public static IPackageResolver DefaultPackageResolver;
    public static bool ForceThrow = false;
    public static void Main(string[] args)
    {
        bool interactive = args.Contains("-i");
        bool line = args.Contains("-c");
        bool verbose = args.Contains("-v");
        bool debug = args.Contains("-d");
        bool help = args.Contains("-h");
        bool forceThrow = args.Contains("-f");
        
        // args without flags
        args = args.Where(x => !x.StartsWith("-") && x.Length != 2).ToArray();
        
        string arg = args.Length > 0 ? string.Join(" ", args) : "";
        
        if (help)
        {
            Console.WriteLine("Carp Programming Language");
            Console.WriteLine("Usage: carp [options] [file]");
            Console.WriteLine("Options:");
            Console.WriteLine("  -i: Start the Carp REPL after executing the script.");
            Console.WriteLine("  -c: Execute the Carp code provided in the command line.");
            Console.WriteLine("  -v: Print the result of the script execution to the console.");
            Console.WriteLine("  -d: Start the Carp debugger.");
            Console.WriteLine("  -h: Display this help menu.");
            Console.WriteLine("  -f: Force the internal errors to trigger the native stacktrace.");
            Console.WriteLine("File: The path to the Carp script to execute. If no file is provided, Carp will start in REPL mode.");
            return;
        }

        DefaultPackageResolver = GetPackageResolver();
        CarpInterpreter.Instance = new(DefaultPackageResolver);
        ForceThrow = forceThrow;
        
        Flags.Instance.LoadedFromFile = !line && arg.Length > 0;
        Flags.Instance.ExecutionContext = arg;
        
        if (debug)
        {
            Flags.Instance.Debug = true;
            Debugger = new();
            Debugger.StartAsync();
            CarpInterpreter.Instance.Paused = true;
            Console.WriteLine("Debugger started");
            while (!Debugger.Attached) Thread.Sleep(50);
            Console.WriteLine("Debugger continuing");
        }
        
        if (line)
        {
            if (arg.Length == 0)
            {
                PrintError("No code given");
                return;
            }
            
            CarpObject response = RunString(CarpInterpreter.Instance, arg);
            if (response != CarpVoid.Instance)
                Console.WriteLine(response.Repr());
        }
        else if (arg.Length > 0)
        {
            CarpObject response = RunString(CarpInterpreter.Instance, File.ReadAllText(arg));
            if (response != CarpVoid.Instance && verbose)
                Console.WriteLine(response.Repr());
        }

        if (interactive || args.Length == 0)
            Repl();
    }

    private static IPackageResolver GetPackageResolver()
    {
        ModularPackageResolver mpr = new();
        mpr.AddResolver("std", new StandardPackageResolver());
        mpr.AddResolver("github", new GithubPackageResolver());

        return mpr;
    }

    private static string ReadLineAdvanced(string prompt)
    {
        Console.Write(prompt);
        StringBuilder sb = new();
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                return sb.ToString();
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                if (sb.Length > 0)
                {
                    Console.Write("\b \b");
                    sb.Remove(sb.Length - 1, 1);
                }
            }
            else
            {
                Console.Write(key.KeyChar);
                sb.Append(key.KeyChar);
            }
        }
    }

    private static void Repl()
    {
        while (true)
        {
            Console.Write(" : ");
            string msg = Console.ReadLine();
            if (msg is null or "exit")
                break;
            
            int predictionDepth = CalculateDepth(msg);
            
            while (predictionDepth > 0)
            {
                Console.Write("   " + string.Concat(Enumerable.Repeat("  ", predictionDepth)));
                string next = Console.ReadLine();
                msg += "\n" + next;
                predictionDepth = CalculateDepth(msg);
            }

            CarpObject response = RunString(CarpInterpreter.Instance, msg);
            if (response != CarpVoid.Instance)
                Console.WriteLine(response.Repr());
        }
    }

    public static CarpObject RunString(CarpInterpreter interpreter, string s)
    {
        if (s.Trim().Length == 0)
            return CarpVoid.Instance;

        Preprocessor preprocessor = new(s);
        string processed = preprocessor.Process();
        
        AntlrInputStream inputStream = new(processed);
        CarpGrammarLexer lexer = new(inputStream);
        lexer.RemoveErrorListeners();
        CommonTokenStream tokenStream = new(lexer);

        CarpGrammarParser parser = new(tokenStream);

        CarpGrammarParser.ProgramContext program = parser.program();
        try
        {
            CarpObject obj = interpreter.Visit(program) as CarpObject;
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
        (string Opening, string Closing)[] delimiters = {
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
}

// See https://aka.ms/new-console-template for more information

using Antlr4.Runtime;
using Carp.objects.types;
using Carp.preprocessor;

namespace Carp;

internal class Program
{
    public static Debugger Debugger;
    public static void Main(string[] args)
    {
        bool interactive = args.Contains("-i");
        bool line = args.Contains("-c");
        bool verbose = args.Contains("-v");
        bool debug = args.Contains("-d");
        bool help = args.Contains("-h");
        
        // args without flags
        args = args.Where(x => !x.StartsWith("-") && x.Length != 2).ToArray();
        
        string arg = args.Length > 0 ? string.Join(" ", args) : "";
        
        if (help)
        {
            Console.WriteLine("Carp Programming Language");
            Console.WriteLine("Usage: carp [options] [file]");
            return;
        }
        
        Flags.Instance.LoadedFromFile = !line && arg.Length > 0;
        Flags.Instance.ExecutionContext = arg;
        
        if (debug)
        {
            Flags.Instance.Debug = true;
            Debugger = new();
            Debugger.StartAsync();
            CarpInterpreter.Instance.Paused = true;
            Console.WriteLine("Debugger started");
        }
        
        if (line)
        {
            if (arg.Length == 0)
            {
                PrintError("No code given");
                return;
            }
            
            CarpObject response = RunString(arg);
            if (response != CarpVoid.Instance)
                Console.WriteLine(response.Repr());
        }
        else if (arg.Length > 0)
        {
            CarpObject response = RunString(File.ReadAllText(arg));
            if (response != CarpVoid.Instance && verbose)
                Console.WriteLine(response.Repr());
        }

        if (interactive || args.Length == 0)
            Repl();
    }

    private static void Repl()
    {
        while (true)
        {
            Console.Write(" : ");
            string msg = Console.ReadLine();
            if (msg == "exit")
                break;

            CarpObject response = RunString(msg);
            if (response != CarpVoid.Instance)
                Console.WriteLine(response.Repr());
        }
    }

    public static CarpObject RunString(string s)
    {
        if (s.Trim().Length == 0)
            return CarpVoid.Instance;

        Preprocessor preprocessor = new(s);
        string processed = preprocessor.Process();
        
        AntlrInputStream inputStream = new(processed);
        CarpGrammarLexer lexer = new(inputStream);
        CommonTokenStream tokenStream = new(lexer);

        CarpGrammarParser parser = new(tokenStream);

        CarpGrammarParser.ProgramContext program = parser.program();
        CarpInterpreter interpreter = CarpInterpreter.Instance;
        try
        {
            CarpObject obj = interpreter.Visit(program) as CarpObject;
            return obj;
        }
        catch (CarpError e)
        {
            PrintError($"{e.DisplayName}: {e.Message}");
        }
        catch (CarpFlowControlError fcError)
        {
            CarpError.UnenclosedFlowControl e = new(fcError);
            PrintError($"{e.DisplayName}: {e.Message}");
        }

        return CarpVoid.Instance;
    }

    public static void PrintError(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine(text);
        Console.ResetColor();
    }
}

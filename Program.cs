namespace Carp;

using CommandLine;
using exceptions;
using interpreter.execution;
using objects;
using objects.typing;
using scoping;
using toolkit;
using utils;
using CommandLineParser = CommandLine.Parser;

public class Program
{
    public static void Main(string[] args)
    {
        CommandLineParser.Default.ParseArguments<RunnerOptions>(args).WithParsed(Program.RunProgram);
    }

    private static void RunProgram(RunnerOptions obj)
    {
        CarpType[] types = CarpType.ConstructTypes();
        Scope scope = Runtime.MakeScope(types);

        try
        {
            if (obj.Line != null)
            {
                CarpObject res = Runtime.Execute(new LineExecutionContext(obj.Line), scope);
                if (res != CarpVoid.Instance)
                    Program.WriteRichObject(res, newLine: true);
            }

            if (obj.File != null)
            {
                CarpObject res = Runtime.Execute(new FileExecutionContext(obj.File), scope);
                if (res != CarpVoid.Instance)
                    Program.WriteRichObject(res, newLine: true);
            }
        }
        catch (ParserException e)
        {
            Console.Error.WriteLine($"[Parser] {e.Message}");
        }
        catch (InterpreterException e)
        {
            Console.Error.WriteLine($"[Interpreter] {e.Message}");
        }
        catch (RuntimeException e)
        {
            Program.WriteRichError(e);
        }

        if (obj.Interactive || (obj.File == null && obj.Line == null))
        {
            Console.WriteLine("Entering REPL mode. Press Ctrl+C to exit.");
            Program.REPL(scope);
        }
    }

    private static void REPL(Scope globalScope)
    {
        int blockCount = 0;
        while (true)
        {
            Console.Write(": ");
            string? input = Console.ReadLine();
            if (input == null)
                return;

            ReplExecutionContext executionContext = new(blockCount, input);
            try
            {
                var lexed = Runtime.Lex(executionContext);
                while (Semantics.ShouldMultiline(lexed))
                {
                    int depth = Semantics.CalculateDepth(lexed);
                    Console.Write("... " + new string(' ', Math.Max(0, depth - 1) * 2));

                    string? nextLine = Console.ReadLine();
                    if (nextLine == null)
                        return;

                    input += "\n" + nextLine;
                    executionContext.Text = input;

                    lexed = Runtime.Lex(executionContext);
                }

                CarpGrammarParser.ProgramContext ast = Runtime.Parse(lexed, executionContext);
                CarpObject res = Runtime.Execute(ast, executionContext, globalScope);
                if (res != CarpVoid.Instance)
                    Program.WriteRichObject(res, newLine: true);
            }
            catch (ParserException e)
            {
                Console.Error.WriteLine($"[Parser] {e.Message}");
            }
            catch (InterpreterException e)
            {
                Console.Error.WriteLine($"[Interpreter] {e.Message}");
            }
            catch (RuntimeException e)
            {
                Program.WriteRichError(e);
            }
            blockCount++;
        }
    }
    private static void WriteRichObject(CarpObject res, bool newLine = false)
    {
        ConsoleColor color = res switch
        {
            CarpString => ConsoleColor.Cyan,
            CarpNumber => ConsoleColor.Yellow,
            CarpBoolean => ConsoleColor.Green,
            CarpNull _ => ConsoleColor.DarkGray,
            CarpVoid _ => ConsoleColor.DarkGray,
            _ => ConsoleColor.White,
        };
        
        if (res is CarpCollection collection)
        {
            Console.Write("[");
            for (int i = 0; i < collection.Items.Count; i++)
            {
                WriteRichObject(collection.Items[i], newLine: false);
                if (i < collection.Items.Count - 1)
                    Console.Write(", ");
            }
            Console.Write("]");
            if (newLine)
                Console.WriteLine();
            return;
        }
        
        Console.ForegroundColor = color;
        Console.Write(res.Repr());
        if (newLine)
            Console.WriteLine();
        Console.ResetColor();
    }

    private static void WriteRichError(RuntimeException ex)
    {
        void Print(string text) => Console.Error.WriteLine(Coloring.SubstituteStyles(text));
        
        Print($"%red%{ex.ErrorFriendlyName}: %white%{ex.Message}");
        foreach (StackFrame frame in ex.InternalStackTrace)
        {
            int pos = frame.Context.Position;
            string content = frame.Context.ExecutionContext?.GetAtPosition(pos) ?? "<missing>";
            Print(
                $"\t%gray%--->  %cyan%{frame.Context.ExecutionContext?.Name ?? "<unknown>"}  %darkred%{pos} %white%|  %gray italic%{content.Replace("%", "%%")}");
        }
    }
}
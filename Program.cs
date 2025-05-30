// See https://aka.ms/new-console-template for more information

namespace Carp;

using Antlr4.Runtime;
using exceptions;
using interpreter;
using interpreter.visitors;
using objects;
using objects.typing;
using scoping;
using utils;

public class Program
{
    public static void Main(string[] args)
    {
        CarpType[]? types = CarpType.ConstructTypes();
        Scope globalScope = Program.MakeScope(types);

        int blockCount = 0;
        while (true)
        {
            Console.Write(" : ");
            CarpObject res = Program.RunString(Console.ReadLine()!, globalScope, Program.WriteRichError, blockCount);
            if (res != CarpVoid.Instance)
                Program.WriteRichObject(res);
            blockCount++;
        }
    }
    private static void WriteRichObject(CarpObject res)
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

        Console.ForegroundColor = color;
        Console.WriteLine(" " + res.Repr());
        Console.ResetColor();
    }

    private static void WriteRichError(RuntimeException ex)
    {
        void Print(string text) => Console.Error.WriteLine(Coloring.SubstituteStyles(text));

        Print($" %red%{ex.ErrorFriendlyName}: %white%{ex.Message}");
        foreach (StackFrame frame in ex.InternalStackTrace)
        {
            int pos = frame.Context.Position;
            string content = frame.Context.ExecutionContext?.GetAtLine(pos) ?? "<missing>";
            Print($" \t%gray%--->  %cyan%{frame.Context.ExecutionContext?.Name ?? "<unknown>"}  %darkred%{pos} %white%|  %gray italic%{content.Replace("%", "%%")}");
        }
    }

    public static Scope MakeScope(CarpType[] types)
    {
        Scope s = new();
        foreach (CarpType type in types)
            s.Define(new FieldMember(type.Name, CarpType.Type, type));

        return s;
    }

    public static CarpObject RunString(string text, Scope? scope = null, Action<RuntimeException>? OnError = null, int? blockNum = null)
    {
        CarpGrammarParser.ProgramContext program = null;
        try
        {
            AntlrInputStream stream = new(text);
            CarpGrammarLexer lexer = new(stream);
            lexer.RemoveErrorListeners();
            CommonTokenStream tokens = new(lexer);

            CarpGrammarParser parser = new(tokens);
            program = parser.program();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);
            return CarpVoid.Instance;
        }

        if (program == null)
            throw new Exception("Failed to parse the program.");

        program.Scope = scope ?? Program.MakeScope(CarpType.ConstructTypes());
        program.ExecutionContext = new ReplExecutionContext(blockNum, text);

        CarpVisitor visitor = new();
        try
        {
            CarpObject? output = visitor.Visit(program) as CarpObject;
            if (output == null)
                throw new Exception("Failed to visit the program.");

            return output;
        }
        catch (RuntimeException e)
        {
            OnError?.Invoke(e);
            // Console.Error.WriteLine(e.ToString());
            return CarpVoid.Instance;
        }
    }
}
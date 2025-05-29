// See https://aka.ms/new-console-template for more information

using System.Text;
using Antlr4.Runtime;
using Carp.exceptions;
using Carp.interpreter;
using Carp.interpreter.visitors;
using Carp.objects;
using Carp.objects.typing;
using Carp.scoping;
using Carp.utils;

namespace Carp;

public class Program
{
    public static void Main(string[] args)
    {
        var types = CarpType.ConstructTypes();
        Scope globalScope = MakeScope(types);

        while (true)
        {
            Console.Write(" : ");
            CarpObject res = RunString(Console.ReadLine()!, globalScope);
            if (res != CarpVoid.Instance)
                WriteRichObject(res);
        }
    }
    private static void WriteRichObject(CarpObject res)
    {
        ConsoleColor color = res switch
        {
            CarpString => (ConsoleColor.Cyan),
            CarpNumber => (ConsoleColor.Yellow),
            CarpBoolean => (ConsoleColor.Green),
            CarpNull _ => (ConsoleColor.DarkGray),
            CarpVoid _ => (ConsoleColor.DarkGray),
            _ => (ConsoleColor.White)
        };

        Console.ForegroundColor = color;
        Console.WriteLine(" " + res.Repr());
        Console.ResetColor();
    }

    private static void WriteRichError(RuntimeException ex)
    {
        string errorName = ex.GetType().Name;
        
        void Print(string text) => Console.Error.WriteLine(Coloring.SubstituteStyles(text));
        
        Print($" %red%{errorName}: %white%{ex.Message}");
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
        foreach (var type in types)
            s.Define(new FieldMember(type.Name, CarpType.Type, type));

        return s;
    }

    public static CarpObject RunString(string text, Scope? scope = null)
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
            throw new("Failed to parse the program.");

        program.Scope = scope ?? MakeScope(CarpType.ConstructTypes());
        program.ExecutionContext = new ReplExecutionContext(text);

        CarpVisitor visitor = new();
        try
        {
            CarpObject? output = visitor.Visit(program) as CarpObject;
            if (output == null)
                throw new("Failed to visit the program.");

            return output;
        }
        catch (RuntimeException e)
        {
            WriteRichError(e);
            // Console.Error.WriteLine(e.ToString());
            return CarpVoid.Instance;
        }
    }
}
// See https://aka.ms/new-console-template for more information

using Antlr4.Runtime;
using Carp.exceptions;
using Carp.interpreter.visitors;
using Carp.objects;

namespace Carp;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            var res = RunString(Console.ReadLine()!);
            if (res != CarpVoid.Instance)
                Console.WriteLine(res.Repr());
        }
    }

    public static CarpObject RunString(string text)
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

        var visitor = new CarpVisitor();
        try
        {
            var output = visitor.Visit(program) as CarpObject;
            if (output == null)
                throw new("Failed to visit the program.");
            
            return output;
        }
        catch (RuntimeException e)
        {
            Console.Error.WriteLine(e.ToString());
            return CarpVoid.Instance;
        }
    }
}
// See https://aka.ms/new-console-template for more information

using Antlr4.Runtime;
using Carp.interpreter.visitors;
using Carp.objects;

namespace Carp;

public class Program
{
    public static void Main(string[] args)
    {
        var res = RunString("1 + 1");
        Console.WriteLine(res.Repr());
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
            return null;
        }
        
        if (program == null)
            throw new("Failed to parse the program.");

        var visitor = new CarpVisitor();
        var output = visitor.Visit(program) as CarpObject;
        if (output == null)
            throw new("Failed to visit the program.");
        
        return output;
    }
}
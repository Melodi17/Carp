// See https://aka.ms/new-console-template for more information

using Antlr4.Runtime;

namespace Carp;

internal class Program
{
    public static void Main(string[] args)
    {
        string content = File.ReadAllText(args[0]);

        AntlrInputStream inputStream = new(content);
        CarpGrammarLexer lexer = new(inputStream);
        CommonTokenStream tokenStream = new(lexer);
        
        CarpGrammarParser parser = new(tokenStream);

        CarpGrammarParser.ProgramContext program = parser.program();
        CarpInterpreter interpreter = CarpInterpreter.Instance;
        try
        {
            interpreter.Visit(program);
        }
        catch (CarpError e)
        {
            Console.Error.WriteLine($"{e.DisplayName}: {e.Message}");
        }
    }
}
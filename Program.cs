// See https://aka.ms/new-console-template for more information

using Antlr4.Runtime;
using Carp.exceptions;
using Carp.interpreter.visitors;
using Carp.objects;
using Carp.objects.typing;
using Carp.scoping;

namespace Carp;

public class Program
{
    public static void Main(string[] args)
    {
        CarpType.ConstructTypes();
        Scope globalScope = MakeScope();
        
        while (true)
        {
            CarpObject res = RunString(Console.ReadLine()!, globalScope);
            if (res != CarpVoid.Instance)
                Console.WriteLine(res.Repr());
        }
    }

    public static Scope MakeScope()
    {
        Scope s = new();
        // s.Define(new FieldMember("int", CarpType.Type, CarpNumber.Type));
        CarpType[] knownTypes =
        [
            CarpObject.Type,
            CarpType.Type,
            CarpString.Type,
            CarpNumber.Type,
            CarpNull.Type,
            CarpVoid.Type,
            CarpBoolean.Type
        ];
        
        foreach (var type in knownTypes)
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

        CarpVisitor visitor = new();
        try
        {
            program.Scope = scope ?? MakeScope();
            CarpObject? output = visitor.Visit(program) as CarpObject;
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
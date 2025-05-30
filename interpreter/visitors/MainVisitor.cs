namespace Carp.interpreter.visitors;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using exceptions;
using objects;
using objects.typing;
using utils;

public partial class CarpVisitor : CarpGrammarBaseVisitor<object>
{
    protected CarpObject VisitExpression(CarpGrammarParser.ExpressionContext context)
    {
        if (this.Visit(context) is CarpObject carpObject)
            return carpObject;

        throw new InterpreterException($"Expected CarpObject, but got {context.GetType().GetFormattedName()} instead.");
    }

    protected T VisitToken<T>(Context context)
        where T : Enum
    {
        if (this.Visit(context) is T token)
            return token;

        throw new InterpreterException($"Expected token of {typeof(T).Name}, but got {context.GetType().GetFormattedName()} instead.");
    }

    private CarpType VisitType(CarpGrammarParser.TypeContext contextRtype)
    {
        if (this.Visit(contextRtype) is CarpType type)
            return type;

        throw new InterpreterException($"Expected type, but got {contextRtype.GetType().GetFormattedName()} instead.");
    }

    public override object Visit(IParseTree tree)
    {
        if (tree is Context ctx)
        {
            ctx.Position = ctx.Start.Line;
            if (tree.Parent is Context parent)
                ctx.ReplicateParent(parent);
            //Console.WriteLine($"Visiting {ctx.GetType().GetFormattedName()} at line {ctx.Position}");
        }

        return base.Visit(tree);
    }

    public override object VisitChildren(IRuleNode node)
    {
        object result = this.DefaultResult;
        int childCount = node.ChildCount;
        for (int i = 0; i < childCount && this.ShouldVisitNextChild(node, result); ++i)
        {
            IParseTree child = node.GetChild(i);
            if (child is ITerminalNode)
                continue;

            object nextResult = this.Visit(child);
            result = this.AggregateResult(result, nextResult);
        }
        return result;
    }
    private string? VisitDocstring(IList<IToken> contextDocs)
    {
        if (contextDocs.Count == 0)
            return null;

        return string.Join("\n", contextDocs.Select(x => x.Text[2..].Trim()));
    }
}
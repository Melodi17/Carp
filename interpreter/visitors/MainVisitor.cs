using Antlr4.Runtime.Tree;
using Carp.exceptions;
using Carp.objects;
using Carp.utils;

namespace Carp.interpreter.visitors;

public partial class CarpVisitor : CarpGrammarBaseVisitor<object>
{
    protected CarpObject VisitExpression(CarpGrammarParser.ExpressionContext context)
    {
        if (context.Accept(this) is CarpObject carpObject)
            return carpObject;

        throw new InterpreterException(
            $"Expected CarpObject, but got {context.GetType().GetFormattedName()} instead.");
    }

    protected T VisitToken<T>(Context context) where T : Enum
    {
        if (context.Accept(this) is T token)
            return token;

        throw new InterpreterException(
            $"Expected token of {typeof(T).Name}, but got {context.GetType().GetFormattedName()} instead.");
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
            
            object nextResult = child.Accept(this);
            result = this.AggregateResult(result, nextResult);
        }
        return result;
    }
}
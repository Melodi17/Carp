namespace Carp.interpreter.visitors;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using exceptions;
using exceptions.impl;
using objects;
using objects.typing;
using scoping;
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

    /// Returns a function that can be used to set a value to the assignment target.
    protected Func<CarpObject, CarpObject> VisitSetter(CarpGrammarParser.ExpressionContext assignmentTarget)
    {
        // since we're not directly visiting the left side, copy the context to it
        assignmentTarget.ReplicateParent(assignmentTarget.Parent as Context 
                                         ?? throw new InvalidOperationException("Parent context is null"));
        
        if (assignmentTarget is CarpGrammarParser.VariableExpressionContext vec)
        {
            string name = vec.ID().GetText();
            Member member = assignmentTarget.Scope.Find(name);
            return value => member.Set(null, value);
        }
        if (assignmentTarget is CarpGrammarParser.IndexExpressionContext iec)
        {
            CarpObject obj = this.VisitExpression(iec.obj);
            CarpObject[] indexes = this.VisitExpression_list(iec.parameters);

            return value => obj.IndexSet(indexes, value);
        }
        if (assignmentTarget is CarpGrammarParser.PropertyExpressionContext pec)
        {
            CarpObject obj = this.VisitExpression(pec.obj);
            string? path = pec.path.Text;

            Member member = obj.Member(path, assignmentTarget.CurrentObject);
            return value => member.Set(member.Is(Modifiers.Static) ? null : obj, value);
        }
        throw new InvalidAssignmentTargetException("target of assignment is not a variable, index or property expression");
    }
    
    public override object Visit(IParseTree tree)
    {
        if (tree is Context ctx)
        {
            ctx.Position = ctx.Start.Line;
            if (tree.Parent is Context parent)
                ctx.ReplicateParent(parent);
            Console.WriteLine($"Visiting {ctx.GetType().GetFormattedName()} at line {ctx.Position} {(ctx.Scope != null ? $"in scope" : "")}");
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
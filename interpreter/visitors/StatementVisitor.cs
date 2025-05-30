namespace Carp.interpreter.visitors;

using exceptions;
using exceptions.flowcontrol;
using objects;
using scoping;

public partial class CarpVisitor
{
    public override object VisitProgram(CarpGrammarParser.ProgramContext context) => this.VisitBlock(context._statements) ?? CarpVoid.Instance;
    public override object VisitBlock(CarpGrammarParser.BlockContext context)
    {
        Scope s = new(context.Scope);
        context.Scope = s;

        object? res = this.VisitBlock(context._statements);
        s.Dispose();

        return res;
    }
    public object VisitBlock(IList<CarpGrammarParser.StatementContext> statements)
    {
        object? obj = null;

        foreach (CarpGrammarParser.StatementContext? statement in statements)
        {
            try
            {
                obj = this.Visit(statement);
            }
            catch (RuntimeException e)
            {
                e.AddStackFrame(new StackFrame(statement));
                throw;
            }
        }

        return obj as CarpObject ?? CarpVoid.Instance;
    }

    public override object VisitLambdaExpressionBlock(CarpGrammarParser.LambdaExpressionBlockContext context)
    {
        try
        {
            return this.Visit(context.expression());
        }
        catch (RuntimeException e)
        {
            e.AddStackFrame(new StackFrame(context.expression()));
            throw;
        }
    }
    public override object VisitLambdaBlock(CarpGrammarParser.LambdaBlockContext context)
    {
        try
        { 
            this.Visit(context.statement());
            return CarpVoid.Instance;
        }
        catch (RuntimeException e)
        {
            e.AddStackFrame(new StackFrame(context.statement()));
            throw;
        }
    }

    public override object VisitExpressionStatement(CarpGrammarParser.ExpressionStatementContext context) => base.VisitExpressionStatement(context);
    public override object VisitFlowControlStatement(CarpGrammarParser.FlowControlStatementContext context) => base.VisitFlowControlStatement(context);
    public override object VisitIf_statement(CarpGrammarParser.If_statementContext context)
    {
        CarpObject? condition = this.VisitExpression(context.cond);
        if (CarpObject.IsTruthy(condition))
            this.Visit(context.body);
        
        else if (context.else_block != null)
            this.Visit(context.else_block);
            
            
        // TODO implement else if
        return null!;
    }
    public override object VisitWhile_statement(CarpGrammarParser.While_statementContext context)
    {
        var cond = context.cond;

        while (CarpObject.IsTruthy(this.VisitExpression(cond)))
        {
            try
            {
                this.Visit(context.body);
            }
            catch (ContinueException) { }
            catch (BreakException)
            {
                break;
            }
        }

        return null!;
    }
    public override object VisitTry_statement(CarpGrammarParser.Try_statementContext context) => base.VisitTry_statement(context);
    public override object VisitIterStatement(CarpGrammarParser.IterStatementContext context) => base.VisitIterStatement(context);
    public override object VisitIterAsStatement(CarpGrammarParser.IterAsStatementContext context) => base.VisitIterAsStatement(context);
    public override object VisitIterAsUnpackedStatement(CarpGrammarParser.IterAsUnpackedStatementContext context) => base.VisitIterAsUnpackedStatement(context);
    public override object VisitReturn_statement(CarpGrammarParser.Return_statementContext context)
    {
        if (context.value != null)
            throw new ReturnException(this.VisitExpression(context.value));
        else
            throw new ReturnException(CarpVoid.Instance);
    }
    public override object VisitBreak_statement(CarpGrammarParser.Break_statementContext context)
    {
        throw new BreakException();
    }
    public override object VisitContinue_statement(CarpGrammarParser.Continue_statementContext context)
    {
        throw new ContinueException();
    }
    public override object VisitYield_statement(CarpGrammarParser.Yield_statementContext context) => base.VisitYield_statement(context);
    public override object VisitImportStatement(CarpGrammarParser.ImportStatementContext context) => base.VisitImportStatement(context);
}
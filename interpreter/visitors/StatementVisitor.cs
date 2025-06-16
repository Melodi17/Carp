namespace Carp.interpreter.visitors;

using exceptions;
using exceptions.flowcontrol;
using exceptions.impl;
using objects;
using objects.typing;
using scoping;

public partial class CarpVisitor
{
    public override object VisitProgram(CarpGrammarParser.ProgramContext context)
        => this.VisitBlock(context._statements) ?? CarpVoid.Instance;
    public override object VisitBlock(CarpGrammarParser.BlockContext context)
    {
        Scope s = new(context.Scope);
        context.Scope = s;

        object res = this.VisitBlock(context._statements);
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

    public override object VisitIf_statement(CarpGrammarParser.If_statementContext context)
    {
        CarpObject condition = this.VisitExpression(context.cond);
        if (CarpObject.IsTruthy(condition))
            this.Visit(context.body);

        else if (context.else_block != null)
            this.Visit(context.else_block);

        // TODO implement else if
        return null!;
    }
    public override object VisitWhile_statement(CarpGrammarParser.While_statementContext context)
    {
        CarpGrammarParser.ExpressionContext? cond = context.cond;

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
    public override object VisitTry_statement(CarpGrammarParser.Try_statementContext context)
        => base.VisitTry_statement(context);
    public override object VisitIterStatement(CarpGrammarParser.IterStatementContext context)
    {
        CarpObject iterable = this.VisitExpression(context.iter);
        if (iterable is not IIterable carpIterable)
            throw new ConversionException(iterable.GetCarpType(), IIterable.Type);

        IEnumerable<CarpObject> iterator = carpIterable.GetIterator();
        foreach (CarpObject _ in iterator)
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
    public override object VisitIterAsStatement(CarpGrammarParser.IterAsStatementContext context)
    {
        CarpObject iterable = this.VisitExpression(context.iter);
        if (iterable is not IIterable carpIterable)
            throw new ConversionException(iterable.GetCarpType(), IIterable.Type);

        CarpType type = this.VisitType(context.type());
        if (type == CarpType.Auto)
            // Set the item type to the type of the iterable
            type = iterable.GetCarpType().TypeArguments[0];

        string varName = context.ID().GetText();

        IEnumerable<CarpObject> iterator = carpIterable.GetIterator();

        // We set the value to void since it is undefined at this point.
        Member iterMember = new FieldMember(varName, type, CarpVoid.Instance);
        context.Scope = new Scope(context.Scope);
        context.Scope.Define(iterMember);
        foreach (CarpObject item in iterator)
        {
            try
            {
                // Coerce the item to the specified type
                CarpObject coercedItem = item.Coerce(type);
                iterMember.Set(null, coercedItem);
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
    public override object VisitIterAsUnpackedStatement(CarpGrammarParser.IterAsUnpackedStatementContext context)
        => base.VisitIterAsUnpackedStatement(context);
    public override object VisitReturn_statement(CarpGrammarParser.Return_statementContext context)
    {
        if (context.value != null)
            throw new ReturnException(this.VisitExpression(context.value));
        throw new ReturnException(CarpVoid.Instance);
    }
    public override object VisitBreak_statement(CarpGrammarParser.Break_statementContext context)
        => throw new BreakException();
    public override object VisitContinue_statement(CarpGrammarParser.Continue_statementContext context)
        => throw new ContinueException();
    public override object VisitYield_statement(CarpGrammarParser.Yield_statementContext context)
        => base.VisitYield_statement(context);
    public override object VisitImportStatement(CarpGrammarParser.ImportStatementContext context)
    {
        string fullPath = context.GetText()[7..].Trim(); // Remove "import "

        string? ver = fullPath.Contains(":") ? fullPath.Split(':')[1] : null;
        string[] parts = fullPath.Split(":")[0].Split('.');

        context.LibraryLoader.Import(context.Scope, parts);

        return null!;
    }
}
using Carp.exceptions;
using Carp.objects;
using Carp.scoping;

namespace Carp.interpreter.visitors;

public partial class CarpVisitor
{
    public override object VisitProgram(CarpGrammarParser.ProgramContext context)
    {
        return this.VisitBlock(context._statements) ?? CarpVoid.Instance;
    }
    public override object VisitBlock(CarpGrammarParser.BlockContext context)
    {
        Scope s = new(context.Scope);
        context.Scope = s;

        var res = this.VisitBlock(context._statements);
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
                e.AddStackFrame(new(statement));
                throw;
            }
        }

        return obj as CarpObject ?? CarpVoid.Instance;
    }
    public override object VisitExpressionStatement(CarpGrammarParser.ExpressionStatementContext context) => base.VisitExpressionStatement(context);
    public override object VisitFlowControlStatement(CarpGrammarParser.FlowControlStatementContext context) => base.VisitFlowControlStatement(context);
    public override object VisitIf_statement(CarpGrammarParser.If_statementContext context) => base.VisitIf_statement(context);
    public override object VisitWhile_statement(CarpGrammarParser.While_statementContext context) => base.VisitWhile_statement(context);
    public override object VisitTry_statement(CarpGrammarParser.Try_statementContext context) => base.VisitTry_statement(context);
    public override object VisitIterStatement(CarpGrammarParser.IterStatementContext context) => base.VisitIterStatement(context);
    public override object VisitIterAsStatement(CarpGrammarParser.IterAsStatementContext context) => base.VisitIterAsStatement(context);
    public override object VisitIterAsUnpackedStatement(CarpGrammarParser.IterAsUnpackedStatementContext context) => base.VisitIterAsUnpackedStatement(context);
    public override object VisitReturn_statement(CarpGrammarParser.Return_statementContext context) => base.VisitReturn_statement(context);
    public override object VisitBreak_statement(CarpGrammarParser.Break_statementContext context) => base.VisitBreak_statement(context);
    public override object VisitContinue_statement(CarpGrammarParser.Continue_statementContext context) => base.VisitContinue_statement(context);
    public override object VisitYield_statement(CarpGrammarParser.Yield_statementContext context) => base.VisitYield_statement(context);
    public override object VisitImportStatement(CarpGrammarParser.ImportStatementContext context) => base.VisitImportStatement(context);
}
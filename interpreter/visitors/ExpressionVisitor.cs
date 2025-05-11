using Carp.objects;
using Carp.parser;

namespace Carp.interpreter.visitors;

public partial class CarpVisitor
{
    public override object VisitComparisonExpression(CarpGrammarParser.ComparisonExpressionContext context)
    {
        var left = VisitExpression(context.left);
        var right = VisitExpression(context.right);
        var op = VisitToken<Comparison>(context.op);
        
        return op switch
        {
            Comparison.Equal => left.Equal(right),
            Comparison.NotEqual => left.NotEqual(right),
            Comparison.Greater => left.Greater(right),
            Comparison.GreaterEqual => left.GreaterEqual(right),
            Comparison.Less => left.Less(right),
            Comparison.LessEqual => left.LessEqual(right),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    public override object VisitLogicalExpression(CarpGrammarParser.LogicalExpressionContext context)
    {
        var left = VisitExpression(context.left);
        var op = VisitToken<Logical>(context.op);

        CarpObject GetRight() => VisitExpression(context.right);
        
        return op switch
        {
            Logical.And => CarpObject.LogicalAnd(left, GetRight),
            Logical.Or => CarpObject.LogicalOr(left, GetRight),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    public override object VisitBinaryExpression(CarpGrammarParser.BinaryExpressionContext context)
    {
        var left = VisitExpression(context.left);
        var right = VisitExpression(context.right);
        
        var op = VisitToken<Binary>(context.op);
        
        return op switch
        {
            Binary.Add => left.Add(right),
            Binary.Subtract => left.Subtract(right),
            Binary.Multiply => left.Multiply(right),
            Binary.Divide => left.Divide(right),
            Binary.Power => left.Power(right),
            Binary.Modulus => left.Modulus(right),
            Binary.LeftShift => left.LeftShift(right),
            Binary.RightShift => left.RightShift(right),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    public override object VisitUnaryExpression(CarpGrammarParser.UnaryExpressionContext context)
    {
        var obj = VisitExpression(context.left);
        var op = VisitToken<Unary>(context.op);

        return op switch
        {
            Unary.Negate => obj.Negate(),
            Unary.Not => obj.Not(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    public override object VisitAssignmentExpression(CarpGrammarParser.AssignmentExpressionContext context) => base.VisitAssignmentExpression(context);
    public override object VisitVariableExpression(CarpGrammarParser.VariableExpressionContext context) => base.VisitVariableExpression(context);
    public override object VisitWindExpression(CarpGrammarParser.WindExpressionContext context) => base.VisitWindExpression(context);
    public override object VisitCastExpression(CarpGrammarParser.CastExpressionContext context) => base.VisitCastExpression(context);
    public override object VisitParenthesizedExpression(CarpGrammarParser.ParenthesizedExpressionContext context) => base.VisitParenthesizedExpression(context);
    public override object VisitCallExpression(CarpGrammarParser.CallExpressionContext context) => base.VisitCallExpression(context);
    public override object VisitInfixExpression(CarpGrammarParser.InfixExpressionContext context) => base.VisitInfixExpression(context);
    public override object VisitCompoundAssignmentExpression(CarpGrammarParser.CompoundAssignmentExpressionContext context) => base.VisitCompoundAssignmentExpression(context);
    public override object VisitFilterExpression(CarpGrammarParser.FilterExpressionContext context) => base.VisitFilterExpression(context);
    public override object VisitIndexExpression(CarpGrammarParser.IndexExpressionContext context) => base.VisitIndexExpression(context);
    public override object VisitTernaryExpression(CarpGrammarParser.TernaryExpressionContext context) => base.VisitTernaryExpression(context);
    public override object VisitPostfixExpression(CarpGrammarParser.PostfixExpressionContext context) => base.VisitPostfixExpression(context);
    public override object VisitPropertyExpression(CarpGrammarParser.PropertyExpressionContext context) => base.VisitPropertyExpression(context);
    public override object VisitEndRangeExpression(CarpGrammarParser.EndRangeExpressionContext context) => base.VisitEndRangeExpression(context);
    public override object VisitCompareTypeExpression(CarpGrammarParser.CompareTypeExpressionContext context) => base.VisitCompareTypeExpression(context);
}
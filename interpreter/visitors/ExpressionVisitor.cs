namespace Carp.interpreter.visitors;

using exceptions;
using exceptions.impl;
using objects;
using parser;
using scoping;

public partial class CarpVisitor
{
    public object VisitComparisonExpression(CarpGrammarParser.ExpressionContext context, CarpGrammarParser.ExpressionContext leftCtx, CarpGrammarParser.ExpressionContext rightCtx, Context opCtx)
    {
        CarpObject? left = this.VisitExpression(leftCtx);
        CarpObject? right = this.VisitExpression(rightCtx);
        Comparison op = this.VisitToken<Comparison>(opCtx);

        return op switch
        {
            Comparison.Equal => left.Equal(right),
            Comparison.NotEqual => left.NotEqual(right),
            Comparison.Greater => left.Greater(right),
            Comparison.GreaterEqual => left.GreaterEqual(right),
            Comparison.Less => left.Less(right),
            Comparison.LessEqual => left.LessEqual(right),
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
    public override object VisitComparisonCompareExpression(CarpGrammarParser.ComparisonCompareExpressionContext context)
        => this.VisitComparisonExpression(context, context.left, context.right, context.op);
    public override object VisitComparisonMatchExpression(CarpGrammarParser.ComparisonMatchExpressionContext context)
        => this.VisitComparisonExpression(context, context.left, context.right, context.op);

    public override object VisitLogicalExpression(CarpGrammarParser.LogicalExpressionContext context)
    {
        CarpObject? left = this.VisitExpression(context.left);
        Logical op = this.VisitToken<Logical>(context.op);

        CarpObject GetRight() => this.VisitExpression(context.right);

        return op switch
        {
            Logical.And => CarpObject.LogicalAnd(left, GetRight),
            Logical.Or => CarpObject.LogicalOr(left, GetRight),
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
    public object VisitBinaryExpression(CarpGrammarParser.ExpressionContext context, CarpGrammarParser.ExpressionContext leftCtx, CarpGrammarParser.ExpressionContext rightCtx, Context opCtx)
    {
        CarpObject? left = this.VisitExpression(leftCtx);
        CarpObject? right = this.VisitExpression(rightCtx);

        if (left.GetCarpType().Group == "number")
            right = right.Coerce(left.GetCarpType());

        Binary op = this.VisitToken<Binary>(opCtx);

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
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
    public override object VisitBinaryArithmaticExpression(CarpGrammarParser.BinaryArithmaticExpressionContext context)
        => this.VisitBinaryExpression(context, context.left, context.right, context.op);
    public override object VisitBinaryBitwiseShiftExpression(CarpGrammarParser.BinaryBitwiseShiftExpressionContext context)
        => this.VisitBinaryExpression(context, context.left, context.right, context.op);
    public override object VisitBinaryGeometricExpression(CarpGrammarParser.BinaryGeometricExpressionContext context)
        => this.VisitBinaryExpression(context, context.left, context.right, context.op);
    public override object VisitUnaryExpression(CarpGrammarParser.UnaryExpressionContext context)
    {
        CarpObject? obj = this.VisitExpression(context.left);
        Unary op = this.VisitToken<Unary>(context.op);

        return op switch
        {
            Unary.Negate => obj.Negate(),
            Unary.Not => obj.Not(),
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public override object VisitMetaMemberExpression(CarpGrammarParser.MetaMemberExpressionContext context)
    {
        CarpObject obj = this.VisitExpression(context.obj);
        string member = context.member.Text ?? throw new InterpreterException("Member token missing");
        Meta op = this.VisitToken<Meta>(context.op);

        // Meta flag is used to access even private members
        Member objMember = obj.Member(member, context.CurrentObject, true);
        return op switch
        {
            Meta.Doc => objMember.Docstring == null ? CarpString.Empty : CarpString.Create(objMember.Docstring),
            // TODO: Implement annotations
            // Meta.Annotations => objMember.Annotations,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public override object VisitMetaObjExpression(CarpGrammarParser.MetaObjExpressionContext context)
    {
        string member = context.member.Text ?? throw new InterpreterException("Member token missing");
        Meta op = this.VisitToken<Meta>(context.op);

        // Meta flag is used to access even private members
        Member objMember = context.Scope!.Find(member);
        return op switch
        {
            Meta.Doc => objMember.Docstring == null ? CarpString.Empty : CarpString.Create(objMember.Docstring),
            // TODO: Implement annotations
            // Meta.Annotations => objMember.Annotations,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
    public override object VisitAssignmentExpression(CarpGrammarParser.AssignmentExpressionContext context)
    {
        CarpGrammarParser.ExpressionContext assignmentTarget = context.left;
        // since we're not directly visiting the left side, copy the context to it
        assignmentTarget.ReplicateParent(context);

        CarpObject value = this.VisitExpression(context.right);

        if (assignmentTarget is CarpGrammarParser.VariableExpressionContext vec)
        {
            string name = vec.ID().GetText();
            Member member = context.Scope.Find(name);
            return member.Set(null, value);
        }
        if (assignmentTarget is CarpGrammarParser.IndexExpressionContext iec)
        {
            // TODO: Implement index assignment
            throw new NotImplementedException("Index assignment is not implemented yet");
        }
        if (assignmentTarget is CarpGrammarParser.PropertyExpressionContext pec)
        {
            CarpObject obj = this.VisitExpression(pec.obj);
            string? path = pec.path.Text;

            Member member = obj.Member(path, context.CurrentObject);
            return member.Set(member.Is(Modifiers.Static) ? null : obj, value);
        }
        throw new InvalidAssignmentTargetException("target of assignment is not a variable, index or property expression");
    }
    public override object VisitVariableExpression(CarpGrammarParser.VariableExpressionContext context)
    {
        string name = context.ID().GetText();
        if (name == "this")
        {
            if (context.CurrentObject == null)
                throw new ThisOutsideObjectException();
            return context.CurrentObject;
        }

        Member member = context.Scope.Find(name);

        // Self is null because we are looking at
        // this outside of an object
        return member.Get(null);
    }
    public override object VisitWindExpression(CarpGrammarParser.WindExpressionContext context) => base.VisitWindExpression(context);
    public override object VisitCastExpression(CarpGrammarParser.CastExpressionContext context) => base.VisitCastExpression(context);
    public override object VisitParenthesizedExpression(CarpGrammarParser.ParenthesizedExpressionContext context) => base.VisitParenthesizedExpression(context);
    public override object VisitCallExpression(CarpGrammarParser.CallExpressionContext context)
    {
        CarpObject? obj = this.VisitExpression(context.obj);
        CarpObject[] args = this.Visit(context.parameters) as CarpObject[] ?? throw new InterpreterException("Parameters must be a CarpObject array");
        return obj.Call(args);
    }
    public override object VisitInfixExpression(CarpGrammarParser.InfixExpressionContext context) => base.VisitInfixExpression(context);
    public override object VisitCompoundAssignmentExpression(CarpGrammarParser.CompoundAssignmentExpressionContext context) => base.VisitCompoundAssignmentExpression(context);
    public override object VisitFilterExpression(CarpGrammarParser.FilterExpressionContext context) => base.VisitFilterExpression(context);
    public override object VisitIndexExpression(CarpGrammarParser.IndexExpressionContext context) => base.VisitIndexExpression(context);
    public override object VisitTernaryExpression(CarpGrammarParser.TernaryExpressionContext context) => base.VisitTernaryExpression(context);
    public override object VisitPostfixExpression(CarpGrammarParser.PostfixExpressionContext context) => base.VisitPostfixExpression(context);
    public override object VisitPropertyExpression(CarpGrammarParser.PropertyExpressionContext context)
    {
        CarpObject obj = this.VisitExpression(context.obj);
        string? path = context.path.Text;

        Member member = obj.Member(path, context.CurrentObject);
        return member.Get(member.Is(Modifiers.Static) ? null : obj);
    }
    public override object VisitEndRangeExpression(CarpGrammarParser.EndRangeExpressionContext context) => base.VisitEndRangeExpression(context);
    public override object VisitCompareTypeExpression(CarpGrammarParser.CompareTypeExpressionContext context) => base.VisitCompareTypeExpression(context);
}
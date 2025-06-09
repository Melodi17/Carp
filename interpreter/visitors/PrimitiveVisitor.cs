namespace Carp.interpreter.visitors;

using exceptions;
using objects;
using objects.typing;

public partial class CarpVisitor
{
    public override CarpNumber VisitIntConstant(CarpGrammarParser.IntConstantContext context)
    {
        bool success = double.TryParse(context.INT().GetText(), out double result);
        if (!success)
            throw new InterpreterException($"Invalid integer constant: {context.INT().GetText()}");

        return CarpNumber.Create(result);
    }
    public override CarpString VisitStringConstant(CarpGrammarParser.StringConstantContext context)
    {
        string text = context.STRING().GetText();
        if (text.Length < 2)
            throw new InterpreterException($"Invalid string constant: {context.STRING().GetText()}");
        text = text[1..^1]; // Remove the quotes
        return CarpString.Create(text);
    }
    public override object VisitCharConstant(CarpGrammarParser.CharConstantContext context)
        => base.VisitCharConstant(context);
    public override CarpBoolean VisitTrueConstant(CarpGrammarParser.TrueConstantContext context) => CarpBoolean.True;
    public override CarpBoolean VisitFalseConstant(CarpGrammarParser.FalseConstantContext context) => CarpBoolean.False;
    public override CarpNull VisitNullConstant(CarpGrammarParser.NullConstantContext context) => CarpNull.Instance;

    public override CarpCollection VisitArray(CarpGrammarParser.ArrayContext context)
    {
        CarpObject[] arr = (CarpObject[]) this.Visit(context.expression_list());
        CarpType type = CarpType.HighestCommonType(arr.Select(x => x.GetCarpType()).ToArray());

        return new CarpCollection(type, arr);
    }
    public override object VisitMap(CarpGrammarParser.MapContext context) => base.VisitMap(context);
    public override CarpRange VisitRangeExpression(CarpGrammarParser.RangeExpressionContext context)
    {
        CarpObject start = this.VisitExpression(context.left);
        CarpObject end = this.VisitExpression(context.right);

        CarpType itemType = CarpType.HighestCommonType(start.GetCarpType(), end.GetCarpType());
        return new CarpRange(itemType, start, end);
    }

    public override CarpRange VisitRangeEndExpression(CarpGrammarParser.RangeEndExpressionContext context)
    {
        CarpObject end = this.VisitExpression(context.right);
        CarpType itemType = end.GetCarpType();

        return new CarpRange(itemType, null, end);
    }
    public override CarpRange VisitRangeStartExpression(CarpGrammarParser.RangeStartExpressionContext context)
    {
        CarpObject start = this.VisitExpression(context.left);
        CarpType itemType = start.GetCarpType();

        return new CarpRange(itemType, start, null);
    }

    public override (CarpType CarpType, string Name)[] VisitType_name_list(
        CarpGrammarParser.Type_name_listContext context)
    {
        context.TryReplicateParent();
        
        return context
            ._types.Zip(context._names, (type, name) => (CarpType: this.VisitType(type), Name: name.Text))
            .ToArray();
    }
    public override CarpObject[] VisitExpression_list(CarpGrammarParser.Expression_listContext context)
    {
        context.TryReplicateParent();
        
        return context._expressions.Select(this.VisitExpression).ToArray();
    }
}
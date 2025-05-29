using Carp.exceptions;
using Carp.objects;
using Carp.parser;

namespace Carp.interpreter.visitors;

public partial class CarpVisitor
{
    public override object VisitIntConstant(CarpGrammarParser.IntConstantContext context)
    {
        bool success = double.TryParse(context.INT().GetText(), out double result);
        if (!success)
            throw new InterpreterException($"Invalid integer constant: {context.INT().GetText()}");
        
        return CarpNumber.Create(result);
    }
    public override object VisitStringConstant(CarpGrammarParser.StringConstantContext context)
    {
        string text = context.STRING().GetText();
        if (text.Length < 2)
            throw new InterpreterException($"Invalid string constant: {context.STRING().GetText()}");
        text = text[1..^1]; // Remove the quotes
        return CarpString.Create(text);
    }
    public override object VisitCharConstant(CarpGrammarParser.CharConstantContext context) => base.VisitCharConstant(context);
    public override object VisitTrueConstant(CarpGrammarParser.TrueConstantContext context) => CarpBoolean.True;
    public override object VisitFalseConstant(CarpGrammarParser.FalseConstantContext context) => CarpBoolean.False;
    public override object VisitNullConstant(CarpGrammarParser.NullConstantContext context) => CarpNull.Instance;

    public override object VisitArray(CarpGrammarParser.ArrayContext context) => base.VisitArray(context);
    public override object VisitMap(CarpGrammarParser.MapContext context) => base.VisitMap(context);
    public override object VisitRangeExpression(CarpGrammarParser.RangeExpressionContext context) => base.VisitRangeExpression(context);
}
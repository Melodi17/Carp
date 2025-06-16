namespace Carp.interpreter.visitors;

using parser;
using scoping;

public partial class CarpVisitor
{
    public override object VisitAddCompound(CarpGrammarParser.AddCompoundContext context) => Compound.Add;
    public override object VisitSubtractCompound(CarpGrammarParser.SubtractCompoundContext context)
        => Compound.Subtract;
    public override object VisitMultiplyCompound(CarpGrammarParser.MultiplyCompoundContext context)
        => Compound.Multiply;
    public override object VisitDivideCompound(CarpGrammarParser.DivideCompoundContext context) => Compound.Divide;
    public override object VisitPowerCompound(CarpGrammarParser.PowerCompoundContext context) => Compound.Power;
    public override object VisitModulusCompound(CarpGrammarParser.ModulusCompoundContext context) => Compound.Modulus;

    public override object VisitNegateUnary(CarpGrammarParser.NegateUnaryContext context) => Unary.Negate;
    public override object VisitNotUnary(CarpGrammarParser.NotUnaryContext context) => Unary.Not;

    public override object VisitAndLogical(CarpGrammarParser.AndLogicalContext context) => Logical.And;
    public override object VisitOrLogical(CarpGrammarParser.OrLogicalContext context) => Logical.Or;

    public override object VisitMatchComparison(CarpGrammarParser.MatchComparisonContext context) => Comparison.Equal;
    public override object VisitNotMatchComparison(CarpGrammarParser.NotMatchComparisonContext context)
        => Comparison.NotEqual;
    public override object VisitGreaterThanComparison(CarpGrammarParser.GreaterThanComparisonContext context)
        => Comparison.Greater;
    public override object VisitLessThanComparison(CarpGrammarParser.LessThanComparisonContext context)
        => Comparison.Less;
    public override object VisitGreaterThanEqualsComparison(
        CarpGrammarParser.GreaterThanEqualsComparisonContext context)
        => Comparison.GreaterEqual;
    public override object VisitLessThanEqualsComparison(CarpGrammarParser.LessThanEqualsComparisonContext context)
        => Comparison.LessEqual;

    public override object VisitAddBinary(CarpGrammarParser.AddBinaryContext context) => Binary.Add;
    public override object VisitSubtractBinary(CarpGrammarParser.SubtractBinaryContext context) => Binary.Subtract;
    public override object VisitMultiplicationBinary(CarpGrammarParser.MultiplicationBinaryContext context)
        => Binary.Multiply;
    public override object VisitDivideBinary(CarpGrammarParser.DivideBinaryContext context) => Binary.Divide;
    public override object VisitPowerBinary(CarpGrammarParser.PowerBinaryContext context) => Binary.Power;
    public override object VisitModulusBinary(CarpGrammarParser.ModulusBinaryContext context) => Binary.Modulus;
    public override object VisitLeftShiftBinary(CarpGrammarParser.LeftShiftBinaryContext context) => Binary.LeftShift;
    public override object VisitRightShiftBinary(CarpGrammarParser.RightShiftBinaryContext context)
        => Binary.RightShift;

    public override object VisitDocMeta(CarpGrammarParser.DocMetaContext context) => Meta.Doc;
    public override object VisitAnnotationsMeta(CarpGrammarParser.AnnotationsMetaContext context) => Meta.Annotations;

    public override object VisitPrivateModifier(CarpGrammarParser.PrivateModifierContext context) => Modifiers.Private;
    public override object VisitStaticModifier(CarpGrammarParser.StaticModifierContext context) => Modifiers.Static;
    public override object VisitProtectedModifier(CarpGrammarParser.ProtectedModifierContext context)
        => Modifiers.Protected;
    public override object VisitAbstractModifier(CarpGrammarParser.AbstractModifierContext context)
        => Modifiers.Abstract;
    public override object VisitFinalModifier(CarpGrammarParser.FinalModifierContext context) => Modifiers.Final;
}
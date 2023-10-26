//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/melod/source/csharp/Carp/CarpGrammar.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="CarpGrammarParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface ICarpGrammarVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] CarpGrammarParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] CarpGrammarParser.BlockContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>enclosedBlock</c>
	/// labeled alternative in <see cref="CarpGrammarParser.generic_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnclosedBlock([NotNull] CarpGrammarParser.EnclosedBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>lambdaExpressionBlock</c>
	/// labeled alternative in <see cref="CarpGrammarParser.generic_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLambdaExpressionBlock([NotNull] CarpGrammarParser.LambdaExpressionBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>lambdaBlock</c>
	/// labeled alternative in <see cref="CarpGrammarParser.generic_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLambdaBlock([NotNull] CarpGrammarParser.LambdaBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>definitionStatement</c>
	/// labeled alternative in <see cref="CarpGrammarParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefinitionStatement([NotNull] CarpGrammarParser.DefinitionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expressionStatement</c>
	/// labeled alternative in <see cref="CarpGrammarParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionStatement([NotNull] CarpGrammarParser.ExpressionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>flowControlStatement</c>
	/// labeled alternative in <see cref="CarpGrammarParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFlowControlStatement([NotNull] CarpGrammarParser.FlowControlStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.flow_control"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFlow_control([NotNull] CarpGrammarParser.Flow_controlContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.if_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIf_statement([NotNull] CarpGrammarParser.If_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.while_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhile_statement([NotNull] CarpGrammarParser.While_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.try_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTry_statement([NotNull] CarpGrammarParser.Try_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>iterStatement</c>
	/// labeled alternative in <see cref="CarpGrammarParser.iter_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIterStatement([NotNull] CarpGrammarParser.IterStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>iterAsStatement</c>
	/// labeled alternative in <see cref="CarpGrammarParser.iter_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIterAsStatement([NotNull] CarpGrammarParser.IterAsStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>iterAsUnpackedStatement</c>
	/// labeled alternative in <see cref="CarpGrammarParser.iter_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIterAsUnpackedStatement([NotNull] CarpGrammarParser.IterAsUnpackedStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.return_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturn_statement([NotNull] CarpGrammarParser.Return_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.break_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBreak_statement([NotNull] CarpGrammarParser.Break_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.continue_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitContinue_statement([NotNull] CarpGrammarParser.Continue_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.yield_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitYield_statement([NotNull] CarpGrammarParser.Yield_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.attribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAttribute([NotNull] CarpGrammarParser.AttributeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.definition_with_attr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefinition_with_attr([NotNull] CarpGrammarParser.Definition_with_attrContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>initializedVariableDefinition</c>
	/// labeled alternative in <see cref="CarpGrammarParser.definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInitializedVariableDefinition([NotNull] CarpGrammarParser.InitializedVariableDefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>variableDefinition</c>
	/// labeled alternative in <see cref="CarpGrammarParser.definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableDefinition([NotNull] CarpGrammarParser.VariableDefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>functionDefinition</c>
	/// labeled alternative in <see cref="CarpGrammarParser.definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionDefinition([NotNull] CarpGrammarParser.FunctionDefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>emptyFunctionDefinition</c>
	/// labeled alternative in <see cref="CarpGrammarParser.definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEmptyFunctionDefinition([NotNull] CarpGrammarParser.EmptyFunctionDefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>classDefinition</c>
	/// labeled alternative in <see cref="CarpGrammarParser.definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassDefinition([NotNull] CarpGrammarParser.ClassDefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>structDefinition</c>
	/// labeled alternative in <see cref="CarpGrammarParser.definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStructDefinition([NotNull] CarpGrammarParser.StructDefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>mapExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMapExpression([NotNull] CarpGrammarParser.MapExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>constantExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstantExpression([NotNull] CarpGrammarParser.ConstantExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>arrayExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayExpression([NotNull] CarpGrammarParser.ArrayExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>assignmentExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignmentExpression([NotNull] CarpGrammarParser.AssignmentExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>comparisonExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComparisonExpression([NotNull] CarpGrammarParser.ComparisonExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>logicalExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalExpression([NotNull] CarpGrammarParser.LogicalExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>variableExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableExpression([NotNull] CarpGrammarParser.VariableExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>windExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWindExpression([NotNull] CarpGrammarParser.WindExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>binaryExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinaryExpression([NotNull] CarpGrammarParser.BinaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>castExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCastExpression([NotNull] CarpGrammarParser.CastExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>parenthesizedExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenthesizedExpression([NotNull] CarpGrammarParser.ParenthesizedExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>callExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCallExpression([NotNull] CarpGrammarParser.CallExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>infixExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInfixExpression([NotNull] CarpGrammarParser.InfixExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>compoundAssignmentExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompoundAssignmentExpression([NotNull] CarpGrammarParser.CompoundAssignmentExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>filterExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFilterExpression([NotNull] CarpGrammarParser.FilterExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>rangeExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRangeExpression([NotNull] CarpGrammarParser.RangeExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>indexExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndexExpression([NotNull] CarpGrammarParser.IndexExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>unaryExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryExpression([NotNull] CarpGrammarParser.UnaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ternaryExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTernaryExpression([NotNull] CarpGrammarParser.TernaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>postfixExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPostfixExpression([NotNull] CarpGrammarParser.PostfixExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>propertyExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPropertyExpression([NotNull] CarpGrammarParser.PropertyExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>endRangeExpression</c>
	/// labeled alternative in <see cref="CarpGrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEndRangeExpression([NotNull] CarpGrammarParser.EndRangeExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.expression_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression_list([NotNull] CarpGrammarParser.Expression_listContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>addCompound</c>
	/// labeled alternative in <see cref="CarpGrammarParser.compoundAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddCompound([NotNull] CarpGrammarParser.AddCompoundContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>subtractCompound</c>
	/// labeled alternative in <see cref="CarpGrammarParser.compoundAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubtractCompound([NotNull] CarpGrammarParser.SubtractCompoundContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>multiplyCompound</c>
	/// labeled alternative in <see cref="CarpGrammarParser.compoundAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiplyCompound([NotNull] CarpGrammarParser.MultiplyCompoundContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>divideCompound</c>
	/// labeled alternative in <see cref="CarpGrammarParser.compoundAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDivideCompound([NotNull] CarpGrammarParser.DivideCompoundContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>powerCompound</c>
	/// labeled alternative in <see cref="CarpGrammarParser.compoundAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPowerCompound([NotNull] CarpGrammarParser.PowerCompoundContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>modulusCompound</c>
	/// labeled alternative in <see cref="CarpGrammarParser.compoundAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitModulusCompound([NotNull] CarpGrammarParser.ModulusCompoundContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>intConstant</c>
	/// labeled alternative in <see cref="CarpGrammarParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIntConstant([NotNull] CarpGrammarParser.IntConstantContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>stringConstant</c>
	/// labeled alternative in <see cref="CarpGrammarParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStringConstant([NotNull] CarpGrammarParser.StringConstantContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>trueConstant</c>
	/// labeled alternative in <see cref="CarpGrammarParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTrueConstant([NotNull] CarpGrammarParser.TrueConstantContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>falseConstant</c>
	/// labeled alternative in <see cref="CarpGrammarParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFalseConstant([NotNull] CarpGrammarParser.FalseConstantContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>nullConstant</c>
	/// labeled alternative in <see cref="CarpGrammarParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNullConstant([NotNull] CarpGrammarParser.NullConstantContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>negateUnary</c>
	/// labeled alternative in <see cref="CarpGrammarParser.unary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNegateUnary([NotNull] CarpGrammarParser.NegateUnaryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>notUnary</c>
	/// labeled alternative in <see cref="CarpGrammarParser.unary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNotUnary([NotNull] CarpGrammarParser.NotUnaryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>andLogical</c>
	/// labeled alternative in <see cref="CarpGrammarParser.logical"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAndLogical([NotNull] CarpGrammarParser.AndLogicalContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>orLogical</c>
	/// labeled alternative in <see cref="CarpGrammarParser.logical"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrLogical([NotNull] CarpGrammarParser.OrLogicalContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>matchComparison</c>
	/// labeled alternative in <see cref="CarpGrammarParser.comparison"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMatchComparison([NotNull] CarpGrammarParser.MatchComparisonContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>notMatchComparison</c>
	/// labeled alternative in <see cref="CarpGrammarParser.comparison"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNotMatchComparison([NotNull] CarpGrammarParser.NotMatchComparisonContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>greaterThanComparison</c>
	/// labeled alternative in <see cref="CarpGrammarParser.comparison"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGreaterThanComparison([NotNull] CarpGrammarParser.GreaterThanComparisonContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>lessThanComparison</c>
	/// labeled alternative in <see cref="CarpGrammarParser.comparison"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLessThanComparison([NotNull] CarpGrammarParser.LessThanComparisonContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>greaterThanEqualsComparison</c>
	/// labeled alternative in <see cref="CarpGrammarParser.comparison"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGreaterThanEqualsComparison([NotNull] CarpGrammarParser.GreaterThanEqualsComparisonContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>lessThanEqualsComparison</c>
	/// labeled alternative in <see cref="CarpGrammarParser.comparison"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLessThanEqualsComparison([NotNull] CarpGrammarParser.LessThanEqualsComparisonContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>addBinary</c>
	/// labeled alternative in <see cref="CarpGrammarParser.binary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddBinary([NotNull] CarpGrammarParser.AddBinaryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>subtractBinary</c>
	/// labeled alternative in <see cref="CarpGrammarParser.binary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubtractBinary([NotNull] CarpGrammarParser.SubtractBinaryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>multiplicationBinary</c>
	/// labeled alternative in <see cref="CarpGrammarParser.binary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiplicationBinary([NotNull] CarpGrammarParser.MultiplicationBinaryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>divideBinary</c>
	/// labeled alternative in <see cref="CarpGrammarParser.binary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDivideBinary([NotNull] CarpGrammarParser.DivideBinaryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>powerBinary</c>
	/// labeled alternative in <see cref="CarpGrammarParser.binary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPowerBinary([NotNull] CarpGrammarParser.PowerBinaryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>modulusBinary</c>
	/// labeled alternative in <see cref="CarpGrammarParser.binary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitModulusBinary([NotNull] CarpGrammarParser.ModulusBinaryContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.array"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArray([NotNull] CarpGrammarParser.ArrayContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.map"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMap([NotNull] CarpGrammarParser.MapContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>privateModifier</c>
	/// labeled alternative in <see cref="CarpGrammarParser.modifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrivateModifier([NotNull] CarpGrammarParser.PrivateModifierContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>namedType</c>
	/// labeled alternative in <see cref="CarpGrammarParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNamedType([NotNull] CarpGrammarParser.NamedTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>autoType</c>
	/// labeled alternative in <see cref="CarpGrammarParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAutoType([NotNull] CarpGrammarParser.AutoTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>mapType</c>
	/// labeled alternative in <see cref="CarpGrammarParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMapType([NotNull] CarpGrammarParser.MapTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>listType</c>
	/// labeled alternative in <see cref="CarpGrammarParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitListType([NotNull] CarpGrammarParser.ListTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.type_name_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType_name_list([NotNull] CarpGrammarParser.Type_name_listContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CarpGrammarParser.name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitName([NotNull] CarpGrammarParser.NameContext context);
}

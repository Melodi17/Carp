// Generated from D:/Source/csharp/Carp/CarpGrammar.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.tree.ParseTreeVisitor;

/**
 * This interface defines a complete generic visitor for a parse tree produced
 * by {@link CarpGrammarParser}.
 *
 * @param <T> The return type of the visit operation. Use {@link Void} for
 * operations with no return type.
 */
public interface CarpGrammarVisitor<T> extends ParseTreeVisitor<T> {
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#program}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitProgram(CarpGrammarParser.ProgramContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#block}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBlock(CarpGrammarParser.BlockContext ctx);
	/**
	 * Visit a parse tree produced by the {@code enclosedBlock}
	 * labeled alternative in {@link CarpGrammarParser#generic_block}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEnclosedBlock(CarpGrammarParser.EnclosedBlockContext ctx);
	/**
	 * Visit a parse tree produced by the {@code lambdaExpressionBlock}
	 * labeled alternative in {@link CarpGrammarParser#generic_block}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLambdaExpressionBlock(CarpGrammarParser.LambdaExpressionBlockContext ctx);
	/**
	 * Visit a parse tree produced by the {@code lambdaBlock}
	 * labeled alternative in {@link CarpGrammarParser#generic_block}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLambdaBlock(CarpGrammarParser.LambdaBlockContext ctx);
	/**
	 * Visit a parse tree produced by the {@code definitionStatement}
	 * labeled alternative in {@link CarpGrammarParser#statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDefinitionStatement(CarpGrammarParser.DefinitionStatementContext ctx);
	/**
	 * Visit a parse tree produced by the {@code expressionStatement}
	 * labeled alternative in {@link CarpGrammarParser#statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExpressionStatement(CarpGrammarParser.ExpressionStatementContext ctx);
	/**
	 * Visit a parse tree produced by the {@code flowControlStatement}
	 * labeled alternative in {@link CarpGrammarParser#statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFlowControlStatement(CarpGrammarParser.FlowControlStatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#flow_control}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFlow_control(CarpGrammarParser.Flow_controlContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#if_statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIf_statement(CarpGrammarParser.If_statementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#while_statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitWhile_statement(CarpGrammarParser.While_statementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#try_statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTry_statement(CarpGrammarParser.Try_statementContext ctx);
	/**
	 * Visit a parse tree produced by the {@code iterStatement}
	 * labeled alternative in {@link CarpGrammarParser#iter_statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIterStatement(CarpGrammarParser.IterStatementContext ctx);
	/**
	 * Visit a parse tree produced by the {@code iterAsStatement}
	 * labeled alternative in {@link CarpGrammarParser#iter_statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIterAsStatement(CarpGrammarParser.IterAsStatementContext ctx);
	/**
	 * Visit a parse tree produced by the {@code iterAsUnpackedStatement}
	 * labeled alternative in {@link CarpGrammarParser#iter_statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIterAsUnpackedStatement(CarpGrammarParser.IterAsUnpackedStatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#return_statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitReturn_statement(CarpGrammarParser.Return_statementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#break_statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBreak_statement(CarpGrammarParser.Break_statementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#continue_statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitContinue_statement(CarpGrammarParser.Continue_statementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#yield_statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitYield_statement(CarpGrammarParser.Yield_statementContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#attribute}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAttribute(CarpGrammarParser.AttributeContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#definition_with_attr}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDefinition_with_attr(CarpGrammarParser.Definition_with_attrContext ctx);
	/**
	 * Visit a parse tree produced by the {@code functionDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunctionDefinition(CarpGrammarParser.FunctionDefinitionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code emptyFunctionDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEmptyFunctionDefinition(CarpGrammarParser.EmptyFunctionDefinitionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code initializedVariableDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitInitializedVariableDefinition(CarpGrammarParser.InitializedVariableDefinitionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code variableDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitVariableDefinition(CarpGrammarParser.VariableDefinitionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code classDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitClassDefinition(CarpGrammarParser.ClassDefinitionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code structDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitStructDefinition(CarpGrammarParser.StructDefinitionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code enumDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEnumDefinition(CarpGrammarParser.EnumDefinitionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code mapExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMapExpression(CarpGrammarParser.MapExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code lambdaExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLambdaExpression(CarpGrammarParser.LambdaExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code constantExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitConstantExpression(CarpGrammarParser.ConstantExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code arrayExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitArrayExpression(CarpGrammarParser.ArrayExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code assignmentExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAssignmentExpression(CarpGrammarParser.AssignmentExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code comparisonExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitComparisonExpression(CarpGrammarParser.ComparisonExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code logicalExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLogicalExpression(CarpGrammarParser.LogicalExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code variableExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitVariableExpression(CarpGrammarParser.VariableExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code windExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitWindExpression(CarpGrammarParser.WindExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code binaryExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBinaryExpression(CarpGrammarParser.BinaryExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code castExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCastExpression(CarpGrammarParser.CastExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code parenthesizedExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitParenthesizedExpression(CarpGrammarParser.ParenthesizedExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code callExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCallExpression(CarpGrammarParser.CallExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code infixExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitInfixExpression(CarpGrammarParser.InfixExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code compoundAssignmentExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCompoundAssignmentExpression(CarpGrammarParser.CompoundAssignmentExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code filterExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFilterExpression(CarpGrammarParser.FilterExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code rangeExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitRangeExpression(CarpGrammarParser.RangeExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code indexExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIndexExpression(CarpGrammarParser.IndexExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code unaryExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitUnaryExpression(CarpGrammarParser.UnaryExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code ternaryExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTernaryExpression(CarpGrammarParser.TernaryExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code postfixExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPostfixExpression(CarpGrammarParser.PostfixExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code propertyExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPropertyExpression(CarpGrammarParser.PropertyExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code endRangeExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitEndRangeExpression(CarpGrammarParser.EndRangeExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code compareTypeExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCompareTypeExpression(CarpGrammarParser.CompareTypeExpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#expression_list}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExpression_list(CarpGrammarParser.Expression_listContext ctx);
	/**
	 * Visit a parse tree produced by the {@code addCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAddCompound(CarpGrammarParser.AddCompoundContext ctx);
	/**
	 * Visit a parse tree produced by the {@code subtractCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSubtractCompound(CarpGrammarParser.SubtractCompoundContext ctx);
	/**
	 * Visit a parse tree produced by the {@code multiplyCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMultiplyCompound(CarpGrammarParser.MultiplyCompoundContext ctx);
	/**
	 * Visit a parse tree produced by the {@code divideCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDivideCompound(CarpGrammarParser.DivideCompoundContext ctx);
	/**
	 * Visit a parse tree produced by the {@code powerCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPowerCompound(CarpGrammarParser.PowerCompoundContext ctx);
	/**
	 * Visit a parse tree produced by the {@code modulusCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitModulusCompound(CarpGrammarParser.ModulusCompoundContext ctx);
	/**
	 * Visit a parse tree produced by the {@code intConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIntConstant(CarpGrammarParser.IntConstantContext ctx);
	/**
	 * Visit a parse tree produced by the {@code stringConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitStringConstant(CarpGrammarParser.StringConstantContext ctx);
	/**
	 * Visit a parse tree produced by the {@code charConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCharConstant(CarpGrammarParser.CharConstantContext ctx);
	/**
	 * Visit a parse tree produced by the {@code trueConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitTrueConstant(CarpGrammarParser.TrueConstantContext ctx);
	/**
	 * Visit a parse tree produced by the {@code falseConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFalseConstant(CarpGrammarParser.FalseConstantContext ctx);
	/**
	 * Visit a parse tree produced by the {@code nullConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNullConstant(CarpGrammarParser.NullConstantContext ctx);
	/**
	 * Visit a parse tree produced by the {@code negateUnary}
	 * labeled alternative in {@link CarpGrammarParser#unary}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNegateUnary(CarpGrammarParser.NegateUnaryContext ctx);
	/**
	 * Visit a parse tree produced by the {@code notUnary}
	 * labeled alternative in {@link CarpGrammarParser#unary}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNotUnary(CarpGrammarParser.NotUnaryContext ctx);
	/**
	 * Visit a parse tree produced by the {@code andLogical}
	 * labeled alternative in {@link CarpGrammarParser#logical}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAndLogical(CarpGrammarParser.AndLogicalContext ctx);
	/**
	 * Visit a parse tree produced by the {@code orLogical}
	 * labeled alternative in {@link CarpGrammarParser#logical}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitOrLogical(CarpGrammarParser.OrLogicalContext ctx);
	/**
	 * Visit a parse tree produced by the {@code matchComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMatchComparison(CarpGrammarParser.MatchComparisonContext ctx);
	/**
	 * Visit a parse tree produced by the {@code notMatchComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNotMatchComparison(CarpGrammarParser.NotMatchComparisonContext ctx);
	/**
	 * Visit a parse tree produced by the {@code greaterThanComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitGreaterThanComparison(CarpGrammarParser.GreaterThanComparisonContext ctx);
	/**
	 * Visit a parse tree produced by the {@code lessThanComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLessThanComparison(CarpGrammarParser.LessThanComparisonContext ctx);
	/**
	 * Visit a parse tree produced by the {@code greaterThanEqualsComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitGreaterThanEqualsComparison(CarpGrammarParser.GreaterThanEqualsComparisonContext ctx);
	/**
	 * Visit a parse tree produced by the {@code lessThanEqualsComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLessThanEqualsComparison(CarpGrammarParser.LessThanEqualsComparisonContext ctx);
	/**
	 * Visit a parse tree produced by the {@code addBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAddBinary(CarpGrammarParser.AddBinaryContext ctx);
	/**
	 * Visit a parse tree produced by the {@code subtractBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitSubtractBinary(CarpGrammarParser.SubtractBinaryContext ctx);
	/**
	 * Visit a parse tree produced by the {@code multiplicationBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMultiplicationBinary(CarpGrammarParser.MultiplicationBinaryContext ctx);
	/**
	 * Visit a parse tree produced by the {@code divideBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDivideBinary(CarpGrammarParser.DivideBinaryContext ctx);
	/**
	 * Visit a parse tree produced by the {@code powerBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPowerBinary(CarpGrammarParser.PowerBinaryContext ctx);
	/**
	 * Visit a parse tree produced by the {@code modulusBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitModulusBinary(CarpGrammarParser.ModulusBinaryContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#array}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitArray(CarpGrammarParser.ArrayContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#map}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMap(CarpGrammarParser.MapContext ctx);
	/**
	 * Visit a parse tree produced by the {@code privateModifier}
	 * labeled alternative in {@link CarpGrammarParser#modifier}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPrivateModifier(CarpGrammarParser.PrivateModifierContext ctx);
	/**
	 * Visit a parse tree produced by the {@code namedType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNamedType(CarpGrammarParser.NamedTypeContext ctx);
	/**
	 * Visit a parse tree produced by the {@code propertyType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPropertyType(CarpGrammarParser.PropertyTypeContext ctx);
	/**
	 * Visit a parse tree produced by the {@code autoType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAutoType(CarpGrammarParser.AutoTypeContext ctx);
	/**
	 * Visit a parse tree produced by the {@code mapType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMapType(CarpGrammarParser.MapTypeContext ctx);
	/**
	 * Visit a parse tree produced by the {@code genericType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitGenericType(CarpGrammarParser.GenericTypeContext ctx);
	/**
	 * Visit a parse tree produced by the {@code listType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitListType(CarpGrammarParser.ListTypeContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#type_name_list}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitType_name_list(CarpGrammarParser.Type_name_listContext ctx);
	/**
	 * Visit a parse tree produced by {@link CarpGrammarParser#name}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitName(CarpGrammarParser.NameContext ctx);
}
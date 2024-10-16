// Generated from D:/Source/csharp/Carp/CarpGrammar.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link CarpGrammarParser}.
 */
public interface CarpGrammarListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(CarpGrammarParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(CarpGrammarParser.ProgramContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#block}.
	 * @param ctx the parse tree
	 */
	void enterBlock(CarpGrammarParser.BlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#block}.
	 * @param ctx the parse tree
	 */
	void exitBlock(CarpGrammarParser.BlockContext ctx);
	/**
	 * Enter a parse tree produced by the {@code enclosedBlock}
	 * labeled alternative in {@link CarpGrammarParser#generic_block}.
	 * @param ctx the parse tree
	 */
	void enterEnclosedBlock(CarpGrammarParser.EnclosedBlockContext ctx);
	/**
	 * Exit a parse tree produced by the {@code enclosedBlock}
	 * labeled alternative in {@link CarpGrammarParser#generic_block}.
	 * @param ctx the parse tree
	 */
	void exitEnclosedBlock(CarpGrammarParser.EnclosedBlockContext ctx);
	/**
	 * Enter a parse tree produced by the {@code lambdaExpressionBlock}
	 * labeled alternative in {@link CarpGrammarParser#generic_block}.
	 * @param ctx the parse tree
	 */
	void enterLambdaExpressionBlock(CarpGrammarParser.LambdaExpressionBlockContext ctx);
	/**
	 * Exit a parse tree produced by the {@code lambdaExpressionBlock}
	 * labeled alternative in {@link CarpGrammarParser#generic_block}.
	 * @param ctx the parse tree
	 */
	void exitLambdaExpressionBlock(CarpGrammarParser.LambdaExpressionBlockContext ctx);
	/**
	 * Enter a parse tree produced by the {@code lambdaBlock}
	 * labeled alternative in {@link CarpGrammarParser#generic_block}.
	 * @param ctx the parse tree
	 */
	void enterLambdaBlock(CarpGrammarParser.LambdaBlockContext ctx);
	/**
	 * Exit a parse tree produced by the {@code lambdaBlock}
	 * labeled alternative in {@link CarpGrammarParser#generic_block}.
	 * @param ctx the parse tree
	 */
	void exitLambdaBlock(CarpGrammarParser.LambdaBlockContext ctx);
	/**
	 * Enter a parse tree produced by the {@code definitionStatement}
	 * labeled alternative in {@link CarpGrammarParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterDefinitionStatement(CarpGrammarParser.DefinitionStatementContext ctx);
	/**
	 * Exit a parse tree produced by the {@code definitionStatement}
	 * labeled alternative in {@link CarpGrammarParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitDefinitionStatement(CarpGrammarParser.DefinitionStatementContext ctx);
	/**
	 * Enter a parse tree produced by the {@code expressionStatement}
	 * labeled alternative in {@link CarpGrammarParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterExpressionStatement(CarpGrammarParser.ExpressionStatementContext ctx);
	/**
	 * Exit a parse tree produced by the {@code expressionStatement}
	 * labeled alternative in {@link CarpGrammarParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitExpressionStatement(CarpGrammarParser.ExpressionStatementContext ctx);
	/**
	 * Enter a parse tree produced by the {@code flowControlStatement}
	 * labeled alternative in {@link CarpGrammarParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterFlowControlStatement(CarpGrammarParser.FlowControlStatementContext ctx);
	/**
	 * Exit a parse tree produced by the {@code flowControlStatement}
	 * labeled alternative in {@link CarpGrammarParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitFlowControlStatement(CarpGrammarParser.FlowControlStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#flow_control}.
	 * @param ctx the parse tree
	 */
	void enterFlow_control(CarpGrammarParser.Flow_controlContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#flow_control}.
	 * @param ctx the parse tree
	 */
	void exitFlow_control(CarpGrammarParser.Flow_controlContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#if_statement}.
	 * @param ctx the parse tree
	 */
	void enterIf_statement(CarpGrammarParser.If_statementContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#if_statement}.
	 * @param ctx the parse tree
	 */
	void exitIf_statement(CarpGrammarParser.If_statementContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#while_statement}.
	 * @param ctx the parse tree
	 */
	void enterWhile_statement(CarpGrammarParser.While_statementContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#while_statement}.
	 * @param ctx the parse tree
	 */
	void exitWhile_statement(CarpGrammarParser.While_statementContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#try_statement}.
	 * @param ctx the parse tree
	 */
	void enterTry_statement(CarpGrammarParser.Try_statementContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#try_statement}.
	 * @param ctx the parse tree
	 */
	void exitTry_statement(CarpGrammarParser.Try_statementContext ctx);
	/**
	 * Enter a parse tree produced by the {@code iterStatement}
	 * labeled alternative in {@link CarpGrammarParser#iter_statement}.
	 * @param ctx the parse tree
	 */
	void enterIterStatement(CarpGrammarParser.IterStatementContext ctx);
	/**
	 * Exit a parse tree produced by the {@code iterStatement}
	 * labeled alternative in {@link CarpGrammarParser#iter_statement}.
	 * @param ctx the parse tree
	 */
	void exitIterStatement(CarpGrammarParser.IterStatementContext ctx);
	/**
	 * Enter a parse tree produced by the {@code iterAsStatement}
	 * labeled alternative in {@link CarpGrammarParser#iter_statement}.
	 * @param ctx the parse tree
	 */
	void enterIterAsStatement(CarpGrammarParser.IterAsStatementContext ctx);
	/**
	 * Exit a parse tree produced by the {@code iterAsStatement}
	 * labeled alternative in {@link CarpGrammarParser#iter_statement}.
	 * @param ctx the parse tree
	 */
	void exitIterAsStatement(CarpGrammarParser.IterAsStatementContext ctx);
	/**
	 * Enter a parse tree produced by the {@code iterAsUnpackedStatement}
	 * labeled alternative in {@link CarpGrammarParser#iter_statement}.
	 * @param ctx the parse tree
	 */
	void enterIterAsUnpackedStatement(CarpGrammarParser.IterAsUnpackedStatementContext ctx);
	/**
	 * Exit a parse tree produced by the {@code iterAsUnpackedStatement}
	 * labeled alternative in {@link CarpGrammarParser#iter_statement}.
	 * @param ctx the parse tree
	 */
	void exitIterAsUnpackedStatement(CarpGrammarParser.IterAsUnpackedStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#return_statement}.
	 * @param ctx the parse tree
	 */
	void enterReturn_statement(CarpGrammarParser.Return_statementContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#return_statement}.
	 * @param ctx the parse tree
	 */
	void exitReturn_statement(CarpGrammarParser.Return_statementContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#break_statement}.
	 * @param ctx the parse tree
	 */
	void enterBreak_statement(CarpGrammarParser.Break_statementContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#break_statement}.
	 * @param ctx the parse tree
	 */
	void exitBreak_statement(CarpGrammarParser.Break_statementContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#continue_statement}.
	 * @param ctx the parse tree
	 */
	void enterContinue_statement(CarpGrammarParser.Continue_statementContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#continue_statement}.
	 * @param ctx the parse tree
	 */
	void exitContinue_statement(CarpGrammarParser.Continue_statementContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#yield_statement}.
	 * @param ctx the parse tree
	 */
	void enterYield_statement(CarpGrammarParser.Yield_statementContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#yield_statement}.
	 * @param ctx the parse tree
	 */
	void exitYield_statement(CarpGrammarParser.Yield_statementContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#attribute}.
	 * @param ctx the parse tree
	 */
	void enterAttribute(CarpGrammarParser.AttributeContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#attribute}.
	 * @param ctx the parse tree
	 */
	void exitAttribute(CarpGrammarParser.AttributeContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#definition_with_attr}.
	 * @param ctx the parse tree
	 */
	void enterDefinition_with_attr(CarpGrammarParser.Definition_with_attrContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#definition_with_attr}.
	 * @param ctx the parse tree
	 */
	void exitDefinition_with_attr(CarpGrammarParser.Definition_with_attrContext ctx);
	/**
	 * Enter a parse tree produced by the {@code functionDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 */
	void enterFunctionDefinition(CarpGrammarParser.FunctionDefinitionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code functionDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 */
	void exitFunctionDefinition(CarpGrammarParser.FunctionDefinitionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code emptyFunctionDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 */
	void enterEmptyFunctionDefinition(CarpGrammarParser.EmptyFunctionDefinitionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code emptyFunctionDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 */
	void exitEmptyFunctionDefinition(CarpGrammarParser.EmptyFunctionDefinitionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code initializedVariableDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 */
	void enterInitializedVariableDefinition(CarpGrammarParser.InitializedVariableDefinitionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code initializedVariableDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 */
	void exitInitializedVariableDefinition(CarpGrammarParser.InitializedVariableDefinitionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code variableDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 */
	void enterVariableDefinition(CarpGrammarParser.VariableDefinitionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code variableDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 */
	void exitVariableDefinition(CarpGrammarParser.VariableDefinitionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code classDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 */
	void enterClassDefinition(CarpGrammarParser.ClassDefinitionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code classDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 */
	void exitClassDefinition(CarpGrammarParser.ClassDefinitionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code structDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 */
	void enterStructDefinition(CarpGrammarParser.StructDefinitionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code structDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 */
	void exitStructDefinition(CarpGrammarParser.StructDefinitionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code enumDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 */
	void enterEnumDefinition(CarpGrammarParser.EnumDefinitionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code enumDefinition}
	 * labeled alternative in {@link CarpGrammarParser#definition}.
	 * @param ctx the parse tree
	 */
	void exitEnumDefinition(CarpGrammarParser.EnumDefinitionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code mapExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterMapExpression(CarpGrammarParser.MapExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code mapExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitMapExpression(CarpGrammarParser.MapExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code lambdaExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterLambdaExpression(CarpGrammarParser.LambdaExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code lambdaExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitLambdaExpression(CarpGrammarParser.LambdaExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code constantExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterConstantExpression(CarpGrammarParser.ConstantExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code constantExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitConstantExpression(CarpGrammarParser.ConstantExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code arrayExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterArrayExpression(CarpGrammarParser.ArrayExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code arrayExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitArrayExpression(CarpGrammarParser.ArrayExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code assignmentExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterAssignmentExpression(CarpGrammarParser.AssignmentExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code assignmentExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitAssignmentExpression(CarpGrammarParser.AssignmentExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code comparisonExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterComparisonExpression(CarpGrammarParser.ComparisonExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code comparisonExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitComparisonExpression(CarpGrammarParser.ComparisonExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code logicalExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterLogicalExpression(CarpGrammarParser.LogicalExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code logicalExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitLogicalExpression(CarpGrammarParser.LogicalExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code variableExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterVariableExpression(CarpGrammarParser.VariableExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code variableExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitVariableExpression(CarpGrammarParser.VariableExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code windExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterWindExpression(CarpGrammarParser.WindExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code windExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitWindExpression(CarpGrammarParser.WindExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code binaryExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterBinaryExpression(CarpGrammarParser.BinaryExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code binaryExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitBinaryExpression(CarpGrammarParser.BinaryExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code castExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterCastExpression(CarpGrammarParser.CastExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code castExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitCastExpression(CarpGrammarParser.CastExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code parenthesizedExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterParenthesizedExpression(CarpGrammarParser.ParenthesizedExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code parenthesizedExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitParenthesizedExpression(CarpGrammarParser.ParenthesizedExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code callExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterCallExpression(CarpGrammarParser.CallExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code callExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitCallExpression(CarpGrammarParser.CallExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code infixExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterInfixExpression(CarpGrammarParser.InfixExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code infixExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitInfixExpression(CarpGrammarParser.InfixExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code compoundAssignmentExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterCompoundAssignmentExpression(CarpGrammarParser.CompoundAssignmentExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code compoundAssignmentExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitCompoundAssignmentExpression(CarpGrammarParser.CompoundAssignmentExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code filterExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterFilterExpression(CarpGrammarParser.FilterExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code filterExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitFilterExpression(CarpGrammarParser.FilterExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code rangeExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterRangeExpression(CarpGrammarParser.RangeExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code rangeExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitRangeExpression(CarpGrammarParser.RangeExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code indexExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterIndexExpression(CarpGrammarParser.IndexExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code indexExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitIndexExpression(CarpGrammarParser.IndexExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code unaryExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterUnaryExpression(CarpGrammarParser.UnaryExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code unaryExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitUnaryExpression(CarpGrammarParser.UnaryExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code ternaryExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterTernaryExpression(CarpGrammarParser.TernaryExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code ternaryExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitTernaryExpression(CarpGrammarParser.TernaryExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code postfixExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterPostfixExpression(CarpGrammarParser.PostfixExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code postfixExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitPostfixExpression(CarpGrammarParser.PostfixExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code propertyExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterPropertyExpression(CarpGrammarParser.PropertyExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code propertyExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitPropertyExpression(CarpGrammarParser.PropertyExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code endRangeExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterEndRangeExpression(CarpGrammarParser.EndRangeExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code endRangeExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitEndRangeExpression(CarpGrammarParser.EndRangeExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code compareTypeExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterCompareTypeExpression(CarpGrammarParser.CompareTypeExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code compareTypeExpression}
	 * labeled alternative in {@link CarpGrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitCompareTypeExpression(CarpGrammarParser.CompareTypeExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#expression_list}.
	 * @param ctx the parse tree
	 */
	void enterExpression_list(CarpGrammarParser.Expression_listContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#expression_list}.
	 * @param ctx the parse tree
	 */
	void exitExpression_list(CarpGrammarParser.Expression_listContext ctx);
	/**
	 * Enter a parse tree produced by the {@code addCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 */
	void enterAddCompound(CarpGrammarParser.AddCompoundContext ctx);
	/**
	 * Exit a parse tree produced by the {@code addCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 */
	void exitAddCompound(CarpGrammarParser.AddCompoundContext ctx);
	/**
	 * Enter a parse tree produced by the {@code subtractCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 */
	void enterSubtractCompound(CarpGrammarParser.SubtractCompoundContext ctx);
	/**
	 * Exit a parse tree produced by the {@code subtractCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 */
	void exitSubtractCompound(CarpGrammarParser.SubtractCompoundContext ctx);
	/**
	 * Enter a parse tree produced by the {@code multiplyCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 */
	void enterMultiplyCompound(CarpGrammarParser.MultiplyCompoundContext ctx);
	/**
	 * Exit a parse tree produced by the {@code multiplyCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 */
	void exitMultiplyCompound(CarpGrammarParser.MultiplyCompoundContext ctx);
	/**
	 * Enter a parse tree produced by the {@code divideCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 */
	void enterDivideCompound(CarpGrammarParser.DivideCompoundContext ctx);
	/**
	 * Exit a parse tree produced by the {@code divideCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 */
	void exitDivideCompound(CarpGrammarParser.DivideCompoundContext ctx);
	/**
	 * Enter a parse tree produced by the {@code powerCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 */
	void enterPowerCompound(CarpGrammarParser.PowerCompoundContext ctx);
	/**
	 * Exit a parse tree produced by the {@code powerCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 */
	void exitPowerCompound(CarpGrammarParser.PowerCompoundContext ctx);
	/**
	 * Enter a parse tree produced by the {@code modulusCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 */
	void enterModulusCompound(CarpGrammarParser.ModulusCompoundContext ctx);
	/**
	 * Exit a parse tree produced by the {@code modulusCompound}
	 * labeled alternative in {@link CarpGrammarParser#compoundAssignment}.
	 * @param ctx the parse tree
	 */
	void exitModulusCompound(CarpGrammarParser.ModulusCompoundContext ctx);
	/**
	 * Enter a parse tree produced by the {@code intConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 */
	void enterIntConstant(CarpGrammarParser.IntConstantContext ctx);
	/**
	 * Exit a parse tree produced by the {@code intConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 */
	void exitIntConstant(CarpGrammarParser.IntConstantContext ctx);
	/**
	 * Enter a parse tree produced by the {@code stringConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 */
	void enterStringConstant(CarpGrammarParser.StringConstantContext ctx);
	/**
	 * Exit a parse tree produced by the {@code stringConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 */
	void exitStringConstant(CarpGrammarParser.StringConstantContext ctx);
	/**
	 * Enter a parse tree produced by the {@code charConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 */
	void enterCharConstant(CarpGrammarParser.CharConstantContext ctx);
	/**
	 * Exit a parse tree produced by the {@code charConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 */
	void exitCharConstant(CarpGrammarParser.CharConstantContext ctx);
	/**
	 * Enter a parse tree produced by the {@code trueConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 */
	void enterTrueConstant(CarpGrammarParser.TrueConstantContext ctx);
	/**
	 * Exit a parse tree produced by the {@code trueConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 */
	void exitTrueConstant(CarpGrammarParser.TrueConstantContext ctx);
	/**
	 * Enter a parse tree produced by the {@code falseConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 */
	void enterFalseConstant(CarpGrammarParser.FalseConstantContext ctx);
	/**
	 * Exit a parse tree produced by the {@code falseConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 */
	void exitFalseConstant(CarpGrammarParser.FalseConstantContext ctx);
	/**
	 * Enter a parse tree produced by the {@code nullConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 */
	void enterNullConstant(CarpGrammarParser.NullConstantContext ctx);
	/**
	 * Exit a parse tree produced by the {@code nullConstant}
	 * labeled alternative in {@link CarpGrammarParser#constant}.
	 * @param ctx the parse tree
	 */
	void exitNullConstant(CarpGrammarParser.NullConstantContext ctx);
	/**
	 * Enter a parse tree produced by the {@code negateUnary}
	 * labeled alternative in {@link CarpGrammarParser#unary}.
	 * @param ctx the parse tree
	 */
	void enterNegateUnary(CarpGrammarParser.NegateUnaryContext ctx);
	/**
	 * Exit a parse tree produced by the {@code negateUnary}
	 * labeled alternative in {@link CarpGrammarParser#unary}.
	 * @param ctx the parse tree
	 */
	void exitNegateUnary(CarpGrammarParser.NegateUnaryContext ctx);
	/**
	 * Enter a parse tree produced by the {@code notUnary}
	 * labeled alternative in {@link CarpGrammarParser#unary}.
	 * @param ctx the parse tree
	 */
	void enterNotUnary(CarpGrammarParser.NotUnaryContext ctx);
	/**
	 * Exit a parse tree produced by the {@code notUnary}
	 * labeled alternative in {@link CarpGrammarParser#unary}.
	 * @param ctx the parse tree
	 */
	void exitNotUnary(CarpGrammarParser.NotUnaryContext ctx);
	/**
	 * Enter a parse tree produced by the {@code andLogical}
	 * labeled alternative in {@link CarpGrammarParser#logical}.
	 * @param ctx the parse tree
	 */
	void enterAndLogical(CarpGrammarParser.AndLogicalContext ctx);
	/**
	 * Exit a parse tree produced by the {@code andLogical}
	 * labeled alternative in {@link CarpGrammarParser#logical}.
	 * @param ctx the parse tree
	 */
	void exitAndLogical(CarpGrammarParser.AndLogicalContext ctx);
	/**
	 * Enter a parse tree produced by the {@code orLogical}
	 * labeled alternative in {@link CarpGrammarParser#logical}.
	 * @param ctx the parse tree
	 */
	void enterOrLogical(CarpGrammarParser.OrLogicalContext ctx);
	/**
	 * Exit a parse tree produced by the {@code orLogical}
	 * labeled alternative in {@link CarpGrammarParser#logical}.
	 * @param ctx the parse tree
	 */
	void exitOrLogical(CarpGrammarParser.OrLogicalContext ctx);
	/**
	 * Enter a parse tree produced by the {@code matchComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 */
	void enterMatchComparison(CarpGrammarParser.MatchComparisonContext ctx);
	/**
	 * Exit a parse tree produced by the {@code matchComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 */
	void exitMatchComparison(CarpGrammarParser.MatchComparisonContext ctx);
	/**
	 * Enter a parse tree produced by the {@code notMatchComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 */
	void enterNotMatchComparison(CarpGrammarParser.NotMatchComparisonContext ctx);
	/**
	 * Exit a parse tree produced by the {@code notMatchComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 */
	void exitNotMatchComparison(CarpGrammarParser.NotMatchComparisonContext ctx);
	/**
	 * Enter a parse tree produced by the {@code greaterThanComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 */
	void enterGreaterThanComparison(CarpGrammarParser.GreaterThanComparisonContext ctx);
	/**
	 * Exit a parse tree produced by the {@code greaterThanComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 */
	void exitGreaterThanComparison(CarpGrammarParser.GreaterThanComparisonContext ctx);
	/**
	 * Enter a parse tree produced by the {@code lessThanComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 */
	void enterLessThanComparison(CarpGrammarParser.LessThanComparisonContext ctx);
	/**
	 * Exit a parse tree produced by the {@code lessThanComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 */
	void exitLessThanComparison(CarpGrammarParser.LessThanComparisonContext ctx);
	/**
	 * Enter a parse tree produced by the {@code greaterThanEqualsComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 */
	void enterGreaterThanEqualsComparison(CarpGrammarParser.GreaterThanEqualsComparisonContext ctx);
	/**
	 * Exit a parse tree produced by the {@code greaterThanEqualsComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 */
	void exitGreaterThanEqualsComparison(CarpGrammarParser.GreaterThanEqualsComparisonContext ctx);
	/**
	 * Enter a parse tree produced by the {@code lessThanEqualsComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 */
	void enterLessThanEqualsComparison(CarpGrammarParser.LessThanEqualsComparisonContext ctx);
	/**
	 * Exit a parse tree produced by the {@code lessThanEqualsComparison}
	 * labeled alternative in {@link CarpGrammarParser#comparison}.
	 * @param ctx the parse tree
	 */
	void exitLessThanEqualsComparison(CarpGrammarParser.LessThanEqualsComparisonContext ctx);
	/**
	 * Enter a parse tree produced by the {@code addBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 */
	void enterAddBinary(CarpGrammarParser.AddBinaryContext ctx);
	/**
	 * Exit a parse tree produced by the {@code addBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 */
	void exitAddBinary(CarpGrammarParser.AddBinaryContext ctx);
	/**
	 * Enter a parse tree produced by the {@code subtractBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 */
	void enterSubtractBinary(CarpGrammarParser.SubtractBinaryContext ctx);
	/**
	 * Exit a parse tree produced by the {@code subtractBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 */
	void exitSubtractBinary(CarpGrammarParser.SubtractBinaryContext ctx);
	/**
	 * Enter a parse tree produced by the {@code multiplicationBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 */
	void enterMultiplicationBinary(CarpGrammarParser.MultiplicationBinaryContext ctx);
	/**
	 * Exit a parse tree produced by the {@code multiplicationBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 */
	void exitMultiplicationBinary(CarpGrammarParser.MultiplicationBinaryContext ctx);
	/**
	 * Enter a parse tree produced by the {@code divideBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 */
	void enterDivideBinary(CarpGrammarParser.DivideBinaryContext ctx);
	/**
	 * Exit a parse tree produced by the {@code divideBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 */
	void exitDivideBinary(CarpGrammarParser.DivideBinaryContext ctx);
	/**
	 * Enter a parse tree produced by the {@code powerBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 */
	void enterPowerBinary(CarpGrammarParser.PowerBinaryContext ctx);
	/**
	 * Exit a parse tree produced by the {@code powerBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 */
	void exitPowerBinary(CarpGrammarParser.PowerBinaryContext ctx);
	/**
	 * Enter a parse tree produced by the {@code modulusBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 */
	void enterModulusBinary(CarpGrammarParser.ModulusBinaryContext ctx);
	/**
	 * Exit a parse tree produced by the {@code modulusBinary}
	 * labeled alternative in {@link CarpGrammarParser#binary}.
	 * @param ctx the parse tree
	 */
	void exitModulusBinary(CarpGrammarParser.ModulusBinaryContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#array}.
	 * @param ctx the parse tree
	 */
	void enterArray(CarpGrammarParser.ArrayContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#array}.
	 * @param ctx the parse tree
	 */
	void exitArray(CarpGrammarParser.ArrayContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#map}.
	 * @param ctx the parse tree
	 */
	void enterMap(CarpGrammarParser.MapContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#map}.
	 * @param ctx the parse tree
	 */
	void exitMap(CarpGrammarParser.MapContext ctx);
	/**
	 * Enter a parse tree produced by the {@code privateModifier}
	 * labeled alternative in {@link CarpGrammarParser#modifier}.
	 * @param ctx the parse tree
	 */
	void enterPrivateModifier(CarpGrammarParser.PrivateModifierContext ctx);
	/**
	 * Exit a parse tree produced by the {@code privateModifier}
	 * labeled alternative in {@link CarpGrammarParser#modifier}.
	 * @param ctx the parse tree
	 */
	void exitPrivateModifier(CarpGrammarParser.PrivateModifierContext ctx);
	/**
	 * Enter a parse tree produced by the {@code namedType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 */
	void enterNamedType(CarpGrammarParser.NamedTypeContext ctx);
	/**
	 * Exit a parse tree produced by the {@code namedType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 */
	void exitNamedType(CarpGrammarParser.NamedTypeContext ctx);
	/**
	 * Enter a parse tree produced by the {@code propertyType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 */
	void enterPropertyType(CarpGrammarParser.PropertyTypeContext ctx);
	/**
	 * Exit a parse tree produced by the {@code propertyType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 */
	void exitPropertyType(CarpGrammarParser.PropertyTypeContext ctx);
	/**
	 * Enter a parse tree produced by the {@code autoType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 */
	void enterAutoType(CarpGrammarParser.AutoTypeContext ctx);
	/**
	 * Exit a parse tree produced by the {@code autoType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 */
	void exitAutoType(CarpGrammarParser.AutoTypeContext ctx);
	/**
	 * Enter a parse tree produced by the {@code mapType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 */
	void enterMapType(CarpGrammarParser.MapTypeContext ctx);
	/**
	 * Exit a parse tree produced by the {@code mapType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 */
	void exitMapType(CarpGrammarParser.MapTypeContext ctx);
	/**
	 * Enter a parse tree produced by the {@code genericType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 */
	void enterGenericType(CarpGrammarParser.GenericTypeContext ctx);
	/**
	 * Exit a parse tree produced by the {@code genericType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 */
	void exitGenericType(CarpGrammarParser.GenericTypeContext ctx);
	/**
	 * Enter a parse tree produced by the {@code listType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 */
	void enterListType(CarpGrammarParser.ListTypeContext ctx);
	/**
	 * Exit a parse tree produced by the {@code listType}
	 * labeled alternative in {@link CarpGrammarParser#type}.
	 * @param ctx the parse tree
	 */
	void exitListType(CarpGrammarParser.ListTypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#type_name_list}.
	 * @param ctx the parse tree
	 */
	void enterType_name_list(CarpGrammarParser.Type_name_listContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#type_name_list}.
	 * @param ctx the parse tree
	 */
	void exitType_name_list(CarpGrammarParser.Type_name_listContext ctx);
	/**
	 * Enter a parse tree produced by {@link CarpGrammarParser#name}.
	 * @param ctx the parse tree
	 */
	void enterName(CarpGrammarParser.NameContext ctx);
	/**
	 * Exit a parse tree produced by {@link CarpGrammarParser#name}.
	 * @param ctx the parse tree
	 */
	void exitName(CarpGrammarParser.NameContext ctx);
}
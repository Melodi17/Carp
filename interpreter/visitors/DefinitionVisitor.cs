namespace Carp.interpreter.visitors;

public partial class CarpVisitor
{
    public override object VisitDefinitionStatement(CarpGrammarParser.DefinitionStatementContext context) => base.VisitDefinitionStatement(context);
    public override object VisitDefinition_with_attr(CarpGrammarParser.Definition_with_attrContext context) => base.VisitDefinition_with_attr(context);
    public override object VisitFunctionDefinition(CarpGrammarParser.FunctionDefinitionContext context) => base.VisitFunctionDefinition(context);
    public override object VisitEmptyFunctionDefinition(CarpGrammarParser.EmptyFunctionDefinitionContext context) => base.VisitEmptyFunctionDefinition(context);
    public override object VisitInitializedVariableDefinition(CarpGrammarParser.InitializedVariableDefinitionContext context) => base.VisitInitializedVariableDefinition(context);
    public override object VisitVariableDefinition(CarpGrammarParser.VariableDefinitionContext context) => base.VisitVariableDefinition(context);
    public override object VisitClassDefinition(CarpGrammarParser.ClassDefinitionContext context) => base.VisitClassDefinition(context);
    public override object VisitStructDefinition(CarpGrammarParser.StructDefinitionContext context) => base.VisitStructDefinition(context);
    public override object VisitEnumDefinition(CarpGrammarParser.EnumDefinitionContext context) => base.VisitEnumDefinition(context);
}
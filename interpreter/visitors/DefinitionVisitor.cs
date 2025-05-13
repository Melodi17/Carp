using System.Text;
using Carp.objects;
using Carp.scoping;

namespace Carp.interpreter.visitors;

public partial class CarpVisitor
{
    public override object VisitWrapped_definition(CarpGrammarParser.Wrapped_definitionContext context)
    {
        // Receives a partially constructed member and completes.
        Member member = (Member)this.Visit(context.def);

        member.Modifiers = context._modifiers
            .Select(this.VisitToken<Modifiers>)
            .MergeFlags();

        member.Annotations = context._attrs
            .Select(x => this.VisitExpression(x.obj))
            .ToList();

        string? docstring = this.VisitDocstring(context._docs);
        member.Docstring = docstring;

        return member;
    }
    
    public override object VisitDefinitionStatement(CarpGrammarParser.DefinitionStatementContext context)
    {
        // Define to current scope.
        Member member = (Member)this.Visit(context.wrapped_definition());
        context.Scope.Define(member);

        return null!;
    }
    
    public override object VisitVariableDefinition(CarpGrammarParser.VariableDefinitionContext context)
    {
        CarpType type = this.VisitType(context.rtype);
        string name = context.key.Text;
        CarpObject value = context.value != null
            ? this.VisitExpression(context.value)
            : type.DefaultValue();
        
        Member member = new FieldMember(name, type, value);
        return member;
    }
    public override object VisitFunctionDefinition(CarpGrammarParser.FunctionDefinitionContext context) => base.VisitFunctionDefinition(context);
    public override object VisitClassDefinition(CarpGrammarParser.ClassDefinitionContext context) => base.VisitClassDefinition(context);
    public override object VisitStructDefinition(CarpGrammarParser.StructDefinitionContext context) => base.VisitStructDefinition(context);
    public override object VisitEnumDefinition(CarpGrammarParser.EnumDefinitionContext context) => base.VisitEnumDefinition(context);
}
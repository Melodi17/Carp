namespace Carp.interpreter.visitors;

using objects;
using objects.typing;
using scoping;

public partial class CarpVisitor
{
    public override object VisitWrapped_definition(CarpGrammarParser.Wrapped_definitionContext context)
    {
        // Receives a partially constructed member and completes.
        Member member = (Member) this.Visit(context.def);

        member.Modifiers = context._modifiers.Select(this.VisitToken<Modifiers>).MergeFlags();

        member.Annotations = context._attrs.Select(x => this.VisitExpression(x.obj)).ToList();

        string? docstring = this.VisitDocstring(context._docs);
        member.Docstring = docstring;

        return member;
    }

    public override object VisitDefinitionStatement(CarpGrammarParser.DefinitionStatementContext context)
    {
        // Define to current scope.
        Member member = (Member) this.Visit(context.wrapped_definition());

        // Basically if the member is a method, and it already exists in the scope,
        // we add an overload
        if (member is MethodMember mm && context.Scope.TryFind(mm.Name, out Member? existing) && existing is MethodMember existingMethod)
        {
            existingMethod.Merge(mm);
            return null!;
        }

        context.Scope.Define(member);
        return null!;
    }

    public override object VisitVariableDefinition(CarpGrammarParser.VariableDefinitionContext context)
    {
        CarpType type = this.VisitType(context.rtype);
        string name = context.key.Text;
        CarpObject value = context.value != null ? this.VisitExpression(context.value) : type.DefaultValue();

        Member member = new FieldMember(name, type, value);
        return member;
    }
    public override object VisitFunctionDefinition(CarpGrammarParser.FunctionDefinitionContext context)
    {
        // Create a function member.
        string name = context.key.Text;
        CarpType returnType = this.VisitType(context.rtype);
        (CarpType Type, string Name)[] args = ((CarpType Type, string Name)[]) this.Visit(context.values);

        InternalFunction func = new(returnType, context, args.ToDictionary(x => x.Name, x => x.Type), this);

        MethodMember member = new(name, func);
        return member;
    }
    public override object VisitClassDefinition(CarpGrammarParser.ClassDefinitionContext context) => base.VisitClassDefinition(context);
    public override object VisitStructDefinition(CarpGrammarParser.StructDefinitionContext context) => base.VisitStructDefinition(context);
    public override object VisitEnumDefinition(CarpGrammarParser.EnumDefinitionContext context) => base.VisitEnumDefinition(context);
    public override object VisitEnumDefinitionAutoValues(CarpGrammarParser.EnumDefinitionAutoValuesContext context) => base.VisitEnumDefinitionAutoValues(context);
}
namespace Carp.interpreter.visitors;

public partial class CarpVisitor
{
    public override object VisitNamedType(CarpGrammarParser.NamedTypeContext context) => base.VisitNamedType(context);
    public override object VisitPropertyType(CarpGrammarParser.PropertyTypeContext context) => base.VisitPropertyType(context);
    public override object VisitAutoType(CarpGrammarParser.AutoTypeContext context) => base.VisitAutoType(context);
    public override object VisitMapType(CarpGrammarParser.MapTypeContext context) => base.VisitMapType(context);
    public override object VisitGenericType(CarpGrammarParser.GenericTypeContext context) => base.VisitGenericType(context);
    public override object VisitListType(CarpGrammarParser.ListTypeContext context) => base.VisitListType(context);
}
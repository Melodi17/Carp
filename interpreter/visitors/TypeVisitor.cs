using Carp.objects;
using Carp.objects.typing;
using Carp.scoping;

namespace Carp.interpreter.visitors;

public partial class CarpVisitor
{
    public override object VisitNamedType(CarpGrammarParser.NamedTypeContext context)
    {
        string name = context.ID().GetText();
        Member member = context.Scope.Find(name);
        
        // Self is null because we are looking at
        // this outside of an object
        return member.Get(null);
    }
    public override object VisitPropertyType(CarpGrammarParser.PropertyTypeContext context) => base.VisitPropertyType(context);
    public override object VisitAutoType(CarpGrammarParser.AutoTypeContext context) => base.VisitAutoType(context);
    public override object VisitMapType(CarpGrammarParser.MapTypeContext context) => base.VisitMapType(context);
    public override object VisitGenericType(CarpGrammarParser.GenericTypeContext context) => base.VisitGenericType(context);
    public override object VisitListType(CarpGrammarParser.ListTypeContext context)
    {
        CarpType itemType = this.VisitType(context.element);
        return CarpType.CreateGeneric(CarpCollection.Type, itemType);
    }
}
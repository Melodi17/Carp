using Antlr4.Runtime;

namespace Carp.interpreter;

public class ScopedParserRuleContext : ParserRuleContext
{
    public ScopedParserRuleContext()
    { }

    public ScopedParserRuleContext(ParserRuleContext parent, int invokingStateNumber) : base(parent, invokingStateNumber)
    {
    }
    
    public IScope ContextScope { get; set; }
}
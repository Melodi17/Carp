using Antlr4.Runtime;

namespace Carp.interpreter;

public class ScopedParserRuleContext : ParserRuleContext
{
    public ScopedParserRuleContext()
    { }

    public ScopedParserRuleContext(ParserRuleContext parent, int invokingStateNumber) : base(parent, invokingStateNumber)
    {
    }

    //public Context Context { get; set; } = new();
    // TODO: use context

    public IScope ContextScope { get; set; }
}

public class Context
{
    public IScope Scope { get; set; }
    public int ThreadID { get; set; }
    public int LineNumber { get; set; }
}
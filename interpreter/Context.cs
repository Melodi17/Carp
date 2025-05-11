using Antlr4.Runtime;

namespace Carp.interpreter;

public class Context : ParserRuleContext
{
    public Context()
    { }

    public Context(ParserRuleContext parent, int invokingStateNumber) : base(parent, invokingStateNumber)
    {
    }

    // public IScope Scope { get; set; }
    public uint ThreadID { get; set; }
    public int Position { get; set; }
    public IExecutionContext ExecutionContext { get; set; }
}
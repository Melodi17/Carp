using Antlr4.Runtime;
using Carp.objects;

namespace Carp.interpreter;

public class Context : ParserRuleContext
{
    public Context()
    { }

    public Context(ParserRuleContext parent, int invokingStateNumber) : base(parent, invokingStateNumber)
    {
    }

    // public IScope Scope { get; set; }
    
    /// <summary>
    /// Current thread ID
    /// </summary>
    public uint ThreadID { get; set; }
    
    /// <summary>
    /// Position (line) in current execution context
    /// </summary>
    public int Position { get; set; }
    
    /// <summary>
    /// Execution context (file) currently being executed
    /// </summary>
    public IExecutionContext ExecutionContext { get; set; }
    
    public CarpObject? CurrentObject { get; set; }
}
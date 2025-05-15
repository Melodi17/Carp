using Antlr4.Runtime;
using Carp.objects;
using Carp.scoping;

namespace Carp.interpreter;

public class Context : ParserRuleContext
{
    public Context()
    {
    }

    public Context(ParserRuleContext parent, int invokingStateNumber) : base(parent, invokingStateNumber)
    {
    }

    public Scope? Scope { get; set; }

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
    public IExecutionContext? ExecutionContext { get; set; }

    public CarpObject? CurrentObject { get; set; }

    public void ReplicateParent(Context context)
    {
        this.Scope = context.Scope;
        this.ThreadID = context.ThreadID;
        this.Position = context.Position;
        this.ExecutionContext = context.ExecutionContext;
        this.CurrentObject = context.CurrentObject;
    }
}
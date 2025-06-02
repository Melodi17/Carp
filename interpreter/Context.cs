namespace Carp.interpreter;

using Antlr4.Runtime;
using Newtonsoft.Json;
using objects;
using scoping;

public class Context : ParserRuleContext
{
    public Context() { }

    public Context(ParserRuleContext parent, int invokingStateNumber) : base(parent, invokingStateNumber) { }

    public Scope Scope { get; set; } = null!;

    /// <summary>
    ///     Current thread ID
    /// </summary>
    public uint ThreadID { get; set; }

    /// <summary>
    ///     Position (line) in current execution context
    /// </summary>
    public int Position { get; set; }

    /// <summary>
    ///     Execution context (file) currently being executed
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

    public T Clone<T>()
        where T : Context
    {
        JsonSerializerSettings? settings = new()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            TypeNameHandling = TypeNameHandling.Auto,
        };
        // use newtonsoft json to clone the context
        T copy = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(this, settings), settings) ?? throw new InvalidOperationException("Failed to clone context");

        // Use non-cloned context data
        copy.ReplicateParent(this);

        return copy;
    }
}
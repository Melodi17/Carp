namespace Carp.exceptions;

using interpreter;

public class StackFrame
{
    public StackFrame(Context context)
    {
        this.Context = context;
    }
    public Context Context { get; }

    public override bool Equals(object? obj)
    {
        if (obj is StackFrame other)
            return other.Context.ExecutionContext == this.Context.ExecutionContext && other.Context.Position == this.Context.Position;

        return false;
    }
}
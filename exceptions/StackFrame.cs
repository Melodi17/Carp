namespace Carp.exceptions;

using interpreter;

public class StackFrame
{
    public StackFrame(Context context)
    {
        this.Context = context;
    }
    public Context Context { get; }
}
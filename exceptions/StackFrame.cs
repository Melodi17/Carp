using Carp.interpreter;

namespace Carp.exceptions;

public class StackFrame
{
    public Context Context { get; }
    public StackFrame(Context context)
    {
        this.Context = context;
    }
}
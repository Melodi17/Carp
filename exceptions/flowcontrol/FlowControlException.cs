using Carp.objects;

namespace Carp.exceptions.flowcontrol;

public class FlowControlException(string type) : RuntimeException($"An unenclosed flow control {type} was used");

public class BreakException() : FlowControlException("break");
public class ContinueException() : FlowControlException("continue");
public class ReturnException(CarpObject value) : FlowControlException("return")
{
    public CarpObject Value { get; } = value;
}

namespace Carp.toolkit.debugging;

using interpreter;
using objects;

public interface IDebuggable
{
    CarpObject Evaluate(string expression, Context? ctx);
    
}

using System.Text;

namespace Carp.exceptions;

public class RuntimeException(string message) : Exception(message)
{
    public List<StackFrame> InternalStackTrace { get; } = new();
    public void AddStackFrame(StackFrame frame) => this.InternalStackTrace.Add(frame);
    
    public override string ToString()
    {
        string errorName = this.GetType().Name;
        
        StringBuilder sb = new();
        sb.AppendLine($"{errorName}: {this.Message}");
        foreach (StackFrame frame in this.InternalStackTrace)
        {
            int pos = frame.Context.Position;
            string content = frame.Context.ExecutionContext?.GetAtLine(pos) ?? "<missing>";
            sb.AppendLine($"\t--->  {frame.Context.ExecutionContext?.Name ?? "<unknown>"}  {pos} |  {content}");
        }
        
        return sb.ToString().TrimEnd('\r', '\n');
    }
}

using System.Text;

namespace Carp.exceptions;

public class RuntimeException(string message) : Exception(message)
{
    public string ErrorFriendlyName => this.GetType().Name.Replace("Exception", "Error");
    public List<StackFrame> InternalStackTrace { get; } = new();
    public void AddStackFrame(StackFrame frame) => this.InternalStackTrace.Add(frame);
    
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"{ErrorFriendlyName}: {this.Message}");
        foreach (StackFrame frame in this.InternalStackTrace)
        {
            int pos = frame.Context.Position;
            string content = frame.Context.ExecutionContext?.GetAtLine(pos) ?? "<missing>";
            sb.AppendLine($"\t--->  {frame.Context.ExecutionContext?.Name ?? "<unknown>"}  {pos} |  {content}");
        }
        
        return sb.ToString().TrimEnd('\r', '\n');
    }
}
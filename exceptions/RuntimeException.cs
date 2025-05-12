
using System.Text;

namespace Carp.exceptions;

public class RuntimeException(string message) : Exception(message)
{
    public List<StackFrame> StackTrace { get; } = new();
    public void AddStackFrame(StackFrame frame) => this.StackTrace.Add(frame);
    
    public override string ToString()
    {
        string errorName = this.GetType().Name;
        
        StringBuilder sb = new();
        sb.AppendLine($"{errorName}: {this.Message}");
        foreach (StackFrame frame in StackTrace)
        {
            int pos = frame.Context.Position;
            string content = frame.Context.ExecutionContext.GetAtLine(pos);
            sb.AppendLine($"\t--->  {frame.Context.ExecutionContext.Name}  {pos} |  {content}");
        }
        
        return sb.ToString().TrimEnd('\r', '\n');
    }
}
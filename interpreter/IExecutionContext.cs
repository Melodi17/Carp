namespace Carp.interpreter;

public interface IExecutionContext
{
    string Name { get; }
    
    /// <summary>
    /// Get the content at a specific position in the context.
    /// </summary>
    /// <param name="position">A 1-based position in the context</param>
    /// <returns></returns>
    string GetAtLine(int position);
}
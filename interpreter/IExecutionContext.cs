namespace Carp.interpreter;

public interface IExecutionContext
{
    string Name { get; }
    string GetAtLine(int position);
}
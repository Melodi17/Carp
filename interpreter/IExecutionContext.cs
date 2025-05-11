namespace Carp;

public interface IExecutionContext
{
    string Name { get; }
    string GetAtLine(int position);
}
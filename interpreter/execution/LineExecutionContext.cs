namespace Carp.interpreter.execution;

internal class LineExecutionContext(string line) : IExecutionContext
{
    public string Line { get; } = line;
    public string Name => "Command-line argument";
    public string GetAtPosition(int position) => position == 1 ? this.Line : "<invalid position>";
    public string GetContent() => this.Line;
}
namespace Carp.interpreter.execution;

public class ReplExecutionContext(int? blockIdx, string text) : IExecutionContext
{
    private readonly string[] _lines = text.Replace("\r", "").Split('\n');
    private readonly string _text = text;
    public string Name => blockIdx != null ? $"REPL block {blockIdx + 1}" : "REPL";

    public string GetAtPosition(int position)
    {
        position -= 1; // Convert to 0-based index

        // In a REPL context, we don't have a specific line to return.
        // This could be extended to return the last evaluated expression or similar.
        if (position < 0 || position >= this._lines.Length)
            return "<invalid position>";

        return this._lines[position];
    }
    public string GetContent() => this._text;
}
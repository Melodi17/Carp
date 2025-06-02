namespace Carp.interpreter.execution;

internal class FileExecutionContext : IExecutionContext
{
    public FileExecutionContext(string file)
    {
        if (!File.Exists(file))
            throw new FileNotFoundException($"File '{file}' does not exist.", file);

        this.FilePath = file;
        this.Name = $"{Path.GetFileName(file)}";
        this.Content = File.ReadAllText(file);
        this.Lines = this.Content.Replace("\r\n", "\n").Split('\n');
    }
    public string FilePath { get; }
    public string Content { get; }
    public string[] Lines { get; }
    public string Name { get; }

    public string GetAtPosition(int position)
    {
        position -= 1; // Convert to 0-based index

        // In a REPL context, we don't have a specific line to return.
        // This could be extended to return the last evaluated expression or similar.
        if (position < 0 || position >= this.Lines.Length)
            return "<invalid position>";

        return this.Lines[position];
    }
    public string GetContent() => this.Content;
}
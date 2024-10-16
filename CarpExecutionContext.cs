namespace Carp;

public class CarpExecutionContext
{
    public string Source;
    public string[] Content;

    public CarpExecutionContext(string source, string[] content)
    {
        this.Source = source;
        this.Content = content;
    }

    public string GetAtLocation(int location)
    {
        if (location < 0 || location >= this.Content.Length)
            return "<OUT OF BOUNDS>";
        return this.Content[location].Trim().Replace("\r", "");
    }
}
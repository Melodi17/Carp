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

    public string GetAtLocation(int location) => this.Content[location].Trim().Replace("\r", "");
}
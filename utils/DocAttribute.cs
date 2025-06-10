namespace Carp.utils;

[AttributeUsage(AttributeTargets.All)]
public class DocAttribute : Attribute
{
    public string Text { get; }

    public DocAttribute(string text)
    {
        this.Text = text;
    }
}
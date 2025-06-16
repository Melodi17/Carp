namespace Carp.utils.attributes;

[AttributeUsage(AttributeTargets.All)]
public class DocAttribute : Attribute
{
    public DocAttribute(string text)
    {
        this.Text = text;
    }
    public string Text { get; }
}
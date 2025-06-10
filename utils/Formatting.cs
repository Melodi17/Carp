namespace Carp.utils;

using System.Text;

public static class Formatting
{
    public static string FormatMethod(string methodName) => methodName.ToSnakeCase();
    public static string FormatProperty(string fieldName) => fieldName.ToSnakeCase();
    public static string ToSnakeCase(this string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        if (text.Length < 2)
            return text.ToLowerInvariant();
        StringBuilder sb = new();
        sb.Append(char.ToLowerInvariant(text[0]));
        for (int i = 1; i < text.Length; ++i)
        {
            char c = text[i];
            if (char.IsUpper(c))
            {
                sb.Append('_');
                sb.Append(char.ToLowerInvariant(c));
            }
            else
                sb.Append(c);
        }
        return sb.ToString();
    }
    public static string FormatNamespace(string ns)
    {
        return string.Join(".", ns.Split(".").Select(x => Formatting.ToSnakeCase(x)).ToArray());
    }
}
using System.Text;

namespace Carp;

public static class Formatting
{
    public static string FormatMethod(string methodName) => ToMergeCase(methodName);
    public static string FormatProperty(string fieldName) => ToSnakeCase(fieldName);

    public static string ToMergeCase(this string text)
    {
        // remove all spaces, make all lowercase
        return text.Replace(" ", "").ToLowerInvariant();
    }
    public static string ToSnakeCase(this string text)
    {
        if(text == null) {
            throw new ArgumentNullException(nameof(text));
        }
        if(text.Length < 2) {
            return text.ToLowerInvariant();
        }
        var sb = new StringBuilder();
        sb.Append(char.ToLowerInvariant(text[0]));
        for(int i = 1; i < text.Length; ++i) {
            char c = text[i];
            if(char.IsUpper(c)) {
                sb.Append('_');
                sb.Append(char.ToLowerInvariant(c));
            } else {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}
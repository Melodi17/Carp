namespace Carp.utils;

using System.Text.RegularExpressions;

public class Coloring
{
    private const string Esc = "\x1b";
    public static void Init()
    {
        // TODO: enable vt processing on windows
    }

    // Styles are stored in format %style%
    public static string SubstituteStyles(string text)
    {
        Regex regex = new(@"%([^%]*)%");

        string result = text;
        MatchCollection matches = regex.Matches(text);
        foreach (Match match in matches)
        {
            string style = match.Groups[1].Value;
            if (style == "")
            {
                result = result.Replace(match.Value, "%");
                continue;
            }

            string[] styles = style.Split(' ');
            string finalStyle = styles.Aggregate("", (c, s) => c + Coloring.GetStyle(s));

            result = result.Replace(match.Value, finalStyle);
        }

        if (!Regex.IsMatch(text, "^%([^%]*)%$"))
            result += Coloring.AnsiStyle("reset", true);

        // if (matches.Count > 0)
        //     result += AnsiStyle("reset", true);

        return result;
    }

    public static string StripStyles(string text)
    {
        Regex regex = new(@"%([^%]*)%");
        string result = text;
        foreach (Match match in regex.Matches(text))
            result = result.Replace(match.Value, match.Groups[1].Value == "" ? "%" : "");

        return result;
    }

    public static string StripAnsi(string text) => Regex.Replace(text, @"\x1b\[[0-9;]*m", "");

    private static string GetStyle(string style)
    {
        bool flag = style.StartsWith("!");
        if (flag)
            style = style[1..];

        if (Enum.TryParse(style, true, out ConsoleColor color))
            return Coloring.AnsiColor(color, flag);

        return Coloring.AnsiStyle(style, flag);
    }

    // Variables are stored in format $var
    public static string SubstituteVariables(string text, Dictionary<string, string> variables)
    {
        string result = text;
        // We sort the variables by length to avoid replacing substrings, e.g. $name and $name2
        foreach (KeyValuePair<string, string> variable in variables.OrderBy(v => v.Key.Length))
            result = result.Replace($"${variable.Key}", variable.Value);

        return result;
    }

    private static string AnsiStyle(string style, bool reset)
    {
        (int, int) styleCodes = style switch
        {
            "bold" => (1, 22),
            "italic" => (3, 23),
            "underline" => (4, 24),
            "inverse" => (7, 27),
            "reset" => (0, 0),
            _ => throw new Exception($"Invalid style '{style}'"),
        };

        return $"{Coloring.Esc}[{(reset ? styleCodes.Item2 : styleCodes.Item1)}m";
    }

    // \x1b[31mHello world\x1b[0m

    private static string AnsiColor(string text, int r, int g, int b) => $"{Coloring.Esc}[38;2;{r};{g};{b}m";

    private static string AnsiColor(ConsoleColor color, bool background)
    {
        // https://en.wikipedia.org/wiki/ANSI_escape_code

        int c = color switch
        {
            ConsoleColor.Black => 30,
            ConsoleColor.Red => 131,
            ConsoleColor.Green => 132,
            ConsoleColor.Yellow => 133,
            ConsoleColor.Blue => 134,
            ConsoleColor.Magenta => 135,
            ConsoleColor.Cyan => 136,
            ConsoleColor.Gray => 37,

            // Bright colors
            ConsoleColor.DarkGray => 130,
            ConsoleColor.DarkRed => 31,
            ConsoleColor.DarkGreen => 32,
            ConsoleColor.DarkYellow => 33,
            ConsoleColor.DarkBlue => 34,
            ConsoleColor.DarkMagenta => 35,
            ConsoleColor.DarkCyan => 36,
            ConsoleColor.White => 137,

            _ => throw new Exception("Invalid color"),
        };

        if (background)
            c += 10;

        return c > 100 ? $"{Coloring.Esc}[1;{c - 100}m" : $"{Coloring.Esc}[{c}m";
        // return $"{Esc}[{c}m";
    }

    public static string ColorTest(bool noNewLine = false)
    {
        string result = "";
        string[] colors = ["black", "red", "yellow", "green", "cyan", "blue", "magenta", "white"];

        // Enum.GetValues<ConsoleColor>();

        for (int i = 0; i < colors.Length; i++)
        {
            string color = colors[i];
            if (i % (colors.Length / 2) == 0 && i != 0 && !noNewLine)
                result += "\n";
            result += $"%!{color}%     %reset%";
        }

        return result;
    }

    public static string AllColorTest()
    {
        string result = "";
        ConsoleColor[] colors = Enum.GetValues<ConsoleColor>();

        for (int i = 0; i < colors.Length; i++)
        {
            ConsoleColor color = colors[i];
            if (i % (colors.Length / 2) == 0 && i != 0)
                result += "\n";
            result += Coloring.AnsiColor(color, false) + color.ToString().Replace("Dark", "D").PadLeft(9) + Coloring.AnsiStyle("reset", true);
        }

        return result;
    }
}
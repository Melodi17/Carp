namespace Carp.libraries.std.parsing;

using System.Text.RegularExpressions;
using utils;
using utils.attributes;

[Doc("Provides methods for working with regular expressions.")]
public static class Regex
{
    public static bool IsMatch(string input, string pattern)
        => System.Text.RegularExpressions.Regex.IsMatch(input, pattern);

    public static Match? FindMatch(string input, string pattern)
    {
        System.Text.RegularExpressions.Match? match = System.Text.RegularExpressions.Regex.Match(input, pattern);
        return match.Success
            ? new Match(match.Value, match.Index, match.Length, match
                .Groups.Cast<System.Text.RegularExpressions.Group>()
                .Select(g => new Group(g.Value, g.Index, g.Length)
                {
                    Name = g.Name
                })
                .ToArray())
            : null;
    }

    public static Match[] FindMatches(string input, string pattern)
    {
        MatchCollection? matches = System.Text.RegularExpressions.Regex.Matches(input, pattern);
        return matches
            .Select(m => new Match(m.Value, m.Index, m.Length, m
                .Groups.Cast<System.Text.RegularExpressions.Group>()
                .Select(g => new Group(g.Value, g.Index, g.Length)
                {
                    Name = g.Name
                })
                .ToArray()))
            .ToArray();
    }
}
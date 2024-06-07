using System.Dynamic;
using System.Text.RegularExpressions;
using Carp.interpreter;
using Carp.objects.types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Carp.package.packages.standard;

public class ParsePackage(IPackageResolver source) : EmbeddedPackage(source, "Parse")
{
    /// <summary>
    /// Represents the type of a match result in regular expressions.
    /// </summary>
    [PackageMember("Regex.MatchResult")] public CarpType MatchType = CarpMatchResult.Type;

    /// <summary>
    /// Loads a JSON string and converts it into a Carp object.
    /// </summary>
    /// <param name="json">The JSON string to load.</param>
    /// <returns>The Carp object representation of the JSON string.</returns>
    [PackageMember("Json.")]
    public CarpObject LoadJson(CarpString json)
    {
        string jsonStr = json.Native;
        dynamic? obj = JsonConvert.DeserializeObject(jsonStr);

        return LayerToCarp(obj);
    }

    /// <summary>
    /// Converts a dynamic object into a Carp object.
    /// </summary>
    /// <param name="d">The dynamic object to convert.</param>
    /// <returns>The Carp object representation of the dynamic object.</returns>
    private CarpObject LayerToCarp(dynamic? d)
    {
        if (d is null) return CarpNull.Instance;
        if (d is bool b) return CarpBool.Of(b);

        if (d is string) return new CarpString(d);

        if (d is int i) return new CarpInt(i);
        if (d is long i64) return new CarpInt(i64);
        if (d is double doub) return new CarpInt(doub);

        if (d is JArray arr)
        {
            List<CarpObject> result = new();
            foreach (dynamic item in arr)
                result.Add(LayerToCarp(item));

            return new CarpCollection(CarpObject.Type, result.ToArray());
        }

        if (d is JObject obj)
        {
            Dictionary<CarpObject, CarpObject> result = new();
            foreach ((string key, JToken? value) in obj)
                result.Add(new CarpString(key), this.LayerToCarp(value));

            return new CarpMap(CarpString.Type, CarpObject.Type, result);
        }

        if (d is JValue jv)
            return this.LayerToCarp(jv.Value);

        throw new("Could not deserialize JSON object into Carp object");
    }

    /// <summary>
    /// Matches a regular expression pattern against a text.
    /// </summary>
    /// <param name="pattern">The regular expression pattern.</param>
    /// <param name="text">The text to match against.</param>
    /// <returns>The result of the match.</returns>
    [PackageMember("Regex.")]
    public CarpMatchResult Match(CarpString pattern, CarpString text)
    {
        string patternStr = pattern.Native;
        string textStr = text.Native;

        Match m = Regex.Match(textStr, patternStr);
        if (!m.Success) return new();

        List<CarpMatchResult> groups = new();
        foreach (Group g in m.Groups)
        {
            groups.Add(new(g.Value, g.Index, g.Length, new()));
        }

        return new(m.Value, m.Index, m.Length, groups);
    }

    /// <summary>
    /// Matches a regular expression pattern against a text and returns all matches.
    /// </summary>
    /// <param name="pattern">The regular expression pattern.</param>
    /// <param name="text">The text to match against.</param>
    /// <returns>A collection of all match results.</returns>
    [PackageMember("Regex.")]
    public CarpCollection Matches(CarpString pattern, CarpString text)
    {
        string patternStr = pattern.Native;
        string textStr = text.Native;

        MatchCollection matches = Regex.Matches(textStr, patternStr);
        List<CarpMatchResult> result = new();
        foreach (Match m in matches)
        {
            List<CarpMatchResult> groups = new();
            foreach (Group g in m.Groups)
            {
                groups.Add(new(g.Value, g.Index, g.Length, new()));
            }

            result.Add(new(m.Value, m.Index, m.Length, groups));
        }

        return new(CarpMatchResult.Type, result.ToArray());
    }

    /// <summary>
    /// Replaces all occurrences of a regular expression pattern in a text with a replacement string.
    /// </summary>
    /// <param name="pattern">The regular expression pattern.</param>
    /// <param name="text">The text to replace in.</param>
    /// <param name="replacement">The replacement string.</param>
    /// <returns>The text with all occurrences of the pattern replaced.</returns>
    [PackageMember("Regex.")]
    public CarpString Replace(CarpString pattern, CarpString text, CarpString replacement)
    {
        string patternStr = pattern.Native;
        string textStr = text.Native;
        string replacementStr = replacement.Native;

        return new(Regex.Replace(textStr, patternStr, replacementStr));
    }

    /// <summary>
    /// Splits a text into an array of strings based on a regular expression pattern.
    /// </summary>
    /// <param name="pattern">The regular expression pattern.</param>
    /// <param name="text">The text to split.</param>
    /// <returns>A collection of strings that are split based on the pattern.</returns>
    [PackageMember("Regex.")]
    public CarpCollection Split(CarpString pattern, CarpString text)
    {
        string patternStr = pattern.Native;
        string textStr = text.Native;

        return new(CarpString.Type, Regex.Split(textStr, patternStr).Select(x => new CarpString(x)).ToArray());
    }

    /// <summary>
    /// Tests if a regular expression pattern matches a text.
    /// </summary>
    /// <param name="pattern">The regular expression pattern.</param>
    /// <param name="text">The text to test against.</param>
    /// <returns>A boolean indicating whether the pattern matches the text.</returns>
    [PackageMember("Regex.")]
    public CarpBool Test(CarpString pattern, CarpString text)
    {
        string patternStr = pattern.Native;
        string textStr = text.Native;

        return CarpBool.Of(Regex.IsMatch(textStr, patternStr));
    }

    public class CarpMatchResult : CarpObject
    {
        public static new CarpType Type = NativeType.Of<CarpMatchResult>("match_result");
        public override CarpType GetCarpType() => Type;

        public bool Success;
        public string? Value;
        public int? Index;
        public int? Length;

        public List<CarpMatchResult> Groups = new();

        public CarpMatchResult(string value, int index, int length, List<CarpMatchResult> groups)
        {
            this.Value = value;
            this.Index = index;
            this.Length = length;
            this.Groups = groups;
            this.Success = true;
        }

        public CarpMatchResult()
        {
            this.Success = false;
        }

        public override CarpObject Property(Signature signature)
        {
            return signature.Name switch
            {
                "success" => CarpBool.Of(this.Success),
                "value" => this.Success ? new CarpString(this.Value) : throw new MatchFailedPropertyAccess(),
                "index" => this.Success ? new CarpInt(this.Index.Value) : throw new MatchFailedPropertyAccess(),
                "length" => this.Success ? new CarpInt(this.Length.Value) : throw new MatchFailedPropertyAccess(),
                "groups" => this.Success
                    ? new CarpCollection(Type, this.Groups.ToArray())
                    : throw new MatchFailedPropertyAccess(),
                _ => throw new CarpError.InvalidProperty(signature),
            };
        }

        public override CarpString String()
        {
            return new($"match({(this.Success ? $"'{this.Value}'" : "<failed>")})");
        }
    }

    public class MatchFailedPropertyAccess() : CarpError("Attempted to access property of failed match");
}
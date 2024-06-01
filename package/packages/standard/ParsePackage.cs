using System.Text.RegularExpressions;
using Carp.interpreter;
using Carp.objects.types;
using Newtonsoft.Json;

namespace Carp.package.packages.standard;

public class ParsePackage(IPackageResolver source) : EmbeddedPackage(source, "Parse")
{
    [PackageMember("Regex.MatchResult")]
    public CarpType MatchType = CarpMatchResult.Type;
    // [PackageMember("ds.json.")]
    // public CarpObject LoadJson(CarpString json)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // [PackageMember("ds.json.")]
    // public CarpObject LoadJsonStructure(CarpString json, CarpType structure)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // [PackageMember("ds.json.")]
    // public CarpObject StoreJson(CarpObject ds)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // [PackageMember("ds.json.")]
    // public CarpObject StoreJsonStructure(CarpObject ds)
    // {
    //     throw new NotImplementedException();
    // }

    [PackageMember("Regex.")]
    public CarpMatchResult Match(CarpString pattern, CarpString text)
    {
        string patternStr = pattern.Native;
        string textStr = text.Native;

        Match m = Regex.Match(textStr, patternStr);
        if (!m.Success) return new();
        
        var groups = new List<CarpMatchResult>();
        foreach (Group g in m.Groups)
        {
            groups.Add(new(g.Value, g.Index, g.Length, new()));
        }

        return new(m.Value, m.Index, m.Length, groups);
    }
    
    [PackageMember("Regex.")]
    public CarpCollection Matches(CarpString pattern, CarpString text)
    {
        string patternStr = pattern.Native;
        string textStr = text.Native;

        MatchCollection matches = Regex.Matches(textStr, patternStr);
        var result = new List<CarpMatchResult>();
        foreach (Match m in matches)
        {
            var groups = new List<CarpMatchResult>();
            foreach (Group g in m.Groups)
            {
                groups.Add(new(g.Value, g.Index, g.Length, new()));
            }

            result.Add(new(m.Value, m.Index, m.Length, groups));
        }

        return new(CarpMatchResult.Type, result.ToArray());
    }
    
    [PackageMember("Regex.")]
    public CarpString Replace(CarpString pattern, CarpString text, CarpString replacement)
    {
        string patternStr = pattern.Native;
        string textStr = text.Native;
        string replacementStr = replacement.Native;

        return new(Regex.Replace(textStr, patternStr, replacementStr));
    }
    
    [PackageMember("Regex.")]
    public CarpCollection Split(CarpString pattern, CarpString text)
    {
        string patternStr = pattern.Native;
        string textStr = text.Native;

        return new(CarpString.Type, Regex.Split(textStr, patternStr).Select(x => new CarpString(x)).ToArray());
    }
    
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
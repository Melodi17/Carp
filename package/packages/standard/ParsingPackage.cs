using System.Text.RegularExpressions;
using Carp.interpreter;
using Carp.objects.types;
using Newtonsoft.Json;

namespace Carp.package.packages.standard;

public class ParsingPackage(IPackageResolver source) : EmbeddedPackage(source, "Parse")
{
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

    [PackageMember("regex.")]
    public CarpMatch Match(CarpString pattern, CarpString text)
    {
        string patternStr = pattern.Native;
        string textStr = text.Native;

        Match m = Regex.Match(textStr, patternStr);
        if (!m.Success) return new();
        
        var groups = new List<CarpMatch>();
        foreach (Group g in m.Groups)
        {
            groups.Add(new(g.Value, g.Index, g.Length, new()));
        }

        return new(m.Value, m.Index, m.Length, groups);
    }
    
    [PackageMember("regex.")]
    public CarpCollection Matches(CarpString pattern, CarpString text)
    {
        string patternStr = pattern.Native;
        string textStr = text.Native;

        MatchCollection matches = Regex.Matches(textStr, patternStr);
        var result = new List<CarpMatch>();
        foreach (Match m in matches)
        {
            var groups = new List<CarpMatch>();
            foreach (Group g in m.Groups)
            {
                groups.Add(new(g.Value, g.Index, g.Length, new()));
            }

            result.Add(new(m.Value, m.Index, m.Length, groups));
        }

        return new(CarpMatch.Type, result.ToArray());
    }
    
    [PackageMember("regex.")]
    public CarpString Replace(CarpString pattern, CarpString text, CarpString replacement)
    {
        string patternStr = pattern.Native;
        string textStr = text.Native;
        string replacementStr = replacement.Native;

        return new(Regex.Replace(textStr, patternStr, replacementStr));
    }
    
    [PackageMember("regex.")]
    public CarpCollection Split(CarpString pattern, CarpString text)
    {
        string patternStr = pattern.Native;
        string textStr = text.Native;

        return new(CarpString.Type, Regex.Split(textStr, patternStr).Select(x => new CarpString(x)).ToArray());
    }
    
    [PackageMember("regex.")]
    public CarpBool Test(CarpString pattern, CarpString text)
    {
        string patternStr = pattern.Native;
        string textStr = text.Native;

        return CarpBool.Of(Regex.IsMatch(textStr, patternStr));
    }


    public class CarpMatch : CarpObject
    {
        public static new CarpType Type = NativeType.Of<CarpMatch>("match");
        public override CarpType GetCarpType() => Type;

        public bool Success;
        public string? Value;
        public int? Index;
        public int? Length;

        public List<CarpMatch> Groups = new();

        public CarpMatch(string value, int index, int length, List<CarpMatch> groups)
        {
            this.Value = value;
            this.Index = index;
            this.Length = length;
            this.Groups = groups;
            this.Success = true;
        }

        public CarpMatch()
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
            return new($"match({(this.Success ? this.Value : "<failed>")})");
        }
    }

    public class MatchFailedPropertyAccess() : CarpError("Attempted to access property of failed match");
}
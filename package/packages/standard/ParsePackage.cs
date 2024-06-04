using System.Dynamic;
using System.Text.RegularExpressions;
using Carp.interpreter;
using Carp.objects.types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Carp.package.packages.standard;

public class ParsePackage(IPackageResolver source) : EmbeddedPackage(source, "Parse")
{
    [PackageMember("Regex.MatchResult")]
    public CarpType MatchType = CarpMatchResult.Type;
    
    [PackageMember("Json.")]
    public CarpObject LoadJson(CarpString json)
    {
        string jsonStr = json.Native;
        dynamic? obj = JsonConvert.DeserializeObject(jsonStr);

        return LayerToCarp(obj);
    }

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
    //
    // [PackageMember("Json.")]
    // public CarpObject LoadJsonStructure(CarpString json, CarpType structure)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // [PackageMember("Json.")]
    // public CarpObject StoreJson(CarpObject ds)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // [PackageMember("Json.")]
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
        
        List<CarpMatchResult> groups = new();
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
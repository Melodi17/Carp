namespace Carp.objects;

using scoping;
using typing;

public class CarpEnum : CarpType
{
    private readonly Dictionary<string, CarpObject> _values;
    public readonly CarpType ValueType;

    public static readonly CarpType Type = CarpType.Create("fixed", CarpObject.Type);
    public CarpEnum(string name, Dictionary<string, CarpObject> values) : base(name, Type, [])
    {
        this._values = values;
        this.ValueType = CarpType.HighestCommonType(values.Values.Select(v => v.GetCarpType()).ToArray());

        DefineMembers();
    }

    public CarpEnum(string name, string[] values) : base(name, Type, [])
    {
        this._values = new Dictionary<string, CarpObject>();
        for (int i = 0; i < values.Length; i++)
            this._values[values[i]] = CarpNumber.Create(i);
        this.ValueType = CarpNumber.Creators["i32"].Type;

        DefineMembers();
    }

    private void DefineMembers()
    {
        foreach (var kvp in this._values)
        {
            this.Members.Define(new PropertyMember(kvp.Key, kvp.Value.GetCarpType())
                .Getter(_ => kvp.Value)
                .With(Modifiers.Static));
        }
    }
}
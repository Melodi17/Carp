namespace Carp.libraries.std.parsing;

public class Group
{
    public string Value { get; set; } = string.Empty;
    public int Index { get; set; }
    public int Length { get; set; }
    public string? Name { get; set; }

    public Group(string value, int index, int length)
    {
        this.Value = value;
        this.Index = index;
        this.Length = length;
    }

    public override string ToString()
    {
        return $"Group(value='{Value}',index={Index},length={Length})";
    }
}
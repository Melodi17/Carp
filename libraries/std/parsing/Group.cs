namespace Carp.libraries.std.parsing;

using utils;
using utils.attributes;

[Doc("Represents a group of matched text in a regular expression.")]
public class Group
{
    public Group(string value, int index, int length)
    {
        this.Value = value;
        this.Index = index;
        this.Length = length;
    }
    public string Value { get; set; } = string.Empty;
    public int Index { get; set; }
    public int Length { get; set; }
    public string? Name { get; set; }

    public override string ToString() => $"Group(value='{this.Value}',index={this.Index},length={this.Length})";
}
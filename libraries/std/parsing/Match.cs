namespace Carp.libraries.std.parsing;

using utils;
using utils.attributes;

[Doc("Represents a match found by a regular expression.")]
public class Match
{
    public Match(string value, int index, int length, Group[] groups)
    {
        this.Value = value;
        this.Index = index;
        this.Length = length;
        this.Groups = groups;
    }
    public string Value { get; set; }
    public int Index { get; set; }
    public int Length { get; set; }
    public Group[] Groups { get; set; }

    public Group Group(int groupIndex)
    {
        if (groupIndex < 0 || groupIndex >= this.Groups.Length)
            throw new ArgumentOutOfRangeException(nameof(groupIndex), "Group index is out of range.");

        return this.Groups[groupIndex];
    }

    public Group? Group(string groupName)
    {
        return Array.Find(this.Groups, g => g.Name == groupName);
    }

    public override string ToString()
        => $"Match(value='{this.Value}',index={this.Index},length={this.Length},groups={this.Groups.Length})";
}
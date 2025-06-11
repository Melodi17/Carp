namespace Carp.libraries.std.parsing;

public class Match
{
    public string Value { get; set; }
    public int Index { get; set; }
    public int Length { get; set; }
    public Group[] Groups { get; set; }

    public Match(string value, int index, int length, Group[] groups)
    {
        this.Value = value;
        this.Index = index;
        this.Length = length;
        this.Groups = groups;
    }

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
    {
        return $"Match(value='{Value}',index={Index},length={Length},groups={Groups.Length})";
    }
}
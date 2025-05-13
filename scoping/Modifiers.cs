namespace Carp.scoping;

[Flags]
public enum Modifiers
{
    None = 0, // No special modifiers
    Private = 1, // Inaccessible outside the object
    Static = 2, // Accessed through the class, not the instance
    Protected = 4, // Implementations can't override this member
    Abstract = 8, // Must be implemented in a subclass
    Final = 16, // Read only
}

public static class ModifierHelpers
{
    public static Modifiers MergeFlags(this IEnumerable<Modifiers> modifiers)
    {
        return modifiers.Aggregate(Modifiers.None, (current, modifier) => current | modifier);
    }
}
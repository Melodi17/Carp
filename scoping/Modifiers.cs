namespace Carp.scoping;

[Flags]
public enum Modifiers
{
    /// No special modifiers
    None = 0,

    /// Inaccessible outside the object
    Private = 1,

    /// Accessed through the class, not the instance
    Static = 2,

    /// Subclasses can't override this member
    Protected = 4,

    /// Must be implemented in a subclass
    Abstract = 8,

    /// Read only
    Final = 16
}

public static class ModifierHelpers
{
    public static Modifiers MergeFlags(this IEnumerable<Modifiers> modifiers)
    {
        return modifiers.Aggregate(Modifiers.None, (current, modifier) => current | modifier);
    }
}
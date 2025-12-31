namespace Carp.interpreter.execution;

public interface IExecutionContext
{
    string Name { get; }

    /// <summary>
    ///     Get the content at a specific position in the context.
    /// </summary>
    /// <param name="position">A 1-based position in the context</param>
    /// <returns></returns>
    string GetAtPosition(int position);

    string GetContent();

    SecurityFlags GetSecurityFlags()
    {
        return SecurityFlags.None;
    }
}

[Flags]
public enum SecurityFlags
{
    None = 0,
    ImportDisallowed = 1,
}
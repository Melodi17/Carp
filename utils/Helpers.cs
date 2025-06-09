namespace Carp.utils;

using interpreter.execution;

public static class Helpers
{
    private static readonly int _idCounter = 0;
    public static string GenerateID()
        =>
            // format like 0x{hexadecimal number} padded
            $"0x{Helpers._idCounter:X16}";
}
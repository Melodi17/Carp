namespace Carp.utils;

public class Helpers
{
    private static int _idCounter = 0;
    public static string GenerateID()
    {
        // format like 0x{hexadecimal number} padded
        return $"0x{_idCounter:X16}";
    }
}
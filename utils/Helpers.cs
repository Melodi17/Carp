namespace Carp.utils;

using interpreter.execution;

public static class Helpers
{
    private static readonly int _idCounter = 0;
    public static string GenerateID()
        =>
            // format like 0x{hexadecimal number} padded
            $"0x{Helpers._idCounter:X16}";
    
    public static Array ConvertToTypedArray(Type x, object?[] input)
    {
        Array typedArray = Array.CreateInstance(x, input.Length);

        for (int i = 0; i < input.Length; i++)
        {
            typedArray.SetValue(Convert.ChangeType(input[i], x), i);
        }

        return typedArray;
    }
}
namespace Carp.libraries.std.io;

public static class Console
{
    public static void Out(object obj)
    {
        System.Console.Write(obj.ToString());
    }

    public static void OutLn(object obj)
    {
        System.Console.WriteLine(obj.ToString());
    }

    public static string? In()
    {
        return System.Console.ReadLine();
    }

    public static string? In(object prompt)
    {
        System.Console.Write(prompt.ToString());
        return System.Console.ReadLine();
    }
}
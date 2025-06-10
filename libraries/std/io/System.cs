namespace Carp.libraries.std.io;

public static class System
{
    public static string Time => DateTime.Now.ToString("f");
    public static void Out(object obj)
    {
        Console.Write(obj.ToString());
    }

    public static void OutLn(object obj)
    {
        Console.WriteLine(obj.ToString());
    }

    public static string? In()
    {
        return Console.ReadLine();
    }

    public static string? In(object prompt)
    {
        Console.Write(prompt.ToString());
        return Console.ReadLine();
    }
}
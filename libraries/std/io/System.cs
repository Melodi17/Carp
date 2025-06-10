namespace Carp.libraries.std.io;

using global::System.Reflection;
using utils;

[Doc("Standard library class for input/output operations primarily to standard streams.")]
public static class System
{
    [Doc("The current date and time in a human-readable format.")]
    public static string Time => DateTime.Now.ToString("f");

    [Doc("The Carp runtime version as a string.")]
    public static string Version
        => $"Carp {Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "unknown version"}";

    [Doc("Writes the specified object to the console without a newline.")]
    public static void Out(object obj)
    {
        Console.Out.Write(obj.ToString());
    }

    [Doc("Writes the specified object to the console followed by a newline.")]
    public static void Outln(object obj)
    {
        Console.Out.WriteLine(obj.ToString());
    }

    [Doc("Reads a line of input from the console and returns it as a string.")]
    public static string? In()
    {
        return Console.In.ReadLine();
    }

    [Doc("When a prompt is provided, writes the prompt to the console as a prefix for the input line.")]
    public static string? In(object prompt)
    {
        Console.Out.Write(prompt.ToString());
        return Console.In.ReadLine();
    }

    [Doc("Writes the specified object to the console as an error message.")]
    public static void Err(object obj)
    {
        Console.Error.Write(obj.ToString());
    }

    [Doc("Writes the specified object to the console as an error message followed by a newline.")]
    public static void Errln(object obj)
    {
        Console.Error.WriteLine(obj.ToString());
    }

    [Doc("Clears the standard output console.")]
    public static void Clear() => Console.Clear();
    
    [Doc("Exits the program.")]
    public static void Exit() => Environment.Exit(0);
    
    [Doc("An error code can be passed to indicate the exit status of the program. A non-zero code typically indicates an error.")]
    public static void Exit(int code)
    {
        Environment.Exit(code);
    }
}
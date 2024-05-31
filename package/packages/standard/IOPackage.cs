using Carp.objects.types;

namespace Carp.package.packages.standard;

public class IOPackage(IPackageResolver source) : EmbeddedPackage(source, "IO")
{
    /// <summary>
    /// Writes a line to the output.
    /// </summary>
    /// <param name="str">The string to write, will be converted to a string</param>
    [PackageMember]
    public void PrintLn(CarpObject str)
    {
        Console.WriteLine(str.String().Native);
    }

    /// <summary>
    /// Writes a string to the output, without a newline.
    /// </summary>
    /// <param name="str">The string to write, will be converted to a string</param>
    [PackageMember]
    public void PrintW(CarpObject str)
    {
        Console.Write(str.String().Native);
    }

    /// <summary>
    /// Reads a line from the input.
    /// </summary>
    /// <param name="str">The string to write before reading, will be converted to a string</param>
    /// <returns>The line read from the input</returns>
    [PackageMember]
    public CarpString ReadLn(CarpObject str)
    {
        Console.Write(str.String().Native);
        return new CarpString(Console.ReadLine());
    }

    /// <summary>
    /// Reads a character from the input.
    /// </summary>
    /// <param name="hideKeyStrokes">Whether to hide the key strokes</param>
    /// <returns>The character read from the input</returns>
    [PackageMember]
    public CarpChar ReadW(CarpBool hideKeyStrokes)
    {
        return new(Console.ReadKey(hideKeyStrokes.Native).KeyChar);
    }

    /// <summary>
    /// Clears the output.
    /// </summary>
    [PackageMember]
    public void Clear()
    {
        Console.Clear();
    }

    /// <summary>
    /// Move the cursor to the specified position.
    /// </summary>
    /// <param name="x">The count from the left</param>
    /// <param name="y">The count from the top</param>
    [PackageMember]
    public void Move(CarpInt x, CarpInt y)
    {
        Console.SetCursorPosition(x.NativeInt, y.NativeInt);
    }
}